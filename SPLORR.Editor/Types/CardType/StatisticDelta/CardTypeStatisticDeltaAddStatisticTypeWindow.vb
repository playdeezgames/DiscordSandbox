Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CardTypeStatisticDeltaAddStatisticTypeWindow
    Inherits BaseListWindow(Of ICardTypeStore, IStatisticTypeStore)

    Public Sub New(store As ICardTypeStore)
        MyBase.New(
            "Add Statistic Delta",
            store,
            Function(x, y) store.AvailableStatisticDeltas.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id}",
            Function(x) New CardTypeStatisticDeltaAddDeltaWindow(store, x),
            {
                ("Cancel", Function() True, Sub() Program.GoToWindow(New CardTypeStatisticDeltaListWindow(store)))
            })
    End Sub
End Class
