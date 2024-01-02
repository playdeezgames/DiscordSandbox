Imports SPLORR.Data
Imports Terminal.Gui

Module Program
    Const ENV_VAR_CONNECTION_STRING = "CONNECTION_STRING"
    Private Const MENUBARITEM_SYSTEM As String = "System"
    Private Const MENUBARITEM_TYPES As String = "Types"
    Private Const MENUITEM_QUIT As String = "Quit"
    Private Const MENUITEM_LOCATION_TYPES = "Location Types"
    Private Const MENUITEM_VERB_TYPES = "Verb Types"
    Private dataStore As IDataStore = Nothing
    Public window As Window = Nothing
    Sub Main(args As String())
        Console.Title = "SPLORR!! Editor"
        dataStore = New DataStore(Environment.GetEnvironmentVariable(ENV_VAR_CONNECTION_STRING))
        Application.Init()
        Application.Top.Add(
            New MenuBar(
            {
                New MenuBarItem(MENUBARITEM_SYSTEM,
                {
                    New MenuItem(MENUITEM_QUIT, String.Empty, AddressOf DoSystemQuit)
                }),
                New MenuBarItem(MENUBARITEM_TYPES,
                {
                    New MenuItem(MENUITEM_LOCATION_TYPES, String.Empty, AddressOf DoLocationTypesList),
                    New MenuItem(MENUITEM_VERB_TYPES, String.Empty, AddressOf DoVerbTypesList)
                })
            }))
        Application.Run()
        Application.Shutdown()
        dataStore.CleanUp()
    End Sub

    Private Sub DoVerbTypesList()
        GoToWindow(New VerbTypeListWindow(dataStore))
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
