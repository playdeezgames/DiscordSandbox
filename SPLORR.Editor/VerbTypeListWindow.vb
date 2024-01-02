Imports Terminal.Gui

Friend Class VerbTypeListWindow
    Inherits BaseListWindow(Of Data.IDataStore, Data.IVerbTypeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Verb Types",
            dataStore,
            Function(store, filter) store.FilterVerbTypes(filter),
            Function(item) New VerbTypeListItem(item),
            Function(item) New VerbTypeEditWindow(CType(item, VerbTypeListItem).VerbTypeStore),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New VerbTypeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
