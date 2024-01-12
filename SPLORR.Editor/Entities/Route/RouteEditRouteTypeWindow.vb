Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteEditRouteTypeWindow
    Inherits BaseListWindow(Of IRouteStore, IRouteTypeStore)
    Public Sub New(store As IRouteStore)
        MyBase.New(
            $"Change Route's Type (currently `{store.RouteType.Name}`)",
            store,
            Function(x, y) x.Store.RouteTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.RouteType = x
                Return New RouteEditWindow(store)
            End Function)
    End Sub
End Class
