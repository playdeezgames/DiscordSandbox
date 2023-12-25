Imports Shouldly
Imports Xunit
Public Class WorldModel_should
    <Fact>
    Sub initialize()
        Dim subject As IWorldModel = New WorldModel

        subject.Initialize()
    End Sub
    <Fact>
    Sub clean_up()
        Dim subject As IWorldModel = New WorldModel

        subject.CleanUp()
    End Sub
    <Fact>
    Sub find_or_create_player()
        Const authorId As ULong = 0
        Dim subject As IWorldModel = New WorldModel

        Dim actual = subject.GetPlayer(authorId)
        actual.ShouldNotBeNull
    End Sub
End Class


