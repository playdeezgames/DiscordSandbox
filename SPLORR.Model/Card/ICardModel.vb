﻿Imports SPLORR.Data

Public Interface ICardModel
    ReadOnly Property Name As String
    ReadOnly Property Store As ICardStore
    ReadOnly Property Character As ICharacterModel
    ReadOnly Property InHand As Boolean
    Sub Discard()
End Interface
