Imports SPLORR.Data

Friend Class PlayerModel
    Implements IPlayerModel
    Private _dataStore As IDataStore
    Private _authorId As ULong
    Private _playerId As Integer

    Public Sub New(dataStore As IDataStore, authorId As ULong, playerId As Integer)
        Me._dataStore = dataStore
        Me._authorId = authorId
        Me._playerId = playerId
    End Sub

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerModel.HasCharacter
        Get
            Return _dataStore.CheckForCharacter(_authorId)
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterModel Implements IPlayerModel.Character
        Get
            Return If(HasCharacter, New CharacterModel(), Nothing)
        End Get
    End Property

    Public Sub CreateCharacter() Implements IPlayerModel.CreateCharacter
        _dataStore.CreateCharacter(_authorId)
    End Sub
End Class
