Imports SPLORR.Data

Friend Class CardTypeStatisticDeltaListWindow
    Inherits BaseListWindow(Of ICardTypeStore, ICardTypeStatisticDeltaStore)

    Public Sub New(store As Data.ICardTypeStore)
        MyBase.New(
            $"Statistic Deltas for Card Type `{store.Name}`",
            store,
            Function(x, y) x.StatisticDeltas.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id},Delta:{x.Delta},Overage:{x.AllowOverage})",
            Function(x) New CardTypeStatisticDeltaEditWindow(x),
            {
                (
                    "Add...",
                    Function() store.CanAddStatisticDelta,
                    Sub() Program.GoToWindow(New CardTypeStatisticDeltaAddStatisticTypeWindow(store))
                ),
                (
                    "Close",
                    Function() True,
                    Sub() Program.GoToWindow(New CardTypeEditWindow(store))
                )
            })
    End Sub
End Class
