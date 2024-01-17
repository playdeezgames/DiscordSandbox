Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterStatisticListWindow
    Inherits BaseListWindow(Of ICharacterStore, ICharacterStatisticStore)

    Public Sub New(store As Data.ICharacterStore)
        MyBase.New(
            $"Statistics for Character `{store.Name}`",
            store,
            Function(x, y) x.Statistics.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CharacterStatisticEditWindow(x),
            AdditionalButtons:=
            {
                (
                    "Close",
                    Function() True,
                    Sub()
                        Program.GoToWindow(New CharacterEditWindow(store))
                    End Sub
                ),
                (
                    "Add Statistic...",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterAddStatisticTypeWindow(store))
                )
            })
    End Sub
End Class
