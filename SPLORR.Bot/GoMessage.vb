Imports SPLORR.Model
Friend Module GoMessage
    Friend Function Handle(player As IPlayerModel, tokens() As String) As String
        If Not player.HasCharacter Then
            Return MESSAGE_NO_CHARACTER
        End If
        Dim directionName = String.Join(" "c, tokens)
        Dim character = player.Character
        Dim location = character.Location
        Dim route As IRouteModel = location.FindRouteByDirectionName(directionName)
        If route Is Nothing Then
            Return MESSAGE_NO_EXIT
        End If
        character.UseRoute(route)
        Return $"{character.Name} goes {route.Direction.Name}."
    End Function
End Module
