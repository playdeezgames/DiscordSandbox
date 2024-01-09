Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeListWindow
    Inherits BaseListWindow(Of IDataStore, ICharacterTypeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Character Types",
            dataStore,
            Function(store, filter) store.CharacterTypes.Filter(filter),
            Function(item) New CharacterTypeListItem(item),
            Function(item) New CharacterTypeEditWindow(CType(item, CharacterTypeListItem).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New CharacterTypeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
