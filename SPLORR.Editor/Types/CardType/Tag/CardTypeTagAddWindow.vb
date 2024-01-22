Friend Class CardTypeTagAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(store As Data.ICardTypeStore)
        MyBase.New(
            $"Add Tag to Card Type `{store.Name}`",
            "Tag for Card Type be unique!",
            ("Add", Function(x) String.IsNullOrEmpty(x) OrElse store.TagExists(x),
            Function(x) New CardTypeTagEditWindow(store.CreateTag(x))),
            ("Cancel", Function() New CardTypeTagListWindow(store)))
    End Sub
End Class
