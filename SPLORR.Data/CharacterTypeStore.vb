Imports Microsoft.Data.SqlClient

Friend Class CharacterTypeStore
    Implements ICharacterTypeStore

    Private _connectionSource As Func(Of SqlConnection)
    Private _characterTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), characterTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._characterTypeId = characterTypeId
    End Sub
End Class
