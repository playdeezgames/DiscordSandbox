Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterAddCardTypeWindow
    Inherits BaseListWindow(Of ICharacterStore, ICardTypeStore)

    Public Sub New(store As ICharacterStore)
        MyBase.New(
            $"Add Card for `{store.Name}`",
            store,
            Function(x, y) x.Store.CardTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                x.CreateCard(store)
                Return New CharacterCardListWindow(store)
            End Function)
    End Sub
End Class
