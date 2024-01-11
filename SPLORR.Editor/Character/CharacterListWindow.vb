Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterListWindow
    Inherits BaseListWindow(Of IDataStore, ICharacterStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Characters",
            dataStore,
            Function(store, filter) store.Characters.Filter(filter),
            Function(x) New ListItem(Of ICharacterStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(item) New CharacterEditWindow(CType(item, ListItem(Of ICharacterStore)).Store),
            AdditionalButtons:=
            {
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
