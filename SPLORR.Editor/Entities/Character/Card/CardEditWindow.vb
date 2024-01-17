Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CardEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(store As ICardStore)
        MyBase.New(
            $"Edit Card `{store.Name}` belonging to `{store.Character.Name}`",
            "Card",
            ("Id", store.Id.ToString),
            ("Card Type", store.Name),
            (False, Nothing, Nothing, Nothing),
            (
                store.CanDelete,
                "Delete",
                Function()
                    Dim character = store.Character
                    store.Delete()
                    Return New CharacterCardListWindow(character)
                End Function),
            (
                "Cancel",
                Function() New CharacterCardListWindow(store.Character)))
    End Sub
End Class
