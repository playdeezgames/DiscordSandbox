﻿Imports Microsoft.Data.SqlClient

Friend Class ItemTypeGeneratorItemTypeStore
    Inherits BaseTypeStore
    Implements IItemTypeGeneratorItemTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(connectionSource, id, VIEW_ITEM_TYPE_GENERATOR_ITEM_TYPE_DETAILS, COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, COLUMN_ITEM_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property ItemType As IItemTypeStore Implements IItemTypeGeneratorItemTypeStore.ItemType
        Get
            Return New ItemTypeStore(connectionSource, connectionSource.ReadIntegerForInteger(VIEW_ITEM_TYPE_GENERATOR_ITEM_TYPE_DETAILS, (COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id), COLUMN_ITEM_TYPE_ID))
        End Get
    End Property
End Class