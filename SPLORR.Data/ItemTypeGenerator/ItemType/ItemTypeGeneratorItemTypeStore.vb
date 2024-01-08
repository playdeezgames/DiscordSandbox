Imports Microsoft.Data.SqlClient

Friend Class ItemTypeGeneratorItemTypeStore
    Inherits BaseTypeStore
    Implements IItemTypeGeneratorItemTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_ITEM_TYPE_GENERATOR_ITEM_TYPE_DETAILS,
            COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID,
            COLUMN_ITEM_TYPE_NAME,
            deleteTableName:=TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property ItemType As IItemTypeStore Implements IItemTypeGeneratorItemTypeStore.ItemType
        Get
            Return New ItemTypeStore(connectionSource, connectionSource.ReadIntegerForValue(VIEW_ITEM_TYPE_GENERATOR_ITEM_TYPE_DETAILS, (COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id), COLUMN_ITEM_TYPE_ID))
        End Get
    End Property

    Public Property GeneratorWeight As Integer Implements IItemTypeGeneratorItemTypeStore.GeneratorWeight
        Get
            Return connectionSource.ReadIntegerForValue(
                TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id),
                COLUMN_GENERATOR_WEIGHT)
        End Get
        Set(value As Integer)
            connectionSource.WriteValueForInteger(
                TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id),
                (COLUMN_GENERATOR_WEIGHT, value))
        End Set
    End Property

    Public ReadOnly Property ItemTypeGenerator As IItemTypeGeneratorStore Implements IItemTypeGeneratorItemTypeStore.ItemTypeGenerator
        Get
            Return New ItemTypeGeneratorStore(connectionSource, connectionSource.ReadIntegerForValue(Of Integer)(TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES, (COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id), COLUMN_ITEM_TYPE_GENERATOR_ID))
        End Get
    End Property
End Class
