Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeListWindow
    Inherits BaseListWindow(Of IDataStore, ICharacterTypeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Character Types",
            dataStore,
            Function(store, filter) store.CharacterTypes.Filter(filter),
            Function(x) New ListItem(Of ICharacterTypeStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(item) New CharacterTypeEditWindow(CType(item, ListItem(Of ICharacterTypeStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New CharacterTypeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
