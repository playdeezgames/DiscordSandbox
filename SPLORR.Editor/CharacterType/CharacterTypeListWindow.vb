Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeListWindow
    Inherits BaseListWindow(Of IDataStore, ICharacterTypeStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Character Types",
            store,
            Function(x, y) x.CharacterTypes.Filter(y),
            Function(x) New ListItem(Of ICharacterTypeStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(x) New CharacterTypeEditWindow(CType(x, ListItem(Of ICharacterTypeStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New CharacterTypeAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
