Imports SPLORR.Data

Friend Class CardTypeListWindow
    Inherits BaseListWindow(Of IDataStore, ICardTypeStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Card Types",
            store,
            Function(x, y) x.CardTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CardTypeEditWindow(x),
            {
                (
                    "Add...",
                    Function() True,
                    Sub() Program.GoToWindow(New CardTypeAddWindow(store))
                ),
                (
                    "Close",
                    Function() True,
                    Sub() Program.GoToWindow(Nothing)
                )
            })
    End Sub
End Class
