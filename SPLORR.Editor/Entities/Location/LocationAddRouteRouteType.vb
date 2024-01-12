Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationAddRouteRouteType
    Inherits BaseListWindow(Of ILocationStore, IRouteTypeStore)
    Public Sub New(store As ILocationStore, direction As IDirectionStore)
        MyBase.New(
            $"Add Route Type (From `{store.Name}` Direction `{direction.Name}`):",
            store,
            Function(x, y) x.Store.RouteTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                Return New LocationAddRouteToLocation(store, direction, x)
            End Function)
    End Sub
End Class
