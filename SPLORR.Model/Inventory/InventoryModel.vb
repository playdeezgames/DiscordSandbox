Imports SPLORR.Data

Friend Class InventoryModel
    Implements IInventoryModel
    Public ReadOnly Property InventoryStore As IInventoryStore Implements IInventoryModel.InventoryStore
    Sub New(characterStore As ICharacterStore)
        inventoryStore = characterStore.Inventory
    End Sub
    Sub New(locationStore As ILocationStore)
        inventoryStore = locationStore.Inventory
    End Sub

    Public Sub Add(item As IItemModel) Implements IInventoryModel.Add
        item.ItemStore.Inventory = inventoryStore
    End Sub
End Class
