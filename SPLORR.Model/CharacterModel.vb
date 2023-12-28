Imports SPLORR.Data

Friend Class CharacterModel
    Implements ICharacterModel
    Private ReadOnly _dataStore As IDataStore
    Private ReadOnly _characterId As Integer
    Sub New(dataStore As IDataStore, characterId As Integer)
        _dataStore = dataStore
        _characterId = characterId
    End Sub

    Public Property Name As String Implements ICharacterModel.Name
        Get
            Return _dataStore.LegacyGetCharacterName(_characterId)
        End Get
        Set(value As String)
            _dataStore.LegacySetCharacterName(_characterId, value)
        End Set
    End Property
End Class
