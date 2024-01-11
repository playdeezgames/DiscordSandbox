Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterListWindow
    Inherits BaseListWindow(Of IDataStore, ICharacterStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Characters",
            store,
            Function(x, y) x.Characters.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CharacterEditWindow(x),
            AdditionalButtons:=
            {
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
