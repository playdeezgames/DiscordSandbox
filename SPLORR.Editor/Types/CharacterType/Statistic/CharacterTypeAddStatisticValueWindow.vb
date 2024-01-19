Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeAddStatisticValueWindow
    Inherits BaseAddTypeWindow

    Public Sub New(store As ICharacterTypeStore, statisticType As IStatisticTypeStore)
        MyBase.New(
            $"Statistic Value for Statistic Type `{statisticType.Name}` for Character Type `{store.Name}`",
            $"Must be an integer!",
            (
                "Add",
                Function(x)
                    Dim value As Integer = 0
                    Return Not Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.AddStatistic(statisticType, Integer.Parse(x), Nothing, Nothing)
                    Return New CharacterTypeStatisticListWindow(store)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterTypeStatisticListWindow(store)
            ))
    End Sub
End Class
