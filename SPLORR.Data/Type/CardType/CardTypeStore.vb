Imports Microsoft.Data.SqlClient

Friend Class CardTypeStore
    Inherits BaseTypeStore
    Implements ICardTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CARD_TYPES,
            COLUMN_CARD_TYPE_ID,
            COLUMN_CARD_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public Function CreateCard(store As ICharacterStore) As ICardStore Implements ICardTypeStore.CreateCard
        Using command = connectionSource().CreateCommand
            command.CommandText = $"INSERT INTO {TABLE_CARDS}({COLUMN_CARD_TYPE_ID},{COLUMN_CHARACTER_ID}) VALUES (@{COLUMN_CARD_TYPE_ID},@{COLUMN_CHARACTER_ID});"
            command.Parameters.AddWithValue($"{COLUMN_CARD_TYPE_ID}", Id)
            command.Parameters.AddWithValue($"{COLUMN_CHARACTER_ID}", store.Id)
            command.ExecuteNonQuery()
        End Using
        Return New CardStore(connectionSource, connectionSource.ReadLastIdentity)
    End Function
End Class
