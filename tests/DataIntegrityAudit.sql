-- ============================================================
-- Sestamk Data Integrity Audit (runs on an ISOLATED CLONE)
-- Usage: restore SestamkDB as SestamkDB_AuditTest, then run.
-- Every result set must be EMPTY (0 rows) for a pass.
-- ============================================================
USE SestamkDB_AuditTest;
GO

PRINT '=== 1. Invoice math: NetTotal <> TotalBeforeDiscount - DiscountAmount ===';
SELECT InvoiceID, InvoiceNumber, TotalBeforeDiscount, DiscountAmount, NetTotal
FROM SalesInvoices
WHERE IsDeleted = 0
  AND ABS(ISNULL(NetTotal,0) - (ISNULL(TotalBeforeDiscount,0) - ISNULL(DiscountAmount,0))) > 0.011;

GO
PRINT '=== 2. Invoice math: RemainingAmount <> NetTotal - PaidAmount ===';
SELECT InvoiceID, InvoiceNumber, NetTotal, PaidAmount, RemainingAmount
FROM SalesInvoices
WHERE IsDeleted = 0
  AND ABS(ISNULL(RemainingAmount,0) - (ISNULL(NetTotal,0) - ISNULL(PaidAmount,0))) > 0.011;

GO
PRINT '=== 3. Header total vs sum of details (normal invoices) ===';
SELECT i.InvoiceID, i.InvoiceNumber, i.NetTotal, d.DetSum
FROM SalesInvoices i
JOIN (SELECT InvoiceID, SUM(TotalPrice) AS DetSum FROM SalesInvoiceDetails GROUP BY InvoiceID) d ON d.InvoiceID = i.InvoiceID
WHERE i.IsDeleted = 0 AND i.InvoiceNumber NOT LIKE 'RET-%'
  AND ABS(d.DetSum - (ISNULL(i.NetTotal,0) + ISNULL(i.DiscountAmount,0))) > 0.011;

GO
PRINT '=== 4. Customer running balance continuity (BalanceAfter chain) ===';
WITH t AS (
  SELECT ct.*, LAG(BalanceAfter) OVER (PARTITION BY CustomerID ORDER BY CreatedAt, ID) AS PrevBal
  FROM CustomerTransactions ct
)
SELECT ID, CustomerID, BalanceAfter, PrevBal, Debit, Credit
FROM t
WHERE PrevBal IS NOT NULL
  AND ABS(BalanceAfter - (ISNULL(PrevBal,0) + ISNULL(Credit,0) - ISNULL(Debit,0))) > 0.011
ORDER BY CustomerID, ID;

GO
PRINT '=== 5. Customers.CurrentBalance vs last transaction BalanceAfter ===';
SELECT c.CustomerID, c.CustomerName, c.CurrentBalance, lt.LastBal, lt.LastID
FROM Customers c
JOIN (SELECT CustomerID, MAX(ID) AS LastID FROM CustomerTransactions GROUP BY CustomerID) m ON m.CustomerID = c.CustomerID
JOIN (SELECT ID, CustomerID, BalanceAfter FROM CustomerTransactions) lt ON lt.ID = m.LastID
WHERE ISNULL(c.IsDeleted,0) = 0
  AND ABS(ISNULL(c.CurrentBalance,0) - ISNULL(lt.BalanceAfter,0)) > 0.011;

GO
PRINT '=== 6. Treasury.CurrentBalance vs OpeningBalance + transactions ===';
SELECT t.TreasuryID, t.TreasuryName, t.CurrentBalance, t.OpeningBalance,
       ISNULL(x.Net,0) AS ComputedNet, ISNULL(t.OpeningBalance,0) + ISNULL(x.Net,0) AS Expected
FROM Treasury t
LEFT JOIN (SELECT TreasuryID,
                  SUM(CASE WHEN IsDeposit = 1 THEN Amount ELSE -Amount END) AS Net
           FROM TreasuryTransactions GROUP BY TreasuryID) x ON x.TreasuryID = t.TreasuryID
WHERE ABS(ISNULL(t.CurrentBalance,0) - (ISNULL(t.OpeningBalance,0) + ISNULL(x.Net,0))) > 0.011;

GO
PRINT '=== 7. Shifts.TotalSales vs sum of invoice PaidAmount per shift ===';
SELECT s.ShiftID, s.ShiftNumber, s.TotalSales, ISNULL(i.PaidSum,0) AS PaidSum, s.TotalSales - ISNULL(i.PaidSum,0) AS Diff
FROM Shifts s
LEFT JOIN (SELECT ShiftID, SUM(PaidAmount) AS PaidSum FROM SalesInvoices WHERE IsDeleted = 0 GROUP BY ShiftID) i ON i.ShiftID = s.ShiftID
WHERE ABS(ISNULL(s.TotalSales,0) - ISNULL(i.PaidSum,0)) > 0.011;

