Imports Shouldly
Imports Xunit

Public Class PlayerModel_should
    <Fact>
    Sub initially_not_have_character()
        Dim subject As IPlayerModel = CreateSubject()
        subject.HasCharacter.ShouldBeFalse
    End Sub
    <Fact>
    Sub create_character()
        Dim subject As IPlayerModel = CreateSubject()
        subject.CreateCharacter()
        subject.HasCharacter.ShouldBeTrue
    End Sub

    Private Shared Function CreateSubject() As IPlayerModel
        Const authorId As ULong = 0
        Dim worldModel As IWorldModel = New WorldModel()
        Dim subject = worldModel.GetPlayer(authorId)
        Return subject
    End Function
End Class
