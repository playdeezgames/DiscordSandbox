Imports Microsoft.Data.SqlClient

Friend Module DataStore
    Private Const CONNECTION_STRING As String = "CONNECTION_STRING"
    Private connection As SqlConnection = Nothing
    Private Const TABLE_PLAYERS = "Players"
    Private Const FIELD_PLAYER_ID = "PlayerId"
    Private Const FIELD_DISCORD_ID = "DiscordId"
    Private Const PARAMETER_DISCORD_ID = "@DiscordId"
    Private ReadOnly READ_PLAYER_ID_FOR_DISCORD_ID As String = $"SELECT {FIELD_PLAYER_ID} FROM {TABLE_PLAYERS} WHERE {FIELD_DISCORD_ID}={PARAMETER_DISCORD_ID};"
    Private ReadOnly ADD_DISCORD_ID_TO_PLAYERS As String = $"INSERT INTO {TABLE_PLAYERS} ({FIELD_DISCORD_ID}) VALUES ({PARAMETER_DISCORD_ID});"
    Friend Function FindOrCreatePlayerForAuthor(discordId As Long) As Integer
        Using command = GetConnection().CreateCommand()
            command.CommandText = READ_PLAYER_ID_FOR_DISCORD_ID
            command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
            Using reader = command.ExecuteReader
                If reader.Read Then
                    Return reader.GetInt32(0)
                End If
            End Using
        End Using
        Using command = GetConnection().CreateCommand()
            command.CommandText = ADD_DISCORD_ID_TO_PLAYERS
            command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
            command.ExecuteNonQuery()
        End Using
        Using command = GetConnection().CreateCommand()
            command.CommandText = READ_PLAYER_ID_FOR_DISCORD_ID
            command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
            Using reader = command.ExecuteReader
                reader.Read()
                Return reader.GetInt32(0)
            End Using
        End Using
    End Function
    Private Function GetConnection() As SqlConnection
        If connection Is Nothing Then
            connection = New SqlConnection(Environment.GetEnvironmentVariable(CONNECTION_STRING))
            connection.Open()
        End If
        Return connection
    End Function
End Module
