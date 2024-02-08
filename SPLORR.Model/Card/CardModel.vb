Imports SPLORR.Data
Imports SPLORR.Game

Friend Class CardModel
    Implements ICardModel
    Public ReadOnly Property Store As ICardStore Implements ICardModel.Store

    Public ReadOnly Property Name As String Implements ICardModel.Name
        Get
            Return Store.Name
        End Get
    End Property

    Private ReadOnly Property InHand As Boolean
        Get
            Return Store.InHand
        End Get
    End Property

    Private ReadOnly Property MeetsRequirements As Boolean
        Get
            For Each requirement In Store.CardType.Requirements
                Dim characterStatistic = Store.Character.Statistics.FromName(requirement.Statistic.Name)
                Dim minimum = requirement.Minimum
                Dim maximum = requirement.Maximum
                Dim value = characterStatistic.Value
                If (minimum.HasValue AndAlso value < minimum.Value) OrElse (maximum.HasValue AndAlso value > maximum.Value) Then
                    Return False
                End If
            Next
            Return True
        End Get
    End Property

    Public ReadOnly Property CanPlay As Boolean Implements ICardModel.CanPlay
        Get
            If Not InHand OrElse Not MeetsRequirements Then
                Return False
            End If
            Return True
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterModel Implements ICardModel.Character
        Get
            Return New CharacterModel(Store.Character)
        End Get
    End Property

    Public ReadOnly Property StatisticDeltas As IEnumerable(Of ICardStatisticDeltaModel) Implements ICardModel.StatisticDeltas
        Get
            Return Store.StatisticDeltas.Select(Function(x) New CardStatisticDeltaModel(x))
        End Get
    End Property

    Public ReadOnly Property CardTypeGenerators As IEnumerable(Of ICardTypeGeneratorModel) Implements ICardModel.CardTypeGenerators
        Get
            Return Store.CardTypeGenerators.Select(Function(x) New CardTypeGeneratorModel(x))
        End Get
    End Property

    Public Sub New(store As ICardStore)
        Me.Store = store
    End Sub

    Private Sub Discard()
        If Store.SelfDestructs Then
            Store.Delete()
            Return
        End If
        Store.Discard()
    End Sub

    Public Sub Play(outputter As Action(Of String)) Implements ICardModel.Play
        For Each statisticDelta In StatisticDeltas
            outputter($"{statisticDelta.Delta} {statisticDelta.StatisticType.Name}")
            Character.GetStatistic(statisticDelta.StatisticType).Value += statisticDelta.Delta
        Next
        For Each cardTypeGenerator In CardTypeGenerators
            Dim cardType = cardTypeGenerator.GenerateCardType()
            outputter($"*NEW CARD!* {cardType.Name}")
            Character.AddCard(cardType)
        Next
        Discard()
    End Sub
End Class
