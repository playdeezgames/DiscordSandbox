Imports SPLORR.Data

Friend Class RecipeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(recipeStore As IRecipeStore)
        MyBase.New(
            $"Edit Recipe: {recipeStore.Name}",
            "Recipe",
            recipeStore.Id,
            ("Name", recipeStore.Name),
            recipeStore.CanDelete,
            Function(x) recipeStore.CanRenameTo(x),
            Function() New RecipeListWindow(recipeStore.Store),
            Function()
                recipeStore.Delete()
                Return New RecipeListWindow(recipeStore.Store)
            End Function,
            Function(x)
                recipeStore.Name = x
                Return New RecipeEditWindow(recipeStore)
            End Function)
    End Sub
End Class
