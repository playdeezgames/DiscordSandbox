Imports SPLORR.Data

Public Class WorldModel
    Implements IWorldModel
    Sub New(dataStore As IDataStore)

    End Sub

    Public Sub Initialize() Implements IWorldModel.Initialize
    End Sub

    Public Sub CleanUp() Implements IWorldModel.CleanUp
    End Sub

    Public Function GetPlayer(authorId As ULong) As IPlayerModel Implements IWorldModel.GetPlayer
        Return New PlayerModel
    End Function
End Class
