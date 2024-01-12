Imports Terminal.Gui

Friend Class RecipeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Recipe...",
            "Recipe",
            ("Add", Function(x) dataStore.Recipes.NameExists(x),
            Function(x) New RecipeEditWindow(dataStore.Recipes.Create(x))),
            ("Cancel", Function() New RecipeListWindow(dataStore)))
    End Sub
End Class
