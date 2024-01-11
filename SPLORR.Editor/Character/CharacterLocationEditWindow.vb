Imports SPLORR.Data

Friend Class CharacterLocationEditWindow
    Inherits BaseListWindow(Of IDataStore, ILocationStore)

    Public Sub New(store As Data.ICharacterStore)
        MyBase.New(
            $"Location for Character `{store.Name}` (current:`{store.Location.Name}`):",
            store.Store,
            Function(x, y) x.Locations.Filter(y),
            Function(x) New ListItem(Of ILocationStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(x)
                store.SetLocation(CType(x, ListItem(Of ILocationStore)).Store, DateTimeOffset.Now)
                Return New CharacterEditWindow(store)
            End Function,
            AdditionalButtons:=
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterEditWindow(store))
                ),
                (
                    $"Edit Location `{store.Location.Name}`...",
                    Function() True,
                    Sub() Program.GoToWindow(New LocationEditWindow(store.Location))
                )
            })
    End Sub
End Class
