Imports Microsoft.Data.SqlClient

Friend Class CardTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements ICardTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CARD_TYPES,
            COLUMN_CARD_TYPE_ID,
            COLUMN_CARD_TYPE_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property DeleteOnPlay As Boolean Implements ICardTypeStore.DeleteOnPlay
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPES,
                (COLUMN_CARD_TYPE_ID, Id),
                (COLUMN_DELETE_ON_PLAY, 1))
        End Get
        Set(value As Boolean)
            connectionSource.WriteValuesForValues(
                TABLE_CARD_TYPES,
                {(COLUMN_CARD_TYPE_ID, Id)},
                {(COLUMN_DELETE_ON_PLAY, If(value, 1, 0))})
        End Set
    End Property

    Public Property Generator As ICardTypeGeneratorStore Implements ICardTypeStore.Generator
        Get
            Dim cardTypeGeneratorId As Integer? =
                connectionSource.FindIntegerForValues(
                    TABLE_CARD_TYPES,
                    {(COLUMN_CARD_TYPE_ID, Id)},
                    COLUMN_CARD_TYPE_GENERATOR_ID)
            If cardTypeGeneratorId.HasValue Then
                Return New CardTypeGeneratorStore(connectionSource, cardTypeGeneratorId.Value)
            End If
            Return Nothing
        End Get
        Set(value As ICardTypeGeneratorStore)
            If value Is Nothing Then
                connectionSource.ClearColumnForValues(
                    TABLE_CARD_TYPES,
                    {(COLUMN_CARD_TYPE_ID, Id)},
                    COLUMN_CARD_TYPE_GENERATOR_ID)
                Return
            End If
            connectionSource.WriteValuesForValues(
                TABLE_CARD_TYPES,
                    {(COLUMN_CARD_TYPE_ID, Id)},
                    {(COLUMN_CARD_TYPE_GENERATOR_ID, value.Id)})
        End Set
    End Property

    Public Property Location As ILocationStore Implements ICardTypeStore.Location
        Get
            Dim locationId As Integer? =
                connectionSource.FindIntegerForValues(
                    TABLE_CARD_TYPES,
                    {(COLUMN_CARD_TYPE_ID, Id)},
                    COLUMN_LOCATION_ID)
            If locationId.HasValue Then
                Return New LocationStore(connectionSource, locationId.Value)
            End If
            Return Nothing
        End Get
        Set(value As ILocationStore)
            If value Is Nothing Then
                connectionSource.ClearColumnForValues(
                    TABLE_CARD_TYPES,
                    {(COLUMN_CARD_TYPE_ID, Id)},
                    COLUMN_LOCATION_ID)
                Return
            End If
            connectionSource.WriteValuesForValues(
                TABLE_CARD_TYPES,
                    {(COLUMN_CARD_TYPE_ID, Id)},
                    {(COLUMN_LOCATION_ID, value.Id)})
        End Set
    End Property

    Public Function CreateCard(store As ICharacterStore) As ICardStore Implements ICardTypeStore.CreateCard
        Return New CardStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CARDS,
                (COLUMN_CARD_TYPE_ID, Id),
                (COLUMN_CHARACTER_ID, store.Id)))
    End Function
End Class
