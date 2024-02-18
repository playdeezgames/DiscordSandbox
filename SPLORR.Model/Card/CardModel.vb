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
            Dim candidates = LocalEffects.Where(AddressOf MeetsEffectTypeRequirements)
            If Not candidates.Any Then
                Return False
            End If
            Dim minimums As New Dictionary(Of String, Integer)
            Dim maximums As New Dictionary(Of String, Integer)
            For Each candidate In candidates
                For Each requirement In candidate.Requirements
                    Dim minimum = requirement.Minimum
                    Dim maximum = requirement.Maximum
                    Dim name = requirement.Name
                    If minimum.HasValue Then
                        If minimums.ContainsKey(name) Then
                            minimums(name) += minimum.Value
                        Else
                            minimums(name) = minimum.Value
                        End If
                    End If
                    If maximum.HasValue Then
                        If maximums.ContainsKey(name) Then
                            maximums(name) = Math.Max(maximums(name), maximum.Value)
                        Else
                            maximums(name) = maximum.Value
                        End If
                    End If
                Next
            Next
            Return (minimums.Count = 0 OrElse minimums.All(AddressOf CharacterMeetsRequiredMinimum)) AndAlso (maximums.Count = 0 OrElse maximums.All(AddressOf CharacterMeetsRequiredMaximum))
        End Get
    End Property

    Private Function CharacterMeetsRequiredMaximum(pair As KeyValuePair(Of String, Integer)) As Boolean
        Return Character.Store.Statistics.FromName(pair.Key).Value <= pair.Value
    End Function

    Private Function CharacterMeetsRequiredMinimum(pair As KeyValuePair(Of String, Integer)) As Boolean
        Return Character.Store.Statistics.FromName(pair.Key).Value >= pair.Value
    End Function

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
            Dim effects = LocalEffects.Where(AddressOf MeetsEffectTypeRequirements)
            Dim result As New List(Of ILocationModel)
            For Each effect In effects
                For Each destination In effect.Destinations
                    For Each index In Enumerable.Range(1, destination.GeneratorWeight)
                        result.Add(destination.Location)
                    Next
                Next
            Next
            Return result
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
        If Not CanPlay Then
            Return
        End If
        Dim effects = LocalEffects.Where(AddressOf MeetsEffectTypeRequirements)
        Dim refreshHand As Boolean = False
        For Each effect In effects
            For Each statisticDelta In effect.StatisticDeltas
                outputter($"{statisticDelta.Delta} {statisticDelta.StatisticType.Name}")
                Character.GetStatistic(statisticDelta.StatisticType).Value += statisticDelta.Delta
            Next
            For Each cardTypeGenerator In effect.CardTypeGenerators
                Dim generator = cardTypeGenerator.CardTypes.ToDictionary(Function(x) x.CardType, Function(x) x.GeneratorWeight)
                Dim cardType = RNG.FromGenerator(generator)
                If Character.AddCard(cardType) Then
                    outputter($"*NEW CARD!* {cardType.Name}")
                End If
            Next
            If effect.RefreshHand Then
                refreshHand = True
            End If
        Next
        Dim destinationLocations As IEnumerable(Of ILocationModel) = Me.Destinations
        If destinationLocations.Any Then
            Character.Location = RNG.FromEnumerable(destinationLocations)
        End If
        Discard()
        If refreshHand Then
            Character.RefreshHand()
        End If
    End Sub
End Class
