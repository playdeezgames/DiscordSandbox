Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeItemTypeAddQuantityInWindow
    Inherits BaseAddTypeWindow
    Public Sub New(store As IRecipeStore, itemType As IItemTypeStore)
        MyBase.New(
            $"Add Quantity In to Recipe `{store.Name}` Item Type `{itemType.Name}`:",
            "Quantity In must be numeric and non-negative!",
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
                    Return New RecipeItemTypeAddQuantityOutWindow(store, itemType, Integer.Parse(x))
                End Function
            ),
            (
                "Cancel",
                Function() New RecipeItemTypeListWindow(store)))
    End Sub
End Class
