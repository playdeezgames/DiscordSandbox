Imports Xunit
Imports Shouldly

Namespace SPLORR.Bot.Tests
    Public Class Bot_should
        <Fact>
        Sub start()
            Dim subject As IBot = New SPLORRBot()
            subject.Start()
        End Sub
        <Fact>
        Sub [stop]()
            Dim subject As IBot = New SPLORRBot()
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
            Dim subject As IBot = New SPLORRBot()
            Dim actual = subject.HandleMessage(authorId, message)
            actual.ShouldBe(expectedMessage)
        End Sub
    End Class
End Namespace

