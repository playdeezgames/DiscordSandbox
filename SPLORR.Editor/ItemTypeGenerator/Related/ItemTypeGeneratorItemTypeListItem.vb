Imports SPLORR.Data

Friend Class ItemTypeGeneratorItemTypeListItem
    Public ReadOnly Property Store As IItemTypeGeneratorItemTypeStore

    Public Sub New(itemTypeGeneratorItemTypeStore As IItemTypeGeneratorItemTypeStore)
        Me.Store = itemTypeGeneratorItemTypeStore
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Weight:{Store.GeneratorWeight},Id:{Store.Id})"
    End Function
End Class
