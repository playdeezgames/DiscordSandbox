Imports SPLORR.Data

Friend Class ItemEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As IItemStore)
        MyBase.New(
            $"Edit Item: {store.Name}",
            "Item",
            store.Id,
            ("Name", store.Name),
            (False, Nothing, Nothing, Nothing),
            (store.CanDelete, "Delete",
            Function()
                store.Delete()
                Return New ItemListWindow(store.Store)
            End Function),
            ("Cancel", Function() New ItemListWindow(store.Store)),
            {
                (
                    "Inventory",
                    Function() True,
                    Sub() Program.GoToWindow(New InventoryEditWindow(store.Inventory))
                ),
                (
                    "Delete from Inventory",
                    Function() store.CanDelete,
                    Sub()
                        Dim inventory = store.Inventory
                        store.Delete()
                        Program.GoToWindow(New InventoryEditWindow(inventory))
                    End Sub
                ),
                (
                    $"Item Type: {store.ItemType.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New ItemEditItemTypeWindow(store))
                )
            })
    End Sub
End Class
