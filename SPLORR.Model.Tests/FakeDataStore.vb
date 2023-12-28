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
        _operationLog.Add($"{NameOf(CreatePlayerCharacter)}(playerId:={playerId},characterName:={characterName},locationId:={locationId},characterType:={characterType})")
    End Sub

    Public Sub CleanUp() Implements IDataStore.CleanUp
        _operationLog.Add($"{NameOf(CleanUp)}()")
    End Sub

    Public Function CheckForCharacter(playerId As Integer) As Boolean Implements IDataStore.CheckForCharacter
        _operationLog.Add($"{NameOf(CheckForCharacter)}(playerId:={playerId})")
        Return _operationLog.Contains($"CreatePlayerCharacter(playerId:={playerId},characterName:=N00b,locationId:=0,characterType:=0)")
    End Function

    Public Function GetPlayerForAuthor(authorId As ULong) As Integer Implements IDataStore.GetPlayerForAuthor
        _operationLog.Add($"{NameOf(GetPlayerForAuthor)}(authorId:={authorId})")
        Return 0
    End Function

    Public Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of Integer, Integer) Implements IDataStore.GetCharacterTypeGenerator
        _operationLog.Add($"{NameOf(GetCharacterTypeGenerator)}()")
        Return New Dictionary(Of Integer, Integer) From {{0, 1}}
    End Function

    Public Function GetLocationGenerator() As IReadOnlyDictionary(Of Integer, Integer) Implements IDataStore.GetLocationGenerator
        _operationLog.Add($"{NameOf(GetLocationGenerator)}()")
        Return New Dictionary(Of Integer, Integer) From {{0, 1}}
    End Function

    Public Function GetCharacterForPlayer(playerId As Integer) As Integer Implements IDataStore.GetCharacterForPlayer
        _operationLog.Add($"{NameOf(GetCharacterForPlayer)}({NameOf(playerId)}:={playerId})")
        Return 0
    End Function
End Class
