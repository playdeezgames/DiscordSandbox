Imports Terminal.Gui

Friend Class RouteTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Route Type...",
            "Route Type",
            Function(x) dataStore.RouteTypes.NameExists(x),
            Function() New RouteTypeListWindow(dataStore),
            Function(x) New RouteTypeEditWindow(dataStore.RouteTypes.Create(x)))
    End Sub
End Class
