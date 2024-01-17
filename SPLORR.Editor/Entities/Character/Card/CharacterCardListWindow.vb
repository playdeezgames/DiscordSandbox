Imports SPLORR.Data

Friend Class CharacterCardListWindow
    Inherits BaseListWindow(Of ICharacterStore, ICardStore)

    Public Sub New(store As Data.ICharacterStore)
        MyBase.New(
            $"Cards for Character `{store.Name}`",
            store,
            Function(x, y) x.Cards.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CardEditWindow(x),
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
                    "Add Card...",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterAddCardTypeWindow(store))
                )
            })
    End Sub
End Class
