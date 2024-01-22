Imports SPLORR.Data

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
        For Each tag In Store.CardType.Tags.All
            ExecuteTag(tag, outputter)
        Next
        Discard()
        If Store.CardType.DeleteOnPlay Then
            Store.Delete()
            Return
        End If
    End Sub

    Private Const CARD_TYPE_TAG_FORAGE = "forage"
    Private Sub ExecuteTag(tag As ICardTypeTagStore, outputter As Action(Of String))
        Select Case tag.Name
            Case CARD_TYPE_TAG_FORAGE
                ExecuteForageTag(outputter)
        End Select
    End Sub

    Private Sub ExecuteForageTag(outputter As Action(Of String))
        Dim character = New CharacterModel(Store.Character)
        Dim foragedItem = character.Location.GenerateForageItem(character.Inventory)
        If foragedItem Is Nothing Then
            outputter($"{character.Name} finds nothing!")
            Return
        End If
        outputter($"{character.Name} finds {foragedItem.Name}.")
    End Sub
End Class
