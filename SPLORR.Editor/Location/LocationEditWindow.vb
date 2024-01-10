Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(locationStore As ILocationStore)
        MyBase.New(
            $"Edit Location: {locationStore.Name}",
            "Item Type",
            locationStore.Id,
            ("Name", locationStore.Name),
            locationStore.CanDelete,
            Function(x) locationStore.CanRenameTo(x),
            Function() New LocationListWindow(locationStore.Store),
            Function()
                locationStore.Delete()
                Return New LocationListWindow(locationStore.Store)
            End Function,
            Function(x)
                locationStore.Name = x
                Return New LocationEditWindow(locationStore)
            End Function)
    End Sub
End Class
