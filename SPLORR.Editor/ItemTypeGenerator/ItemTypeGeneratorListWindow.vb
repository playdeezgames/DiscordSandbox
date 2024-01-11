Imports SPLORR.Data

Friend Class ItemTypeGeneratorListWindow
    Inherits BaseListWindow(Of Data.IDataStore, Data.IItemTypeGeneratorStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Item Type Generators",
            store,
            Function(x, y) x.ItemTypeGenerators.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New ItemTypeGeneratorEditWindow(x),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New ItemTypeGeneratorAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
