Imports SPLORR.Data
Imports Terminal.Gui

Friend Class StatisticTypeEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(statisticTypeStore As IStatisticTypeStore)
        MyBase.New(
            $"Edit Statistic Type: {statisticTypeStore.Name}",
            "Statistic Type",
            statisticTypeStore.Id,
            ("Name", statisticTypeStore.Name),
            (True, "Update",
            Function(x) statisticTypeStore.CanRenameTo(x),
            Function(x)
                statisticTypeStore.Name = x
                Return New StatisticTypeEditWindow(statisticTypeStore)
            End Function),
            (statisticTypeStore.CanDelete, "Delete",
            Function()
                statisticTypeStore.Delete()
                Return New StatisticTypeListWindow(statisticTypeStore.Store)
            End Function),
            ("Cancel", Function() New StatisticTypeListWindow(statisticTypeStore.Store)))
    End Sub
End Class
