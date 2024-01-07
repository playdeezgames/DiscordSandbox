Imports SPLORR.Data
Imports Terminal.Gui

Friend Class ItemTypeGeneratorItemTypeListWindow
    Inherits BaseListWindow(Of IItemTypeGeneratorStore, IItemTypeGeneratorItemTypeStore)

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New(
            $"List Item Types For: {itemTypeGeneratorStore.Name}",
            itemTypeGeneratorStore,
            Function(x, y) x.ItemTypes.Filter(y),
            Function(x) New ItemTypeGeneratorItemTypeListItem(x),
            Function(x) New ItemTypeGeneratorItemTypeListWindow(itemTypeGeneratorStore),
            AdditionalButtons:=
            {
                (
                    "Close",
                    Function() True,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore))
                )
            })
    End Sub
End Class
