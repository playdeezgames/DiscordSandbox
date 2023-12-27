Imports SPLORR.Model

Friend Class FakePlayerModel
    Implements IPlayerModel
    Private _fakeCharacter As FakeCharacterModel = Nothing
    Sub New(Optional characterModel As FakeCharacterModel = Nothing)
        _fakeCharacter = characterModel
    End Sub
    ReadOnly Property FakeCharacter As FakeCharacterModel
        Get
            Return _fakeCharacter
        End Get
    End Property

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerModel.HasCharacter
        Get
            Return _fakeCharacter IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterModel Implements IPlayerModel.Character
        Get
            Return _fakeCharacter
        End Get
    End Property

    Public Sub CreateCharacter() Implements IPlayerModel.CreateCharacter
        _fakeCharacter = New FakeCharacterModel
    End Sub
End Class
