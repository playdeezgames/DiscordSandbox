Public Interface IVerbTypeStore
    ReadOnly Property Id As Integer
    Property Name As String
    ReadOnly Property CanDelete As Boolean
    Sub Delete()
    Function CanRenameTo(newName As String) As Boolean
End Interface
