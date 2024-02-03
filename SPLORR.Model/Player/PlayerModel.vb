Imports SPLORR.Data
Imports SPLORR.Game

Friend Class PlayerModel
    Implements IPlayerModel
    Const DEFAULT_CHARACTER_NAME = "N00b"
    Private ReadOnly store As IPlayerStore

    Public Sub New(playerStore As IPlayerStore)
        store = playerStore
    End Sub

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerModel.HasCharacter
        Get
            Return store.HasCharacter
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterModel Implements IPlayerModel.Character
        Get
            Return New CharacterModel(store.Character)
        End Get
    End Property

    Public Sub CreateCharacter(Optional characterTypeModel As ICharacterTypeModel = Nothing) Implements IPlayerModel.CreateCharacter
        Dim characterTypeStore = If(characterTypeModel Is Nothing, GenerateCharacterType(), characterTypeModel.Store)
        Dim character = store.CreateCharacter(
            GenerateCharacterName(),
            GenerateStartingLocation(),
            characterTypeStore,
            characterTypeStore.Statistics.Filter("%").ToDictionary(Function(x) x.StatisticType, Function(x) (x.Value, x.Minimum, x.Maximum)))
        store.Character = character
        For Each entry In characterTypeStore.Cards.Filter("%")
            For Each dummy In Enumerable.Range(0, entry.Quantity)
                entry.CardType.CreateCard(character)
            Next
        Next
        Dim characterModel As ICharacterModel = New CharacterModel(character)
        characterModel.RefreshHand()
    End Sub

    Public Function FindSelectableCharacterType(characterTypeName As String) As ICharacterTypeModel Implements IPlayerModel.FindSelectableCharacterType
        Dim characterTypeStore = store.Store.CharacterTypes.Filter(characterTypeName).FirstOrDefault
        If characterTypeStore IsNot Nothing AndAlso characterTypeStore.IsPlayerSelectable Then
            Return New CharacterTypeModel(characterTypeStore)
        End If
        Return Nothing
    End Function

    Private Function GenerateCharacterType() As ICharacterTypeStore
        Dim generator = store.GetCharacterTypeGenerator()
        Return RNG.FromGenerator(generator)
    End Function

    Private Function GenerateCharacterName() As String
        Return DEFAULT_CHARACTER_NAME
    End Function

    Private Function GenerateStartingLocation() As ILocationStore
        Dim generator = store.GetLocationGenerator()
        Return RNG.FromGenerator(generator)
    End Function
End Class
