Imports SPLORR.Data

Friend Class CharacterAddStatisticTypeWindow
    Inherits BaseListWindow(Of ICharacterStore, IStatisticTypeStore)

    Public Sub New(store As ICharacterStore)
        MyBase.New(
            $"Add Statistic for Character `{store.Name}`",
            store,
            Function(x, y) x.AvailableStatistics.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CharacterAddStatisticValueWindow(store, x))
    End Sub
End Class
