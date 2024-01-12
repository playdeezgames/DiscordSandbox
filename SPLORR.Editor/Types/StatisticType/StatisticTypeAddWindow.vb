Friend Class StatisticTypeAddWindow
    Inherits BaseAddTypeWindow

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Statistic Type...",
            "Statistic Type",
            (
                "Add",
                Function(x) dataStore.StatisticTypes.NameExists(x),
                Function(x) New StatisticTypeEditWindow(dataStore.StatisticTypes.Create(x))
            ),
            (
                "Cancel",
                Function() New StatisticTypeListWindow(dataStore)
            ))
    End Sub
End Class
