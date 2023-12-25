﻿Imports SPLORR.Model

Friend Class FakeWorldModel
    Implements IWorldModel
    Private _initializeCalled As Boolean = False
    Private _cleanUpCalled As Boolean = False
    Private ReadOnly _getPlayerHook As Func(Of ULong, FakePlayerModel)
    Private ReadOnly _fakePlayers As New Dictionary(Of ULong, FakePlayerModel)
    Friend Sub New(Optional getPlayerHook As Func(Of ULong, FakePlayerModel) = Nothing)
        _getPlayerHook = If(getPlayerHook, Function(a)
                                               Return New FakePlayerModel
                                           End Function)
    End Sub
    Friend ReadOnly Property InitializeCalled As Boolean
        Get
            Return _initializeCalled
        End Get
    End Property
    Friend ReadOnly Property CleanUpCalled As Boolean
        Get
            Return _cleanUpCalled
        End Get
    End Property

    Public Sub CleanUp() Implements IWorldModel.CleanUp
        _cleanUpCalled = True
    End Sub

    Public Sub Initialize() Implements IWorldModel.Initialize
        _initializeCalled = True
    End Sub

    Public Function GetPlayer(authorId As ULong) As IPlayerModel Implements IWorldModel.GetPlayer
        _fakePlayers(authorId) = _getPlayerHook(authorId)
        Return _fakePlayers(authorId)
    End Function
    Public ReadOnly Property FakePlayers As IReadOnlyDictionary(Of ULong, FakePlayerModel)
        Get
            Return _fakePlayers
        End Get
    End Property
End Class
