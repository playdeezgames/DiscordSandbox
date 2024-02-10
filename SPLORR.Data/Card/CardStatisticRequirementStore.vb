Imports Microsoft.Data.SqlClient

Public Class CardStatisticRequirementStore
    Implements ICardStatisticRequirementStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly cardId As Integer
    Private ReadOnly statisticTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), cardId As Integer, statisticTypeId As Integer)
        Me.connectionSource = connectionSource
        Me.cardId = cardId
        Me.statisticTypeId = statisticTypeId
    End Sub

    Public ReadOnly Property Statistic As IStatisticTypeStore Implements ICardStatisticRequirementStore.Statistic
        Get
            Return New StatisticTypeStore(connectionSource, statisticTypeId)
        End Get
    End Property

    Public ReadOnly Property Minimum As Integer? Implements ICardStatisticRequirementStore.Minimum
        Get
            Return connectionSource.FindIntegerForValues(
                VIEW_CARD_STATISTIC_REQUIREMENTS,
                {
                    (COLUMN_CARD_ID, cardId),
                    (COLUMN_STATISTIC_TYPE_ID, statisticTypeId)
                },
                COLUMN_MINIMUM_VALUE)
        End Get
    End Property

    Public ReadOnly Property Maximum As Integer? Implements ICardStatisticRequirementStore.Maximum
        Get
            Return connectionSource.FindIntegerForValues(
                VIEW_CARD_STATISTIC_REQUIREMENTS,
                {
                    (COLUMN_CARD_ID, cardId),
                    (COLUMN_STATISTIC_TYPE_ID, statisticTypeId)
                },
                COLUMN_MAXIMUM_VALUE)
        End Get
    End Property
End Class
