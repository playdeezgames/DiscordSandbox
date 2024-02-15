Imports System.Data
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

    Public ReadOnly Property CanPlay As Boolean Implements ICardModel.CanPlay
        Get
            If Not InHand OrElse Not HasLocalEffects Then
                Return False
            End If
            Return LocalEffects.Any(AddressOf MeetsEffectTypeRequirements)
        End Get
    End Property

    Private Function MeetsEffectTypeRequirements(effectType As IEffectTypeModel) As Boolean
        Return Character.Store.SatisfiesRequirements(effectType.Store)
    End Function

    Private ReadOnly Property LocalEffects As IEnumerable(Of IEffectTypeModel)
        Get
            Return Store.LocalEffects.Select(Function(x) New EffectTypeModel(x))
        End Get
    End Property

    Private ReadOnly Property HasLocalEffects As Boolean
        Get
            Return Store.HasLocalEffects
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

    Public ReadOnly Property Destinations As IEnumerable(Of ILocationModel) Implements ICardModel.Destinations
        Get
            Return Store.Destinations.Select(Function(x) New LocationModel(x))
        End Get
    End Property

    Public ReadOnly Property Effects As IEnumerable(Of IEffectTypeModel) Implements ICardModel.Effects
        Get
            Return Store.EffectTypes.Select(Function(x) New EffectTypeModel(x))
        End Get
    End Property

    Public ReadOnly Property CardType As ICardTypeModel Implements ICardModel.CardType
        Get
            Return New CardTypeModel(Store.CardType)
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
            If Character.AddCard(cardType) Then
                outputter($"*NEW CARD!* {cardType.Name}")
            End If
        Next
        Dim destinationLocations As IEnumerable(Of ILocationModel) = Me.Destinations
        If destinationLocations.Any Then
            Character.Location = RNG.FromEnumerable(destinationLocations)
        End If
        Discard()
    End Sub
End Class
