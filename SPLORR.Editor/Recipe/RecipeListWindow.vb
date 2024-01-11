Imports SPLORR.Data
Imports Terminal.Gui

Friend Class RecipeListWindow
    Inherits BaseListWindow(Of IDataStore, IRecipeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Recipes",
            dataStore,
            Function(store, filter) store.Recipes.Filter(filter),
            Function(x) New ListItem(Of IRecipeStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(item) New RecipeEditWindow(CType(item, ListItem(Of IRecipeStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New RecipeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
