Public Interface IDataStore
    Sub CleanUp()
    Function GetPlayer(playerId As Integer) As IPlayerStore
    Function GetCharacter(characterId As Integer) As ICharacterStore
    Function GetLocation(locationId As Integer) As ILocationStore
    Function GetCharacterType(characterTypeId As Integer) As ICharacterTypeStore
    Function CreateCharacter(characterName As String, location As ILocationStore, characterType As ICharacterTypeStore) As ICharacterStore
    Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer)
    Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer)
    Function GetAuthorPlayer(authorId As ULong) As IPlayerStore
    Function FilterLocationTypes(filter As String) As IEnumerable(Of ILocationTypeStore)
End Interface
