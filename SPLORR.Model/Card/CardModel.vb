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

    Private ReadOnly Property StatisticDeltas As IEnumerable(Of ICardTypeStatisticDeltaModel)
        Get
            Return Store.
                CardType.
                StatisticDeltas.
                All.
                Select(Function(x) New CardTypeStatisticDeltaModel(x))
        End Get
    End Property

    Public ReadOnly Property CanPlay As Boolean Implements ICardModel.CanPlay
        Get
            If Not InHand Then
                Return False
            End If
            For Each delta In StatisticDeltas.Where(Function(x) Not x.Store.AllowOverage)
                Dim deltaStore = delta.Store
                Dim statistic = Store.Character.Statistics.FromName(deltaStore.Name)
                Dim newValue = statistic.Value + deltaStore.Delta
                If newValue > statistic.Maximum OrElse newValue < statistic.Minimum Then
                    Return False
                End If
            Next
            Return True
        End Get
    End Property

    Public Sub New(store As ICardStore)
        Me.Store = store
    End Sub

    Private Sub Discard()
        Store.Discard()
    End Sub

    Public Sub Play(outputter As Action(Of String)) Implements ICardModel.Play
        For Each delta In StatisticDeltas
            Dim deltaStore = delta.Store
            Dim deltaName = deltaStore.Name
            Dim deltaDelta = deltaStore.Delta
            Dim statistic = Store.Character.Statistics.FromName(deltaName)
            outputter($"{deltaDelta} {deltaName}")
            statistic.Value += deltaDelta
        Next
        Dim generator = Store.CardType.Generator
        If generator IsNot Nothing Then
            Dim cardType = RNG.FromGenerator(generator.CardTypes.All.ToDictionary(Function(x) x.CardType, Function(x) x.GeneratorWeight))
            outputter($"{Store.Character.Name} gains card `{cardType.Name}`!")
            cardType.CreateCard(Store.Character)
        End If
        Dim location = Store.CardType.Location
        If location IsNot Nothing Then
            Store.Character.Location = location
            outputter($"{Store.Character.Name} moves to {location.Name}.")
        End If
        Discard()
        If Store.CardType.DeleteOnPlay Then
            Store.Delete()
            Return
        End If
    End Sub

End Class
