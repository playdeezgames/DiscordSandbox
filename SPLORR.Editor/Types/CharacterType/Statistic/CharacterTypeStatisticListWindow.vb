Imports SPLORR.Data

Friend Class CharacterTypeStatisticListWindow
    Inherits BaseListWindow(Of ICharacterTypeStore, ICharacterTypeStatisticStore)

    Public Sub New(store As Data.ICharacterTypeStore)
        MyBase.New(
            $"Statistics for Character Type `{store.Name}`",
            store,
            Function(x, y) x.Statistics.Filter(y),
            Function(x)
                Dim minimum = x.Minimum
                Dim maximum = x.Maximum
                Return $"{x.Name}(Id:{x.Id},Value:{x.Value}{If(minimum.HasValue, $",Minimum:{minimum.Value}", "")}{If(maximum.HasValue, $",Maximum:{maximum.Value}", "")})"
            End Function,
            Function(x) New CharacterTypeEditStatisticWindow(x),
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterTypeEditWindow(store))
                ),
                (
                    "Add",
                    Function() store.CanAddStatistic,
                    Sub() Program.GoToWindow(New CharacterTypeAddStatisticTypeWindow(store))
                )
            })
    End Sub
End Class
