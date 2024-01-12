Imports SPLORR.Data

Friend Class CharacterTypeEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(characterTypeStore As ICharacterTypeStore)
        MyBase.New(
            $"Edit Character Type: {characterTypeStore.Name}",
            "Character Type",
            characterTypeStore.Id,
            ("Name", characterTypeStore.Name),
            True,
            characterTypeStore.CanDelete,
            Function(x) characterTypeStore.CanRenameTo(x),
            ("Cancel", Function() New CharacterTypeListWindow(characterTypeStore.Store)),
            Function()
                characterTypeStore.Delete()
                Return New CharacterTypeListWindow(characterTypeStore.Store)
            End Function,
            Function(x)
                characterTypeStore.Name = x
                Return New CharacterTypeEditWindow(characterTypeStore)
            End Function,
            {
                (
                    "Create Character...",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterAddWindow(characterTypeStore))
                )
            })
    End Sub
End Class
