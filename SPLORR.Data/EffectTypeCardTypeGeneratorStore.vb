Imports Microsoft.Data.SqlClient

Friend Class EffectTypeCardTypeGeneratorStore
    Implements IEffectTypeCardTypeGeneratorStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly id As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        Me.connectionSource = connectionSource
        Me.id = id
    End Sub

    Public ReadOnly Property Name As String Implements IEffectTypeCardTypeGeneratorStore.Name
        Get
            Return connectionSource.ReadStringForValues(
                VIEW_EFFECT_TYPE_CARD_TYPE_GENERATOR_DETAILS,
                {(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID, id)},
                COLUMN_CARD_TYPE_GENERATOR_NAME)
        End Get
    End Property

    Public ReadOnly Property CardCount As Integer Implements IEffectTypeCardTypeGeneratorStore.CardCount
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_EFFECT_TYPE_CARD_TYPE_GENERATORS,
                {(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID, id)},
                COLUMN_CARD_COUNT)
        End Get
    End Property

    Public ReadOnly Property CardTypes As IEnumerable(Of ICardTypeGeneratorCardTypeStore) Implements IEffectTypeCardTypeGeneratorStore.CardTypes
        Get
            Return connectionSource.ReadIntegersForValues(
                VIEW_EFFECT_TYPE_CARD_TYPE_GENERATOR_CARD_TYPES,
                {(COLUMN_EFFECT_TYPE_CARD_TYPE_GENERATOR_ID, id)},
                {},
                COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID).
                Select(
                Function(x) New CardTypeGeneratorCardTypeStore(connectionSource, x))
        End Get
    End Property
End Class
