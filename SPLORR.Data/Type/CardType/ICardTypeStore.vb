Public Interface ICardTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    Function CreateCard(store As ICharacterStore) As ICardStore
    ReadOnly Property SelfDestructs As Boolean
End Interface
