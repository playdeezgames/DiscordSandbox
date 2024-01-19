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

    Public Sub CreateCharacter() Implements IPlayerModel.CreateCharacter
        Dim characterType = GenerateCharacterType()
        Dim character = store.CreateCharacter(
            GenerateCharacterName(),
            GenerateStartingLocation(),
            characterType,
            characterType.Statistics.Filter("%").ToDictionary(Function(x) x.StatisticType, Function(x) (x.Value, x.Minimum, x.Maximum)))
        store.Character = character
        For Each entry In characterType.Cards.Filter("%")
            For Each dummy In Enumerable.Range(0, entry.Quantity)
                entry.CardType.CreateCard(character)
            Next
        Next
        Dim characterModel As ICharacterModel = New CharacterModel(character)
        characterModel.RefreshHand()
    End Sub

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
