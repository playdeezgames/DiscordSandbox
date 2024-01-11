Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationCharacterListWindow
    Inherits BaseListWindow(Of ILocationStore, ICharacterStore)

    Public Sub New(store As ILocationStore)
        MyBase.New(
            $"Characters at Location `{store.Name}`",
            store,
            Function(x, y) x.Characters.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CharacterEditWindow(CType(x, ListItem(Of ICharacterStore)).Store),
            AdditionalButtons:=
            {
                ("Close", Function() True, Sub() Program.GoToWindow(New LocationEditWindow(store)))
            })
    End Sub
End Class
