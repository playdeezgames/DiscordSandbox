Imports Microsoft.Data.SqlClient

Friend Class StatisticTypeStore
    Inherits BaseTypeStore
    Implements IStatisticTypeStore

    Public Sub New(
                  connectionSource As Func(Of SqlConnection),
                  id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_STATISTIC_TYPES,
            COLUMN_STATISTIC_TYPE_ID,
            COLUMN_STATISTIC_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return HasDeltas
        End Get
    End Property


    Private ReadOnly Property HasDeltas As Boolean
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                (COLUMN_STATISTIC_TYPE_ID, Id))
        End Get
    End Property

End Class
