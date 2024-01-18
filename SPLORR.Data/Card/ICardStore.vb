Public Interface ICardStore
    Inherits IBaseTypeStore
    ReadOnly Property Character As ICharacterStore
    WriteOnly Property DrawOrder As Integer
    Sub AddToHand()
    Sub Discard()
End Interface
