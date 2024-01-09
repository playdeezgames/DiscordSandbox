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
                    If location.Inventory.HasItems Then
                        outputter($"There is stuff on the ground.")
                    End If
                    If location.HasRoutes Then
                        outputter($"Exits:")
                        For Each route In location.Routes
                            outputter($"- {route.RouteType.Name} going {route.Direction.Name}")
                        Next
                    End If
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
