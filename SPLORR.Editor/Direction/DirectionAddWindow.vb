Friend Class DirectionAddWindow
    Inherits BaseAddTypeWindow

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Direction...",
            "Direction",
            Function(x) dataStore.Directions.NameExists(x),
            Function() New DirectionListWindow(dataStore),
            Function(x) New DirectionEditWindow(dataStore.Directions.Create(x)))
    End Sub
End Class
