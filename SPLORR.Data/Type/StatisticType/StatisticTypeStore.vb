Imports Microsoft.Data.SqlClient

Friend Class StatisticTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements IStatisticTypeStore

    Public Sub New(
                  connectionSource As Func(Of SqlConnection),
                  id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_STATISTIC_TYPES,
            COLUMN_STATISTIC_TYPE_ID,
            COLUMN_STATISTIC_TYPE_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property
End Class
