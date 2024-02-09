Imports Microsoft.Data.SqlClient

Friend Class EffectTypeStatisticRequirementStore
    Implements IEffectTypeStatisticRequirementStore

    Private connectionSource As Func(Of SqlConnection)
    Private id As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        Me.connectionSource = connectionSource
        Me.id = id
    End Sub

    Public ReadOnly Property Statistic As IStatisticTypeStore Implements IEffectTypeStatisticRequirementStore.Statistic
        Get
            Return New StatisticTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_EFFECT_TYPE_STATISTIC_REQUIREMENTS,
                    {(COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID, id)},
                    COLUMN_STATISTIC_TYPE_ID))
        End Get
    End Property

    Public ReadOnly Property Minimum As Integer? Implements IEffectTypeStatisticRequirementStore.Minimum
        Get
            Return connectionSource.FindIntegerForValues(
                TABLE_EFFECT_TYPE_STATISTIC_REQUIREMENTS,
                {(COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID, id)},
                COLUMN_MINIMUM_VALUE)
        End Get
    End Property

    Public ReadOnly Property Maximum As Integer? Implements IEffectTypeStatisticRequirementStore.Maximum
        Get
            Return connectionSource.FindIntegerForValues(
                TABLE_EFFECT_TYPE_STATISTIC_REQUIREMENTS,
                {(COLUMN_EFFECT_TYPE_STATISTIC_REQUIREMENT_ID, id)},
                COLUMN_MAXIMUM_VALUE)
        End Get
    End Property
End Class
