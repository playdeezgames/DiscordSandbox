Imports Microsoft.Data.SqlClient

Friend Class ItemTypeGeneratorStore
    Inherits BaseTypeStore
    Implements IItemTypeGeneratorStore

    Public Sub New(connectionSource As Func(Of SqlConnection), itemTypeGeneratorId As Integer)
        MyBase.New(
            connectionSource,
            itemTypeGeneratorId,
            TABLE_ITEM_TYPE_GENERATORS,
            COLUMN_ITEM_TYPE_GENERATOR_ID,
            COLUMN_ITEM_TYPE_GENERATOR_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForInteger(
                TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_GENERATOR_ID, Id))
        End Get
    End Property
End Class
