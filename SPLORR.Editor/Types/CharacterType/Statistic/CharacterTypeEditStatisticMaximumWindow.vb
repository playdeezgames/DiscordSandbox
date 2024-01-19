Imports SPLORR.Data

Friend Class CharacterTypeEditStatisticMaximumWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterTypeStatisticStore)
        MyBase.New(
            $"Statistic `{store.Name}` for Character Type `{store.CharacterType.Name}`",
            "Character Type Statistic",
            ("Id", store.Id.ToString),
            ("Minimum Value", If(store.Maximum.HasValue, store.Maximum.Value.ToString, "")),
            (
                True,
                "Update",
                Function(x)
                    Dim value As Integer = 0
                    Return Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.Maximum = Integer.Parse(x)
                    Return New CharacterTypeEditStatisticWindow(store)
                End Function
            ),
            (
                True,
                "Clear",
                Function()
                    Dim characterType = store.CharacterType
                    store.Maximum = Nothing
                    Return New CharacterTypeEditStatisticWindow(store)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterTypeEditStatisticWindow(store)
            ))
    End Sub
End Class
