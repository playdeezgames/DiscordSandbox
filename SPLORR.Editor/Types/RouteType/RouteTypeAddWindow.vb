Imports Terminal.Gui

Friend Class RouteTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Route Type...",
            "Route Type",
            ("Add", Function(x) dataStore.RouteTypes.NameExists(x),
            Function(x) New RouteTypeEditWindow(dataStore.RouteTypes.Create(x))),
            ("Cancel", Function() New RouteTypeListWindow(dataStore)))
    End Sub
End Class
