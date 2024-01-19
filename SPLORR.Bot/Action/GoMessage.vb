Imports SPLORR.Model
Friend Module GoMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        WithCharacter(
            player,
            outputter,
            Sub(character)
                Dim directionName = String.Join(" "c, tokens)
                Dim location = character.Location
                Dim route As IRouteModel = location.FindRouteByDirectionName(directionName)
                If route Is Nothing Then
                    outputter(MESSAGE_NO_EXIT)
                    Return
                End If
                character.UseRoute(route)
                outputter($"{character.Name} goes {route.Direction.Name}.")
                StatusMessage.Handle(player, Array.Empty(Of String), outputter)
            End Sub)
    End Sub
End Module
