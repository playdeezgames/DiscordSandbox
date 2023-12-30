Imports System.Text
Imports SPLORR.Model

Friend Module StatusMessage

    Friend Sub Handle(player As IPlayerModel, tokens As String(), outputter As Action(Of String))
        If tokens.Length = 0 Then
            If Not player.HasCharacter Then
                outputter(MESSAGE_NO_CHARACTER)
                Return
            End If
            Dim character = player.Character
            Dim location = character.Location
            outputter($"Character Name: {character.Name}")
            outputter($"Location Name: {location.Name}")
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
            Return
        End If
        outputter(MESSAGE_INVALID_INPUT)
    End Sub

End Module
