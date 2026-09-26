Imports System
Imports System.Collections.Generic

''' <summary>
''' نوع عملية المزامنة (Sync Operation Type)
''' </summary>
Public Enum SyncOperation
    Insert = 0
    Update = 1
    Delete = 2
End Enum

''' <summary>
''' حالة المزامنة (Sync Status)
''' </summary>
Public Enum SyncStatus
    Idle = 0
    Syncing = 1
    Success = 2
    Failed = 3
    Offline = 4
    PartialSuccess = 5
End Enum

''' <summary>
''' اتجاه المزامنة (Sync Direction)
''' </summary>
Public Enum SyncDirection
    Bidirectional = 0
    PushOnly = 1
    PullOnly = 2
End Enum

''' <summary>
''' استراتيجية حل التعارضات (Conflict Resolution Strategy)
''' </summary>
Public Enum ConflictStrategy
    LastWriteWins = 0
    ManualReview = 1
    LocalWins = 2
    RemoteWins = 3
End Enum

''' <summary>
''' سجل حركات المزامنة (Sync Log Entry)
''' </summary>
Public Class SyncLogEntry
    Public Property LogId As Long
    Public Property TableName As String
    Public Property RowSyncId As Guid
    Public Property Operation As SyncOperation
    ''' <summary>مصفوفة JSON للأعمدة المعدلة (JSON array of changed columns)</summary>
    Public Property ChangedColumns As String
    ''' <summary>بيانات الصف كاملة بصيغة JSON (Full row as JSON)</summary>
    Public Property RowDataJson As String
    Public Property CreatedAt As DateTime
    Public Property IsSynced As Boolean
    Public Property SyncedAt As DateTime?
    Public Property ErrorMessage As String
    Public Property RetryCount As Integer
End Class

''' <summary>
''' حالة المزامنة للجدول (Table Sync State)
''' </summary>
Public Class SyncStateEntry
    Public Property TableName As String
    Public Property LastPushAt As DateTime?
    Public Property LastPullAt As DateTime?
    Public Property LastPullVersion As Long
    Public Property TotalPushed As Long
    Public Property TotalPulled As Long
    Public Property LastError As String
    Public Property LastErrorAt As DateTime?
End Class

''' <summary>
''' تعارض بيانات المزامنة (Sync Conflict)
''' </summary>
Public Class SyncConflict
    Public Property ConflictId As Long
    Public Property TableName As String
    Public Property RowSyncId As Guid
    Public Property LocalDataJson As String
    Public Property RemoteDataJson As String
    Public Property DetectedAt As DateTime
    Public Property IsResolved As Boolean
    ''' <summary>طريقة الحل: "local"، "remote"، "merged" (Resolution strategy)</summary>
    Public Property Resolution As String
End Class

''' <summary>
''' نتيجة عملية المزامنة (Sync Result)
''' </summary>
Public Class SyncResult
    Public Property Status As SyncStatus
    Public Property TotalPushed As Integer
    Public Property TotalPulled As Integer
    Public Property TotalConflicts As Integer
    Public Property Errors As New List(Of String)
    Public Property StartedAt As DateTime
    Public Property CompletedAt As DateTime

    ''' <summary>
    ''' المدة المستغرقة للمزامنة (Duration of the sync)
    ''' </summary>
    Public ReadOnly Property Duration As TimeSpan
        Get
            Return CompletedAt - StartedAt
        End Get
    End Property

    ''' <summary>
    ''' إنشاء نتيجة نجاح (Create success result)
    ''' </summary>
    Public Shared Function CreateSuccess(pushed As Integer, pulled As Integer, conflicts As Integer) As SyncResult
        Return New SyncResult With {
            .Status = SyncStatus.Success,
            .TotalPushed = pushed,
            .TotalPulled = pulled,
            .TotalConflicts = conflicts,
            .StartedAt = DateTime.Now,
            .CompletedAt = DateTime.Now
        }
    End Function

    ''' <summary>
    ''' إنشاء نتيجة فشل (Create failed result)
    ''' </summary>
    Public Shared Function CreateFailed(errorMessage As String) As SyncResult
        Dim result = New SyncResult With {
            .Status = SyncStatus.Failed,
            .StartedAt = DateTime.Now,
            .CompletedAt = DateTime.Now
        }
        If Not String.IsNullOrWhiteSpace(errorMessage) Then
            result.Errors.Add(errorMessage)
        End If
        Return result
    End Function
End Class

''' <summary>
''' أحداث تقدم المزامنة (Sync Progress Event Arguments)
''' </summary>
Public Class SyncProgressEventArgs
    Inherits EventArgs

    Public Property TableName As String
    Public Property CurrentTable As Integer
    Public Property TotalTables As Integer
    Public Property CurrentRow As Integer
    Public Property TotalRows As Integer
    ''' <summary>نوع العملية: "push" أو "pull" (Operation type)</summary>
    Public Property Operation As String
    Public Property Message As String
End Class
