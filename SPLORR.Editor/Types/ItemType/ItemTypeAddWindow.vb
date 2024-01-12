Friend Class ItemTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Item Type...",
            "Item Type",
            ("Add", Function(x) dataStore.ItemTypes.NameExists(x),
            Function(x) New ItemTypeEditWindow(dataStore.ItemTypes.Create(x))),
            ("Cancel", Function() New ItemTypeListWindow(dataStore)))
    End Sub
End Class
