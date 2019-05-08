Public Class OriginMessageData
    Public Sub New(filePath As String, message As ZCL_MERE026_IDLE_CAUSE)
        Me.FilePath = filePath
        Me.Message = message
    End Sub

    Public ReadOnly Property FilePath As String
    Public ReadOnly Property Message As ZCL_MERE026_IDLE_CAUSE
End Class
