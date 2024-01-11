﻿Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RouteEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(store As IRouteStore)
        MyBase.New(
            $"Edit Route",
            "Route",
            store.Id,
            ("Name", $"{store.Direction.Name} {store.RouteType.Name} from {store.FromLocation.Name} to {store.ToLocation.Name}"),
            False,
            True,
            Function(x) False,
            Function() New LocationEditWindow(store.FromLocation),
            Function()
                Dim fromLocation = store.FromLocation
                store.Delete()
                Return New LocationEditWindow(fromLocation)
            End Function,
            Function(x) Nothing)
    End Sub
End Class