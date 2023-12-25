Imports Xunit
Imports Shouldly
Imports SPLORR.Model

Namespace SPLORR.Bot.Tests
    Public Class Bot_should
        <Fact>
        Sub start()
            Dim worldModel As IWorldModel = Nothing
            Dim subject As IBot = New SPLORRBot(worldModel)
            subject.Start()
        End Sub
        <Fact>
        Sub [stop]()
            Dim worldModel As IWorldModel = Nothing
            Dim subject As IBot = New SPLORRBot(worldModel)
            subject.Stop()
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
            Dim worldModel As IWorldModel = Nothing
            Dim subject As IBot = New SPLORRBot(worldModel)
            Dim actual = subject.HandleMessage(authorId, message)
            actual.ShouldBe(expectedMessage)
        End Sub
    End Class
End Namespace

