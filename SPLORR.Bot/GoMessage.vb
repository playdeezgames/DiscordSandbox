Imports SPLORR.Model
Friend Module GoMessage
    Friend Sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If Not player.HasCharacter Then
            outputter(MESSAGE_NO_CHARACTER)
            Return
        End If
        Dim directionName = String.Join(" "c, tokens)
        Dim character = player.Character
        Dim location = character.Location
        Dim route As IRouteModel = location.FindRouteByDirectionName(directionName)
        If route Is Nothing Then
            outputter(MESSAGE_NO_EXIT)
            Return
        End If
        character.UseRoute(route)
        outputter($"{character.Name} goes {route.Direction.Name}.")
        StatusMessage.Handle(player, Array.Empty(Of String), outputter)
    End Sub
End Module
