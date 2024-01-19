Imports SPLORR.Data

Friend Class CharacterTypeEditStatisticMinimumWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterTypeStatisticStore)
        MyBase.New(
            $"Statistic `{store.Name}` for Character Type `{store.CharacterType.Name}`",
            "Character Type Statistic",
            ("Id", store.Id.ToString),
            ("Minimum Value", If(store.Minimum.HasValue, store.Minimum.Value.ToString, "")),
            (
                True,
                "Update",
                Function(x)
                    Dim value As Integer = 0
                    Return Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.Minimum = Integer.Parse(x)
                    Return New CharacterTypeEditStatisticWindow(store)
                End Function
            ),
            (
                True,
                "Clear",
                Function()
                    Dim characterType = store.CharacterType
                    store.Minimum = Nothing
                    Return New CharacterTypeEditStatisticWindow(store)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterTypeEditStatisticWindow(store)
            ))
    End Sub
End Class
