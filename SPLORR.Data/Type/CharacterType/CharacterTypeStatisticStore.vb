Imports Microsoft.Data.SqlClient

Friend Class CharacterTypeStatisticStore
    Inherits BaseTypeStore
    Implements ICharacterTypeStatisticStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(connectionSource, id, VIEW_CHARACTER_TYPE_STATISTIC_DETAILS, COLUMN_CHARACTER_TYPE_STATISTIC_ID, COLUMN_STATISTIC_TYPE_NAME, TABLE_CHARACTER_TYPE_STATISTICS)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property Value As Integer Implements ICharacterTypeStatisticStore.Value
        Get
            Return connectionSource.ReadIntegerForValue(TABLE_CHARACTER_TYPE_STATISTICS, (COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id), COLUMN_STATISTIC_VALUE)
        End Get
        Set(value As Integer)
            connectionSource.WriteValueForInteger(
                TABLE_CHARACTER_TYPE_STATISTICS,
                (COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id),
                (COLUMN_STATISTIC_VALUE, value))
        End Set
    End Property

    Public ReadOnly Property CharacterType As ICharacterTypeStore Implements ICharacterTypeStatisticStore.CharacterType
        Get
            Return New CharacterTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValue(
                    TABLE_CHARACTER_TYPE_STATISTICS,
                    (COLUMN_CHARACTER_TYPE_STATISTIC_ID, Id),
                    COLUMN_CHARACTER_TYPE_ID))
        End Get
    End Property
End Class
