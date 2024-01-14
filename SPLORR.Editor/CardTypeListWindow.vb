Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CardTypeListWindow
    Inherits BaseListWindow(Of IDataStore, ICardTypeStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Card Types",
            store,
            Function(x, y) x.CardTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) Nothing,
            {
                (
                    "Close",
                    Function() True,
                    Sub() Program.GoToWindow(Nothing)
                )
            })
    End Sub
End Class
