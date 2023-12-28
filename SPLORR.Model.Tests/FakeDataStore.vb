Imports SPLORR.Data

Friend Class FakeDataStore
    Implements IDataStore
    Private ReadOnly _operationLog As New List(Of String)
    Friend ReadOnly Property OperationLog As IEnumerable(Of String)
        Get
            Return _operationLog
        End Get
    End Property

    Public Sub CreatePlayerCharacter(playerId As Integer) Implements IDataStore.CreatePlayerCharacter
        _operationLog.Add($"CreateCharacter(playerId:={playerId})")
    End Sub

    Public Sub CleanUp() Implements IDataStore.CleanUp
        _operationLog.Add("CleanUp()")
    End Sub

    Public Function CheckForCharacter(playerId As Integer) As Boolean Implements IDataStore.CheckForCharacter
        _operationLog.Add($"CheckForCharacter(playerId:={playerId})")
        Return _operationLog.Contains($"CreateCharacter(playerId:={playerId})")
    End Function

    Public Function GetPlayerForAuthor(authorId As ULong) As Integer Implements IDataStore.GetPlayerForAuthor
        _operationLog.Add($"GetPlayerForAuthor(authorId:={authorId})")
        Return 0
    End Function
End Class
