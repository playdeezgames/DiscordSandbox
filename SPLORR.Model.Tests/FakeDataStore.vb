Imports SPLORR.Data

Friend Class FakeDataStore
    Implements IDataStore
    Private ReadOnly _operationLog As New List(Of String)
    Private ReadOnly _characterNames As New Dictionary(Of Integer, String)
    Friend ReadOnly Property OperationLog As IEnumerable(Of String)
        Get
            Return _operationLog
        End Get
    End Property

    Public Sub CreatePlayerCharacter(playerId As Integer, characterName As String, locationId As Integer, characterType As Integer) Implements IDataStore.CreatePlayerCharacter
        _operationLog.Add($"{NameOf(CreatePlayerCharacter)}({NameOf(playerId)}:={playerId},{NameOf(characterName)}:={characterName},{NameOf(locationId)}:={locationId},{NameOf(characterType)}:={characterType})")
    End Sub

    Public Sub CleanUp() Implements IDataStore.CleanUp
        _operationLog.Add($"{NameOf(CleanUp)}()")
    End Sub

    Public Sub SetCharacterName(characterId As Integer, characterName As String) Implements IDataStore.SetCharacterName
        _operationLog.Add($"{NameOf(SetCharacterName)}({NameOf(characterId)}:={characterId},{NameOf(characterName)}:={characterName})")
        _characterNames(characterId) = characterName
    End Sub

    Public Function CheckForCharacter(playerId As Integer) As Boolean Implements IDataStore.CheckForCharacter
        _operationLog.Add($"{NameOf(CheckForCharacter)}({NameOf(playerId)}:={playerId})")
        Return _operationLog.Contains($"{NameOf(CreatePlayerCharacter)}(playerId:={playerId},characterName:=N00b,locationId:=0,characterType:=0)")
    End Function

    Public Function GetPlayerForAuthor(authorId As ULong) As Integer Implements IDataStore.GetPlayerForAuthor
        _operationLog.Add($"{NameOf(GetPlayerForAuthor)}({NameOf(authorId)}:={authorId})")
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

    Public Function GetCharacterName(characterId As Integer) As String Implements IDataStore.GetCharacterName
        _operationLog.Add($"{NameOf(GetCharacterName)}({NameOf(characterId)}:={characterId})")
        Dim characterName As String = Nothing
        Return If(_characterNames.TryGetValue(characterId, characterName), characterName, "N00b")
    End Function

    Public Function GetPlayer(playerId As Integer) As IPlayerStore Implements IDataStore.GetPlayer
        Return Nothing
    End Function
End Class
