Imports System.Text
Imports SPLORR.Model

Friend Module HelpMessage
    Private ReadOnly helps As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {TOKEN_CARDS, "Shows the cards in yer deck."},
            {TOKEN_CHARACTER, "Shows yer character's vital statistics."},
            {TOKEN_CRAFT, "Crafts items from other items."},
            {TOKEN_CREATE, "Allows you to create stuff."},
            {TOKEN_DIE, "Causes yer character to die."},
            {TOKEN_DROP, "Drops items from yer inventory to the ground."},
            {TOKEN_FORAGE, "Forages for items."},
            {TOKEN_GO, "Allows you to move yer character in a direction."},
            {TOKEN_GROUND, "Looks at the items on the ground."},
            {TOKEN_HAND, "Looks at the cards in yer hand."},
            {TOKEN_HELP, "Shows help."},
            {TOKEN_INVENTORY, "Looks at the items in yer inventory."},
            {TOKEN_RENAME, "Renames stuff."},
            {TOKEN_STATUS, "Shows yer status."},
            {TOKEN_TAKE, "Takes items from the ground into yer inventory."}
        }
    Private ReadOnly helpTopics As IReadOnlyDictionary(Of String, Action(Of IPlayerModel, String(), Action(Of String))) =
        New Dictionary(Of String, Action(Of IPlayerModel, String(), Action(Of String))) From
        {
            {TOKEN_CARDS, AddressOf HelpCards},
            {TOKEN_CHARACTER, AddressOf HelpCharacter},
            {TOKEN_CRAFT, AddressOf HelpCraft},
            {TOKEN_CREATE, AddressOf HelpCreate},
            {TOKEN_DIE, AddressOf HelpDie},
            {TOKEN_DROP, AddressOf HelpDrop},
            {TOKEN_FORAGE, AddressOf HelpForage},
            {TOKEN_GO, AddressOf HelpGo},
            {TOKEN_GROUND, AddressOf HelpGround},
            {TOKEN_HAND, AddressOf HelpHand},
            {TOKEN_HELP, AddressOf HelpHelp},
            {TOKEN_INVENTORY, AddressOf HelpInventory},
            {TOKEN_RENAME, AddressOf HelpRename},
            {TOKEN_STATUS, AddressOf HelpStatus},
            {TOKEN_TAKE, AddressOf HelpTake}
        }

    Private Sub HelpHand(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_HAND}:")
        outputter($"- usage: {TOKEN_HAND}")
    End Sub

    Private Sub HelpDie(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_DIE}:")
        outputter($"- usage: {TOKEN_DIE}")
    End Sub

    Private Sub HelpCharacter(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_CHARACTER}:")
        outputter($"- usage: {TOKEN_CHARACTER}")
    End Sub

    Private Sub HelpTake(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_TAKE}:")
        outputter($"- usage: {TOKEN_TAKE} <item>")
    End Sub

    Private Sub HelpRename(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_RENAME}:")
        outputter($"- usage: {TOKEN_RENAME} <thing> <new name>")
        outputter($"- values for <thing>: {TOKEN_CHARACTER}")
    End Sub

    Private Sub HelpInventory(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_INVENTORY}:")
        outputter($"- usage: {TOKEN_INVENTORY}")
    End Sub

    Private Sub HelpGround(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_GROUND}:")
        outputter($"- usage: {TOKEN_GROUND}")
    End Sub

    Private Sub HelpForage(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_FORAGE}:")
        outputter($"- usage: {TOKEN_FORAGE}")
    End Sub

    Private Sub HelpDrop(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_DROP}:")
        outputter($"- usage: {TOKEN_DROP} <item>")
    End Sub

    Private Sub HelpCraft(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_DROP}:")
        outputter($"- usage: {TOKEN_DROP} <item>")
    End Sub

    Private Sub HelpCards(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_CARDS}:")
        outputter($"- usage: {TOKEN_CARDS}")
    End Sub

    Private Sub HelpStatus(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_STATUS}:")
        outputter($"- usage: {TOKEN_STATUS}")
    End Sub

    Private Sub HelpHelp(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_HELP}:")
        outputter($"- usage: {TOKEN_HELP} <topic>")
    End Sub

    Private sub HelpGo(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_GO}:")
        outputter($"- usage: {TOKEN_GO} <direction>")
    End sub

    Private sub HelpCreate(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length <> 0 Then
            InvalidMessage.Handle(player, tokens, outputter)
            Return
        End If
        outputter($"Help for {TOKEN_CREATE}:")
        outputter($"- usage: {TOKEN_CREATE} <thing>")
        outputter($"- values for <thing>: {TOKEN_CHARACTER}")
    End sub

    Friend sub Handle(player As IPlayerModel, tokens() As String, outputter As Action(Of String))
        If tokens.Length = 0 Then
            outputter($"Commands:")
            For Each help In helps
                outputter($"- {help.Key}: {help.Value}")
            Next
            Return
        End If
        Dim firstToken = tokens.First.ToLower
        tokens = tokens.Skip(1).ToArray
        Dim handler As Action(Of IPlayerModel, String(), Action(Of String)) = Nothing
        If helpTopics.TryGetValue(firstToken, handler) Then
            handler(player, tokens, outputter)
            Return
        End If
        InvalidMessage.Handle(player, tokens, outputter)
    End sub
End Module
