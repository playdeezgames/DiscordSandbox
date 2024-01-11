Imports SPLORR.Data

Friend Class ItemListItem
    Private ReadOnly Property Store As IItemStore

    Public Sub New(x As IItemStore)
        Me.Store = x
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
