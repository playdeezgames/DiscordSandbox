Imports Shouldly
Imports Xunit

Public Class PlayerModel_should
    <Fact>
    Sub initially_not_have_character()
        Dim subject = CreateSubject()
        subject.Model.HasCharacter.ShouldBeFalse
        subject.Model.Character.ShouldBeNull
        subject.Store.OperationLog.ShouldNotBeEmpty
    End Sub
    <Fact>
    Sub create_character()
        Dim subject = CreateSubject()
        subject.Model.CreateCharacter()
        subject.Model.HasCharacter.ShouldBeTrue
        subject.Model.Character.ShouldNotBeNull
        subject.Store.OperationLog.ShouldNotBeEmpty
    End Sub

    Private Shared Function CreateSubject() As (Model As IPlayerModel, Store As FakeDataStore)
        Const authorId As ULong = 0
        Dim dataStore As New FakeDataStore
        Dim worldModel As IWorldModel = New WorldModel(dataStore)
        Dim subject = worldModel.GetPlayer(authorId)
        Return (subject, dataStore)
    End Function
End Class
