Public Interface ICardTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    Function CreateCard(store As ICharacterStore) As ICardStore
End Interface
