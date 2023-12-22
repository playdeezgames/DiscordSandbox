Imports Microsoft.Data.SqlClient

Friend Class PlayerStore
    Private Const TABLE_PLAYERS = "Players"
    Private Const FIELD_PLAYER_ID = "PlayerId"
    Private Const FIELD_DISCORD_ID = "DiscordId"
    Private Const PARAMETER_DISCORD_ID = "@DiscordId"
    Private Shared ReadOnly READ_PLAYER_ID_FOR_DISCORD_ID As String = $"SELECT {FIELD_PLAYER_ID} FROM {TABLE_PLAYERS} WHERE {FIELD_DISCORD_ID}={PARAMETER_DISCORD_ID};"
    Private Shared ReadOnly ADD_DISCORD_ID_TO_PLAYERS As String = $"INSERT INTO {TABLE_PLAYERS} ({FIELD_DISCORD_ID}) VALUES ({PARAMETER_DISCORD_ID});"
    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Friend Sub New(connectionSource As Func(Of SqlConnection))
        Me.connectionSource = connectionSource
    End Sub
    Friend Function FindOrCreate(discordId As Long) As Integer
        Using command = connectionSource().CreateCommand()
            command.CommandText = READ_PLAYER_ID_FOR_DISCORD_ID
            command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
            Using reader = command.ExecuteReader
                If reader.Read Then
                    Return reader.GetInt32(0)
                End If
            End Using
        End Using
        Using command = connectionSource().CreateCommand()
            command.CommandText = ADD_DISCORD_ID_TO_PLAYERS
            command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
            command.ExecuteNonQuery()
        End Using
        Using command = connectionSource().CreateCommand()
            command.CommandText = READ_PLAYER_ID_FOR_DISCORD_ID
            command.Parameters.AddWithValue(PARAMETER_DISCORD_ID, discordId)
            Using reader = command.ExecuteReader
                reader.Read()
                Return reader.GetInt32(0)
            End Using
        End Using
    End Function
    Private Const TABLE_PLAYER_MONEY = "PlayerMoney"
    Private Const PARAMETER_PLAYER_ID = "@PlayerId"
    Private Shared ReadOnly CHECK_PAY_RECORD As String = $"SELECT COUNT(1) FROM {TABLE_PLAYER_MONEY} WHERE {FIELD_PLAYER_ID}={PARAMETER_PLAYER_ID};"
    Friend Function HasPayRecord(playerId As Integer) As Boolean
        Using command = connectionSource().CreateCommand()
            command.CommandText = CHECK_PAY_RECORD
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            Return CInt(command.ExecuteScalar()) > 0
        End Using
    End Function
    Private Const FIELD_PAYMENT_DUE = "PaymentDue"
    Private Shared ReadOnly READ_PAYMENT_DUE As String = $"SELECT {FIELD_PAYMENT_DUE} FROM {TABLE_PLAYER_MONEY} WHERE {FIELD_PLAYER_ID}={PARAMETER_PLAYER_ID};"
    Friend Function IsOwedPay(playerId As Integer) As Boolean
        Using command = connectionSource().CreateCommand()
            command.CommandText = READ_PAYMENT_DUE
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            Using reader = command.ExecuteReader
                If reader.Read Then
                    Return reader.GetDateTimeOffset(0) <= DateTimeOffset.Now
                Else
                    Return True
                End If
            End Using
        End Using
    End Function
    Friend Function PaymentDue(playerId As Integer) As DateTimeOffset
        Using command = connectionSource().CreateCommand()
            command.CommandText = READ_PAYMENT_DUE
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            Using reader = command.ExecuteReader
                reader.Read()
                Return reader.GetDateTimeOffset(0)
            End Using
        End Using
    End Function
    Private Shared ReadOnly READ_AMOUNT As String = $"SELECT {FIELD_AMOUNT} FROM {TABLE_PLAYER_MONEY} WHERE {FIELD_PLAYER_ID}={PARAMETER_PLAYER_ID};"
    Private Shared ReadOnly UPDATE_AMOUNT As String = $"
UPDATE 
    {TABLE_PLAYER_MONEY} 
SET 
    {FIELD_AMOUNT}={PARAMETER_AMOUNT}, 
    {FIELD_PAYMENT_DUE}={PARAMETER_PAYMENT_DUE} 
WHERE 
    {FIELD_PLAYER_ID}={PARAMETER_PLAYER_ID};"
    Friend Function AdditionalPay(playerId As Integer) As (Amount As Integer, Total As Integer)
        Dim amount As Integer
        Using command = connectionSource().CreateCommand
            command.CommandText = READ_AMOUNT
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            amount = CInt(command.ExecuteScalar())
        End Using
        Dim total As Integer = amount + PAY_RATE
        Using command = connectionSource().CreateCommand
            command.CommandText = UPDATE_AMOUNT
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            command.Parameters.AddWithValue(PARAMETER_PAYMENT_DUE, PaymentDue(playerId).AddDays(PAY_INTERVAL))
            command.Parameters.AddWithValue(PARAMETER_AMOUNT, total)
            command.ExecuteNonQuery()
        End Using
        Return (PAY_RATE, total)
    End Function
    Private Const PARAMETER_PAYMENT_DUE = "@PaymentDue"
    Private Const PARAMETER_AMOUNT = "@Amount"
    Private Const FIELD_AMOUNT = "Amount"
    Private Shared ReadOnly INITIAL_PAYMENT As String = $"INSERT INTO {TABLE_PLAYER_MONEY} ({FIELD_PLAYER_ID},{FIELD_PAYMENT_DUE},{FIELD_AMOUNT}) VALUES ({PARAMETER_PLAYER_ID},{PARAMETER_PAYMENT_DUE},{PARAMETER_AMOUNT});"
    Private Const PAY_RATE = 100
    Private Const PAY_INTERVAL = 1.0
    Friend Function InitialPay(playerId As Integer) As (Amount As Integer, Total As Integer)
        Using command = connectionSource().CreateCommand
            command.CommandText = INITIAL_PAYMENT
            command.Parameters.AddWithValue(PARAMETER_PLAYER_ID, playerId)
            command.Parameters.AddWithValue(PARAMETER_PAYMENT_DUE, DateTimeOffset.Now.AddDays(PAY_INTERVAL))
            command.Parameters.AddWithValue(PARAMETER_AMOUNT, PAY_RATE)
            command.ExecuteNonQuery()
        End Using
        Return (PAY_RATE, PAY_RATE)
    End Function
End Class
