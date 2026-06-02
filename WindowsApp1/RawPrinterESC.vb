'Imports System.Runtime.InteropServices

'Public Class RawPrinterHelper

'    <DllImport("winspool.drv", SetLastError:=True, CharSet:=CharSet.Auto)>
'    Public Shared Function OpenPrinter(pPrinterName As String, ByRef phPrinter As IntPtr, pDefault As IntPtr) As Boolean
'    End Function

'    <DllImport("winspool.drv", SetLastError:=True)>
'    Public Shared Function ClosePrinter(hPrinter As IntPtr) As Boolean
'    End Function

'    <DllImport("winspool.drv", SetLastError:=True)>
'    Public Shared Function StartDocPrinter(hPrinter As IntPtr, level As Integer, ByRef pDocInfo As DOCINFOA) As Boolean
'    End Function

'    <DllImport("winspool.drv", SetLastError:=True)>
'    Public Shared Function EndDocPrinter(hPrinter As IntPtr) As Boolean
'    End Function

'    <DllImport("winspool.drv", SetLastError:=True)>
'    Public Shared Function StartPagePrinter(hPrinter As IntPtr) As Boolean
'    End Function

'    <DllImport("winspool.drv", SetLastError:=True)>
'    Public Shared Function EndPagePrinter(hPrinter As IntPtr) As Boolean
'    End Function

'    <DllImport("winspool.drv", SetLastError:=True)>
'    Public Shared Function WritePrinter(hPrinter As IntPtr, pBytes As Byte(), dwCount As Integer, ByRef dwWritten As Integer) As Boolean
'    End Function

'    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
'    Public Structure DOCINFOA
'        Public pDocName As String
'        Public pOutputFile As String
'        Public pDataType As String
'    End Structure

'    Public Shared Function SendStringToPrinter(printerName As String, data As String) As Boolean
'        Dim hPrinter As IntPtr = IntPtr.Zero
'        Dim di As New DOCINFOA With {
'            .pDocName = "RAW Document",
'            .pDataType = "RAW"
'        }

'        Dim bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(data)
'        Dim written As Integer = 0

'        If OpenPrinter(printerName, hPrinter, IntPtr.Zero) Then
'            If StartDocPrinter(hPrinter, 1, di) Then
'                If StartPagePrinter(hPrinter) Then
'                    WritePrinter(hPrinter, bytes, bytes.Length, written)
'                    EndPagePrinter(hPrinter)
'                End If
'                EndDocPrinter(hPrinter)
'            End If
'            ClosePrinter(hPrinter)
'        End If

'        Return written = bytes.Length
'    End Function

'End Class
