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
            Return Not connectionSource.CheckForValues(TABLE_CHARACTERS, (COLUMN_CHARACTER_TYPE_ID, Id))
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
            Return connectionSource.CheckForValues(
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

    Public ReadOnly Property Cards As IRelatedTypeStore(Of ICharacterTypeCardStore) Implements ICharacterTypeStore.Cards
        Get
            Return New RelatedTypeStore(Of ICharacterTypeCardStore, Integer)(
                connectionSource,
                VIEW_CHARACTER_TYPE_CARD_DETAILS,
                COLUMN_CHARACTER_TYPE_CARD_ID,
                COLUMN_CARD_TYPE_NAME,
                (COLUMN_CHARACTER_TYPE_ID, Id),
                Function(x, y) New CharacterTypeCardStore(x, y))
        End Get
    End Property

    Public ReadOnly Property AvailableCards As IRelatedTypeStore(Of ICardTypeStore) Implements ICharacterTypeStore.AvailableCards
        Get
            Return New RelatedTypeStore(Of ICardTypeStore, Integer)(
                connectionSource,
                VIEW_CHARACTER_TYPE_AVAILABLE_CARD_TYPES,
                COLUMN_CARD_TYPE_ID,
                COLUMN_CARD_TYPE_NAME,
                (COLUMN_CHARACTER_TYPE_ID, Id),
                Function(x, y) New CardTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CanAddCard As Boolean Implements ICharacterTypeStore.CanAddCard
        Get
            Return connectionSource.CheckForValues(
                VIEW_CHARACTER_TYPE_AVAILABLE_CARD_TYPES,
                (COLUMN_CHARACTER_TYPE_ID, Id))
        End Get
    End Property

    Public Function CreateCharacter(name As String, location As ILocationStore) As ICharacterStore Implements ICharacterTypeStore.CreateCharacter
        Return New CharacterStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CHARACTERS,
                (COLUMN_CHARACTER_NAME, name),
                (COLUMN_CHARACTER_TYPE_ID, Id),
                (COLUMN_LOCATION_ID, location.Id)))
    End Function

    Public Function AddStatistic(statisticType As IStatisticTypeStore, statisticValue As Integer, minimumValue As Integer?, maximumValue As Integer?) As ICharacterTypeStatisticStore Implements ICharacterTypeStore.AddStatistic
        Dim columns As New List(Of (String, Object)) From
            {
                (COLUMN_CHARACTER_TYPE_ID, Id),
                (COLUMN_STATISTIC_TYPE_ID, statisticType.Id),
                (COLUMN_STATISTIC_VALUE, statisticValue)
            }
        If minimumValue.HasValue Then
            columns.Add((COLUMN_MINIMUM_VALUE, minimumValue.Value))
        End If
        If maximumValue.HasValue Then
            columns.Add((COLUMN_MAXIMUM_VALUE, maximumValue.Value))
        End If
        Return New CharacterTypeStatisticStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CHARACTER_TYPE_STATISTICS,
                columns.ToArray))
    End Function

    Public Function AddCard(cardType As ICardTypeStore, cardQuantity As Integer) As ICharacterTypeCardStore Implements ICharacterTypeStore.AddCard
        Return New CharacterTypeCardStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CHARACTER_TYPE_CARDS,
                (COLUMN_CHARACTER_TYPE_ID, Id),
                (COLUMN_CARD_TYPE_ID, cardType.Id),
                (COLUMN_CARD_QUANTITY, cardQuantity)))
    End Function
End Class
