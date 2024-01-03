Imports SPLORR.Data

Public Class ItemTypeListItem
    Public ReadOnly Property ItemTypeStore As IItemTypeStore

    Public Sub New(store As IItemTypeStore)
        Me.ItemTypeStore = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{ItemTypeStore.Name}(Id:{ItemTypeStore.Id})"
    End Function
End Class
