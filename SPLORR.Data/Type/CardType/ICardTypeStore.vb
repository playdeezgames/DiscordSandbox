Public Interface ICardTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    Function CanCreateCard(character As ICharacterStore) As Boolean
    Function CreateCard(character As ICharacterStore) As ICardStore
    ReadOnly Property SelfDestructs As Boolean
    ReadOnly Property CardLimit As Integer?
End Interface
