Imports DiscordSandbox
Imports Shouldly
Imports Xunit

Public Class MainProcessor_should
    <Fact>
    Sub give_invalid_command_when_command_is_invalid()
        Dim actual = MainProcessor.Process(Nothing, 0, Array.Empty(Of String))
        actual.ShouldBe("Invalid Input!")
    End Sub
End Class


