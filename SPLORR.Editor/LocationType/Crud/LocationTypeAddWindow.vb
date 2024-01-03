Imports Terminal.Gui

Friend Class LocationTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Location Type...",
            "Location Type",
            Function(x) dataStore.LocationTypeNameExists(x),
            Function() New LocationTypeListWindow(dataStore),
            Function(x) New LocationTypeEditWindow(dataStore.CreateLocationType(x)))
    End Sub
End Class
