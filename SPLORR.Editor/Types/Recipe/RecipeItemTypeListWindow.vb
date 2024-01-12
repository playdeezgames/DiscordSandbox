Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeItemTypeListWindow
    Inherits BaseListWindow(Of IRecipeStore, IRecipeItemTypeStore)

    Public Sub New(store As Data.IRecipeStore)
        MyBase.New(
            $"Item Types for Recipe `{store.Name}`",
            store,
            Function(x, y) x.ItemTypes.Filter(y),
            Function(x) $"{x.ItemType.Name}(Id:{x.Id},In:{x.QuantityIn},Out:{x.QuantityOut})",
            Function(x) New RecipeItemTypeEditWindow(x),
            AdditionalButtons:=
            {
                ("Add...", Function() store.CanAddItemType, Sub() Program.GoToWindow(New RecipeAddItemTypeWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(New RecipeEditWindow(store)))
            })
    End Sub
End Class
