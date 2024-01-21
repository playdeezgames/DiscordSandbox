Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CardTypeTagEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICardTypeTagStore)
        MyBase.New(
            $"Edit Tag For Card Type: {store.CardType.Name}",
            "Card Type Tag",
            ("Id", store.Id.ToString),
            ("Name", store.Name),
            (True, "Update",
            Function(x) store.CanRenameTo(x),
            Function(x)
                store.Name = x
                Return New CardTypeTagListWindow(store.CardType)
            End Function),
            (store.CanDelete, "Delete",
            Function()
                Dim cardType = store.CardType
                store.Delete()
                Return New CardTypeTagListWindow(cardType)
            End Function),
            ("Cancel", Function() New CardTypeTagListWindow(store.CardType)))
    End Sub
End Class
