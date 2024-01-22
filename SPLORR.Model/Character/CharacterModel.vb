Imports SPLORR.Data

Friend Class CharacterModel
    Implements ICharacterModel

    ReadOnly Property Store As ICharacterStore Implements ICharacterModel.Store
    Sub New(characterStore As ICharacterStore)
        store = characterStore
    End Sub
    Public Property Name As String Implements ICharacterModel.Name
        Get
            Return store.Name
        End Get
        Set(value As String)
            store.Name = value
        End Set
    End Property
    Public Property Location As ILocationModel Implements ICharacterModel.Location
        Get
            Return New LocationModel(store.Location)
        End Get
        Set(value As ILocationModel)
            store.SetLocation(value.LocationStore, DateTimeOffset.Now)
        End Set
    End Property

    Public ReadOnly Property HasOtherCharacters As Boolean Implements ICharacterModel.HasOtherCharacters
        Get
            Return store.HasOtherCharacters
        End Get
    End Property

    Public ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterModel) Implements ICharacterModel.OtherCharacters
        Get
            Return store.OtherCharacters.Select(Function(x) New CharacterModel(x))
        End Get
    End Property

    Public ReadOnly Property Cards As IEnumerable(Of ICardModel) Implements ICharacterModel.Cards
        Get
            Return store.Cards.All.Select(Function(x) New CardModel(x))
        End Get
    End Property

    Public ReadOnly Property Health As Integer Implements ICharacterModel.Health
        Get
            Return Store.Statistics.FromName(STATISTIC_TYPE_HEALTH).Value
        End Get
    End Property

    Public ReadOnly Property MaximumHealth As Integer Implements ICharacterModel.MaximumHealth
        Get
            Return Store.Statistics.FromName(STATISTIC_TYPE_HEALTH).Maximum.Value
        End Get
    End Property

    Public ReadOnly Property Satiety As Integer Implements ICharacterModel.Satiety
        Get
            Return Store.Statistics.FromName(STATISTIC_TYPE_SATIETY).Value
        End Get
    End Property

    Public ReadOnly Property MaximumSatiety As Integer Implements ICharacterModel.MaximumSatiety
        Get
            Return Store.Statistics.FromName(STATISTIC_TYPE_SATIETY).Maximum.Value
        End Get
    End Property

    Public ReadOnly Property Energy As Integer Implements ICharacterModel.Energy
        Get
            Return Store.Statistics.FromName(STATISTIC_TYPE_ENERGY).Value
        End Get
    End Property

    Public ReadOnly Property MaximumEnergy As Integer Implements ICharacterModel.MaximumEnergy
        Get
            Return Store.Statistics.FromName(STATISTIC_TYPE_ENERGY).Maximum.Value
        End Get
    End Property

    Public ReadOnly Property HandSize As Integer Implements ICharacterModel.HandSize
        Get
            Return store.Statistics.FromName(STATISTIC_TYPE_HAND_SIZE).Value
        End Get
    End Property

    Public ReadOnly Property Hand As IEnumerable(Of ICardModel) Implements ICharacterModel.Hand
        Get
            Return store.Cards.Hand.Select(Function(x) New CardModel(x))
        End Get
    End Property

    Public Sub RefreshHand() Implements ICharacterModel.RefreshHand
        DiscardHand()
        DrawHand()
    End Sub

    Private Sub DrawHand()
        For Each dummy In Enumerable.Range(0, HandSize)
            If Not DrawCard() Then
                Exit For
            End If
        Next
    End Sub

    Private Function DrawCard() As Boolean
        If TryDrawCard() Then
            Return True
        End If
        RestockCards()
        Return TryDrawCard()
    End Function

    Private Sub RestockCards()
        Dim cards As IEnumerable(Of ICardStore) = store.Cards.DiscardPile.OrderBy(Function(x) Guid.NewGuid)
        For Each card In cards
            store.Cards.AddToDrawPile(card)
        Next
    End Sub

    Private Function TryDrawCard() As Boolean
        Dim card As ICardStore = store.Cards.TopOfDeck
        If card Is Nothing Then
            Return False
        End If
        card.AddToHand()
        Return True
    End Function

    Private Sub DiscardHand()
        For Each card In store.Cards.Hand
            card.Discard()
        Next
    End Sub

    Public Function UseRoute(route As IRouteModel) As (Result As Boolean, Messages As String()) Implements ICharacterModel.UseRoute
        If route Is Nothing Then
            Return (False, {"The route does not exist!"})
        End If
        If Not route.FromLocation.IsSameAs(Location) Then
            Return (False, {"The route is not available!"})
        End If
        Location = route.ToLocation
        Return (True, Array.Empty(Of String))
    End Function

    Public Sub Die() Implements ICharacterModel.Die
        Dim location = store.Location
        For Each card In store.Cards.All
            card.Delete()
        Next
        For Each statistic In store.Statistics.All
            statistic.Delete()
        Next
        Store.ClearPlayer()
        Store.Delete()
    End Sub

    Public Function HandCardByName(cardName As String) As ICardModel Implements ICharacterModel.HandCardByName
        Dim card = Store.Cards.HandCardByName(cardName)
        If card Is Nothing Then
            Return Nothing
        End If
        Return New CardModel(card)
    End Function

    Public Function Rest() As IEnumerable(Of String) Implements ICharacterModel.Rest
        Dim result As New List(Of String)
        Dim energy = Store.Statistics.FromName(STATISTIC_TYPE_ENERGY)
        If energy.Value >= energy.Maximum Then
            result.Add($"{Store.Name}'s energy is at maximum, so there is no need to rest!")
            Return result
        End If
        Dim satiety = Store.Statistics.FromName(STATISTIC_TYPE_SATIETY)
        If satiety.Value = 0 Then
            Dim health = Store.Statistics.FromName(STATISTIC_TYPE_HEALTH)
            If health.Value <= 1 Then
                result.Add($"{Store.Name} starves to death!")
                Die()
                Return result
            End If
            health.Value -= 1
            result.Add($"-1 {STATISTIC_TYPE_HEALTH}")
        Else
            satiety.Value -= 1
            result.Add($"-1 {STATISTIC_TYPE_SATIETY}")
        End If
        Dim delta = energy.Maximum.Value - energy.Value
        result.Add($"+{delta} {STATISTIC_TYPE_ENERGY}")
        energy.Value = energy.Maximum.Value
        RefreshHand()
        Return result
    End Function
End Class
