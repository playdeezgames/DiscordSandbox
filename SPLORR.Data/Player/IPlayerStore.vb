Public Interface IPlayerStore
    ReadOnly Property HasCharacter As Boolean
    Function CreateCharacter(characterName As String, location As ILocationStore, characterType As ICharacterTypeStore) As ICharacterStore
    Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer)
    Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer)
    Property Character As ICharacterStore
    Function GetVerbTypeByName(verbTypeName As String) As IVerbTypeStore
End Interface
