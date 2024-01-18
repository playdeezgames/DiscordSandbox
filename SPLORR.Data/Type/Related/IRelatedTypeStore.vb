Public Interface IRelatedTypeStore(Of TTypeStore)
    Function Filter(textFilter As String) As IEnumerable(Of TTypeStore)
    Function FromName(name As String) As TTypeStore
End Interface
