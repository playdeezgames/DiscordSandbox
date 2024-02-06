Imports Raylib_cs

Public Module RLVB
    Private Function GetKeyPressed() As Integer
        Return Raylib_cs.Raylib.GetKeyPressed()
    End Function

    Function GetKeysPressed() As IEnumerable(Of Integer)
        Dim result As New List(Of Integer)
        Dim key As Integer
        Do
            key = GetKeyPressed()
            If key <> 0 Then
                result.Add(key)
            End If
        Loop Until key = 0
        Return result
    End Function
    Function GetGamepadButtonPressed() As Integer
        Return Raylib_cs.Raylib.GetGamepadButtonPressed()
    End Function
    Sub InitWindow(
                  size As (Width As Integer, Height As Integer),
                  title As String)
        Raylib_cs.Raylib.InitWindow(size.Width, size.Height, title)
        Raylib_cs.Raylib.SetExitKey(KeyboardKey.Null)
    End Sub
    Sub SetTargetFPS(fps As Integer)
        Raylib_cs.Raylib.SetTargetFPS(fps)
    End Sub
    Function WindowShouldClose() As Boolean
        Return Raylib_cs.Raylib.WindowShouldClose()
    End Function
    Sub BeginDrawing()
        Raylib_cs.Raylib.BeginDrawing()
    End Sub
    Sub EndDrawing()
        Raylib_cs.Raylib.EndDrawing()
    End Sub
    Sub CloseWindow()
        Raylib_cs.Raylib.CloseWindow()
    End Sub
    Sub ClearBackground(color As Color)
        Raylib_cs.Raylib.ClearBackground(color)
    End Sub
    Sub DrawText(
                text As String,
                position As (X As Integer, Y As Integer),
                fontSize As Integer,
                color As Color)
        Raylib_cs.Raylib.DrawText(
            text,
            position.X,
            position.Y,
            fontSize,
            color)
    End Sub
    Function MeasureText(
                        text As String,
                        fontSize As Integer) As Integer
        Return Raylib_cs.Raylib.MeasureText(
            text,
            fontSize)
    End Function
    Sub DrawRectangle(
                     position As (X As Integer, Y As Integer),
                     size As (Width As Integer, Height As Integer),
                     color As Color)
        Raylib_cs.Raylib.DrawRectangle(
            position.X,
            position.Y,
            size.Width,
            size.Height,
            color)
    End Sub
End Module
