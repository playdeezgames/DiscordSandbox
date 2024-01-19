Imports SPLORR.Data

Friend Class CharacterEditStatisticMinimumWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterStatisticStore)
        MyBase.New(
            $"Statistic `{store.Name}`",
            "Character Statistic",
            ("Character", $"{store.Character.Name}"),
            ("Minimum", If(store.Minimum.HasValue, store.Minimum.ToString, "")),
            (
                True,
                "Update",
                Function(x)
                    Dim value As Integer = 0
                    Return Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.Minimum = Integer.Parse(x)
                    Return New CharacterStatisticEditWindow(store)
                End Function
            ),
            (
                True,
                "Clear",
                Function()
                    store.Minimum = Nothing
                    Return New CharacterStatisticEditWindow(store)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterStatisticEditWindow(store)
            ))
    End Sub
End Class
