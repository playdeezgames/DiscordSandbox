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
End Class
