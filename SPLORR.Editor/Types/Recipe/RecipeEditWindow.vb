Imports SPLORR.Data

Friend Class RecipeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As IRecipeStore)
        MyBase.New(
            $"Edit Recipe: {store.Name}",
            "Recipe",
            store.Id,
            ("Name", store.Name),
            (True, "Update",
            Function(x) store.CanRenameTo(x),
            Function(x)
                store.Name = x
                Return New RecipeEditWindow(store)
            End Function),
            (store.CanDelete, "Delete",
            Function()
                store.Delete()
                Return New RecipeListWindow(store.Store)
            End Function),
            ("Cancel", Function() New RecipeListWindow(store.Store)),
            {
                (
                    "Item Types...",
                    Function() True,
                    Sub() Program.GoToWindow(New RecipeItemTypeListWindow(store))
                )
            })
    End Sub
End Class
