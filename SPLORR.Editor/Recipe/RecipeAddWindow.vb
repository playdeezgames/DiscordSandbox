Imports Terminal.Gui

Friend Class RecipeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Recipe...",
            "Recipe",
            Function(x) dataStore.Recipes.NameExists(x),
            Function() New RecipeListWindow(dataStore),
            Function(x) New RecipeEditWindow(dataStore.Recipes.Create(x)))
    End Sub
End Class
