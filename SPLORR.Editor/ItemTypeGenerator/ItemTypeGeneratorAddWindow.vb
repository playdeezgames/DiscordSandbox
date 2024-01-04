Imports Terminal.Gui

Friend Class ItemTypeGeneratorAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Item Type Generator...",
            "Item Type Generator",
            Function(x) dataStore.ItemTypeGenerators.NameExists(x),
            Function() New ItemTypeGeneratorListWindow(dataStore),
            Function(x) New ItemTypeGeneratorEditWindow(dataStore.ItemTypeGenerators.Create(x)))
    End Sub
End Class
