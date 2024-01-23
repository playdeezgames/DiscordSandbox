Imports Microsoft.Data.SqlClient

Friend Class CardTypeGeneratorStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements ICardTypeGeneratorStore

    Public Sub New(
                  connectionSource As Func(Of SqlConnection),
                  id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CARD_TYPE_GENERATORS,
            COLUMN_CARD_TYPE_GENERATOR_ID,
            COLUMN_CARD_TYPE_GENERATOR_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not HasCardTypes
        End Get
    End Property

    Public ReadOnly Property CardTypes As IRelatedTypeStore(Of ICardTypeGeneratorCardTypeStore) Implements ICardTypeGeneratorStore.CardTypes
        Get
            Return New RelatedTypeStore(Of ICardTypeGeneratorCardTypeStore, Integer)(
                connectionSource,
                VIEW_CARD_TYPE_GENERATOR_CARD_TYPE_DETAILS,
                COLUMN_CARD_TYPE_GENERATOR_CARD_TYPE_ID,
                COLUMN_CARD_TYPE_NAME,
                (COLUMN_CARD_TYPE_GENERATOR_ID, Id),
                Function(x, y) New CardTypeGeneratorCardTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CanAddCardType As Boolean Implements ICardTypeGeneratorStore.CanAddCardType
        Get
            Return connectionSource.CheckForValues(
                VIEW_CARD_TYPE_GENERATOR_AVAILABLE_CARD_TYPE,
                (COLUMN_CARD_TYPE_GENERATOR_ID, Id))
        End Get
    End Property

    Public ReadOnly Property AvailableCardTypes As IRelatedTypeStore(Of ICardTypeStore) Implements ICardTypeGeneratorStore.AvailableCardTypes
        Get
            Return New RelatedTypeStore(Of ICardTypeStore, Integer)(
                connectionSource,
                VIEW_CARD_TYPE_GENERATOR_AVAILABLE_CARD_TYPE,
                COLUMN_CARD_TYPE_ID,
                COLUMN_CARD_TYPE_NAME,
                (COLUMN_CARD_TYPE_GENERATOR_ID, Id),
                Function(x, y) New CardTypeStore(x, y))
        End Get
    End Property

    Private ReadOnly Property HasCardTypes As Boolean
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPE_GENERATOR_CARD_TYPES,
                (COLUMN_CARD_TYPE_GENERATOR_ID, Id))
        End Get
    End Property

    Public Function AddCardType(cardType As ICardTypeStore, generatorWeight As Integer) As ICardTypeGeneratorCardTypeStore Implements ICardTypeGeneratorStore.AddCardType
        Return New CardTypeGeneratorCardTypeStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CARD_TYPE_GENERATOR_CARD_TYPES,
                (COLUMN_CARD_TYPE_GENERATOR_ID, Id),
                (COLUMN_CARD_TYPE_ID, cardType.Id),
                (COLUMN_GENERATOR_WEIGHT, generatorWeight)))
    End Function
End Class
