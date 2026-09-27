Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports ClosedXML.Excel

Public NotInheritable Class PurchaseDocumentHelper
    Public Shared Sub ExportGrid(grid As DataGridView, title As String, Optional context As String = Nothing)
        Using dialog As New SaveFileDialog With {.Filter = "Excel (*.xlsx)|*.xlsx", .FileName = title & ".xlsx"}
            If dialog.ShowDialog(grid.FindForm()) <> DialogResult.OK Then Return
            WriteGridExcel(grid, title, dialog.FileName, context)

        End Using
    End Sub

    Public Shared Sub WriteGridExcel(grid As DataGridView, title As String, filePath As String, Optional context As String = Nothing)
            Using book As New XLWorkbook()
                Dim metadata = book.Worksheets.Add("وصف التقرير")
                metadata.RightToLeft = True
                metadata.Cell(1, 1).Value = If(context, title)
                metadata.Cell(1, 1).Style.Alignment.WrapText = True
                metadata.Column(1).Width = 100
                metadata.Row(1).Height = 90
                Dim sheet = book.Worksheets.Add("التقرير")
                sheet.RightToLeft = True
                Dim columns = grid.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible).OrderBy(Function(c) c.DisplayIndex).ToList()
                For c = 0 To columns.Count - 1
                    sheet.Cell(1, c + 1).Value = columns(c).HeaderText
                    Dim r = 2
                    For Each row As DataGridViewRow In grid.Rows
                        If row.IsNewRow Then Continue For
                        Dim value = row.Cells(columns(c).Index).Value
                        If value IsNot Nothing AndAlso Not IsDBNull(value) Then
                            If TypeOf value Is Decimal OrElse TypeOf value Is Double OrElse TypeOf value Is Integer Then
                                sheet.Cell(r, c + 1).Value = CDbl(value)
                                sheet.Cell(r, c + 1).Style.NumberFormat.Format = "#,##0.00"
                            ElseIf TypeOf value Is Date Then
                                sheet.Cell(r, c + 1).Value = CDate(value)
                                sheet.Cell(r, c + 1).Style.DateFormat.Format = "yyyy-MM-dd HH:mm"
                            Else
                                sheet.Cell(r, c + 1).Value = Convert.ToString(value)
                            End If
                        End If
                        r += 1
                    Next
                Next
                If columns.Count > 0 Then
                    sheet.Range(1, 1, 1, columns.Count).Style.Fill.BackgroundColor = XLColor.DarkBlue
                    sheet.Range(1, 1, 1, columns.Count).Style.Font.FontColor = XLColor.White
                    sheet.SheetView.FreezeRows(1)
                    sheet.Columns().AdjustToContents(8, 40)
                End If
                Dim sumHeaders = New String() {"مدين", "دائن", "المشتريات", "المسدد", "الرصيد الحالي", "الرصيد الافتتاحي", "فرق تاريخي غير مسجل", "الإجمالي", "إجمالي السطر", "الصافي", "المدفوع", "المتبقي (آجل)", "الخصم"}
                Dim rowCount = grid.Rows.Cast(Of DataGridViewRow)().Count(Function(r) Not r.IsNewRow)
                If rowCount > 0 Then
                    For c = 0 To columns.Count - 1
                        If sumHeaders.Contains(columns(c).HeaderText) Then
                            Dim letter = sheet.Cell(1, c + 1).Address.ColumnLetter
                            sheet.Cell(rowCount + 2, c + 1).FormulaA1 = "SUM(" & letter & "2:" & letter & (rowCount + 1).ToString() & ")"
                            sheet.Cell(rowCount + 2, c + 1).Style.Font.Bold = True
                        End If
                    Next
                End If
                book.SaveAs(filePath)
            End Using
    End Sub

    Public Shared Sub PrintGrid(grid As DataGridView, title As String)
        Dim columns = grid.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible).OrderBy(Function(c) c.DisplayIndex).ToList()
        If columns.Count = 0 Then Return
        Dim rows = grid.Rows.Cast(Of DataGridViewRow)().Where(Function(r) Not r.IsNewRow).Select(Function(r) columns.Select(Function(c) Convert.ToString(r.Cells(c.Index).FormattedValue)).ToArray()).ToList()
        Dim rowIndex As Integer = 0
        Using document As New PrintDocument(), body As New Font("Tahoma", 9), heading As New Font("Tahoma", 12, FontStyle.Bold), format As New StringFormat With {.FormatFlags = StringFormatFlags.DirectionRightToLeft, .Alignment = StringAlignment.Near}
            document.DocumentName = title.Split(ControlChars.Lf)(0)
            document.DefaultPageSettings.Landscape = True
            document.DefaultPageSettings.Margins = New Margins(35, 35, 35, 35)
            AddHandler document.BeginPrint, Sub(s, e) rowIndex = 0
            AddHandler document.PrintPage,
                Sub(s, e)
                    Dim bounds = e.MarginBounds
                    Dim titleHeight = e.Graphics.MeasureString(title, heading, bounds.Width, format).Height + 12
                    e.Graphics.DrawString(title, heading, Brushes.Black, New RectangleF(bounds.Left, bounds.Top, bounds.Width, titleHeight), format)
                    Dim y As Single = bounds.Top + titleHeight
                    Dim width As Single = CSng(bounds.Width / columns.Count)
                    Dim headerHeight As Single = 45
                    For c = 0 To columns.Count - 1
                        Dim rect As New RectangleF(bounds.Right - (c + 1) * width, y, width, headerHeight)
                        e.Graphics.FillRectangle(Brushes.LightGray, rect)
                        e.Graphics.DrawString(columns(c).HeaderText, body, Brushes.Black, rect, format)
                    Next
                    y += headerHeight
                    While rowIndex < rows.Count
                        Dim height As Single = 26
                        For Each value In rows(rowIndex)
                            height = Math.Max(height, e.Graphics.MeasureString(value, body, CInt(width - 6), format).Height + 8)
                        Next
                        height = Math.Min(height, bounds.Height - titleHeight - headerHeight)
                        If y + height > bounds.Bottom Then Exit While
                        For c = 0 To columns.Count - 1
                            Dim rect As New RectangleF(bounds.Right - (c + 1) * width, y, width, height)
                            e.Graphics.DrawRectangle(Pens.Gray, rect.X, rect.Y, rect.Width, rect.Height)
                            e.Graphics.DrawString(rows(rowIndex)(c), body, Brushes.Black, New RectangleF(rect.X + 3, rect.Y + 3, width - 6, height - 6), format)
                        Next
                        y += height
                        rowIndex += 1
                    End While
                    e.HasMorePages = rowIndex < rows.Count
                End Sub
            Using preview As New PrintPreviewDialog With {.Document = document, .Width = 1200, .Height = 800}
                preview.ShowDialog(grid.FindForm())
            End Using
        End Using
    End Sub

    Public Shared Sub ShowInvoice(owner As Form, purchaseID As Integer)
        SupplierAccountingService.DemandPermission("frmPurchaseReports", "CanOpen")
        Dim header = SupplierAccountingService.Query("SELECT H.*, S.SupplierName, ST.StoreName FROM PurchaseHeaders H INNER JOIN Suppliers S ON S.SupplierID=H.SupplierID INNER JOIN Stores ST ON ST.StoreID=H.StoreID WHERE PurchaseID=@ID AND ISNULL(H.IsDeleted,0)=0", New SqlParameter("@ID", purchaseID))
        If header.Rows.Count = 0 Then Throw New ArgumentException("الفاتورة غير موجودة.")
        Dim h = header.Rows(0)
        Dim title = "فاتورة مشتريات " & CStr(h("InvoiceNumber")) & " | " & CDate(h("PurchaseDate")).ToString("yyyy-MM-dd") & vbLf &
            "المورد: " & CStr(h("SupplierName")) & " | المخزن: " & CStr(h("StoreName")) & " | الدفع: " & CStr(h("PaymentType")) & vbLf &
            "الإجمالي: " & CDec(h("TotalAmount")).ToString("N2") & " | الخصم: " & CDec(h("Discount")).ToString("N2") & " | الصافي: " & CDec(h("NetTotal")).ToString("N2") &
            " | المدفوع: " & CDec(h("PaidAmount")).ToString("N2") & " | المتبقي عند الحفظ: " & CDec(h("RemainingAmount")).ToString("N2")
        Dim data = SupplierAccountingService.Query("SELECT M.MaterialName AS [الخامة], U.UnitName AS [الوحدة], D.Quantity AS [الكمية], D.ConversionFactor AS [معامل التحويل], D.UnitPrice AS [السعر], D.Quantity*D.UnitPrice AS [الإجمالي] FROM PurchaseDetails D INNER JOIN RawMaterials M ON M.MaterialID=D.MaterialID INNER JOIN Units U ON U.UnitID=D.UnitID WHERE D.PurchaseID=@ID ORDER BY D.DetailID", New SqlParameter("@ID", purchaseID))
        Using viewer As New FrmPurchaseDocument(title, data)
            viewer.ShowDialog(owner)
        End Using
    End Sub

    Public Shared Sub RunSafely(action As Action)
        Try
            action()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "تعذر إتمام العملية", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class
