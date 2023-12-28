Imports SPLORR.Data

Friend Class CharacterModel
    Implements ICharacterModel
    Private ReadOnly _dataStore As IDataStore
    Private ReadOnly _characterId As Integer
    Sub New(dataStore As IDataStore, characterId As Integer)
        _dataStore = dataStore
        _characterId = characterId
    End Sub

    Public Property Name As String = "N00b" Implements ICharacterModel.Name
End Class
