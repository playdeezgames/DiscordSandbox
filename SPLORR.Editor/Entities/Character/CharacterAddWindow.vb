Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterAddWindow
    Inherits BaseListWindow(Of IDataStore, ILocationStore)

    Public Sub New(store As Data.ICharacterTypeStore)
        MyBase.New(
            $"Create Character Type `{store.Name}` at Location:",
            store.Store,
            Function(x, y) x.Locations.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CharacterEditWindow(store.CreateCharacter("Nameless", CType(x, ListItem(Of ILocationStore)).Store)),
            AdditionalButtons:=
            {
                ("Cancel", Function() True, Sub() Program.GoToWindow(New CharacterTypeEditWindow(store)))
            })
    End Sub
End Class
