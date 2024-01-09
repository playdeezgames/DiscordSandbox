Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(characterTypeStore As ICharacterTypeStore)
        MyBase.New(
            $"Edit Character Type: {characterTypeStore.Name}",
            "Character Type",
            characterTypeStore.Id,
            ("Name", characterTypeStore.Name),
            characterTypeStore.CanDelete,
            Function(x) characterTypeStore.CanRenameTo(x),
            Function() New CharacterTypeListWindow(characterTypeStore.Store),
            Function()
                characterTypeStore.Delete()
                Return New CharacterTypeListWindow(characterTypeStore.Store)
            End Function,
            Function(x)
                characterTypeStore.Name = x
                Return New CharacterTypeEditWindow(characterTypeStore)
            End Function)
    End Sub
End Class
