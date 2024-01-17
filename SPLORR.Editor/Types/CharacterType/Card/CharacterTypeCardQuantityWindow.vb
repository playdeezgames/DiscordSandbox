Imports SPLORR.Data

Friend Class CharacterTypeCardQuantityWindow
    Inherits BaseAddTypeWindow

    Public Sub New(store As ICharacterTypeStore, cardType As ICardTypeStore)
        MyBase.New(
            $"Quantity for Card `{cardType.Name}` for Character Type `{store.Name}`",
            $"Must be an integer!",
            (
                "Add",
                Function(x)
                    Dim value As Integer = 0
                    Return Not Integer.TryParse(x, value)
                End Function,
                Function(x)
                    store.AddCard(cardType, Integer.Parse(x))
                    Return New CharacterTypeCardListWindow(store)
                End Function
            ),
            (
                "Cancel",
                Function() New CharacterTypeCardListWindow(store)
            ))
    End Sub
End Class
