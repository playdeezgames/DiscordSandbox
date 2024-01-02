﻿Imports Microsoft.Data.SqlClient

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
                (COLUMN_CHARACTER_ID, _characterId),
                COLUMN_CHARACTER_NAME)
        End Get
        Set(value As String)
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
UPDATE 
    {TABLE_CHARACTERS} 
SET 
    {COLUMN_CHARACTER_NAME}={PARAMETER_CHARACTER_NAME} 
WHERE 
    {COLUMN_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
                command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, _characterId)
                command.Parameters.AddWithValue(PARAMETER_CHARACTER_NAME, value)
                command.ExecuteNonQuery()
            End Using
        End Set
    End Property

    Public ReadOnly Property Location As ILocationStore Implements ICharacterStore.Location
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {COLUMN_LOCATION_ID} 
FROM 
    {TABLE_CHARACTERS} 
WHERE 
    {COLUMN_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
                command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, _characterId)
                Return New LocationStore(_connectionSource, CInt(command.ExecuteScalar))
            End Using
        End Get
    End Property

    Public Sub SetLocation(location As ILocationStore, lastModified As DateTimeOffset) Implements ICharacterStore.SetLocation
        Using command = _connectionSource().CreateCommand
            command.CommandText = $"
UPDATE 
    {TABLE_CHARACTERS} 
SET 
    {COLUMN_LOCATION_ID}={PARAMETER_LOCATION_ID},
    {COLUMN_LAST_MODIFIED}={PARAMETER_LAST_MODIFIED}
WHERE 
    {COLUMN_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, _characterId)
            command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, location.Id)
            command.Parameters.AddWithValue(PARAMETER_LAST_MODIFIED, lastModified)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function CanDoVerb(verbType As IVerbTypeStore) As Boolean Implements ICharacterStore.CanDoVerb
        Using command = _connectionSource().CreateCommand()
            command.CommandText = $"SELECT COUNT(1) FROM {VIEW_CHARACTER_AVAILABLE_VERB_TYPES} WHERE {COLUMN_CHARACTER_ID}={PARAMETER_CHARACTER_ID} AND {COLUMN_VERB_TYPE_ID}={PARAMETER_VERB_TYPE_ID};"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, Id)
            command.Parameters.AddWithValue(PARAMETER_VERB_TYPE_ID, verbType.Id)
            Return CInt(command.ExecuteScalar) > 0
        End Using
    End Function

    Public ReadOnly Property HasOtherCharacters As Boolean Implements ICharacterStore.HasOtherCharacters
        Get
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {VIEW_CHARACTER_LOCATION_OTHER_CHARACTERS} 
WHERE 
    {COLUMN_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
                command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, _characterId)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterStore) Implements ICharacterStore.OtherCharacters
        Get
            Dim result As New List(Of ICharacterStore)
            Using command = _connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {COLUMN_OTHER_CHARACTER_ID}
FROM 
    {VIEW_CHARACTER_LOCATION_OTHER_CHARACTERS} 
WHERE 
    {COLUMN_CHARACTER_ID}={PARAMETER_CHARACTER_ID};"
                command.Parameters.AddWithValue(PARAMETER_CHARACTER_ID, _characterId)
                Using reader = command.ExecuteReader
                    While reader.Read
                        result.Add(New CharacterStore(_connectionSource, reader.GetInt32(0)))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property
End Class
