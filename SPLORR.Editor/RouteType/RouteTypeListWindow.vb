Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteTypeListWindow
    Inherits BaseListWindow(Of IDataStore, IRouteTypeStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Route Types",
            store,
            Function(x, y) x.RouteTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New RouteTypeEditWindow(x),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New RouteTypeAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
