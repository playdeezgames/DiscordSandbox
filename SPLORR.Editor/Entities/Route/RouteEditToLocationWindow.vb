Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteEditToLocationWindow
    Inherits BaseListWindow(Of IRouteStore, ILocationStore)
    Public Sub New(store As IRouteStore)
        MyBase.New(
            $"Change To Location (Currently `{store.ToLocation.Name}`)",
            store,
            Function(x, y) x.Store.Locations.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.ToLocation = x
                Return New RouteEditWindow(store)
            End Function)
    End Sub
End Class
