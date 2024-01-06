Imports SPLORR.Data

Friend Class InventoryModel
    Implements IInventoryModel
    Private ReadOnly inventoryStore As IInventoryStore
    Sub New(characterStore As ICharacterStore)
        inventoryStore = characterStore.Inventory
    End Sub
    Sub New(locationStore As ILocationStore)
        inventoryStore = locationStore.Inventory
    End Sub
End Class
