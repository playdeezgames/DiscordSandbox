Public Interface ILocationTypeStore
    Property Name As String
    ReadOnly Property Id As Integer
    ReadOnly Property CanDelete As Boolean
    ReadOnly Property HasLocations As Boolean
    ReadOnly Property HasVerbs As Boolean
    ReadOnly Property CanAddVerb As Boolean
    Sub Delete()
    Function CanRenameTo(name As String) As Boolean
End Interface
