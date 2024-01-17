Imports System.Data
Imports Microsoft.VisualBasic.FileIO
Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(store As IRouteStore)
        MyBase.New(
            $"Edit Route",
            "Route",
            ("Id", store.Id.ToString),
            ("Name", $"{store.Direction.Name} {store.RouteType.Name} from {store.FromLocation.Name} to {store.ToLocation.Name}"),
            (False, Nothing, Nothing, Nothing),
            (True, "Delete",
            Function()
                Dim fromLocation = store.FromLocation
                store.Delete()
                Return New LocationEditWindow(fromLocation)
            End Function),
            ("Cancel", Function() New LocationEditWindow(store.FromLocation)),
            {
                (
                    $"Direction: {store.Direction.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New RouteEditDirectionWindow(store))
                ),
                (
                    $"Route Type: {store.RouteType.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New RouteEditRouteTypeWindow(store))
                ),
                (
                    $"From: {store.FromLocation.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New RouteEditFromLocationWindow(store))
                ),
                (
                    $"To: {store.ToLocation.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New RouteEditToLocationWindow(store))
                )
            })
    End Sub
End Class
