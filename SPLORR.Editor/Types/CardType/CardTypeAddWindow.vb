Friend Class CardTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Card Type...",
            "Card Type Name must exist and be unique!",
            ("Add", Function(x) String.IsNullOrEmpty(x) OrElse dataStore.CardTypes.NameExists(x),
            Function(x) New CardTypeEditWindow(dataStore.CardTypes.Create(x))),
            ("Cancel", Function() New CardTypeListWindow(dataStore)))
    End Sub
End Class
