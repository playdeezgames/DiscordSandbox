Public Interface ICharacterStore
    ReadOnly Property Id As Integer
    Function GetLocation() As ILocationStore
    Sub SetLocation(location As ILocationStore)
    Property Name As String
End Interface
