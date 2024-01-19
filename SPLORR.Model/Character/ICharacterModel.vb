Imports SPLORR.Data

Public Interface ICharacterModel
    Property Name As String
    Property Location As ILocationModel
    ReadOnly Property Inventory As IInventoryModel
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterModel)
    Function UseRoute(route As IRouteModel) As (Result As Boolean, Messages As String())
    Function FindRecipeByName(recipeName As String) As IRecipeModel
    Function CanCraft(recipe As IRecipeModel) As Boolean
    Function Craft(recipe As IRecipeModel) As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeModel))
    Sub RefreshHand()
    Sub Die()
    Function HandCardByName(cardName As String) As ICardModel
    Function CanPlay(card As ICardModel) As Boolean
    Function Play(card As ICardModel) As IEnumerable(Of String)
    ReadOnly Property Cards As IEnumerable(Of ICardModel)
    ReadOnly Property Hand As IEnumerable(Of ICardModel)
    ReadOnly Property Health As Integer
    ReadOnly Property MaximumHealth As Integer
    ReadOnly Property Satiety As Integer
    ReadOnly Property MaximumSatiety As Integer
    ReadOnly Property Energy As Integer
    ReadOnly Property MaximumEnergy As Integer
    ReadOnly Property HandSize As Integer
    ReadOnly Property Store As ICharacterStore
End Interface
