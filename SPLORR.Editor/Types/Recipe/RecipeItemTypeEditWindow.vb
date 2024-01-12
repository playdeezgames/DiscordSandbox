Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeItemTypeEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(store As IRecipeItemTypeStore)
        MyBase.New(
            $"Item Type `{store.ItemType.Name}` for Recipe `{store.Recipe.Name}`:",
            "Recipe Item Type",
            store.Id,
            ("Item Type", store.ItemType.Name),
            False,
            True,
            Function(x) False,
            ("Cancel", Function() Nothing),
            Function() Nothing,
            Function() Nothing)
    End Sub
End Class
