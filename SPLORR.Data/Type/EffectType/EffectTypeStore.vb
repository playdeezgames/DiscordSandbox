Imports Microsoft.Data.SqlClient

Friend Class EffectTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements IEffectTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_EFFECT_TYPES,
            COLUMN_EFFECT_TYPE_ID,
            COLUMN_EFFECT_TYPE_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property Requirements As IEnumerable(Of IEffectTypeStatisticRequirementStore) Implements IEffectTypeStore.Requirements
        Get
            Return connectionSource.ReadIntegersForValues(
                TABLE_EFFECT_TYPE_STATISTIC_REQUIREMENTS,
                {(COLUMN_EFFECT_TYPE_ID, Id)},
                Array.Empty(Of (Name As String, Value As String))(),
                COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID).
                Select(Function(x) New EffectTypeStatisticRequirementStore(connectionSource, x))
        End Get
    End Property

    Public ReadOnly Property StatisticDeltas As IEnumerable(Of IEffectTypeStatisticDeltaStore) Implements IEffectTypeStore.StatisticDeltas
        Get
            Return connectionSource.ReadIntegersForValues(
                TABLE_EFFECT_TYPE_STATISTIC_DELTAS,
                {(COLUMN_EFFECT_TYPE_ID, Id)},
                Array.Empty(Of (Name As String, Value As String))(),
                COLUMN_EFFECT_TYPE_STATISTIC_DELTA_ID).
                Select(
                Function(x) New EffectTypeStatisticDeltaStore(connectionSource, x))
        End Get
    End Property

    Public ReadOnly Property LocationType As ILocationTypeStore Implements IEffectTypeStore.LocationType
        Get
            Dim locationTypeId = connectionSource.FindIntegerForValues(TABLE_EFFECT_TYPES, {(COLUMN_EFFECT_TYPE_ID, Id)}, COLUMN_LOCATION_TYPE_ID)
            If Not locationTypeId.HasValue Then
                Return Nothing
            End If
            Return New LocationTypeStore(connectionSource, locationTypeId.Value)
        End Get
    End Property

    Public ReadOnly Property Destinations As IEnumerable(Of IEffectTypeDestinationStore) Implements IEffectTypeStore.Destinations
        Get
            Return connectionSource.ReadIntegersForValues(
                VIEW_EFFECT_TYPE_DESTINATION_DETAILS,
                {(COLUMN_EFFECT_TYPE_ID, Id)},
                Array.Empty(Of (Name As String, Value As String))(),
                COLUMN_LOCATION_ID).Select(
                Function(x) New EffectTypeDestinationStore(connectionSource, Id, x))
        End Get
    End Property

    Public ReadOnly Property CardTypeGenerators As IEnumerable(Of IEffectTypeCardTypeGeneratorStore) Implements IEffectTypeStore.CardTypeGenerators
        Get
            Return connectionSource.ReadIntegersForValues(
                VIEW_EFFECT_TYPE_CARD_TYPE_GENERATORS,
                {(COLUMN_EFFECT_TYPE_ID, Id)},
                Array.Empty(Of (Name As String, Value As String))(),
                COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID).Select(
                Function(x) New EffectTypeCardTypeGeneratorStore(connectionSource, x))
        End Get
    End Property

    Public ReadOnly Property RefreshHand As Boolean Implements IEffectTypeStore.RefreshHand
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_EFFECT_TYPES,
                {(COLUMN_EFFECT_TYPE_ID, Id)},
                COLUMN_REFRESH_HAND) <> 0
        End Get
    End Property
End Class
