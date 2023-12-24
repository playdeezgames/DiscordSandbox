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
        <Fact>
        Sub handle_message()
            Const authorId As ULong = 0
            Const message As String = ""
            Dim subject As IBot = New SPLORRBot()
            Dim actual = subject.HandleMessage(authorId, message)
            actual.ShouldBe("")
        End Sub
    End Class
End Namespace

