Imports System.Data.SqlClient

Public Class frm_LowStockProducts
    Private Sub LoadLowStockProducts()

        Dim sql As String = "
        SELECT 
            P.Product_Name,
            S.Quantity_OnHand,
            S.Min_Quantity
        FROM Stock S
        INNER JOIN Products P ON P.Product_ID = S.Product_ID
        WHERE 
            S.Quantity_OnHand < S.Min_Quantity
            OR S.Quantity_OnHand = 0
        ORDER BY S.Quantity_OnHand ASC"

        Dim dt As New DataTable()

        Connect()
        Using cmd As New SqlCommand(sql, Conn)
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using

        DGV_LowStock.DataSource = dt
        Disconnect()

        ' تنسيق الأعمدة
        DGV_LowStock.Columns("Product_Name").HeaderText = "اسم المنتج"
        DGV_LowStock.Columns("Quantity_OnHand").HeaderText = "المخزون"
        DGV_LowStock.Columns("Min_Quantity").HeaderText = "الحد الأدنى"
    End Sub

    Private Sub frm_LowStockProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLowStockProducts()
    End Sub
End Class