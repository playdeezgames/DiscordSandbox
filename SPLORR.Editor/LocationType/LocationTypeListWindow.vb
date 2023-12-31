Friend Class LocationTypeListWindow
    Inherits BaseListWindow(Of Data.IDataStore, Data.ILocationTypeStore)
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Location Types",
            dataStore,
            Function(store, filter) store.FilterLocationTypes(filter),
            Function(item) New LocationTypeListItem(item),
            Function(item) New LocationTypeEditWindow(CType(item, LocationTypeListItem).LocationTypeStore))
    End Sub
End Class
