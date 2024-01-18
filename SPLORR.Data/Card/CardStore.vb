Imports Microsoft.Data.SqlClient

Friend Class CardStore
    Inherits BaseTypeStore
    Implements ICardStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_CARD_DETAILS,
            COLUMN_CARD_ID,
            COLUMN_CARD_TYPE_NAME,
            TABLE_CARDS)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterStore Implements ICardStore.Character
        Get
            Return New CharacterStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_CARDS,
                    {(COLUMN_CARD_ID, Id)},
                    COLUMN_CHARACTER_ID))
        End Get
    End Property

    Public WriteOnly Property DrawOrder As Integer Implements ICardStore.DrawOrder
        Set(value As Integer)
            connectionSource.WriteValuesForValues(
                TABLE_CARDS,
                {
                    (COLUMN_CARD_ID, Id)
                },
                {
                    (COLUMN_IN_HAND, 0),
                    (COLUMN_IN_DISCARD_PILE, 0),
                    (COLUMN_IN_DRAW_PILE, 1),
                    (COLUMN_DRAW_ORDER, value)
                })
        End Set
    End Property

    Public Sub AddToHand() Implements ICardStore.AddToHand
        connectionSource.WriteValuesForValues(
                TABLE_CARDS,
                {
                    (COLUMN_CARD_ID, Id)
                },
                {
                    (COLUMN_IN_HAND, 1),
                    (COLUMN_IN_DISCARD_PILE, 0),
                    (COLUMN_IN_DRAW_PILE, 0),
                    (COLUMN_DRAW_ORDER, DBNull.Value)
                })
    End Sub

    Public Sub Discard() Implements ICardStore.Discard
        connectionSource.WriteValuesForValues(
                TABLE_CARDS,
                {
                    (COLUMN_CARD_ID, Id)
                },
                {
                    (COLUMN_IN_HAND, 0),
                    (COLUMN_IN_DISCARD_PILE, 1),
                    (COLUMN_IN_DRAW_PILE, 0),
                    (COLUMN_DRAW_ORDER, DBNull.Value)
                })
    End Sub
End Class