GO
PRINT '=== 8. Shifts.TotalRefunds vs return invoices per shift ===';
SELECT s.ShiftID, s.TotalRefunds, ISNULL(i.RefSum,0) AS RefSum
FROM Shifts s
LEFT JOIN (SELECT ShiftID, SUM(-PaidAmount) AS RefSum FROM SalesInvoices WHERE IsDeleted = 0 AND InvoiceNumber LIKE 'RET-%' AND PaidAmount < 0 GROUP BY ShiftID) i ON i.ShiftID = s.ShiftID
WHERE ABS(ISNULL(s.TotalRefunds,0) - ISNULL(i.RefSum,0)) > 0.011;

GO
PRINT '=== 9. Orphan invoice details / negative quantities in normal invoices ===';
SELECT 'orphan_detail' AS Issue, d.InvoiceID FROM SalesInvoiceDetails d
LEFT JOIN SalesInvoices i ON i.InvoiceID = d.InvoiceID
WHERE i.InvoiceID IS NULL
UNION ALL
SELECT 'neg_qty', InvoiceID FROM SalesInvoiceDetails WHERE InvoiceID IN (SELECT InvoiceID FROM SalesInvoices WHERE InvoiceNumber NOT LIKE 'RET-%') AND Quantity <= 0
UNION ALL
SELECT 'neg_price', InvoiceID FROM SalesInvoiceDetails WHERE UnitPrice < 0;

GO
PRINT '=== 10. Detail rows referencing missing products ===';
SELECT d.InvoiceID, d.ProductID, d.ProductName
FROM SalesInvoiceDetails d
LEFT JOIN Products p ON p.Product_ID = d.ProductID
WHERE d.ProductID IS NOT NULL AND p.Product_ID IS NULL;

GO
PRINT '=== 11. Returns exceeding original invoice (quantity sanity) ===';
SELECT r.InvoiceID, r.InvoiceNumber, d.ProductID, d.Quantity AS RetQty, d.InvoiceID
FROM SalesInvoiceDetails d
JOIN SalesInvoices r ON r.InvoiceID = d.InvoiceID AND r.InvoiceNumber LIKE 'RET-%'
WHERE d.Quantity >= 0;

GO
PRINT '=== 12. Treasury transaction referencing missing treasury ===';
SELECT tt.TransactionID, tt.TreasuryID FROM TreasuryTransactions tt
LEFT JOIN Treasury t ON t.TreasuryID = tt.TreasuryID
WHERE t.TreasuryID IS NULL;

GO
PRINT '=== 13. Supplier running balance vs SupplierTransactions ===';
SELECT s.Supplier_ID, s.Supplier_Name, s.CurrentBalance, lt.LastBal
FROM Suppliers s
JOIN (SELECT SupplierID, MAX(TransactionID) AS LastID FROM SupplierTransactions GROUP BY SupplierID) m ON m.SupplierID = s.Supplier_ID
JOIN (SELECT TransactionID, SupplierID, BalanceAfter FROM SupplierTransactions) lt ON lt.TransactionID = m.LastID
WHERE ISNULL(s.IsDeleted,0) = 0 AND ABS(ISNULL(s.CurrentBalance,0) - ISNULL(lt.BalanceAfter,0)) > 0.011;

GO
PRINT '=== 14. Legacy vs modern sales overlap (dual architecture) ===';
SELECT 'legacy_SalesHeader' AS Tbl, COUNT(*) AS Rows_ FROM SalesHeader
UNION ALL SELECT 'modern_SalesInvoices', COUNT(*) FROM SalesInvoices
UNION ALL SELECT 'legacy_SalesDetails', COUNT(*) FROM SalesDetails
UNION ALL SELECT 'modern_Details', COUNT(*) FROM SalesInvoiceDetails;

GO
PRINT '=== 15. Negative paid / paid > net anomalies ===';
SELECT InvoiceID, InvoiceNumber, NetTotal, PaidAmount, RemainingAmount, IsCredit
FROM SalesInvoices
WHERE IsDeleted = 0 AND InvoiceNumber NOT LIKE 'RET-%'
  AND (PaidAmount < 0 OR PaidAmount > NetTotal + 0.011 OR RemainingAmount < -0.011);

GO
PRINT '=== 16. StoreStock vs StockMovements net (top 20 mismatches) ===';
SELECT TOP 20 ss.ProductID, ss.StoreID, ss.Quantity AS StockQty, ISNULL(m.Net,0) AS MovementNet
FROM StoreStock ss
LEFT JOIN (SELECT ProductID, StoreID, SUM(CASE WHEN MovementType IN (N'إضافة',N'شراء',N'مرتجع شراء',N'تسوية زيادة',N'مرتجع مبيعات') THEN Quantity
                                             WHEN MovementType IN (N'خصم',N'بيع',N'هالك',N'تسوية نقص',N'صرف') THEN -Quantity
                                             ELSE 0 END) AS Net
           FROM StockMovements GROUP BY ProductID, StoreID) m ON m.ProductID = ss.ProductID AND m.StoreID = ss.StoreID
WHERE ABS(ISNULL(ss.Quantity,0) - ISNULL(m.Net,0)) > 0.011
ORDER BY ABS(ISNULL(ss.Quantity,0) - ISNULL(m.Net,0)) DESC;

GO
PRINT '=== AUDIT DONE ===';
