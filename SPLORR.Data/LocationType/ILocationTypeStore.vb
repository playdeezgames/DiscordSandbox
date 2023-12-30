Public Interface ILocationTypeStore
    ReadOnly Property Name As String
    ReadOnly Property Id As Integer
    ReadOnly Property CanDelete As Boolean
    Sub Delete()
End Interface
