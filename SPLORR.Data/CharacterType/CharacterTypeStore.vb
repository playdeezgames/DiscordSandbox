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
End Class
