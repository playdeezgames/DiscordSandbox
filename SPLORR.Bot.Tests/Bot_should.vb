Imports Xunit

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
    End Class
End Namespace

