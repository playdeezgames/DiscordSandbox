Imports Microsoft.Data.SqlClient

Friend Class PlayerStore
    Implements IPlayerStore
    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _playerId As Integer
    Sub New(connectionSource As Func(Of SqlConnection), playerId As Integer)
        _connectionSource = connectionSource
        _playerId = playerId
    End Sub

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerStore.HasCharacter
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {TABLE_PLAYER_CHARACTERS} 
WHERE 
    {FIELD_PLAYER_ID}={PARAMETER_PLAYER_ID};"
                command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, _playerId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property
End Class
