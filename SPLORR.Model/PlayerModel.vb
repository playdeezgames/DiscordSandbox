Imports SPLORR.Data

Friend Class PlayerModel
    Implements IPlayerModel
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
        _dataStore.CreatePlayerCharacter(_playerId)
    End Sub
End Class
