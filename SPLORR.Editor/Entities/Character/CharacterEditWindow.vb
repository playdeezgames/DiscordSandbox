﻿Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterStore)
        MyBase.New(
            $"Edit Character: {store.Name}",
            "Character",
            ("Id", store.Id.ToString),
            ("Name", store.Name),
            (True, "Update",
            Function(x) store.CanRenameTo(x),
            Function(x)
                store.Name = x
                Return New CharacterEditWindow(store)
            End Function),
            (store.CanDelete, "Delete",
            Function()
                store.Delete()
                Return New CharacterListWindow(store.Store)
            End Function),
            ("Cancel", Function() New CharacterListWindow(store.Store)),
            {
                (
                    $"Location: {store.Location.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterLocationEditWindow(store))
                ),
                (
                    $"Type: {store.CharacterType.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterCharacterTypeEditWindow(store))
                ),
                (
                    $"Clear Player",
                    Function() store.HasPlayer,
                    Sub()
                        store.ClearPlayer()
                        Program.GoToWindow(New CharacterEditWindow(store))
                    End Sub
                ),
                (
                    "Cards...",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterCardListWindow(store))
                ),
                (
                    "Statistics...",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterStatisticListWindow(store))
                )
            })
    End Sub
End Class
