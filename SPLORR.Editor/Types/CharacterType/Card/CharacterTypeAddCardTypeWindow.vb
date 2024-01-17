Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterTypeAddCardTypeWindow
    Inherits BaseListWindow(Of ICharacterTypeStore, ICardTypeStore)

    Public Sub New(store As ICharacterTypeStore)
        MyBase.New(
            $"Add Card for Character Type {store.Name}",
            store,
            Function(x, y) x.AvailableCards.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CharacterTypeCardQuantityWindow(store, x))
    End Sub
End Class
