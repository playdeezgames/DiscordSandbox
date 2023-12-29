Public Interface ICharacterStore
    ReadOnly Property Id As Integer
    Function GetLocation() As ILocationStore
End Interface
