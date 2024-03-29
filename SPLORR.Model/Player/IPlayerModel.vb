﻿Public Interface IPlayerModel
    ReadOnly Property HasCharacter As Boolean
    Function FindSelectableCharacterType(characterTypeName As String) As ICharacterTypeModel
    ReadOnly Property SelectableCharacterTypes As IEnumerable(Of ICharacterTypeModel)
    Sub CreateCharacter(Optional characterType As ICharacterTypeModel = Nothing)
    ReadOnly Property Character As ICharacterModel
End Interface
