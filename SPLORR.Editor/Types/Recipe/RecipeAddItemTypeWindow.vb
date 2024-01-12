Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeAddItemTypeWindow
    Inherits BaseListWindow(Of IRecipeStore, IItemTypeStore)

    Public Sub New(store As IRecipeStore)
        MyBase.New(
            $"Add Item Type to Recipe `{store.Name}`:",
            store,
            Function(x, y) x.AvailableItemTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.CreateRecipeItemType(x, 1, 0)
                Return New RecipeItemTypeListWindow(store)
            End Function)
    End Sub
End Class
