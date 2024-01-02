Public Interface IPlayerModel
    ReadOnly Property HasCharacter As Boolean
    Sub CreateCharacter()
    ReadOnly Property Character As ICharacterModel
    Function GetVerbTypeByName(verbTypeName As String) As IVerbTypeModel
End Interface
