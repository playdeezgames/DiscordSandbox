Public Interface IPlayerStore
    ReadOnly Property HasCharacter As Boolean
    Function CreateCharacter(characterName As String, location As ILocationStore, characterType As ICharacterTypeStore) As ICharacterStore
End Interface
