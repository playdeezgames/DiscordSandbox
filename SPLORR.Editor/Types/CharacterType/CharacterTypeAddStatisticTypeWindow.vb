Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeAddStatisticTypeWindow
    Inherits BaseListWindow(Of ICharacterTypeStore, IStatisticTypeStore)

    Public Sub New(store As ICharacterTypeStore)
        MyBase.New(
            $"Add Statistic for Character Type {store.Name}",
            store,
            Function(x, y) x.AvailableStatistics.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CharacterTypeAddStatisticValueWindow(store, x))
    End Sub
End Class
