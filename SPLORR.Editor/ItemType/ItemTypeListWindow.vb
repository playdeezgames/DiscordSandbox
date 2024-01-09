Imports SPLORR.Data

Friend Class ItemTypeListWindow
    Inherits BaseListWindow(Of IDataStore, IItemTypeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Item Types",
            dataStore,
            Function(store, filter) store.ItemTypes.Filter(filter),
            Function(item) New ItemTypeListItem(item),
            Function(item) New ItemTypeEditWindow(CType(item, ItemTypeListItem).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New ItemTypeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
