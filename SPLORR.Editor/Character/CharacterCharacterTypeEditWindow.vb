Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterCharacterTypeEditWindow
    Inherits BaseListWindow(Of IDataStore, ICharacterTypeStore)

    Public Sub New(store As Data.ICharacterStore)
        MyBase.New(
            $"Type for Character `{store.Name}` (current:`{store.CharacterType.Name}`):",
            store.Store,
            Function(x, y) x.CharacterTypes.Filter(y),
            Function(x) New CharacterTypeListItem(x),
            Function(x)
                store.CharacterType = CType(x, CharacterTypeListItem).Store
                Return New CharacterEditWindow(store)
            End Function,
            AdditionalButtons:=
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterEditWindow(store))
                )
            })
    End Sub
End Class
