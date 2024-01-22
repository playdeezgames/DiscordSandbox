Imports Microsoft.Data.SqlClient

Public Class DeckStore
    Inherits RelatedTypeStore(Of ICardStore, Integer)
    Implements IDeckStore

    Public Sub New(connectionSource As Func(Of SqlConnection), character As ICharacterStore)
        MyBase.New(connectionSource,
            VIEW_CARD_DETAILS,
            COLUMN_CARD_ID,
            COLUMN_CARD_TYPE_NAME,
            (COLUMN_CHARACTER_ID, character.Id),
            Function(x, y) New CardStore(x, y))
    End Sub

    Public ReadOnly Property TopOfDeck As ICardStore Implements IDeckStore.TopOfDeck
        Get
            Dim cardId = connectionSource.FindIntegerForValues(
                tableName,
                {
                    (relatedColumnName, relatedColumnValue),
                    (COLUMN_IN_DRAW_PILE, 1)
                },
                idColumnName,
                orders:=
                {
                    (COLUMN_DRAW_ORDER, True)
                })
            If cardId.HasValue Then
                Return New CardStore(connectionSource, cardId.Value)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Hand As IEnumerable(Of ICardStore) Implements IDeckStore.Hand
        Get
            Return connectionSource.ReadIntegersForValues(
                tableName,
                {
                    (relatedColumnName, relatedColumnValue),
                    (COLUMN_IN_HAND, 1)
                },
                Array.Empty(Of (Name As String, Value As String))(),
                idColumnName).
                Select(Function(x) New CardStore(connectionSource, x))
        End Get
    End Property

    Public ReadOnly Property DiscardPile As IEnumerable(Of ICardStore) Implements IDeckStore.DiscardPile
        Get
            Return connectionSource.ReadIntegersForValues(
                tableName,
                {
                    (relatedColumnName, relatedColumnValue),
                    (COLUMN_IN_DISCARD_PILE, 1)
                },
                Array.Empty(Of (Name As String, Value As String))(),
                idColumnName).
                Select(Function(x) New CardStore(connectionSource, x))
        End Get
    End Property

    Public Sub AddToDrawPile(card As ICardStore) Implements IDeckStore.AddToDrawPile
        Dim result = connectionSource.FindIntegerForValues(
            tableName,
            {(relatedColumnName, relatedColumnValue)},
            $"MAX({COLUMN_DRAW_ORDER})")
        card.DrawOrder = If(result, 0) + 1
    End Sub

    Public Function HandCardByName(cardName As String) As ICardStore Implements IDeckStore.HandCardByName
        Dim cardId = connectionSource.FindIntegerForValues(
            VIEW_CARD_DETAILS,
            {
                (relatedColumnName, relatedColumnValue),
                (COLUMN_CARD_TYPE_NAME, cardName),
                (COLUMN_IN_HAND, 1)
            }, COLUMN_CARD_ID)
        If cardId.HasValue Then
            Return New CardStore(connectionSource, cardId.Value)
        End If
        Return Nothing
    End Function
End Class
