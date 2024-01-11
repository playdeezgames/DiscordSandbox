Imports SPLORR.Data

Friend Class InventoryAddItemWindow
    Inherits BaseListWindow(Of IInventoryStore, IItemTypeStore)

    Public Sub New(store As Data.IInventoryStore)
        MyBase.New(
            $"Add Item Type to Inventory for {If(store.HasCharacter, $"Character `{store.Character.Name}`", $"Location `{store.Location.Name}`")}",
            store,
            Function(x, y) x.Store.ItemTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                x.CreateItem(store)
                Return New InventoryEditWindow(store)
            End Function,
            AdditionalButtons:=
            {
                ("Cancel", Function() True, Sub() Program.GoToWindow(New InventoryEditWindow(store)))
            })
    End Sub
End Class
