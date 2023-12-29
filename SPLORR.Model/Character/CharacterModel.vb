Imports SPLORR.Data

Friend Class CharacterModel
    Implements ICharacterModel
    Private ReadOnly _dataStore As IDataStore 'TODO: change this to characterstore?
    Private ReadOnly _characterId As Integer
    Sub New(dataStore As IDataStore, characterId As Integer)
        _dataStore = dataStore
        _characterId = characterId
    End Sub

    Public Property Name As String Implements ICharacterModel.Name
        Get
            Return _dataStore.GetCharacter(_characterId).Name
        End Get
        Set(value As String)
            _dataStore.GetCharacter(_characterId).Name = value
        End Set
    End Property

    Public ReadOnly Property Location As ILocationModel Implements ICharacterModel.Location
        Get
            Return New LocationModel(_dataStore.GetCharacter(_characterId).GetLocation())
        End Get
    End Property
End Class
