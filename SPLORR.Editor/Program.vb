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
    Private Const TEXT_ITEM_TYPE_GENERATORS = "Item Type Generators"
    Private Const TEXT_DIRECTIONS = "Directions"
    Private Const TEXT_STATISTIC_TYPES = "Statistic Types"
    Private Const TEXT_CHARACTER_TYPES = "Character Types"
    Private Const TEXT_RECIPES = "Recipes"
    Private Const TEXT_ROUTE_TYPES = "Route Types"
    Private Const TEXT_ENTITIES = "Entities"
    Private Const TEXT_LOCATIONS = "Locations"
    Private Const TEXT_CHARACTERS = "Characters"
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
                    New MenuItem(TEXT_CHARACTER_TYPES, String.Empty, AddressOf DoCharacterTypesList),
                    New MenuItem(TEXT_DIRECTIONS, String.Empty, AddressOf DoDirectionsList),
                    New MenuItem(TEXT_ITEM_TYPES, String.Empty, AddressOf DoItemTypesList),
                    New MenuItem(TEXT_LOCATION_TYPES, String.Empty, AddressOf DoLocationTypesList),
                    New MenuItem(TEXT_RECIPES, String.Empty, AddressOf DoRecipesList),
                    New MenuItem(TEXT_ROUTE_TYPES, String.Empty, AddressOf DoRouteTypesList),
                    New MenuItem(TEXT_STATISTIC_TYPES, String.Empty, AddressOf DoStatisticTypesList)
                }),
                New MenuBarItem(TEXT_GENERATORS,
                {
                    New MenuItem(TEXT_ITEM_TYPE_GENERATORS, String.Empty, AddressOf DoItemTypeGeneratorsList)
                }),
                New MenuBarItem(TEXT_ENTITIES,
                {
                    New MenuItem(TEXT_CHARACTERS, String.Empty, AddressOf DoCharactersList),
                    New MenuItem(TEXT_LOCATIONS, String.Empty, AddressOf DoLocationsList)
                })
            }))
        Application.Run()
        Application.Shutdown()
        dataStore.CleanUp()
    End Sub

    Private Sub DoLocationsList()
        Throw New NotImplementedException()
    End Sub

    Private Sub DoCharactersList()
        Throw New NotImplementedException()
    End Sub

    Private Sub DoRouteTypesList()
        GoToWindow(New RouteTypeListWindow(dataStore))
    End Sub

    Private Sub DoRecipesList()
        GoToWindow(New RecipeListWindow(dataStore))
    End Sub

    Private Sub DoCharacterTypesList()
        GoToWindow(New CharacterTypeListWindow(dataStore))
    End Sub

    Private Sub DoStatisticTypesList()
        GoToWindow(New StatisticTypeListWindow(dataStore))
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
