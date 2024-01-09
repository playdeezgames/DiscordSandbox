Imports SPLORR.Data

Friend Class InventoryModel
    Implements IInventoryModel
    Public ReadOnly Property InventoryStore As IInventoryStore Implements IInventoryModel.InventoryStore

    Public ReadOnly Property HasItems As Boolean Implements IInventoryModel.HasItems
        Get
            Return InventoryStore.HasItems
        End Get
    End Property

    Public ReadOnly Property Items As IEnumerable(Of IItemModel) Implements IInventoryModel.Items
        Get
            Return InventoryStore.Items.Select(Function(x) New ItemModel(x))
        End Get
    End Property

    Sub New(characterStore As ICharacterStore)
        InventoryStore = characterStore.Inventory
    End Sub
    Sub New(locationStore As ILocationStore)
        inventoryStore = locationStore.Inventory
    End Sub

    Public Sub Add(item As IItemModel) Implements IInventoryModel.Add
        item.ItemStore.Inventory = inventoryStore
    End Sub
End Class
