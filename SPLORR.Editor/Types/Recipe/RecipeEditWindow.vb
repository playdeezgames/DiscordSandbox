Imports SPLORR.Data

Friend Class RecipeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As IRecipeStore)
        MyBase.New(
            $"Edit Recipe: {store.Name}",
            "Recipe",
            store.Id,
            ("Name", store.Name),
            True,
            store.CanDelete,
            Function(x) store.CanRenameTo(x),
            ("Cancel", Function() New RecipeListWindow(store.Store)),
            Function()
                store.Delete()
                Return New RecipeListWindow(store.Store)
            End Function,
            Function(x)
                store.Name = x
                Return New RecipeEditWindow(store)
            End Function,
            {
                (
                    "Item Types...",
                    Function() True,
                    Sub() Program.GoToWindow(New RecipeItemTypeListWindow(store))
                )
            })
    End Sub
End Class
