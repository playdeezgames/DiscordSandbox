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
End Interface
