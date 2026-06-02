Imports System.Data.SqlClient
Imports System.Diagnostics

Module Module1

    Sub Main()

        Try
            ' 1) ????? LocalDB Instance (?? ?? ??????)
            Dim createInstance = New ProcessStartInfo("sqllocaldb", "create CashierLocalDB")
            createInstance.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(createInstance).WaitForExit()

        Catch
            ' ?? ?????? ?????? ????? ?????
        End Try

        Try
            ' 2) ????? ??? Instance
            Dim startInstance = New ProcessStartInfo("sqllocaldb", "start CashierLocalDB")
            startInstance.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(startInstance).WaitForExit()

        Catch ex As Exception
            Console.WriteLine("Error starting instance: " & ex.Message)
        End Try

        ' 3) ????? Restore ?????-??
        Dim connectionString As String =
            "Server=(localdb)\CashierLocalDB;Integrated Security=true;"

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim restoreCommand As String =
                "IF DB_ID('CashierDB') IS NULL " &
                "RESTORE DATABASE CashierDB FROM DISK = '" &
                AppDomain.CurrentDomain.BaseDirectory & "Database.bak' " &
                "WITH MOVE 'CashierDB' TO '" &
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) &
                "\CashierDB.mdf', " &
                "MOVE 'CashierDB_log' TO '" &
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) &
                "\CashierDB_log.ldf';"

            Dim cmd As New SqlCommand(restoreCommand, con)
            cmd.ExecuteNonQuery()
        End Using

    End Sub

End Module
