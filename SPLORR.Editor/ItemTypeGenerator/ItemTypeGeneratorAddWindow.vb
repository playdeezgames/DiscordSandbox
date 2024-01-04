Imports Terminal.Gui

Friend Class ItemTypeGeneratorAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Item Type Generator...",
            "Item Type Generator",
            Function(x) dataStore.ItemTypeGeneratorNameExists(x),
            Function() New ItemTypeGeneratorListWindow(dataStore),
            Function(x) New ItemTypeGeneratorEditWindow(dataStore.CreateItemTypeGenerator(x)))
    End Sub
End Class
