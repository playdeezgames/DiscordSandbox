Imports Microsoft.Data.SqlClient

Friend Class CharacterStore
    Implements ICharacterStore
    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _characterId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), characterId As Integer)
        Me._connectionSource = connectionSource
        Me._characterId = characterId
    End Sub

    Public ReadOnly Property Id As Integer Implements ICharacterStore.Id
        Get
            Return _characterId
        End Get
    End Property

    Public Property Name As String Implements ICharacterStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(
                TABLE_CHARACTERS,
                (FIELD_CHARACTER_ID, _characterId),
                FIELD_CHARACTER_NAME)
        End Get
        Set(value As String)
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
UPDATE 
    {TABLE_CHARACTERS} 
SET 
    {FIELD_CHARACTER_NAME}={PARAMETER_CHARACTER_NAME} 
WHERE 
    {FIELD_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
                command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, _characterId)
                command.Parameters.AddWithValue(PARAMETER_CHARACTER_NAME, value)
                command.ExecuteNonQuery()
            End Using
        End Set
    End Property

    Public Sub SetLocation(location As ILocationStore) Implements ICharacterStore.SetLocation
        Using command = _connectionSource().CreateCommand
            command.CommandText = $"UPDATE {TABLE_CHARACTERS} SET {FIELD_LOCATION_ID}={PARAMETER_LOCATION_ID} WHERE {FIELD_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, _characterId)
            command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, location.Id)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function GetLocation() As ILocationStore Implements ICharacterStore.GetLocation
        Using command = _connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {FIELD_LOCATION_ID} 
FROM 
    {TABLE_CHARACTERS} 
WHERE 
    {FIELD_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, _characterId)
            Return New LocationStore(_connectionSource, CInt(command.ExecuteScalar))
        End Using
    End Function
End Class
