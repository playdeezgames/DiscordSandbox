Imports Microsoft.Data.SqlClient

Friend Class ItemTypeGeneratorStore
    Implements IItemTypeGeneratorStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly itemTypeGeneratorId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), itemTypeGeneratorId As Integer)
        Me.connectionSource = connectionSource
        Me.itemTypeGeneratorId = itemTypeGeneratorId
    End Sub

    Public ReadOnly Property Id As Integer Implements IItemTypeGeneratorStore.Id
        Get
            Return itemTypeGeneratorId
        End Get
    End Property

    Public Property Name As String Implements IItemTypeGeneratorStore.Name
        Get
            Return connectionSource.ReadStringForInteger(TABLE_ITEM_TYPE_GENERATORS, (COLUMN_ITEM_TYPE_GENERATOR_ID, itemTypeGeneratorId), COLUMN_ITEM_TYPE_GENERATOR_NAME)
        End Get
        Set(value As String)
            connectionSource.WriteStringForInteger(TABLE_ITEM_TYPE_GENERATORS, (COLUMN_ITEM_TYPE_GENERATOR_ID, itemTypeGeneratorId), (COLUMN_ITEM_TYPE_GENERATOR_NAME, value))
        End Set
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IItemTypeGeneratorStore.CanDelete
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IItemTypeGeneratorStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property

    Public Sub Delete() Implements IItemTypeGeneratorStore.Delete
        connectionSource.DeleteForInteger(TABLE_ITEM_TYPE_GENERATORS, (COLUMN_ITEM_TYPE_GENERATOR_ID, itemTypeGeneratorId))
    End Sub

    Public Function CanRenameTo(x As String) As Boolean Implements IItemTypeGeneratorStore.CanRenameTo
        Return Not connectionSource.FindIntegerForString(
            TABLE_ITEM_TYPE_GENERATORS,
            (COLUMN_ITEM_TYPE_GENERATOR_NAME, x),
            COLUMN_ITEM_TYPE_GENERATOR_ID).HasValue
    End Function
End Class
