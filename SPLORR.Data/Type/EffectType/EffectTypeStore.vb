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
                {},
                COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID).
                Select(Function(x) New EffectTypeStatisticRequirementStore(connectionSource, x))
        End Get
    End Property
End Class
