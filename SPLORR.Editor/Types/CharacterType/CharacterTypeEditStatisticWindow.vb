Imports SPLORR.Data

Friend Class CharacterTypeEditStatisticWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterTypeStatisticStore)
        MyBase.New(
            $"Statistic `{store.Name}` for Character Type `{store.CharacterType.Name}`",
            "Character Type Statistic",
            store.Id,
            ("Value", store.Value.ToString),
            (
                True,
                "Update",
                Function(x)
                    Dim value As Integer = 0
                    Return Not Integer.TryParse(x, value)
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
                    Return New CharacterTypeStatisticsListWindow(characterType)
                End Function
            ),
            (
                "Cancel",
                Function() Nothing
            ))
    End Sub
End Class
