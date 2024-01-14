Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CardTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICardTypeStore)
        MyBase.New(
            $"Edit Card Type: {store.Name}",
            "Card Type",
            store.Id,
            ("Name", store.Name),
            (True, "Update",
            Function(x) store.CanRenameTo(x),
            Function(x)
                store.Name = x
                Return New CardTypeEditWindow(store)
            End Function),
            (store.CanDelete, "Delete",
            Function()
                store.Delete()
                Return New CardTypeListWindow(store.Store)
            End Function),
            ("Cancel", Function() New CardTypeListWindow(store.Store)))
    End Sub
End Class
