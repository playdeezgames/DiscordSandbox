Imports SPLORR.Data

Friend Class ItemTypeGeneratorItemTypeListItem
    Public ReadOnly Property ItemTypeGeneratorItemTypeStore As IItemTypeGeneratorItemTypeStore

    Public Sub New(itemTypeGeneratorItemTypeStore As IItemTypeGeneratorItemTypeStore)
        Me.itemTypeGeneratorItemTypeStore = itemTypeGeneratorItemTypeStore
    End Sub

    Public Overrides Function ToString() As String
        Return $"{ItemTypeGeneratorItemTypeStore.Name}(Id:{ItemTypeGeneratorItemTypeStore.Id},ItemTypeId:{ItemTypeGeneratorItemTypeStore.ItemType.Id},GeneratorWeight:{ItemTypeGeneratorItemTypeStore.GeneratorWeight})"
    End Function
End Class
