Imports System.Data
Imports Microsoft.VisualBasic.FileIO
Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(routeTypeStore As IRouteTypeStore)
        MyBase.New(
            $"Edit Route Type: {routeTypeStore.Name}",
            "Route Type",
            ("Id", routeTypeStore.Id.ToString),
            ("Name", routeTypeStore.Name),
            (True, "Update",
            Function(x) routeTypeStore.CanRenameTo(x),
            Function(x)
                routeTypeStore.Name = x
                Return New RouteTypeEditWindow(routeTypeStore)
            End Function),
            (
                routeTypeStore.CanDelete,
                "Delete",
                Function()
                    routeTypeStore.Delete()
                    Return New RouteTypeListWindow(routeTypeStore.Store)
                End Function
            ),
            ("Cancel", Function() New RouteTypeListWindow(routeTypeStore.Store)))
    End Sub
End Class
