Public Class Game
    Const CELL_WIDTH = 16
    Const CELL_HEIGHT = 16
    Const CELL_COLUMNS = 80
    Const CELL_ROWS = 45
    Const SCREEN_WIDTH = CELL_WIDTH * CELL_COLUMNS
    Const SCREEN_HEIGHT = CELL_HEIGHT * CELL_ROWS
    Const FPS = 60
    Const WINDOW_TITLE = "SPLORR!!"

    Dim lastButton As Integer = -1
    Dim position As (X As Integer, Y As Integer) = (CELL_COLUMNS \ 2, CELL_ROWS \ 2)

    Public Sub Run()
        InitWindow(
            (SCREEN_WIDTH, SCREEN_HEIGHT),
            WINDOW_TITLE)
        SetTargetFPS(FPS)
        Do Until WindowShouldClose()
            Update()
            Draw()
        Loop
        CloseWindow()
    End Sub

    Private Sub Draw()
        BeginDrawing()
        ClearBackground(Color.Black)
        DrawRectangle(
            (position.X * CELL_WIDTH, position.Y * CELL_HEIGHT),
            (CELL_WIDTH, CELL_HEIGHT),
            Color.Green)
        EndDrawing()
    End Sub

    Private Sub Update()
        Dim key = GetKeyPressed()
        Do Until key = 0
            Select Case key
                Case KeyboardKey.Up
                    position = (position.X, position.Y - 1)
                Case KeyboardKey.Down
                    position = (position.X, position.Y + 1)
                Case KeyboardKey.Left
                    position = (position.X - 1, position.Y)
                Case KeyboardKey.Right
                    position = (position.X + 1, position.Y)
            End Select
            key = GetKeyPressed()
        Loop
        Dim button = GetGamepadButtonPressed()
        If button <> lastButton Then
            Select Case button
                Case 1
                    position = (position.X, position.Y - 1)
                Case 2
                    position = (position.X + 1, position.Y)
                Case 3
                    position = (position.X, position.Y + 1)
                Case 4
                    position = (position.X - 1, position.Y)
                Case 6
                        'b button
                Case 7
                    'a button
            End Select
            lastButton = button
        End If
    End Sub
End Class
