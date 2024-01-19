Imports SPLORR.Data

Friend Class CharacterEditStatisticMaximumWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterStatisticStore)
        MyBase.New(
            $"Statistic `{store.Name}`",
            "Character Statistic",
            ("Character", $"{store.Character.Name}"),
            ("Maximum", If(store.Maximum.HasValue, store.Maximum.ToString, "")),
            (
                True,
                "Update",
                Function(x)
                    Dim value As Integer = 0
                    Return Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.Maximum = Integer.Parse(x)
                    Return New CharacterStatisticEditWindow(store)
                End Function
            ),
            (
                True,
                "Clear",
                Function()
                    store.Maximum = Nothing
                    Return New CharacterStatisticEditWindow(store)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterStatisticEditWindow(store)
            ))
    End Sub
End Class
