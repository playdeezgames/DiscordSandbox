Public Interface ICardTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    Function CreateCard(store As ICharacterStore) As ICardStore
    Property DeleteOnPlay As Boolean
    Property Generator As ICardTypeGeneratorStore
    Property Location As ILocationStore
End Interface
