Imports SPLORR.Data

Friend Class ItemTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As IItemTypeStore)
        MyBase.New(
            $"Edit Item Type: {store.Name}",
            "Item Type",
            store.Id,
            ("Name", store.Name),
            (True, "Update",
            Function(x) store.CanRenameTo(x),
            Function(x)
                store.Name = x
                Return New ItemTypeEditWindow(store)
            End Function),
            (store.CanDelete, "Delete",
            Function()
                store.Delete()
                Return New ItemTypeListWindow(store.Store)
            End Function),
            ("Cancel", Function() New ItemTypeListWindow(store.Store)))
    End Sub
End Class
