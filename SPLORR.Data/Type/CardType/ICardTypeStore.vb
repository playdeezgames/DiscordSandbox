Public Interface ICardTypeStore
    Inherits IBaseTypeStore
    Function CreateCard(store As ICharacterStore) As ICardStore
End Interface
