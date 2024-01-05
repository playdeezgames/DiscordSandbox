Imports SPLORR.Data
Imports Terminal.Gui

Module Program
    Const ENV_VAR_CONNECTION_STRING = "CONNECTION_STRING"
    Private Const TEXT_SYSTEM As String = "System"
    Private Const TEXT_TYPES As String = "Types"
    Private Const TEXT_GENERATORS = "Generators"
    Private Const TEXT_QUIT As String = "Quit"
    Private Const TEXT_LOCATION_TYPES = "Location Types"
    Private Const TEXT_ITEM_TYPES = "Item Types"
    Private Const TEXT_ITEM_TYPE_GENERATOR = "Item Type Generators"
    Private Const TEXT_DIRECTIONS = "Directions"
    Private dataStore As IDataStore = Nothing
    Public window As Window = Nothing
    Sub Main(args As String())
        Console.Title = "SPLORR!! Editor"
        dataStore = New DataStore(Environment.GetEnvironmentVariable(ENV_VAR_CONNECTION_STRING))
        Application.Init()
        Application.Top.Add(
            New MenuBar(
            {
                New MenuBarItem(TEXT_SYSTEM,
                {
                    New MenuItem(TEXT_QUIT, String.Empty, AddressOf DoSystemQuit)
                }),
                New MenuBarItem(TEXT_TYPES,
                {
                    New MenuItem(TEXT_DIRECTIONS, String.Empty, AddressOf DoDirectionsList),
                    New MenuItem(TEXT_ITEM_TYPES, String.Empty, AddressOf DoItemTypesList),
                    New MenuItem(TEXT_LOCATION_TYPES, String.Empty, AddressOf DoLocationTypesList)
                }),
                New MenuBarItem(TEXT_GENERATORS,
                {
                    New MenuItem(TEXT_ITEM_TYPE_GENERATOR, String.Empty, AddressOf DoItemTypeGeneratorsList)
                })
            }))
        Application.Run()
        Application.Shutdown()
        dataStore.CleanUp()
    End Sub

    Private Sub DoDirectionsList()
        GoToWindow(New DirectionListWindow(dataStore))
    End Sub

    Private Sub DoItemTypeGeneratorsList()
        GoToWindow(New ItemTypeGeneratorListWindow(dataStore))
    End Sub

    Private Sub DoItemTypesList()
        GoToWindow(New ItemTypeListWindow(dataStore))
    End Sub

    Private Sub DoLocationTypesList()
        GoToWindow(New LocationTypeListWindow(dataStore))
    End Sub

    Private Sub DoSystemQuit()
        Application.RequestStop()
    End Sub
    Sub GoToWindow(newWindow As Window)
        If window IsNot Nothing Then
            Application.Top.Remove(window)
            window = Nothing
        End If
        If newWindow IsNot Nothing Then
            window = newWindow
            Application.Top.Add(window)
        End If
    End Sub
End Module
