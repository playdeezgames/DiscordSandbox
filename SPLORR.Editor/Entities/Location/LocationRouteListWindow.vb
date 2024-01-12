Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationRouteListWindow
    Inherits BaseListWindow(Of ILocationStore, IRouteStore)

    Public Sub New(store As ILocationStore)
        MyBase.New(
            $"Routes for Location `{store.Name}`",
            store,
            Function(x, y) x.Routes.Filter(y),
            Function(x) $"{x.Direction.Name} {x.RouteType.Name} to {x.ToLocation.Name}",
            Function(x) New RouteEditWindow(x),
            {
                ("Cancel", Function() True, Sub() Program.GoToWindow(New LocationEditWindow(store)))
            })
    End Sub
End Class
