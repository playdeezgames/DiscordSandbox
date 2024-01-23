Public Interface IBaseTypeStore(Of TStore)
    ReadOnly Property Id As Integer
    Property Name As String
    ReadOnly Property CanDelete As Boolean
    ReadOnly Property Store As TStore
    Sub Delete()
    Function CanRenameTo(newName As String) As Boolean
End Interface
