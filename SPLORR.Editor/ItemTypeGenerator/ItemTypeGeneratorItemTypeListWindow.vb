Imports SPLORR.Data

Friend Class ItemTypeGeneratorItemTypeListWindow
    Inherits BaseListWindow(Of IItemTypeGeneratorStore, IItemTypeGeneratorItemTypeStore)

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New(
            $"List Item Types For: {itemTypeGeneratorStore.Name}",
            itemTypeGeneratorStore,
            Function(x, y) x.ItemTypes.Filter(y),
            Function(x) New ItemTypeGeneratorItemTypeListItem(x),
            ToResultWindow:=Function(x)
                                Return New ItemTypeGeneratorItemTypeEditWindow(CType(x, ItemTypeGeneratorItemTypeListItem).Store)
                            End Function,
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
                )
            })
    End Sub
End Class
