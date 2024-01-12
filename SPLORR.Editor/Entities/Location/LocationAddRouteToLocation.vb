Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationAddRouteToLocation
    Inherits BaseListWindow(Of ILocationStore, ILocationStore)
    Public Sub New(store As ILocationStore, direction As IDirectionStore, routeType As IRouteTypeStore)
        MyBase.New(
            $"Add Route Destination (From `{store.Name}` Direction `{direction.Name}` Type `{routeType.Name}`):",
            store,
            Function(x, y) x.Store.Locations.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                Return New RouteEditWindow(store.AddRoute(direction, routeType, x))
            End Function)
    End Sub
End Class
