Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationAddRouteDirection
    Inherits BaseListWindow(Of ILocationStore, IDirectionStore)
    Public Sub New(store As ILocationStore)
        MyBase.New(
            $"Add Route Direction (From `{store.Name}`):",
            store,
            Function(x, y) x.AvailableDirections.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                Return New LocationAddRouteRouteType(store, x)
            End Function)
    End Sub
End Class
