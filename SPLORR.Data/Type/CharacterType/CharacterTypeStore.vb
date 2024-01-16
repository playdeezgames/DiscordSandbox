Imports Microsoft.Data.SqlClient

Friend Class CharacterTypeStore
    Inherits BaseTypeStore
    Implements ICharacterTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CHARACTER_TYPES,
            COLUMN_CHARACTER_TYPE_ID,
            COLUMN_CHARACTER_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForValue(TABLE_CHARACTERS, (COLUMN_CHARACTER_TYPE_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Statistics As IRelatedTypeStore(Of ICharacterTypeStatisticStore) Implements ICharacterTypeStore.Statistics
        Get
            Return New RelatedTypeStore(Of ICharacterTypeStatisticStore, Integer)(
                connectionSource,
                VIEW_CHARACTER_TYPE_STATISTIC_DETAILS,
                COLUMN_CHARACTER_TYPE_STATISTIC_ID,
                COLUMN_STATISTIC_TYPE_NAME,
                (COLUMN_CHARACTER_TYPE_ID, Id),
                Function(x, y) New CharacterTypeStatisticStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CanAddStatistic As Boolean Implements ICharacterTypeStore.CanAddStatistic
        Get
            Return connectionSource.CheckForValue(
                VIEW_CHARACTER_TYPE_AVAILABLE_STATISTIC_TYPES,
                (COLUMN_CHARACTER_TYPE_ID, Id))
        End Get
    End Property

    Public ReadOnly Property AvailableStatistics As IRelatedTypeStore(Of IStatisticTypeStore) Implements ICharacterTypeStore.AvailableStatistics
        Get
            Return New RelatedTypeStore(Of IStatisticTypeStore, Integer)(
                connectionSource,
                VIEW_CHARACTER_TYPE_AVAILABLE_STATISTIC_TYPES,
                COLUMN_STATISTIC_TYPE_ID,
                COLUMN_STATISTIC_TYPE_NAME,
                (COLUMN_CHARACTER_TYPE_ID, Id),
                Function(x, y) New StatisticTypeStore(x, y))
        End Get
    End Property

    Public Function CreateCharacter(name As String, location As ILocationStore) As ICharacterStore Implements ICharacterTypeStore.CreateCharacter
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_CHARACTERS}
    (
        {COLUMN_CHARACTER_NAME},
        {COLUMN_CHARACTER_TYPE_ID},
        {COLUMN_LOCATION_ID}
    ) 
    VALUES 
    (
        {PARAMETER_CHARACTER_NAME},
        {PARAMETER_CHARACTER_TYPE_ID},
        {PARAMETER_LOCATION_ID}
    );"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_NAME, name)
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_TYPE_ID, Id)
            command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, location.Id)
            command.ExecuteNonQuery()
        End Using
        Return New CharacterStore(connectionSource, connectionSource.ReadLastIdentity)
    End Function

    Public Function AddStatistic(statisticType As IStatisticTypeStore, statisticValue As Integer) As ICharacterTypeStatisticStore Implements ICharacterTypeStore.AddStatistic
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_CHARACTER_TYPE_STATISTICS}
    (
        {COLUMN_CHARACTER_TYPE_ID},
        {COLUMN_STATISTIC_TYPE_ID},
        {COLUMN_STATISTIC_VALUE}
    ) 
VALUES 
    (
        @{COLUMN_CHARACTER_TYPE_ID},
        @{COLUMN_STATISTIC_TYPE_ID},
        @{COLUMN_STATISTIC_VALUE}
    );"
            command.Parameters.AddWithValue($"@{COLUMN_CHARACTER_TYPE_ID}", Id)
            command.Parameters.AddWithValue($"@{COLUMN_STATISTIC_TYPE_ID}", statisticType.Id)
            command.Parameters.AddWithValue($"@{COLUMN_STATISTIC_VALUE}", statisticValue)
            command.ExecuteNonQuery()
        End Using
        Return New CharacterTypeStatisticStore(connectionSource, connectionSource.ReadLastIdentity)
    End Function
End Class
