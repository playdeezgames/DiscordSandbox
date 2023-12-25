Public Class WorldModel
    Implements IWorldModel

    Public Sub Initialize() Implements IWorldModel.Initialize
    End Sub

    Public Sub CleanUp() Implements IWorldModel.CleanUp
    End Sub

    Public Function GetPlayer(authorId As ULong) As IPlayerModel Implements IWorldModel.GetPlayer
        Throw New NotImplementedException()
    End Function
End Class
