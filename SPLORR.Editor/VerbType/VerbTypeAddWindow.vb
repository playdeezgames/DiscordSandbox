Friend Class VerbTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Verb Type...",
            "Verb Type",
            Function(x) dataStore.VerbTypes.NameExists(x),
            Function() New VerbTypeListWindow(dataStore),
            Function(x) New VerbTypeEditWindow(dataStore.VerbTypes.Create(x)))
    End Sub
End Class
