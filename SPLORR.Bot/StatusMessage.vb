Imports System.Text
Imports SPLORR.Model

Friend Module StatusMessage

    Friend Function Handle(player As IPlayerModel, tokens As String()) As String
        If tokens.Length = 0 Then
            If Not player.HasCharacter Then
                Return MESSAGE_NO_CHARACTER
            End If
            Dim character = player.Character
            Dim location = character.Location
            Dim builder As New StringBuilder
            builder.AppendLine($"Character Name: {character.Name}")
            builder.AppendLine($"Location Name: {location.Name}")
            If location.HasRoutes Then
                builder.AppendLine($"Exits:")
                For Each route In location.Routes
                    builder.AppendLine($"- {route.RouteType.Name} going {route.Direction.Name}")
                Next
            End If
            Return builder.ToString
        End If
        Return MESSAGE_INVALID_INPUT
    End Function

End Module
