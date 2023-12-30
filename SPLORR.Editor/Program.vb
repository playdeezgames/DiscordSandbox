Imports SPLORR.Data
Imports Terminal.Gui

Module Program
    Const ENV_VAR_CONNECTION_STRING = "CONNECTION_STRING"
    Private Const MENUBARITEM_SYSTEM As String = "System"
    Private Const MENUITEM_QUIT As String = "Quit"
    Private Const MENUBARITEM_LOCATION_TYPES As String = "Location Types"
    Private Const MENUITEM_LIST As String = "List"
    Private Const MENUITEM_ADD As String = "Add..."
    Private dataStore As IDataStore = Nothing
    Public window As Window = Nothing
    Sub Main(args As String())
        dataStore = New DataStore(Environment.GetEnvironmentVariable(ENV_VAR_CONNECTION_STRING))
        Application.Init()
        Application.Top.Add(
            New MenuBar(
            {
                New MenuBarItem(MENUBARITEM_SYSTEM,
                {
                    New MenuItem(MENUITEM_QUIT, String.Empty, AddressOf DoSystemQuit)
                }),
                New MenuBarItem(MENUBARITEM_LOCATION_TYPES,
                {
                    New MenuItem(MENUITEM_LIST, String.Empty, AddressOf DoLocationTypesList),
                    New MenuItem(MENUITEM_ADD, String.Empty, AddressOf DoLocationTypesAdd)
                })
            }))
        Application.Run()
        Application.Shutdown()
        dataStore.CleanUp()
    End Sub

    Private Sub DoLocationTypesAdd()
        GoToWindow(New LocationTypeAddWindow(dataStore))
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
