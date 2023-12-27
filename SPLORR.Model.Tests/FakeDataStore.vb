Imports SPLORR.Data

Friend Class FakeDataStore
    Implements IDataStore
    Private ReadOnly _operationLog As New List(Of String)
    Friend ReadOnly Property OperationLog As IEnumerable(Of String)
        Get
            Return _operationLog
        End Get
    End Property

    Public Sub CreateCharacter(authorId As ULong) Implements IDataStore.CreateCharacter
        _operationLog.Add($"CreateCharacter({authorId})")
    End Sub

    Public Function CheckForCharacter(authorId As ULong) As Boolean Implements IDataStore.CheckForCharacter
        _operationLog.Add($"CheckForCharacter({authorId})")
        Return _operationLog.Contains($"CreateCharacter({authorId})")
    End Function

    Public Function GetPlayerForAuthor(authorId As ULong) As Integer Implements IDataStore.GetPlayerForAuthor
        _operationLog.Add($"GetPlayerForAuthor({authorId})")
        Return 0
    End Function
End Class
