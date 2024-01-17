Imports Microsoft.Data.SqlClient

Friend Class InventoryStore
    Implements IInventoryStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Public ReadOnly Property Id As Integer Implements IInventoryStore.Id

    Public ReadOnly Property HasItems As Boolean Implements IInventoryStore.HasItems
        Get
            Return connectionSource.CheckForValues(TABLE_ITEMS, (COLUMN_INVENTORY_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Items As IRelatedTypeStore(Of IItemStore) Implements IInventoryStore.Items
        Get
            Return New RelatedTypeStore(Of IItemStore, Integer)(
                connectionSource,
                VIEW_ITEM_DETAILS,
                COLUMN_ITEM_ID,
                COLUMN_ITEM_NAME,
                (COLUMN_INVENTORY_ID, Id),
                Function(x, y) New ItemStore(x, y))
        End Get
    End Property

    Public ReadOnly Property HasCharacter As Boolean Implements IInventoryStore.HasCharacter
        Get
            Return connectionSource.FindIntegerForValue(TABLE_INVENTORIES, (COLUMN_INVENTORY_ID, Id), COLUMN_CHARACTER_ID).HasValue
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterStore Implements IInventoryStore.Character
        Get
            Dim characterId = connectionSource.FindIntegerForValue(TABLE_INVENTORIES, (COLUMN_INVENTORY_ID, Id), COLUMN_CHARACTER_ID)
            If characterId.HasValue Then
                Return New CharacterStore(connectionSource, characterId.Value)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Location As ILocationStore Implements IInventoryStore.Location
        Get
            Dim locationId = connectionSource.FindIntegerForValue(TABLE_INVENTORIES, (COLUMN_INVENTORY_ID, Id), COLUMN_LOCATION_ID)
            If locationId.HasValue Then
                Return New LocationStore(connectionSource, locationId.Value)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IInventoryStore.CanDelete
        Get
            Return Not connectionSource.CheckForValues(TABLE_ITEMS, (COLUMN_INVENTORY_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IInventoryStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property

    Public Sub New(connectionSource As Func(Of SqlConnection), inventoryId As Integer)
        Me.connectionSource = connectionSource
        Me.Id = inventoryId
    End Sub

    Public Function ItemsByName(itemName As String) As IEnumerable(Of IItemStore) Implements IInventoryStore.ItemsByName
        Return connectionSource.ReadIntegersForValues(
            VIEW_ITEM_DETAILS,
            (COLUMN_INVENTORY_ID, Id),
            (COLUMN_ITEM_NAME, itemName),
            COLUMN_ITEM_ID).
            Select(Function(x) New ItemStore(connectionSource, x))
    End Function

    Public Sub Delete() Implements IInventoryStore.Delete
        connectionSource.DeleteForValue(TABLE_INVENTORIES, (COLUMN_INVENTORY_ID, Id))
    End Sub

    Public Function ItemTypeCount(itemType As IItemTypeStore) As Integer Implements IInventoryStore.ItemTypeCount
        Return If(
            connectionSource.FindIntegerForValues(
                VIEW_INVENTORY_ITEM_TYPE_COUNTS,
                (COLUMN_INVENTORY_ID, Id),
                (COLUMN_ITEM_TYPE_ID, itemType.Id),
                COLUMN_ITEM_TYPE_COUNT),
            0)
    End Function

    Public Function ItemsByType(itemType As IItemTypeStore) As IEnumerable(Of IItemStore) Implements IInventoryStore.ItemsByType
        Return connectionSource.ReadIntegersForValues(
            TABLE_ITEMS,
            (COLUMN_INVENTORY_ID, Id),
            (COLUMN_ITEM_TYPE_ID, itemType.Id),
            COLUMN_ITEM_ID).
            Select(Function(x) New ItemStore(connectionSource, x))
    End Function
End Class
