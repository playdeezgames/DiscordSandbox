Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(routeTypeStore As IRouteTypeStore)
        MyBase.New(
            $"Edit Route Type: {routeTypeStore.Name}",
            "Route Type",
            routeTypeStore.Id,
            ("Name", routeTypeStore.Name),
            True,
            routeTypeStore.CanDelete,
            Function(x) routeTypeStore.CanRenameTo(x),
            Function() New RouteTypeListWindow(routeTypeStore.Store),
            Function()
                routeTypeStore.Delete()
                Return New RouteTypeListWindow(routeTypeStore.Store)
            End Function,
            Function(x)
                routeTypeStore.Name = x
                Return New RouteTypeEditWindow(routeTypeStore)
            End Function)
    End Sub
End Class
