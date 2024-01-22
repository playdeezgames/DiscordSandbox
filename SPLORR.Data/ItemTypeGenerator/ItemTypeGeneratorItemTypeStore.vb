Imports Microsoft.Data.SqlClient

Friend Class ItemTypeGeneratorItemTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements IItemTypeGeneratorItemTypeStore
    Const GENERATOR_WEIGHT_MINIMUM = 1

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_ITEM_TYPE_GENERATOR_ITEM_TYPE_DETAILS,
            COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID,
            COLUMN_ITEM_TYPE_NAME,
            New DataStore(connectionSource()),
            deleteTableName:=TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property ItemType As IItemTypeStore Implements IItemTypeGeneratorItemTypeStore.ItemType
        Get
            Return New ItemTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                VIEW_ITEM_TYPE_GENERATOR_ITEM_TYPE_DETAILS,
                {(COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id)},
                COLUMN_ITEM_TYPE_ID))
        End Get
    End Property

    Public Property GeneratorWeight As Integer Implements IItemTypeGeneratorItemTypeStore.GeneratorWeight
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                {(COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id)},
                COLUMN_GENERATOR_WEIGHT)
        End Get
        Set(value As Integer)
            connectionSource.WriteValuesForValues(
                TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                {(COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id)},
                {(COLUMN_GENERATOR_WEIGHT, Math.Max(value, GENERATOR_WEIGHT_MINIMUM))})
        End Set
    End Property

    Public ReadOnly Property ItemTypeGenerator As IItemTypeGeneratorStore Implements IItemTypeGeneratorItemTypeStore.ItemTypeGenerator
        Get
            Return New ItemTypeGeneratorStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                    {(COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID, Id)},
                    COLUMN_ITEM_TYPE_GENERATOR_ID))
        End Get
    End Property
End Class
