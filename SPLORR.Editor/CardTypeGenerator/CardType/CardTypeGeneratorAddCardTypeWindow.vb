Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CardTypeGeneratorAddCardTypeWindow
    Inherits BaseListWindow(Of ICardTypeGeneratorStore, ICardTypeStore)
    Public Sub New(store As ICardTypeGeneratorStore)
        MyBase.New(
            $"Add Card Type to Card Type Generator `{store.Name}`",
            store,
            Function(x, y) x.AvailableCardTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CardTypeGeneratorAddGeneratorWeight(store, x),
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CardTypeGeneratorEditWindow(store))
                )
            })
    End Sub
End Class
