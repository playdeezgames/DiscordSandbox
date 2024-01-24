Imports SPLORR.Model

Friend Module StatusMessage

    Friend Sub Handle(player As IPlayerModel, tokens As String(), outputter As Action(Of String))
        WithNoTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                player,
                outputter,
                Sub(character)
                    Dim location = character.Location
                    outputter($"Character Name: {character.Name}")
                    outputter($"Location Name: {location.Name}")
                    If character.HasOtherCharacters Then
                        outputter($"Other Characters:")
                        For Each otherCharacter In character.OtherCharacters
                            outputter($"- {otherCharacter.Name}")
                        Next
                    End If
                End Sub)
            End Sub)
    End Sub

End Module
