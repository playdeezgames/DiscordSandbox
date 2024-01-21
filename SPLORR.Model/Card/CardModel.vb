Imports SPLORR.Data

Friend Class CardModel
    Implements ICardModel

    Public ReadOnly Property Store As ICardStore Implements ICardModel.Store

    Public ReadOnly Property Name As String Implements ICardModel.Name
        Get
            Return Store.Name
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterModel Implements ICardModel.Character
        Get
            Return New CharacterModel(Store.Character)
        End Get
    End Property

    Public ReadOnly Property InHand As Boolean Implements ICardModel.InHand
        Get
            Return Store.InHand
        End Get
    End Property

    Public ReadOnly Property StatisticDeltas As IEnumerable(Of ICardTypeStatisticDeltaModel) Implements ICardModel.StatisticDeltas
        Get
            Return Store.
                CardType.
                StatisticDeltas.
                All.
                Select(Function(x) New CardTypeStatisticDeltaModel(x))
        End Get
    End Property

    Public Sub New(store As ICardStore)
        Me.Store = store
    End Sub

    Public Sub Discard() Implements ICardModel.Discard
        Store.Discard()
    End Sub
End Class
