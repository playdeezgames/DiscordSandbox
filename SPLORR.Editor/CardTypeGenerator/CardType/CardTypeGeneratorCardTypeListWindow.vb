Imports SPLORR.Data

Friend Class CardTypeGeneratorCardTypeListWindow
    Inherits BaseListWindow(Of ICardTypeGeneratorStore, ICardTypeGeneratorCardTypeStore)
    Public Sub New(store As ICardTypeGeneratorStore)
        MyBase.New(
            $"Card Types for Card Type Generator `{store.Name}`",
            store,
            Function(x, y) x.CardTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id},Weight:{x.GeneratorWeight})",
            Function(x) New CardTypeGeneratorCardTypeEditWindow(x),
            {
                (
                    "Add",
                    Function() store.CanAddCardType,
                    Sub() Program.GoToWindow(New CardTypeGeneratorAddCardTypeWindow(store))
                ),
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CardTypeGeneratorEditWindow(store))
                )
            })
    End Sub
End Class
