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
End Class


