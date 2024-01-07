Public Interface IItemTypeGeneratorStore
    Inherits IBaseTypeStore

    ReadOnly Property TotalWeight As Integer
    ReadOnly Property HasItemTypes As Boolean
    ReadOnly Property CanAddItemType As Boolean
    Function Generate(generated As Integer) As IItemTypeStore
    ReadOnly Property ItemTypes As ITypeStore(Of IItemTypeGeneratorItemTypeStore)
End Interface
