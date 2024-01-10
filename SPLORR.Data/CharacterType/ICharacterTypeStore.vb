Public Interface ICharacterTypeStore
    Inherits IBaseTypeStore
    Function CreateCharacter(name As String, location As ILocationStore) As ICharacterStore
End Interface
