Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeStatisticsListWindow
    Inherits BaseListWindow(Of ICharacterTypeStore, ICharacterTypeStatisticStore)

    Public Sub New(store As Data.ICharacterTypeStore)
        MyBase.New(
            $"Statistics for Character Type `{store.Name}`",
            store,
            Function(x, y) x.Statistics.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id},Value:{x.Value})",
            Function(x) New CharacterTypeEditStatisticWindow(x),
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterTypeEditWindow(store))
                ),
                (
                    "Add",
                    Function() store.CanAddStatistic,
                    Sub() Program.GoToWindow(New CharacterTypeAddStatisticTypeWindow(store))
                )
            })
    End Sub
End Class
