Public Interface IInventoryStore
    ReadOnly Property Id As Integer
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IRelatedTypeStore(Of IItemStore)
    Function ItemsByName(itemName As String) As IEnumerable(Of IItemStore)
    Sub Delete()
    Function ItemTypeCount(itemType As IItemTypeStore) As Integer
    Function ItemsByType(itemType As IItemTypeStore) As IEnumerable(Of IItemStore)
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property Character As ICharacterStore
    ReadOnly Property Location As ILocationStore
    ReadOnly Property CanDelete As Boolean
    ReadOnly Property Store As IDataStore
End Interface
