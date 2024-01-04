Public Interface IDataStore
    Sub CleanUp()
    Function CreateVerbType(verbTypeName As String) As IVerbTypeStore
    Function CreateLocationType(locationTypeName As String) As ILocationTypeStore
    Function GetPlayer(playerId As Integer) As IPlayerStore
    Function GetCharacter(characterId As Integer) As ICharacterStore
    Function GetLocation(locationId As Integer) As ILocationStore
    Function GetCharacterType(characterTypeId As Integer) As ICharacterTypeStore
    Function CreateCharacter(characterName As String, location As ILocationStore, characterType As ICharacterTypeStore) As ICharacterStore
    Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer)
    Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer)
    Function GetAuthorPlayer(authorId As ULong) As IPlayerStore
    Function FilterLocationTypes(filter As String) As IEnumerable(Of ILocationTypeStore)
    Function LocationTypeNameExists(locationTypeName As String) As Boolean
    Function GetVerbTypeByName(verbTypeName As String) As IVerbTypeStore
    Function FilterVerbTypes(filter As String) As IEnumerable(Of IVerbTypeStore)
    Function VerbTypeNameExists(verbTypeName As String) As Boolean
    Function FilterItemTypes(filter As String) As IEnumerable(Of IItemTypeStore)
    Function ItemTypeNameExists(itemTypeName As String) As Boolean
    Function CreateItemType(itemTypeName As String) As IItemTypeStore
    Function FilterItemTypeGenerators(filter As String) As IEnumerable(Of IItemTypeGeneratorStore)
    Function ItemTypeGeneratorNameExists(name As String) As Boolean
    Function CreateItemTypeGenerator(name As String) As IItemTypeGeneratorStore
End Interface
