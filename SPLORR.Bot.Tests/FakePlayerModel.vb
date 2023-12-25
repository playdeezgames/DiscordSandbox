Imports SPLORR.Model

Friend Class FakePlayerModel
    Implements IPlayerModel
    Private _fakeCharacter As FakeCharacterModel = Nothing
    ReadOnly Property FakeCharacter As FakeCharacterModel
        Get
            Return _fakeCharacter
        End Get
    End Property

    Public Sub CreateCharacter() Implements IPlayerModel.CreateCharacter
        _fakeCharacter = New FakeCharacterModel
    End Sub
End Class
