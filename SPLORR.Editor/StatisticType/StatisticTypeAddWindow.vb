Imports Terminal.Gui

Friend Class StatisticTypeAddWindow
    Inherits BaseAddTypeWindow

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Statistic Type...",
            "Statistic Type",
            Function(x) dataStore.StatisticTypes.NameExists(x),
            Function() New StatisticTypeListWindow(dataStore),
            Function(x) New StatisticTypeEditWindow(dataStore.StatisticTypes.Create(x)))
    End Sub
End Class
