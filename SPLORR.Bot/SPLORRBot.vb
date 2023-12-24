﻿Public Class SPLORRBot
    Implements IBot

    Private Const TOKEN_STATUS As String = "status"
    Private Const MESSAGE_NO_CHARACTER As String = "You have no character!"
    Private Const MESSAGE_INVALID_INPUT As String = "Invalid input!"

    Public Sub Start() Implements IBot.Start
    End Sub

    Public Sub [Stop]() Implements IBot.Stop
    End Sub

    Public Function HandleMessage(authorId As ULong, message As String) As String Implements IBot.HandleMessage
        Dim tokens = message.ToLower.Split(" "c)
        If tokens.Length > 0 Then
            Return ProcessMessage(authorId, tokens)
        End If
        Return MESSAGE_INVALID_INPUT
    End Function

    Private Function ProcessMessage(authorId As ULong, tokens() As String) As String
        Dim firstToken = tokens.First
        Dim remainingTokens = tokens.Skip(1).ToArray
        Select Case firstToken
            Case TOKEN_STATUS
                Return HandleStatusMessage(remainingTokens)
            Case Else
                Return MESSAGE_INVALID_INPUT
        End Select
    End Function

    Private Shared Function HandleStatusMessage(tokens As String()) As String
        If tokens.Length = 0 Then
            Return MESSAGE_NO_CHARACTER
        End If
        Return MESSAGE_INVALID_INPUT
    End Function
End Class
