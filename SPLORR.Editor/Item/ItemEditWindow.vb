Imports SPLORR.Data

Friend Class ItemEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As IItemStore)
        MyBase.New(
            $"Edit Item: {store.Name}",
            "Item",
            store.Id,
            ("Name", store.Name),
            store.CanDelete,
            Function(x) False,
            Function() New ItemListWindow(store.Store),
            Function()
                store.Delete()
                Return New ItemListWindow(store.Store)
            End Function,
            Function(x)
                Return New ItemEditWindow(store)
            End Function)
    End Sub
End Class
