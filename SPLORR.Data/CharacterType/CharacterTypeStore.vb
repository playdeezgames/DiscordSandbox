Imports Microsoft.Data.SqlClient

Friend Class CharacterTypeStore
    Inherits BaseTypeStore
    Implements ICharacterTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CHARACTER_TYPES,
            COLUMN_CHARACTER_TYPE_ID,
            COLUMN_CHARACTER_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForValue(TABLE_CHARACTERS, (COLUMN_CHARACTER_TYPE_ID, Id))
        End Get
    End Property

    Public Function CreateCharacter(name As String, location As ILocationStore) As ICharacterStore Implements ICharacterTypeStore.CreateCharacter
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_CHARACTERS}
    (
        {COLUMN_CHARACTER_NAME},
        {COLUMN_CHARACTER_TYPE_ID},
        {COLUMN_LOCATION_ID}
    ) 
    VALUES 
    (
        {PARAMETER_CHARACTER_NAME},
        {PARAMETER_CHARACTER_TYPE_ID},
        {PARAMETER_LOCATION_ID}
    );"
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_NAME, name)
            command.Parameters.AddWithValue(PARAMETER_CHARACTER_TYPE_ID, Id)
            command.Parameters.AddWithValue(PARAMETER_LOCATION_ID, location.Id)
            command.ExecuteNonQuery()
        End Using
        Return New CharacterStore(connectionSource, connectionSource.ReadLastIdentity)
    End Function
End Class
