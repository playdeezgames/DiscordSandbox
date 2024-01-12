Friend Class DirectionAddWindow
    Inherits BaseAddTypeWindow

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Direction...",
            "Direction",
            ("Add", Function(x) dataStore.Directions.NameExists(x),
            Function(x) New DirectionEditWindow(dataStore.Directions.Create(x))),
            ("Cancel", Function() New DirectionListWindow(dataStore)))
    End Sub
End Class
