Public Interface IRelatedTypeStore(Of TTypeStore)
    Function Filter(textFilter As String) As IEnumerable(Of TTypeStore)
End Interface
