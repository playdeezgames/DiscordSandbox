Friend Class ItemTypeGeneratorAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Item Type Generator...",
            "Item Type Generator Name must exist and be unique!",
            ("Add", Function(x) String.IsNullOrEmpty(x) OrElse dataStore.ItemTypeGenerators.NameExists(x),
            Function(x) New ItemTypeGeneratorEditWindow(dataStore.ItemTypeGenerators.Create(x))),
            ("Cancel", Function() New ItemTypeGeneratorListWindow(dataStore)))
    End Sub
End Class
