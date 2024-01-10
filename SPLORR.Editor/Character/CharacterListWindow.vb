Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterListWindow
    Inherits BaseListWindow(Of IDataStore, ICharacterStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Characters",
            dataStore,
            Function(store, filter) store.Characters.Filter(filter),
            Function(item) New CharacterListItem(item),
            Function(item) New CharacterEditWindow(CType(item, CharacterListItem).Store),
            AdditionalButtons:=
            {
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
