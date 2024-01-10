Imports SPLORR.Data

Friend Class ItemTypeListWindow
    Inherits BaseListWindow(Of IDataStore, IItemTypeStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Item Types",
            store,
            Function(x, y) x.ItemTypes.Filter(y),
            Function(x) New ItemTypeListItem(x),
            Function(x) New ItemTypeEditWindow(CType(x, ItemTypeListItem).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New ItemTypeAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
