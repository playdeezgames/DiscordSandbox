Public Interface IDataStore
    Sub CleanUp()
    ReadOnly Property Characters As ITypeStore(Of ICharacterStore)
    ReadOnly Property Items As ITypeStore(Of IItemStore)
    ReadOnly Property Locations As ITypeStore(Of ILocationStore)
    ReadOnly Property CharacterTypes As ITypeStore(Of ICharacterTypeStore)
    ReadOnly Property Recipes As ITypeStore(Of IRecipeStore)
    ReadOnly Property RouteTypes As ITypeStore(Of IRouteTypeStore)
    ReadOnly Property StatisticTypes As ITypeStore(Of IStatisticTypeStore)
    ReadOnly Property Directions As ITypeStore(Of IDirectionStore)
    'Location Type
    ReadOnly Property LocationTypes As ITypeStore(Of ILocationTypeStore)
    'Item Type
    ReadOnly Property ItemTypes As ITypeStore(Of IItemTypeStore)
    'Item Type Generator
    ReadOnly Property ItemTypeGenerators As ITypeStore(Of IItemTypeGeneratorStore)

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
