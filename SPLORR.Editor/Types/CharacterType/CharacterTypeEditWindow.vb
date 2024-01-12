﻿Imports SPLORR.Data

Friend Class CharacterTypeEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(characterTypeStore As ICharacterTypeStore)
        MyBase.New(
            $"Edit Character Type: {characterTypeStore.Name}",
            "Character Type",
            characterTypeStore.Id,
            ("Name", characterTypeStore.Name),
            (True, "Update",
            Function(x) characterTypeStore.CanRenameTo(x),
            Function(x)
                characterTypeStore.Name = x
                Return New CharacterTypeEditWindow(characterTypeStore)
            End Function),
            (characterTypeStore.CanDelete, "Delete",
            Function()
                characterTypeStore.Delete()
                Return New CharacterTypeListWindow(characterTypeStore.Store)
            End Function),
            ("Cancel", Function() New CharacterTypeListWindow(characterTypeStore.Store)),
            {
                (
                    "Create Character...",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterAddWindow(characterTypeStore))
                )
            })
    End Sub
End Class
