Public Interface IItemTypeGeneratorStore
    Inherits IBaseTypeStore

    ReadOnly Property TotalWeight As Integer
    Function Generate(generated As Integer) As IItemTypeStore
End Interface
