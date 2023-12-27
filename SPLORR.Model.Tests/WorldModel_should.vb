Imports Shouldly
Imports Xunit
Public Class WorldModel_should
    <Fact>
    Sub initialize()
        Dim subject = CreateSubject()
        subject.Model.Initialize()
    End Sub

    Private Shared Function CreateSubject() As (Model As IWorldModel, Store As FakeDataStore)
        Dim dataStore As New FakeDataStore
        Dim subject As IWorldModel = New WorldModel(dataStore)
        Return (subject, dataStore)
    End Function

    <Fact>
    Sub clean_up()
        Dim subject = CreateSubject()

        subject.Model.CleanUp()
    End Sub
    <Fact>
    Sub find_or_create_player()
        Const authorId As ULong = 0
        Dim subject = CreateSubject()

        Dim actual = subject.Model.GetPlayer(authorId)
        actual.ShouldNotBeNull
    End Sub
End Class


