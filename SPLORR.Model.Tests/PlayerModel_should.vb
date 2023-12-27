Imports Shouldly
Imports Xunit

Public Class PlayerModel_should
    <Fact>
    Sub initially_not_have_character()
        Const authorId As ULong = 0
        Dim worldModel As IWorldModel = New WorldModel()
        Dim subject = worldModel.GetPlayer(authorId)
        subject.HasCharacter.ShouldBeFalse
    End Sub
End Class
