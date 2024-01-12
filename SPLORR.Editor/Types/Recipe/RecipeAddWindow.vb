Imports Terminal.Gui

Friend Class RecipeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Recipe...",
            "Recipe Name must exist and be unique!",
            ("Add", Function(x) String.IsNullOrEmpty(x) OrElse dataStore.Recipes.NameExists(x),
            Function(x) New RecipeEditWindow(dataStore.Recipes.Create(x))),
            ("Cancel", Function() New RecipeListWindow(dataStore)))
    End Sub
End Class
