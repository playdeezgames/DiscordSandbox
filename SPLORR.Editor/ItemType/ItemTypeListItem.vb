Imports SPLORR.Data

Public Class ItemTypeListItem
    Public ReadOnly Property Store As IItemTypeStore

    Public Sub New(store As IItemTypeStore)
        Me.Store = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
