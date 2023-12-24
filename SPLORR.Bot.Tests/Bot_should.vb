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
        <Theory>
        <InlineData(0, "", "OHAI!")>
        <InlineData(0, "status", "TODO: give you yer status!")>
        Sub handle_message(authorId As ULong, message As String, expectedMessage As String)
            Dim subject As IBot = New SPLORRBot()
            Dim actual = subject.HandleMessage(authorId, message)
            actual.ShouldBe(expectedMessage)
        End Sub
    End Class
End Namespace

