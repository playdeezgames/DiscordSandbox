Imports Microsoft.Data.SqlClient

Friend Class EffectTypeDestinationStore
    Implements IEffectTypeDestinationStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly effectTypeId As Integer
    Private ReadOnly locationId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), effectTypeId As Integer, locationId As Integer)
        Me.connectionSource = connectionSource
        Me.effectTypeId = effectTypeId
        Me.locationId = locationId
    End Sub

    Public ReadOnly Property Name As String Implements IEffectTypeDestinationStore.Name
        Get
            Return connectionSource.ReadStringForValues(
                TABLE_LOCATIONS,
                {(COLUMN_LOCATION_ID, locationId)},
                COLUMN_LOCATION_NAME)
        End Get
    End Property

    Public ReadOnly Property GeneratorWeight As Integer Implements IEffectTypeDestinationStore.GeneratorWeight
        Get
            Return connectionSource.ReadIntegerForValues(
                VIEW_EFFECT_TYPE_DESTINATION_DETAILS,
                {
                    (COLUMN_EFFECT_TYPE_ID, effectTypeId),
                    (COLUMN_LOCATION_ID, locationId)
                },
                COLUMN_GENERATOR_WEIGHT)
        End Get
    End Property
End Class
