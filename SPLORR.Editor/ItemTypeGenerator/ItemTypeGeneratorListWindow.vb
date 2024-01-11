Imports SPLORR.Data

Friend Class ItemTypeGeneratorListWindow
    Inherits BaseListWindow(Of Data.IDataStore, Data.IItemTypeGeneratorStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Item Type Generators",
            dataStore,
            Function(store, filter) store.ItemTypeGenerators.Filter(filter),
            Function(x) New ListItem(Of IItemTypeGeneratorStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(item) New ItemTypeGeneratorEditWindow(CType(item, ListItem(Of IItemTypeGeneratorStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New ItemTypeGeneratorAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
