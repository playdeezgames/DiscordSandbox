Imports Microsoft.Data.SqlClient

Friend Class CardTypeTagStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements ICardTypeTagStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CARD_TYPE_TAGS,
            COLUMN_CARD_TYPE_TAG_ID,
            COLUMN_TAG_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public ReadOnly Property CardType As ICardTypeStore Implements ICardTypeTagStore.CardType
        Get
            Return New CardTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CARD_TYPE_TAGS,
                    {(COLUMN_CARD_TYPE_TAG_ID, Id)},
                    COLUMN_CARD_TYPE_ID))
        End Get
    End Property

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property
End Class
