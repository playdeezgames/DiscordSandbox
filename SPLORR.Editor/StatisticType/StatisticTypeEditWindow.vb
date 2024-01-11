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
            True,
            statisticTypeStore.CanDelete,
            Function(x) statisticTypeStore.CanRenameTo(x),
            Function() New StatisticTypeListWindow(statisticTypeStore.Store),
            Function()
                statisticTypeStore.Delete()
                Return New StatisticTypeListWindow(statisticTypeStore.Store)
            End Function,
            Function(x)
                statisticTypeStore.Name = x
                Return New StatisticTypeEditWindow(statisticTypeStore)
            End Function)
    End Sub
End Class
