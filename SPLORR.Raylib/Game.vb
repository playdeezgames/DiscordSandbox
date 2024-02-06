Public Class Game
    ReadOnly CELL_SIZE As (Width As Integer, Height As Integer) = (16, 16)
    ReadOnly GRID_SIZE As (Width As Integer, Height As Integer) = (80, 45)
    ReadOnly SCREEN_SIZE As (Width As Integer, Height As Integer) = SizesMultiply(CELL_SIZE, GRID_SIZE)

    Const FPS = 60
    Const WINDOW_TITLE = "SPLORR!!"

    Dim lastButton As Integer = 0
    Dim position As (X As Integer, Y As Integer) = (GRID_SIZE.Width \ 2, GRID_SIZE.Height \ 2)

    Public Sub Run()
        InitWindow(
            SCREEN_SIZE,
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
            PointSizeMultiply(position, CELL_SIZE),
            CELL_SIZE,
            Color.Green)
        EndDrawing()
    End Sub

    Private deltas As IReadOnlyDictionary(Of Direction, (X As Integer, Y As Integer)) =
        New Dictionary(Of Direction, (X As Integer, Y As Integer)) From
        {
            {Direction.Up, (0, -1)},
            {Direction.Right, (1, 0)},
            {Direction.Down, (0, 1)},
            {Direction.Left, (-1, 0)}
        }

    Private Sub MoveUp()
        position = PointsAdd(position, deltas(Direction.Up))
    End Sub

    Private Sub MoveDown()
        position = PointsAdd(position, deltas(Direction.Down))
    End Sub

    Private Sub MoveLeft()
        position = PointsAdd(position, deltas(Direction.Left))
    End Sub

    Private Sub MoveRight()
        position = PointsAdd(position, deltas(Direction.Right))
    End Sub

    Private ReadOnly keyHandlers As IReadOnlyDictionary(Of Integer, Action) =
        New Dictionary(Of Integer, Action) From
        {
            {KeyboardKey.Up, AddressOf MoveUp},
            {KeyboardKey.Down, AddressOf MoveDown},
            {KeyboardKey.Left, AddressOf MoveLeft},
            {KeyboardKey.Right, AddressOf MoveRight},
            {KeyboardKey.Escape, AddressOf RedButton},
            {KeyboardKey.Space, AddressOf GreenButton}
        }

    Private Sub Update()
        HandleKeyInput()
        HandleGamePadInput()
    End Sub

    Private ReadOnly buttonHandlers As IReadOnlyDictionary(Of Integer, Action) =
        New Dictionary(Of Integer, Action) From
        {
            {1, AddressOf MoveUp},
            {2, AddressOf MoveRight},
            {3, AddressOf MoveDown},
            {4, AddressOf MoveLeft},
            {6, AddressOf RedButton},
            {7, AddressOf GreenButton}
        }

    Private Sub GreenButton()
    End Sub

    Private Sub RedButton()
    End Sub

    Private Sub HandleGamePadInput()
        Dim button = GetGamepadButtonPressed()
        If button <> lastButton Then
            Dim axn As Action = Nothing
            If buttonHandlers.TryGetValue(button, axn) Then
                axn.Invoke
            End If
            lastButton = button
        End If
    End Sub

    Private Sub HandleKeyInput()
        For Each key In GetKeysPressed()
            Dim axn As Action = Nothing
            If keyHandlers.TryGetValue(key, axn) Then
                axn.Invoke
            End If
        Next
    End Sub
End Class
