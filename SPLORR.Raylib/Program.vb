Module Program
    Const SCREEN_WIDTH = 1280
    Const SCREEN_HEIGHT = 720
    Const FPS = 60
    Const WINDOW_TITLE = "SPLORR!!"
    Const FONT_SIZE = 20
    Sub Main(args As String())
        InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, WINDOW_TITLE)
        SetTargetFPS(FPS)
        Do Until WindowShouldClose()
            BeginDrawing()
            ClearBackground(Color.Black)
            DrawText(WINDOW_TITLE, SCREEN_WIDTH \ 2 - MeasureText(WINDOW_TITLE, FONT_SIZE), SCREEN_HEIGHT \ 2 - FONT_SIZE \ 2, FONT_SIZE, Color.White)
            EndDrawing()
        Loop
        CloseWindow()
    End Sub
End Module
