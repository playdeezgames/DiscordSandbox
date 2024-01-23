Public Interface ICardTypeGeneratorCardTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    Property GeneratorWeight As Integer
    ReadOnly Property Generator As ICardTypeGeneratorStore
    ReadOnly Property CardType As ICardTypeStore
End Interface
