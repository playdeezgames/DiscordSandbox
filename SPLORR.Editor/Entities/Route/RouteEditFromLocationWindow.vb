Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteEditFromLocationWindow
    Inherits BaseListWindow(Of IRouteStore, ILocationStore)
    Public Sub New(store As IRouteStore)
        MyBase.New(
            $"Change From Location (Currently `{store.FromLocation.Name}`)",
            store,
            Function(x, y) x.Store.Locations.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.FromLocation = x
                Return New RouteEditWindow(store)
            End Function)
    End Sub
End Class
