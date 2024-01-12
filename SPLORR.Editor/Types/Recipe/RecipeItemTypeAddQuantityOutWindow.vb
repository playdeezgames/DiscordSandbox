Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeItemTypeAddQuantityOutWindow
    Inherits BaseAddTypeWindow
    Public Sub New(store As IRecipeStore, itemType As IItemTypeStore, quantityIn As Integer)
        MyBase.New(
            $"Add Quantity Out to Recipe `{store.Name}` Item Type `{itemType.Name}` Quantity In `{quantityIn}`:",
            "Quantity Out must be numeric and non-negative, and total quantity must be non-zero!",
            (
                "Next",
                Function(x)
                    Dim value As Integer = 0
                    If Integer.TryParse(x, value) Then
                        Return value < 0
                    End If
                    Return True
                End Function,
                Function(x)
                    store.CreateRecipeItemType(itemType, quantityIn, Integer.Parse(x))
                    Return New RecipeItemTypeListWindow(store)
                End Function
            ),
            (
                "Cancel",
                Function() New RecipeItemTypeListWindow(store)))
    End Sub
End Class
