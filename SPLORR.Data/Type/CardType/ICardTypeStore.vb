Public Interface ICardTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    Function CreateCard(store As ICharacterStore) As ICardStore
    ReadOnly Property Requirements As IEnumerable(Of ICardTypeStatisticRequirementStore)
    ReadOnly Property SelfDestructs As Boolean
End Interface
