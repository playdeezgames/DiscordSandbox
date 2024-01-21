Imports SPLORR.Data

Friend Class CardTypeStatisticDeltaModel
    Implements ICardTypeStatisticDeltaModel
    Sub New(store As ICardTypeStatisticDeltaStore)
        Me.Store = store
    End Sub

    Public ReadOnly Property Store As ICardTypeStatisticDeltaStore Implements ICardTypeStatisticDeltaModel.Store
End Class
