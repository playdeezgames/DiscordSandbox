Friend Class CharacterTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Character Type...",
            "Character Type",
            Function(x) dataStore.CharacterTypes.NameExists(x),
            Function() New CharacterTypeListWindow(dataStore),
            Function(x) New CharacterTypeEditWindow(dataStore.CharacterTypes.Create(x)))
    End Sub
End Class
