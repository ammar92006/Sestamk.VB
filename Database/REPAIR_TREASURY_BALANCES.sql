-- ============================================================
-- إصلاح أرصدة الخزائن المنحرفة — يرافق إصدار v1.2.7
-- يشغَّل على قاعدة بيانات الإنتاج مرة واحدة (يدوياً أو بواسطة المطور).
-- يعيد بناء CurrentBalance لكل خزينة من المعادلة المرجعية:
--     الرصيد = الافتتاحي + مجموع(إيداع - سحب)
-- ويبلغ عن حركات خزينة يتيمة (TreasuryID غير موجود) بدل حذفها.
-- آمن للتشغيل المتكرر (idempotent).
-- ============================================================

PRINT '--- قبل الإصلاح: الخزائن المخالفة ---';
SELECT T.TreasuryID, T.CurrentBalance AS StoredBalance,
       ISNULL(T.OpeningBalance,0) + ISNULL(x.Net,0) AS CorrectBalance
FROM Treasury T
LEFT JOIN (SELECT TreasuryID, SUM(CASE WHEN IsDeposit=1 THEN Amount ELSE -Amount END) AS Net
           FROM TreasuryTransactions GROUP BY TreasuryID) x ON x.TreasuryID = T.TreasuryID
WHERE ABS(ISNULL(T.CurrentBalance,0) - (ISNULL(T.OpeningBalance,0) + ISNULL(x.Net,0))) > 0.011;

-- 1) إعادة حساب كل الأرصدة من الحركات
UPDATE T
SET T.CurrentBalance = ISNULL(T.OpeningBalance,0) + ISNULL(x.Net,0)
FROM Treasury T
OUTER APPLY (SELECT SUM(CASE WHEN TT.IsDeposit=1 THEN TT.Amount ELSE -TT.Amount END) AS Net
             FROM TreasuryTransactions TT WHERE TT.TreasuryID = T.TreasuryID) x;

-- 2) تقرير الحركات اليتيمة (لا تُحذف تلقائياً — تُراجع يدوياً)
PRINT '--- حركات خزينة يتيمة (TreasuryID غير موجود) — تحتاج مراجعة يدوية ---';
SELECT TT.TransactionID, TT.TreasuryID, TT.Amount, TT.IsDeposit, TT.Notes
FROM TreasuryTransactions TT
LEFT JOIN Treasury T ON T.TreasuryID = TT.TreasuryID
WHERE T.TreasuryID IS NULL;

PRINT '--- بعد الإصلاح: يجب ألا توجد صفوف أعلاه تظهر هنا ---';
SELECT T.TreasuryID, T.CurrentBalance AS StoredBalance,
       ISNULL(T.OpeningBalance,0) + ISNULL(x.Net,0) AS CorrectBalance
FROM Treasury T
LEFT JOIN (SELECT TreasuryID, SUM(CASE WHEN IsDeposit=1 THEN Amount ELSE -Amount END) AS Net
           FROM TreasuryTransactions GROUP BY TreasuryID) x ON x.TreasuryID = T.TreasuryID
WHERE ABS(ISNULL(T.CurrentBalance,0) - (ISNULL(T.OpeningBalance,0) + ISNULL(x.Net,0))) > 0.011;
