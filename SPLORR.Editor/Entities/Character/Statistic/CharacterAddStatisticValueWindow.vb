Imports SPLORR.Data

Friend Class CharacterAddStatisticValueWindow
    Inherits BaseAddTypeWindow

    Public Sub New(store As ICharacterStore, statisticType As IStatisticTypeStore)
        MyBase.New(
            $"Value for Statistic `{statisticType.Name}` for Character `{store.Name}`",
            $"Must be an integer!",
            (
                "Add",
                Function(x)
                    Dim value As Integer = 0
                    Return Not Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.AddStatistic(statisticType, Integer.Parse(x), Nothing, Nothing)
                    Return New CharacterStatisticListWindow(store)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterStatisticListWindow(store)
            ))
    End Sub
End Class
