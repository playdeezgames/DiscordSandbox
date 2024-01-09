Imports SPLORR.Data

Friend Class ItemModel
    Implements IItemModel

    Public ReadOnly Property ItemStore As IItemStore Implements IItemModel.ItemStore

    Public Sub New(itemStore As IItemStore)
        Me.itemStore = itemStore
    End Sub

    Public ReadOnly Property Name As String Implements IItemModel.Name
        Get
            Return ItemStore.Name
        End Get
    End Property

    Public Property Inventory As IInventoryModel Implements IItemModel.Inventory
        Get
            Return New InventoryModel(ItemStore.Inventory)
        End Get
        Set(value As IInventoryModel)
            ItemStore.Inventory = value.InventoryStore
        End Set
    End Property
End Class
