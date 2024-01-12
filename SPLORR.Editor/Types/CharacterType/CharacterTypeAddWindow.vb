Friend Class CharacterTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Character Type...",
            "Character Type",
            ("Add", Function(x) dataStore.CharacterTypes.NameExists(x),
            Function(x) New CharacterTypeEditWindow(dataStore.CharacterTypes.Create(x))),
            ("Cancel", Function() New CharacterTypeListWindow(dataStore)))
    End Sub
End Class
