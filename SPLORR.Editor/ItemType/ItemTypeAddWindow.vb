Friend Class ItemTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Item Type...",
            "Item Type",
            Function(x) dataStore.ItemTypes.NameExists(x),
            Function() New ItemTypeListWindow(dataStore),
            Function(x) New ItemTypeEditWindow(dataStore.ItemTypes.Create(x)))
    End Sub
End Class
