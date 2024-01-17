Imports SPLORR.Data

Friend Class CharacterStatisticEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterStatisticStore)
        MyBase.New(
            $"Statistic `{store.Name}`",
            "Character Statistic",
            ("Character", $"{store.Character.Name}"),
            ("Value", store.Value.ToString),
            (
                True,
                "Update",
                Function(x)
                    Dim value As Integer = 0
                    Return Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.Value = Integer.Parse(x)
                    Return New CharacterStatisticEditWindow(store)
                End Function
            ),
            (
                True,
                "Delete",
                Function()
                    Dim character = store.Character
                    store.Delete()
                    Return New CharacterStatisticListWindow(character)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterStatisticListWindow(store.Character)
            ))
    End Sub
End Class
