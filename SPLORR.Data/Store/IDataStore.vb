Public Interface IDataStore
    Sub CleanUp()
    'Verb Type
    ReadOnly Property VerbTypes As ITypeStore(Of IVerbTypeStore)
    Function CreateVerbType(verbTypeName As String) As IVerbTypeStore
    Function GetVerbTypeByName(verbTypeName As String) As IVerbTypeStore
    Function FilterVerbTypes(filter As String) As IEnumerable(Of IVerbTypeStore)
    Function VerbTypeNameExists(verbTypeName As String) As Boolean

    'Location Type
    Function CreateLocationType(locationTypeName As String) As ILocationTypeStore
    Function FilterLocationTypes(filter As String) As IEnumerable(Of ILocationTypeStore)
    Function LocationTypeNameExists(locationTypeName As String) As Boolean

    'Item Type
    Function CreateItemType(itemTypeName As String) As IItemTypeStore
    Function FilterItemTypes(filter As String) As IEnumerable(Of IItemTypeStore)
    Function ItemTypeNameExists(itemTypeName As String) As Boolean

    'Item Type Generator
    Function CreateItemTypeGenerator(name As String) As IItemTypeGeneratorStore
    Function FilterItemTypeGenerators(filter As String) As IEnumerable(Of IItemTypeGeneratorStore)
    Function ItemTypeGeneratorNameExists(name As String) As Boolean

    'Character Type
    Function GetCharacterType(characterTypeId As Integer) As ICharacterTypeStore

    'Player
    Function GetPlayer(playerId As Integer) As IPlayerStore
    Function GetAuthorPlayer(authorId As ULong) As IPlayerStore

    'Character
    Function GetCharacter(characterId As Integer) As ICharacterStore
    Function CreateCharacter(characterName As String, location As ILocationStore, characterType As ICharacterTypeStore) As ICharacterStore

    'Location
    Function GetLocation(locationId As Integer) As ILocationStore

    'Character Type Generator
    Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer)

    'Location Generator
    Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer)
End Interface
