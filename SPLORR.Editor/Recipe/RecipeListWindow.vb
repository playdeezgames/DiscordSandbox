Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeListWindow
    Inherits BaseListWindow(Of IDataStore, IRecipeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Recipes",
            dataStore,
            Function(store, filter) store.Recipes.Filter(filter),
            Function(item) New RecipeListItem(item),
            Function(item) New RecipeEditWindow(CType(item, RecipeListItem).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New RecipeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
