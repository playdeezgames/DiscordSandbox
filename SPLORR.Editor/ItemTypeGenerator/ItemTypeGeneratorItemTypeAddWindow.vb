﻿Imports SPLORR.Data

Friend Class ItemTypeGeneratorItemTypeAddWindow
    Inherits BaseListWindow(Of IItemTypeGeneratorStore, IItemTypeStore)

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New(
            $"Add Item Type To: {itemTypeGeneratorStore.Name}", itemTypeGeneratorStore,
            Function(x, y) x.AvailableItemTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                Return New ItemTypeGeneratorItemTypeEditWindow(
                    itemTypeGeneratorStore.AddItemType(
                    CType(x, ListItem(Of IItemTypeStore)).Store, 1))
            End Function,
            AdditionalButtons:=
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Return
                )
            })
    End Sub
End Class