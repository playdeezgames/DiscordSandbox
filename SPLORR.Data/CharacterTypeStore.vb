Imports Microsoft.Data.SqlClient

Friend Class CharacterTypeStore
    Implements ICharacterTypeStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _characterTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), characterTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._characterTypeId = characterTypeId
    End Sub

    Public ReadOnly Property Id As Integer Implements ICharacterTypeStore.Id
        Get
            Return _characterTypeId
        End Get
    End Property
End Class
