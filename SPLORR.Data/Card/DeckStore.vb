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
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
SELECT TOP 1 
    {idColumnName} 
FROM 
    {tableName} 
WHERE 
    {relatedColumnName}=@{relatedColumnName} 
    AND {COLUMN_IN_DRAW_PILE}=1
ORDER BY 
    {COLUMN_DRAW_ORDER} ASC;"
                command.Parameters.AddWithValue($"@{relatedColumnName}", relatedColumnValue)
                Using reader = command.ExecuteReader
                    If reader.Read Then
                        Return New CardStore(connectionSource, reader.GetInt32(0))
                    End If
                End Using
            End Using
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
                idColumnName).
                Select(Function(x) New CardStore(connectionSource, x))
        End Get
    End Property

    Public Sub AddToDrawPile(card As ICardStore) Implements IDeckStore.AddToDrawPile
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT
	MAX({COLUMN_DRAW_ORDER})
FROM	
	{tableName}
WHERE
	{relatedColumnName}=@{relatedColumnName};"
            command.Parameters.AddWithValue($"@{relatedColumnName}", relatedColumnValue)
            Dim result As Integer = 1
            Using reader = command.ExecuteReader
                If reader.Read Then
                    If Not reader.IsDBNull(0) Then
                        result = CInt(reader.GetInt32(0) + 1)
                    End If
                End If
            End Using
            card.DrawOrder = result
        End Using
    End Sub
End Class
