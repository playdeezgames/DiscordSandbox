Imports Raylib_cs

Public Module RLVB
    Sub InitWindow(width As Integer, height As Integer, title As String)
        Raylib_cs.Raylib.InitWindow(width, height, title)
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
    Sub DrawText(text As String, x As Integer, y As Integer, fontSize As Integer, color As Color)
        Raylib_cs.Raylib.DrawText(text, x, y, fontSize, color)
    End Sub
    Function MeasureText(text As String, fontSize As Integer) As Integer
        Return Raylib_cs.Raylib.MeasureText(text, fontSize)
    End Function
End Module
