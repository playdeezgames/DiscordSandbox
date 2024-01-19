Imports Microsoft.Data.SqlClient

Friend Class CharacterStatisticStore
    Inherits BaseTypeStore
    Implements ICharacterStatisticStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_CHARACTER_STATISTIC_DETAILS,
            COLUMN_CHARACTER_STATISTIC_ID,
            COLUMN_STATISTIC_TYPE_NAME,
            TABLE_CHARACTER_STATISTICS)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property Value As Integer Implements ICharacterStatisticStore.Value
        Get
            Return connectionSource.ReadIntegerForValues(
                    TABLE_CHARACTER_STATISTICS,
                    {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                    COLUMN_STATISTIC_VALUE)
        End Get
        Set(value As Integer)
            connectionSource.WriteValuesForValues(
                    TABLE_CHARACTER_STATISTICS,
                    {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                    {(COLUMN_STATISTIC_VALUE, value)})
        End Set
    End Property

    Public ReadOnly Property Character As ICharacterStore Implements ICharacterStatisticStore.Character
        Get
            Return New CharacterStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CHARACTER_STATISTICS,
                    {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                    COLUMN_CHARACTER_ID))
        End Get
    End Property

    Public Property Minimum As Integer? Implements ICharacterStatisticStore.Minimum
        Get
            Return connectionSource.ReadIntegerForValues(
                    TABLE_CHARACTER_STATISTICS,
                    {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                    COLUMN_MINIMUM_VALUE)
        End Get
        Set(value As Integer?)
            If Not value.HasValue Then
                connectionSource.ClearColumnForValues(
                    TABLE_CHARACTER_STATISTICS,
                    {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                    COLUMN_MINIMUM_VALUE)
                Return
            End If
            connectionSource.WriteValuesForValues(
                TABLE_CHARACTER_STATISTICS,
                {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                {(COLUMN_MINIMUM_VALUE, value.Value)})
        End Set
    End Property

    Public Property Maximum As Integer? Implements ICharacterStatisticStore.Maximum
        Get
            Return connectionSource.ReadIntegerForValues(
                    TABLE_CHARACTER_STATISTICS,
                    {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                    COLUMN_MAXIMUM_VALUE)
        End Get
        Set(value As Integer?)
            If Not value.HasValue Then
                connectionSource.ClearColumnForValues(
                    TABLE_CHARACTER_STATISTICS,
                    {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                    COLUMN_MAXIMUM_VALUE)
                Return
            End If
            connectionSource.WriteValuesForValues(
                TABLE_CHARACTER_STATISTICS,
                {(COLUMN_CHARACTER_STATISTIC_ID, Id)},
                {(COLUMN_MAXIMUM_VALUE, value.Value)})
        End Set
    End Property
End Class
