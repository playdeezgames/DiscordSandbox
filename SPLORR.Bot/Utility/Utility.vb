Imports SPLORR.Model

Friend Module Utility
    Friend Sub WithCard(
                        player As IPlayerModel,
                        tokens() As String,
                        outputter As Action(Of String),
                        subhandler As Action(Of ICharacterModel, ICardModel))
        WithTokens(
            tokens,
            outputter,
            Sub()
                WithCharacter(
                    (player,
                    outputter),
                    Sub(character)
                        Dim cardName = String.Join(" "c, tokens)
                        Dim card As ICardModel = character.HandCardByName(cardName)
                        If card Is Nothing Then
                            outputter($"{character.Name} has no such card.")
                            Return
                        End If
                        subhandler(character, card)
                    End Sub)
            End Sub)
    End Sub
    Friend Sub WithCharacter(context As (Player As IPlayerModel, Outputter As Action(Of String)),
                            subhandler As Action(Of ICharacterModel))
        If Not context.Player.HasCharacter Then
            context.Outputter(MESSAGE_NO_CHARACTER)
            Return
        End If
        subhandler(context.Player.Character)
    End Sub
    Friend Sub WithNoTokens(tokens As String(),
                            outputter As Action(Of String),
                            subhandler As Action)
        If tokens.Length > 0 Then
            outputter(MESSAGE_INVALID_INPUT)
            Return
        End If
        subhandler()
    End Sub
    Friend Sub WithTokens(tokens As String(),
                            outputter As Action(Of String),
                            subhandler As Action)
        If tokens.Length = 0 Then
            outputter(MESSAGE_INVALID_INPUT)
            Return
        End If
        subhandler()
    End Sub
End Module
