Public Interface ICardTypeTagStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property CardType As ICardTypeStore
End Interface
