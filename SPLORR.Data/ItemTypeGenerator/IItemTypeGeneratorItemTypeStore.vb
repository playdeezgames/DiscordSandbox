Public Interface IItemTypeGeneratorItemTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property ItemType As IItemTypeStore
    ReadOnly Property ItemTypeGenerator As IItemTypeGeneratorStore
    Property GeneratorWeight As Integer
End Interface
