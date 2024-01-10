Public Interface ITypeStore(Of TTypeStore)
    Inherits IRelatedTypeStore(Of TTypeStore)
    Function Create(name As String) As TTypeStore
    Function NameExists(name As String) As Boolean
    Function FromName(name As String) As TTypeStore
End Interface
