﻿Imports Microsoft.Data.SqlClient

Public Class DataStore
    Implements IDataStore
    Private ReadOnly _connectionString As String = Nothing
    Private _connection As SqlConnection = Nothing
    Private Function GetConnection() As SqlConnection
        If _connection Is Nothing Then
            _connection = New SqlConnection(_connectionString)
            _connection.Open()
        End If
        Return _connection
    End Function
    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub
    Friend Sub New(connection As SqlConnection)
        _connection = connection
    End Sub
    Private ReadOnly Property ConnectionSource As Func(Of SqlConnection)
        Get
            Return AddressOf GetConnection
        End Get
    End Property

    Public ReadOnly Property LocationTypes As ITypeStore(Of ILocationTypeStore) Implements IDataStore.LocationTypes
        Get
            Return New TypeStore(Of ILocationTypeStore)(
                ConnectionSource,
                TABLE_LOCATION_TYPES,
                COLUMN_LOCATION_TYPE_ID,
                COLUMN_LOCATION_TYPE_NAME,
                Function(x, y) New LocationTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property StatisticTypes As ITypeStore(Of IStatisticTypeStore) Implements IDataStore.StatisticTypes
        Get
            Return New TypeStore(Of IStatisticTypeStore)(
                ConnectionSource,
                TABLE_STATISTIC_TYPES,
                COLUMN_STATISTIC_TYPE_ID,
                COLUMN_STATISTIC_TYPE_NAME,
                Function(x, y) New StatisticTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CharacterTypes As ITypeStore(Of ICharacterTypeStore) Implements IDataStore.CharacterTypes
        Get
            Return New TypeStore(Of ICharacterTypeStore)(
                ConnectionSource,
                TABLE_CHARACTER_TYPES,
                COLUMN_CHARACTER_TYPE_ID,
                COLUMN_CHARACTER_TYPE_NAME,
                Function(x, y) New CharacterTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property Characters As ITypeStore(Of ICharacterStore) Implements IDataStore.Characters
        Get
            Return New TypeStore(Of ICharacterStore)(
                ConnectionSource,
                TABLE_CHARACTERS,
                COLUMN_CHARACTER_ID,
                COLUMN_CHARACTER_NAME,
                Function(x, y) New CharacterStore(x, y))
        End Get
    End Property

    Public ReadOnly Property Locations As ITypeStore(Of ILocationStore) Implements IDataStore.Locations
        Get
            Return New TypeStore(Of ILocationStore)(
                ConnectionSource,
                TABLE_LOCATIONS,
                COLUMN_LOCATION_ID,
                COLUMN_LOCATION_NAME,
                Function(x, y) New LocationStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CardTypes As ITypeStore(Of ICardTypeStore) Implements IDataStore.CardTypes
        Get
            Return New TypeStore(Of ICardTypeStore)(
                ConnectionSource,
                TABLE_CARD_TYPES,
                COLUMN_CARD_TYPE_ID,
                COLUMN_CARD_TYPE_NAME,
                Function(x, y) New CardTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CardTypeGenerators As ITypeStore(Of ICardTypeGeneratorStore) Implements IDataStore.CardTypeGenerators
        Get
            Return New TypeStore(Of ICardTypeGeneratorStore)(
                ConnectionSource,
                TABLE_CARD_TYPE_GENERATORS,
                COLUMN_CARD_TYPE_GENERATOR_ID,
                COLUMN_CARD_TYPE_GENERATOR_NAME,
                Function(x, y) New CardTypeGeneratorStore(x, y))
        End Get
    End Property

    Public ReadOnly Property EffectTypes As ITypeStore(Of IEffectTypeStore) Implements IDataStore.EffectTypes
        Get
            Return New TypeStore(Of IEffectTypeStore)(
                ConnectionSource,
                TABLE_EFFECT_TYPES,
                COLUMN_EFFECT_TYPE_ID,
                COLUMN_EFFECT_TYPE_NAME,
                Function(x, y) New EffectTypeStore(x, y))
        End Get
    End Property

    Public Sub CleanUp() Implements IDataStore.CleanUp
        If _connection IsNot Nothing Then
            _connection.Close()
            _connection = Nothing
        End If
    End Sub

    Public Function GetPlayer(playerId As Integer) As IPlayerStore Implements IDataStore.GetPlayer
        Return New PlayerStore(AddressOf GetConnection, playerId)
    End Function

    Public Function GetCharacter(characterId As Integer) As ICharacterStore Implements IDataStore.GetCharacter
        Return New CharacterStore(AddressOf GetConnection, characterId)
    End Function

    Public Function GetLocation(locationId As Integer) As ILocationStore Implements IDataStore.GetLocation
        Return New LocationStore(AddressOf GetConnection, locationId)
    End Function

    Public Function GetCharacterType(characterTypeId As Integer) As ICharacterTypeStore Implements IDataStore.GetCharacterType
        Return New CharacterTypeStore(AddressOf GetConnection, characterTypeId)
    End Function

    Public Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer) Implements IDataStore.GetCharacterTypeGenerator
        Dim result As New Dictionary(Of ICharacterTypeStore, Integer)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {COLUMN_CHARACTER_TYPE_ID}, 
    {COLUMN_GENERATOR_WEIGHT} 
FROM 
    {TABLE_CHARACTER_TYPES}
WHERE
    {COLUMN_GENERATOR_WEIGHT}>0;"
            Using reader = command.ExecuteReader
                While reader.Read
                    result(GetCharacterType(reader.GetInt32(0))) = reader.GetInt32(1)
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer) Implements IDataStore.GetLocationGenerator
        Dim result As New Dictionary(Of ILocationStore, Integer)
        Using command = GetConnection().CreateCommand
            command.CommandText = $"
SELECT 
    {COLUMN_LOCATION_ID}, 
    {COLUMN_GENERATOR_WEIGHT} 
FROM 
    {TABLE_LOCATION_STARTS};"
            Using reader = command.ExecuteReader
                While reader.Read
                    result(GetLocation(reader.GetInt32(0))) = reader.GetInt32(1)
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function CreateCharacter(characterName As String, location As ILocationStore, characterType As ICharacterTypeStore) As ICharacterStore Implements IDataStore.CreateCharacter

        Return New CharacterStore(
            ConnectionSource,
            ConnectionSource.Insert(
                TABLE_CHARACTERS,
                (COLUMN_CHARACTER_NAME, characterName),
                (COLUMN_LOCATION_ID, location.Id),
                (COLUMN_CHARACTER_TYPE_ID, characterType.Id)))
    End Function

    Private Function FindAuthorPlayer(authorId As ULong) As Integer?
        Return ConnectionSource.FindIntegerForValues(
            TABLE_PLAYERS,
            {(COLUMN_DISCORD_ID, CLng(authorId))},
            COLUMN_PLAYER_ID)
    End Function

    Public Function GetAuthorPlayer(authorId As ULong) As IPlayerStore Implements IDataStore.GetAuthorPlayer
        Dim playerId As Integer? = FindAuthorPlayer(authorId)
        If Not playerId.HasValue Then
            playerId = ConnectionSource.Insert(
                TABLE_PLAYERS,
                (COLUMN_DISCORD_ID, authorId))
        End If
        Return New PlayerStore(AddressOf GetConnection, playerId.Value)
    End Function
End Class
