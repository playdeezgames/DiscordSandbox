Imports Terminal.Gui

Friend Class VerbTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Verb Type...",
            "Verb Type",
            Function(x) dataStore.VerbTypeNameExists(x),
            Function() New VerbTypeListWindow(dataStore),
            Function(x) New VerbTypeEditWindow(dataStore.CreateVerbType(x)))
    End Sub
End Class
