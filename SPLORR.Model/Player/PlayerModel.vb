Imports SPLORR.Data
Imports SPLORR.Game

Friend Class PlayerModel
    Implements IPlayerModel
    Const DEFAULT_CHARACTER_NAME = "N00b"
    Private ReadOnly _playerStore As IPlayerStore

    Public Sub New(playerStore As IPlayerStore)
        _playerStore = playerStore
    End Sub

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerModel.HasCharacter
        Get
            Return _playerStore.HasCharacter
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterModel Implements IPlayerModel.Character
        Get
            Return New CharacterModel(_playerStore.Character)
        End Get
    End Property

    Public Sub CreateCharacter() Implements IPlayerModel.CreateCharacter
        _playerStore.Character = _playerStore.CreateCharacter(
            GenerateCharacterName(),
            GenerateStartingLocation(),
            GenerateCharacterType())
    End Sub

    Private Function GenerateCharacterType() As ICharacterTypeStore
        Dim generator = _playerStore.GetCharacterTypeGenerator()
        Return RNG.FromGenerator(generator)
    End Function

    Private Function GenerateCharacterName() As String
        Return DEFAULT_CHARACTER_NAME
    End Function

    Private Function GenerateStartingLocation() As ILocationStore
        Dim generator = _playerStore.GetLocationGenerator()
        Return RNG.FromGenerator(generator)
    End Function
End Class
