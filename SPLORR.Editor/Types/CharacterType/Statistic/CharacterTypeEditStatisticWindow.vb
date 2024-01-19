Imports SPLORR.Data

Friend Class CharacterTypeEditStatisticWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterTypeStatisticStore)
        MyBase.New(
            $"Statistic `{store.Name}` for Character Type `{store.CharacterType.Name}`",
            "Character Type Statistic",
            ("Id", store.Id.ToString),
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
                    Return New CharacterTypeEditStatisticWindow(store)
                End Function
            ),
            (
                True,
                "Delete",
                Function()
                    Dim characterType = store.CharacterType
                    store.Delete()
                    Return New CharacterTypeStatisticListWindow(characterType)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterTypeStatisticListWindow(store.CharacterType)
            ),
            {
                (
                    $"Minimum: {If(store.Minimum.HasValue, store.Minimum.Value.ToString, "n/a")}",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterTypeEditStatisticMinimumWindow(store))
                ),
                (
                    $"Maximum: {If(store.Maximum.HasValue, store.Maximum.Value.ToString, "n/a")}",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterTypeEditStatisticMaximumWindow(store))
                )
            })
    End Sub
End Class
