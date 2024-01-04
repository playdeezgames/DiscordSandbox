Public Interface ITypeStore(Of TTypeStore)
    Function Create(name As String) As TTypeStore
    Function Filter(textFilter As String) As IEnumerable(Of TTypeStore)
    Function NameExists(name As String) As Boolean
End Interface
