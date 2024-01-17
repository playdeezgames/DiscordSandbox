Public Interface ICharacterTypeCardStore
    Inherits IBaseTypeStore
    Property Quantity As Integer
    ReadOnly Property CharacterType As ICharacterTypeStore
    ReadOnly Property CardType As ICardTypeStore
End Interface
