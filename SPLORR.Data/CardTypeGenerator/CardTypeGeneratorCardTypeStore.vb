Imports Microsoft.Data.SqlClient

Friend Class CardTypeGeneratorCardTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements ICardTypeGeneratorCardTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_CARD_TYPE_GENERATOR_CARD_TYPE_DETAILS,
            COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID,
            COLUMN_CARD_TYPE_NAME,
            New DataStore(connectionSource()),
            TABLE_CARD_TYPE_GENERATOR_CARD_TYPES)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property GeneratorWeight As Integer Implements ICardTypeGeneratorCardTypeStore.GeneratorWeight
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_CARD_TYPE_GENERATOR_CARD_TYPES,
                {(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID, Id)},
                COLUMN_GENERATOR_WEIGHT)
        End Get
        Set(value As Integer)
            connectionSource.WriteValuesForValues(
                TABLE_CARD_TYPE_GENERATOR_CARD_TYPES,
                {(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID, Id)},
                {(COLUMN_GENERATOR_WEIGHT, value)})
        End Set
    End Property

    Public ReadOnly Property Generator As ICardTypeGeneratorStore Implements ICardTypeGeneratorCardTypeStore.Generator
        Get
            Return New CardTypeGeneratorStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CARD_TYPE_GENERATOR_CARD_TYPES,
                    {(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID, Id)},
                    COLUMN_CARD_TYPE_GENERATOR_ID))
        End Get
    End Property

    Public ReadOnly Property CardType As ICardTypeStore Implements ICardTypeGeneratorCardTypeStore.CardType
        Get
            Return New CardTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CARD_TYPE_GENERATOR_CARD_TYPES,
                    {(COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID, Id)},
                    COLUMN_CARD_TYPE_ID))
        End Get
    End Property
End Class
