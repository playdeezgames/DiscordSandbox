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
            ),
            {
                (
                    $"Minimum: {If(store.Minimum.HasValue, store.Minimum.Value.ToString, "n/a")}",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterEditStatisticMinimumWindow(store))
                ),
                (
                    $"Maximum: {If(store.Maximum.HasValue, store.Maximum.Value.ToString, "n/a")}",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterEditStatisticMaximumWindow(store))
                )
            })
    End Sub
End Class
