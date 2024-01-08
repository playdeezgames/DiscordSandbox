Imports SPLORR.Data

Friend Class ItemTypeGeneratorItemTypeListWindow
    Inherits BaseListWindow(Of IItemTypeGeneratorStore, IItemTypeGeneratorItemTypeStore)

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New(
            $"List Item Types For: {itemTypeGeneratorStore.Name}",
            itemTypeGeneratorStore,
            Function(x, y) x.ItemTypes.Filter(y),
            Function(x) New ItemTypeGeneratorItemTypeListItem(x),
            AdditionalButtons:=
            {
                (
                    "Close",
                    Function() True,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore))
                ),
                (
                    "Add...",
                    Function() itemTypeGeneratorStore.CanAddItemType,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorItemTypeAddWindow(itemTypeGeneratorStore))
                ),
                (
                    "Remove...",
                    Function() itemTypeGeneratorStore.HasItemTypes,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorItemTypeRemoveWindow(itemTypeGeneratorStore))
                )
            })
    End Sub
End Class
