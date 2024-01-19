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

    Public ReadOnly Property Inventory As IInventoryModel Implements ICharacterModel.Inventory
        Get
            Return New InventoryModel(store)
        End Get
    End Property

    Public ReadOnly Property Cards As IEnumerable(Of ICardModel) Implements ICharacterModel.Cards
        Get
            Return store.Cards.All.Select(Function(x) New CardModel(x))
        End Get
    End Property

    Public ReadOnly Property Health As Integer Implements ICharacterModel.Health
        Get
            Return MaximumHealth - store.Statistics.FromName(STATISTIC_TYPE_WOUNDS).Value
        End Get
    End Property

    Public ReadOnly Property MaximumHealth As Integer Implements ICharacterModel.MaximumHealth
        Get
            Return store.Statistics.FromName(STATISTIC_TYPE_HEALTH).Value
        End Get
    End Property

    Public ReadOnly Property Satiety As Integer Implements ICharacterModel.Satiety
        Get
            Return MaximumSatiety - store.Statistics.FromName(STATISTIC_TYPE_HUNGER).Value
        End Get
    End Property

    Public ReadOnly Property MaximumSatiety As Integer Implements ICharacterModel.MaximumSatiety
        Get
            Return store.Statistics.FromName(STATISTIC_TYPE_SATIETY).Value
        End Get
    End Property

    Public ReadOnly Property Energy As Integer Implements ICharacterModel.Energy
        Get
            Return MaximumEnergy - store.Statistics.FromName(STATISTIC_TYPE_FATIGUE).Value
        End Get
    End Property

    Public ReadOnly Property MaximumEnergy As Integer Implements ICharacterModel.MaximumEnergy
        Get
            Return store.Statistics.FromName(STATISTIC_TYPE_ENERGY).Value
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

    Public Function FindRecipeByName(recipeName As String) As IRecipeModel Implements ICharacterModel.FindRecipeByName
        Dim recipe = store.Store.Recipes.Filter(recipeName).FirstOrDefault
        If recipe Is Nothing Then
            Return Nothing
        End If
        Return New RecipeModel(recipe)
    End Function

    Public Function CanCraft(recipe As IRecipeModel) As Boolean Implements ICharacterModel.CanCraft
        Dim inputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore)) = recipe.Store.Inputs
        Return inputs.All(Function(x) store.Inventory.ItemTypeCount(x.ItemType) >= x.Quantity)
    End Function

    Public Function Craft(recipe As IRecipeModel) As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeModel)) Implements ICharacterModel.Craft
        If Not CanCraft(recipe) Then
            Return Array.Empty(Of (Quantity As Integer, Item As IItemTypeModel))
        End If
        Dim inputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore)) = recipe.Store.Inputs
        Dim outputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore)) = recipe.Store.Outputs
        Dim deltas As New Dictionary(Of IItemTypeStore, Integer)
        For Each itemOut In outputs
            deltas(itemOut.ItemType) = itemOut.Quantity
        Next
        For Each itemIn In inputs
            Dim itemType = itemIn.ItemType
            If Not deltas.ContainsKey(itemType) Then
                deltas(itemType) = 0
            End If
            deltas(itemType) -= itemIn.Quantity
        Next
        For Each entry In deltas
            Dim removeCount = -Math.Min(entry.Value, 0)
            Dim createCount = Math.Max(entry.Value, 0)
            For Each dummy In Enumerable.Range(1, createCount)
                entry.Key.CreateItem(store.Inventory)
            Next
            Dim items As IEnumerable(Of IItemStore) = store.Inventory.ItemsByType(entry.Key).Take(removeCount)
            For Each item In items
                item.Delete()
            Next
        Next
        Return deltas.Select(Function(x)
                                 Dim result As (Quantity As Integer, ItemType As IItemTypeModel) = (x.Value, New ItemTypeModel(x.Key))
                                 Return result
                             End Function)
    End Function

    Public Sub Die() Implements ICharacterModel.Die
        Dim location = store.Location
        For Each card In store.Cards.All
            card.Delete()
        Next
        For Each statistic In store.Statistics.All
            statistic.Delete()
        Next
        For Each item In store.Inventory.Items.All
            item.Inventory = location.Inventory
        Next
        store.Inventory.Delete()
        store.ClearPlayer()
        store.Delete()
    End Sub

    Public Function HandCardByName(cardName As String) As ICardModel Implements ICharacterModel.HandCardByName
        Return New CardModel(store.Cards.HandCardByName(cardName))
    End Function

    Public Function CanPlay(card As ICardModel) As Boolean Implements ICharacterModel.CanPlay
        If Not card.Character.Store.Id = store.Id Then
            Return False
        End If
        If Not card.InHand Then
            Return False
        End If
        Return True
    End Function

    Public Function Play(card As ICardModel) As IEnumerable(Of String) Implements ICharacterModel.Play
        Dim result As New List(Of String)
        card.Discard()
        Return result
    End Function
End Class
