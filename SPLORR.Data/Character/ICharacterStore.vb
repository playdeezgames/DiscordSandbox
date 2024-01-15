Public Interface ICharacterStore
    Inherits IBaseTypeStore
    ReadOnly Property Location As ILocationStore
    Sub SetLocation(location As ILocationStore, lastModified As DateTimeOffset)
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterStore)
    ReadOnly Property Inventory As IInventoryStore
    Property CharacterType As ICharacterTypeStore
    ReadOnly Property Cards As IRelatedTypeStore(Of ICardStore)
End Interface
