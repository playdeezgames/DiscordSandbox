Imports SPLORR.Data

Friend Class ItemTypeGeneratorItemTypeListItem
    Public ReadOnly Property ItemTypeGeneratorItemTypeStore As IItemTypeGeneratorItemTypeStore

    Public Sub New(itemTypeGeneratorItemTypeStore As IItemTypeGeneratorItemTypeStore)
        Me.itemTypeGeneratorItemTypeStore = itemTypeGeneratorItemTypeStore
    End Sub

    Public Overrides Function ToString() As String
        Return $"{ItemTypeGeneratorItemTypeStore.Name}(Weight:{ItemTypeGeneratorItemTypeStore.GeneratorWeight},Id:{ItemTypeGeneratorItemTypeStore.Id})"
    End Function
End Class
