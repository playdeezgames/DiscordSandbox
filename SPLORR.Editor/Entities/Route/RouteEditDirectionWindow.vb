Imports SPLORR.Data
Friend Class RouteEditDirectionWindow
    Inherits BaseListWindow(Of IRouteStore, IDirectionStore)
    Public Sub New(store As IRouteStore)
        MyBase.New(
            $"Change Route Direction",
            store,
            Function(x, y) x.FromLocation.AvailableDirections.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.Direction = x
                Return New RouteEditWindow(store)
            End Function)
    End Sub
End Class
