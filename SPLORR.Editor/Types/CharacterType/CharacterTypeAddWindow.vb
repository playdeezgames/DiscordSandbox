Friend Class CharacterTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Character Type...",
            "Character Type Name must exist and be unique!",
            ("Add", Function(x) String.IsNullOrEmpty(x) OrElse dataStore.CharacterTypes.NameExists(x),
            Function(x) New CharacterTypeEditWindow(dataStore.CharacterTypes.Create(x))),
            ("Cancel", Function() New CharacterTypeListWindow(dataStore)))
    End Sub
End Class
