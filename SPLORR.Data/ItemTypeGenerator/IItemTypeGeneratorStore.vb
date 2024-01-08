Public Interface IItemTypeGeneratorStore
    Inherits IBaseTypeStore

    ReadOnly Property TotalWeight As Integer
    ReadOnly Property HasItemTypes As Boolean
    ReadOnly Property CanAddItemType As Boolean
    Function Generate(generated As Integer) As IItemTypeStore
    Sub AddItemType(itemType As IItemTypeStore, quantity As Integer)
    ReadOnly Property ItemTypes As ITypeStore(Of IItemTypeGeneratorItemTypeStore)
    ReadOnly Property AvailableItemTypes As ITypeStore(Of IItemTypeStore)
End Interface
