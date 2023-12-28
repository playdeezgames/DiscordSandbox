Imports SPLORR.Data
Imports SPLORR.Game

Friend Class PlayerModel
    Implements IPlayerModel
    Const DEFAULT_CHARACTER_NAME = "N00b"
    Private _dataStore As IDataStore
    Private _playerId As Integer

    Public Sub New(dataStore As IDataStore, playerId As Integer)
        Me._dataStore = dataStore
        Me._playerId = playerId
    End Sub

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerModel.HasCharacter
        Get
            Return _dataStore.CheckForCharacter(_playerId)
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterModel Implements IPlayerModel.Character
        Get
            Return If(HasCharacter, New CharacterModel(), Nothing)
        End Get
    End Property

    Public Sub CreateCharacter() Implements IPlayerModel.CreateCharacter
        _dataStore.CreatePlayerCharacter(
            _playerId,
            GenerateCharacterName(),
            GenerateStartingLocation(),
            GenerateCharacterType())
    End Sub

    Private Function GenerateCharacterType() As Integer
        Dim generator As IReadOnlyDictionary(Of Integer, Integer) = _dataStore.GetCharacterTypeGenerator()
        Return RNG.FromGenerator(generator)
    End Function

    Private Function GenerateCharacterName() As String
        Return DEFAULT_CHARACTER_NAME
    End Function

    Private Function GenerateStartingLocation() As Integer
        Dim generator As IReadOnlyDictionary(Of Integer, Integer) = _dataStore.GetLocationGenerator()
        Return RNG.FromGenerator(generator)
    End Function
End Class
