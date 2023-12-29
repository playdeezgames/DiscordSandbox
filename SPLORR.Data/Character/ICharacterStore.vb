Public Interface ICharacterStore
    ReadOnly Property Id As Integer
    Function GetLocation() As ILocationStore
    Property Name As String
End Interface
