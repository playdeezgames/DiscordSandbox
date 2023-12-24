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
            Dim subject As IBot = New SPLORRBot()
            Dim actual = subject.HandleMessage()
            actual.ShouldBe("")
        End Sub
    End Class
End Namespace

