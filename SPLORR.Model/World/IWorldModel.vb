Public Interface IWorldModel
    Sub Initialize()
    Sub CleanUp()
    Function GetPlayer(authorId As ULong) As IPlayerModel
End Interface
