Imports SPLORR.Data

Friend Class ItemTypeGeneratorItemTypeAddWindow
    Inherits BaseListWindow(Of IItemTypeGeneratorStore, IItemTypeStore)

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New(
            $"Add Item Type To: {itemTypeGeneratorStore.Name}", itemTypeGeneratorStore,
            Function(x, y) x.AvailableItemTypes.Filter(y),
            Function(x) New ItemTypeListItem(x),
            Function(x)
                Dim itemType = CType(x, ItemTypeListItem).ItemTypeStore
                itemTypeGeneratorStore.AddItemType(itemType, 1)
                Return New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore) 'TODO: go to itgit edit window!
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
