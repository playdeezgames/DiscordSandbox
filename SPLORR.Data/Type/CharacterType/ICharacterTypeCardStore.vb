Public Interface ICharacterTypeCardStore
    Inherits IBaseTypeStore(Of IDataStore)
    Property Quantity As Integer
    ReadOnly Property CharacterType As ICharacterTypeStore
    ReadOnly Property CardType As ICardTypeStore
End Interface
