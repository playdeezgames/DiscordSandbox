Imports SPLORR.Data

Friend Class CharacterTypeCardListWindow
    Inherits BaseListWindow(Of ICharacterTypeStore, ICharacterTypeCardStore)

    Public Sub New(store As Data.ICharacterTypeStore)
        MyBase.New(
            $"Cards for Character Type `{store.Name}`",
            store,
            Function(x, y) x.Cards.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id},Quantity:{x.Quantity})",
            Function(x) New CharacterTypeEditCardWindow(x),
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterTypeEditWindow(store))
                ),
                (
                    "Add",
                    Function() store.CanAddCard,
                    Sub() Program.GoToWindow(New CharacterTypeAddCardTypeWindow(store))
                )
            })
    End Sub
End Class
