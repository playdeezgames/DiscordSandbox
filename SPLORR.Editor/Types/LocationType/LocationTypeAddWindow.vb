Imports Terminal.Gui

Friend Class LocationTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Location Type...",
            "Location Type",
            ("Add", Function(x) dataStore.LocationTypes.NameExists(x),
            Function(x) New LocationTypeEditWindow(dataStore.LocationTypes.Create(x))),
            ("Cancel", Function() New LocationTypeListWindow(dataStore)))
    End Sub
End Class
