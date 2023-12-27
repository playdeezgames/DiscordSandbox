Imports Shouldly
Imports Xunit
Public Class WorldModel_should
    <Fact>
    Sub initialize()
        Dim subject As IWorldModel = CreateSubject()
        subject.Initialize()
    End Sub

    Private Shared Function CreateSubject() As IWorldModel
        Dim dataStore As New FakeDataStore
        Dim subject As IWorldModel = New WorldModel(dataStore)
        Return subject
    End Function

    <Fact>
    Sub clean_up()
        Dim subject As IWorldModel = CreateSubject()

        subject.CleanUp()
    End Sub
    <Fact>
    Sub find_or_create_player()
        Const authorId As ULong = 0
        Dim subject As IWorldModel = CreateSubject()

        Dim actual = subject.GetPlayer(authorId)
        actual.ShouldNotBeNull
    End Sub
End Class


