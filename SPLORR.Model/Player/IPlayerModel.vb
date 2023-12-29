Public Interface IPlayerModel
    ReadOnly Property HasCharacter As Boolean
    Sub CreateCharacter()
    ReadOnly Property Character As ICharacterModel
End Interface
