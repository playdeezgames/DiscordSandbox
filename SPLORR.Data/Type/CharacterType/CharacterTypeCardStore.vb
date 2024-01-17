Imports Microsoft.Data.SqlClient

Friend Class CharacterTypeCardStore
    Inherits BaseTypeStore
    Implements ICharacterTypeCardStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_CHARACTER_TYPE_CARD_DETAILS,
            COLUMN_CHARACTER_TYPE_CARD_ID,
            COLUMN_CARD_TYPE_NAME,
            TABLE_CHARACTER_TYPE_CARDS)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property Quantity As Integer Implements ICharacterTypeCardStore.Quantity
        Get
            Return connectionSource.ReadIntegerForValue(
                TABLE_CHARACTER_TYPE_CARDS,
                (COLUMN_CHARACTER_TYPE_CARD_ID, Id),
                COLUMN_CARD_QUANTITY)
        End Get
        Set(value As Integer)
            connectionSource.WriteValuesForValues(
                TABLE_CHARACTER_TYPE_CARDS,
                {(COLUMN_CHARACTER_TYPE_CARD_ID, Id)},
                {(COLUMN_CARD_QUANTITY, value)})
        End Set
    End Property

    Public ReadOnly Property CharacterType As ICharacterTypeStore Implements ICharacterTypeCardStore.CharacterType
        Get
            Return New CharacterTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValue(
                    TABLE_CHARACTER_TYPE_CARDS,
                    (COLUMN_CHARACTER_TYPE_CARD_ID, Id),
                    COLUMN_CHARACTER_TYPE_ID))
        End Get
    End Property

    Public ReadOnly Property CardType As ICardTypeStore Implements ICharacterTypeCardStore.CardType
        Get
            Return New CardTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValue(
                    TABLE_CHARACTER_TYPE_CARDS,
                    (COLUMN_CHARACTER_TYPE_CARD_ID, Id),
                    COLUMN_CARD_TYPE_ID))
        End Get
    End Property
End Class
