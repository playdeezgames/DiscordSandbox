Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteTypeListWindow
    Inherits BaseListWindow(Of IDataStore, IRouteTypeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Route Types",
            dataStore,
            Function(store, filter) store.RouteTypes.Filter(filter),
            Function(item) New RouteTypeListItem(item),
            Function(item) New RouteTypeEditWindow(CType(item, RouteTypeListItem).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New RouteTypeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
