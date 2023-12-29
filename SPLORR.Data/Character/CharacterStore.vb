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
