Public Interface IInventoryStore
    ReadOnly Property Id As Integer
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IRelatedTypeStore(Of IItemStore)
    Function ItemsByName(itemName As String) As IEnumerable(Of IItemStore)
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property Character As ICharacterStore
    ReadOnly Property Location As ILocationStore
End Interface
