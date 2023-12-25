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
        Const STATUS_RESULT = "You have no character!"
        <Theory>
        <InlineData(0, "", "Invalid input!")>
        <InlineData(0, "status", STATUS_RESULT)>
        <InlineData(0, "Status", STATUS_RESULT)>
        <InlineData(0, "statuS", STATUS_RESULT)>
        <InlineData(0, "STATUS", STATUS_RESULT)>
        <InlineData(0, "status asdflkasdkfjal", "Invalid input!")>
        Sub handle_message(authorId As ULong, message As String, expectedMessage As String)
            Dim worldModel As FakeWorldModel = New FakeWorldModel
            Dim subject As IBot = New SPLORRBot(worldModel)
            Dim actual = subject.HandleMessage(authorId, message)
            actual.ShouldBe(expectedMessage)
        End Sub
    End Class
End Namespace

