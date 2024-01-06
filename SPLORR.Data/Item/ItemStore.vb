﻿Imports Microsoft.Data.SqlClient

Friend Class ItemStore
    Implements IItemStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly itemId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), itemId As Integer)
        Me.connectionSource = connectionSource
        Me.itemId = itemId
    End Sub

    Public ReadOnly Property Name As String Implements IItemStore.Name
        Get
            Return connectionSource.ReadStringForInteger(
                VIEW_ITEM_NAMES,
                (COLUMN_ITEM_ID, itemId),
                COLUMN_ITEM_NAME)
        End Get
    End Property

    Public Property Inventory As IInventoryStore Implements IItemStore.Inventory
        Get
            Return New InventoryStore(
                connectionSource,
                connectionSource.ReadIntegerForInteger(
                    TABLE_ITEMS,
                    (COLUMN_ITEM_ID, itemId),
                    COLUMN_INVENTORY_ID))
        End Get
        Set(value As IInventoryStore)
            connectionSource.WriteValueForInteger(
                TABLE_ITEMS,
                (COLUMN_ITEM_ID, itemId),
                (COLUMN_INVENTORY_ID, value.Id))
        End Set
    End Property
End Class