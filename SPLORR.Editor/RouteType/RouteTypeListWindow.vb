Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteTypeListWindow
    Inherits BaseListWindow(Of IDataStore, IRouteTypeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Route Types",
            dataStore,
            Function(store, filter) store.RouteTypes.Filter(filter),
            Function(x) New ListItem(Of IRouteTypeStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(item) New RouteTypeEditWindow(CType(item, ListItem(Of IRouteTypeStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New RouteTypeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
