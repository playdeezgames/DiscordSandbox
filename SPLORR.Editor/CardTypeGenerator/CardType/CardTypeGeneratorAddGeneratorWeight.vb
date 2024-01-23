Imports SPLORR.Data

Friend Class CardTypeGeneratorAddGeneratorWeight
    Inherits BaseAddTypeWindow

    Public Sub New(store As ICardTypeGeneratorStore, cardType As ICardTypeStore)
        MyBase.New(
            $"Generator Weight for Card Type `{cardType.Name}` for Generator `{store.Name}`",
            "Generator Weight must be greater than zero!",
            (
                "Add",
                Function(x) False,
                Function(x) New CardTypeGeneratorCardTypeEditWindow(store.AddCardType(cardType, Integer.Parse(x)))
            ),
            (
                "Cancel",
                Function() New CardTypeGeneratorEditWindow(store)
            ))
    End Sub
End Class
