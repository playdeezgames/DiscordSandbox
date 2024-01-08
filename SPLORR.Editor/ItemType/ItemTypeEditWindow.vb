Imports SPLORR.Data

Friend Class ItemTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(itemTypeStore As IItemTypeStore)
        MyBase.New(
            $"Edit Item Type: {itemTypeStore.Name}",
            "Item Type",
            itemTypeStore.Id,
            ("Name", itemTypeStore.Name),
            itemTypeStore.CanDelete,
            Function(x) itemTypeStore.CanRenameTo(x),
            Function() New ItemTypeListWindow(itemTypeStore.Store),
            Function()
                itemTypeStore.Delete()
                Return New ItemTypeListWindow(itemTypeStore.Store)
            End Function,
            Function(x)
                itemTypeStore.Name = x
                Return New ItemTypeEditWindow(itemTypeStore)
            End Function)
    End Sub
End Class
