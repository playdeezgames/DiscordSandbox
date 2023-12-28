Imports SPLORR.Data

Friend Class FakeDataStore
    Implements IDataStore
    Private ReadOnly _operationLog As New List(Of String)
    Friend ReadOnly Property OperationLog As IEnumerable(Of String)
        Get
            Return _operationLog
        End Get
    End Property

    Public Sub CreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer) Implements IDataStore.CreatePlayerCharacter
        _operationLog.Add($"CreatePlayerCharacter(playerId:={playerId},characterName:={characterName},locationId:={locationId},characterType:={characterType})")
    End Sub

    Public Sub CleanUp() Implements IDataStore.CleanUp
        _operationLog.Add("CleanUp()")
    End Sub

    Public Function CheckForCharacter(playerId As Integer) As Boolean Implements IDataStore.CheckForCharacter
        _operationLog.Add($"CheckForCharacter(playerId:={playerId})")
        Return _operationLog.Contains($"CreatePlayerCharacter(playerId:={playerId},characterName:=N00b,locationId:=0,characterType:=0)")
    End Function

    Public Function GetPlayerForAuthor(authorId As ULong) As Integer Implements IDataStore.GetPlayerForAuthor
        _operationLog.Add($"GetPlayerForAuthor(authorId:={authorId})")
        Return 0
    End Function

    Public Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of Integer, Integer) Implements IDataStore.GetCharacterTypeGenerator
        _operationLog.Add($"GetCharacterTypeGenerator()")
        Return New Dictionary(Of Integer, Integer) From {{0, 1}}
    End Function

    Public Function GetLocationGenerator() As IReadOnlyDictionary(Of Integer, Integer) Implements IDataStore.GetLocationGenerator
        _operationLog.Add($"GetLocationGenerator()")
        Return New Dictionary(Of Integer, Integer) From {{0, 1}}
    End Function
End Class
