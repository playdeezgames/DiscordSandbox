﻿Imports SPLORR.Data

Friend Class ItemTypeGeneratorItemTypeListItem
    Private ReadOnly itemTypeGeneratorItemTypeStore As IItemTypeGeneratorItemTypeStore

    Public Sub New(itemTypeGeneratorItemTypeStore As IItemTypeGeneratorItemTypeStore)
        Me.itemTypeGeneratorItemTypeStore = itemTypeGeneratorItemTypeStore
    End Sub

    Public Overrides Function ToString() As String
        Return $"{itemTypeGeneratorItemTypeStore.Name}(Id:{itemTypeGeneratorItemTypeStore.Id},ItemTypeId:{itemTypeGeneratorItemTypeStore.ItemType.Id})"
    End Function
End Class