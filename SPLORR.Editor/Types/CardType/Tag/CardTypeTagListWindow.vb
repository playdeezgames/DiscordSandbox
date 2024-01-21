Imports SPLORR.Data

Friend Class CardTypeTagListWindow
    Inherits BaseListWindow(Of ICardTypeStore, ICardTypeTagStore)

    Public Sub New(store As Data.ICardTypeStore)
        MyBase.New(
            $"Tags for Card Type `{store.Name}`",
            store,
            Function(x, y) x.Tags.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CardTypeTagEditWindow(x),
            {
                (
                    "Add...",
                    Function() True,
                    Sub() Program.GoToWindow(New CardTypeTagAddWindow(store))
                ),
                (
                    "Close",
                    Function() True,
                    Sub() Program.GoToWindow(New CardTypeEditWindow(store))
                )
            })
    End Sub
End Class
