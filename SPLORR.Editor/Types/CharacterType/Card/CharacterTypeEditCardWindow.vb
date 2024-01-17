Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeEditCardWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterTypeCardStore)
        MyBase.New(
            $"Card `{store.Name}` for Character Type `{store.CharacterType.Name}`",
            "Character Type Card",
            ("Id", store.Id.ToString),
            ("Quantity", store.Quantity.ToString),
            (
                True,
                "Update",
                Function(x)
                    Dim value As Integer = 0
                    Return Not Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.Quantity = Integer.Parse(x)
                    Return New CharacterTypeEditCardWindow(store)
                End Function
            ),
            (
                True,
                "Delete",
                Function()
                    Dim characterType = store.CharacterType
                    store.Delete()
                    Return New CharacterTypeCardListWindow(characterType)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterTypeCardListWindow(store.CharacterType)
            ))
    End Sub
End Class
