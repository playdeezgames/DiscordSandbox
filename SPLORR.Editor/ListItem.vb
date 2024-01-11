Public Class ListItem(Of TStore)
    Public ReadOnly Property Store As TStore
    Private ReadOnly text As String
    Sub New(store As TStore, text As String)
        Me.Store = store
    End Sub
    Public Overrides Function ToString() As String
        Return text
    End Function
End Class
