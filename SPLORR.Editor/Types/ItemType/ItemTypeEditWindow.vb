Imports SPLORR.Data

Friend Class ItemTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As IItemTypeStore)
        MyBase.New(
            $"Edit Item Type: {store.Name}",
            "Item Type",
            store.Id,
            ("Name", store.Name),
            True,
            (store.CanDelete, "Delete",
            Function()
                store.Delete()
                Return New ItemTypeListWindow(store.Store)
            End Function),
            Function(x) store.CanRenameTo(x),
            ("Cancel", Function() New ItemTypeListWindow(store.Store)),
            Function(x)
                store.Name = x
                Return New ItemTypeEditWindow(store)
            End Function)
    End Sub
End Class
