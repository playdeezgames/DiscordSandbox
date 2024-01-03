Friend Class ItemTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Item Type...",
            "Item Type",
            Function(x) dataStore.ItemTypeNameExists(x),
            Function() New ItemTypeListWindow(dataStore),
            Function(x) New ItemTypeEditWindow(dataStore.CreateItemType(x)))
    End Sub
End Class
