Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeItemTypeEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(store As IRecipeItemTypeStore)
        MyBase.New(
            $"Item Type `{store.ItemType.Name}` for Recipe `{store.Recipe.Name}`:",
            "Recipe Item Type",
            ("Id", store.Id.ToString),
            ("Item Type", store.ItemType.Name),
            (False, Nothing, Nothing, Nothing),
            (True, "Delete", Function()
                                 Dim recipe = store.Recipe
                                 store.Delete()
                                 Return New RecipeItemTypeListWindow(recipe)
                             End Function),
            ("Cancel", Function() Nothing))
    End Sub
End Class
