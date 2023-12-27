Friend Class PlayerModel
    Implements IPlayerModel
    Private _hasCharacter As Boolean = False

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerModel.HasCharacter
        Get
            Return _hasCharacter
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterModel Implements IPlayerModel.Character
        Get
            Return If(HasCharacter, New CharacterModel(), Nothing)
        End Get
    End Property

    Public Sub CreateCharacter() Implements IPlayerModel.CreateCharacter
        _hasCharacter = True
    End Sub
End Class
