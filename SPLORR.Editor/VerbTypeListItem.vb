Imports SPLORR.Data

Public Class VerbTypeListItem
    Public ReadOnly Property VerbTypeStore As IVerbTypeStore

    Public Sub New(store As IVerbTypeStore)
        Me.VerbTypeStore = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{VerbTypeStore.Name}(Id:{VerbTypeStore.Id})"
    End Function
End Class
