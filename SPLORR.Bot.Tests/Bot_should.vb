Imports Shouldly
Imports Xunit

Namespace SPLORR.Bot.Tests
    Public Class Bot_should
        <Fact>
        Sub have_a_blank_initial_state()
            Dim worldModel As FakeWorldModel = New FakeWorldModel
            Dim subject As IBot = New SPLORRBot(worldModel)
            worldModel.InitializeCalled.ShouldBeFalse
            worldModel.CleanUpCalled.ShouldBeFalse
        End Sub
        <Fact>
        Sub start()
            Dim worldModel As FakeWorldModel = New FakeWorldModel
            Dim subject As IBot = New SPLORRBot(worldModel)
            subject.Start()
            worldModel.InitializeCalled.ShouldBeTrue
            worldModel.CleanUpCalled.ShouldBeFalse
        End Sub
        <Fact>
        Sub [stop]()
            Dim worldModel As FakeWorldModel = New FakeWorldModel
            Dim subject As IBot = New SPLORRBot(worldModel)
            subject.Stop()
            worldModel.InitializeCalled.ShouldBeFalse
            worldModel.CleanUpCalled.ShouldBeTrue
        End Sub
        Const NO_CHARACTER_RESULT = "You have no character!"
        Const INVALID_INPUT_RESULT = "Invalid input!"
        <Theory>
        <InlineData(0, "", INVALID_INPUT_RESULT)>
        <InlineData(0, "status", NO_CHARACTER_RESULT)>
        <InlineData(0, "Status", NO_CHARACTER_RESULT)>
        <InlineData(0, "statuS", NO_CHARACTER_RESULT)>
        <InlineData(0, "STATUS", NO_CHARACTER_RESULT)>
        <InlineData(0, "status asdflkasdkfjal", INVALID_INPUT_RESULT)>
        Sub handle_message(authorId As ULong, message As String, expectedMessage As String)
            Dim worldModel As FakeWorldModel = New FakeWorldModel()
            Dim subject As IBot = New SPLORRBot(worldModel)

            Dim actual = subject.HandleMessage(authorId, message)
            actual.ShouldBe(expectedMessage)

            worldModel.FakePlayers.ShouldHaveSingleItem
        End Sub
    End Class
End Namespace

