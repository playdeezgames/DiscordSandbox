Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeListWindow
    Inherits BaseListWindow(Of IDataStore, IRecipeStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Recipes",
            store,
            Function(x, y) x.Recipes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New RecipeEditWindow(CType(x, ListItem(Of IRecipeStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New RecipeAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
