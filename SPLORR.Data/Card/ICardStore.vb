Public Interface ICardStore
    Inherits IBaseTypeStore
    ReadOnly Property Character As ICharacterStore
    WriteOnly Property DrawOrder As Integer
    ReadOnly Property InHand As Boolean
    Sub AddToHand()
    Sub Discard()
End Interface
