Imports SPLORR.Data

Public Class WorldModel
    Implements IWorldModel
    Private _dataStore As IDataStore
    Sub New(dataStore As IDataStore)
        _dataStore = dataStore
    End Sub

    Public Sub Initialize() Implements IWorldModel.Initialize
    End Sub

    Public Sub CleanUp() Implements IWorldModel.CleanUp
    End Sub

    Public Function GetPlayer(authorId As ULong) As IPlayerModel Implements IWorldModel.GetPlayer
        Dim playerId = _dataStore.GetPlayerForAuthor(authorId)
        Return New PlayerModel(_dataStore, authorId, playerId)
    End Function
End Class
