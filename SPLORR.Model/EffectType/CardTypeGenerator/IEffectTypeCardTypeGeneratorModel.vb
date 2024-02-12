Public Interface IEffectTypeCardTypeGeneratorModel
    ReadOnly Property CardCount As Integer
    ReadOnly Property Name As String
    ReadOnly Property CardTypes As IEnumerable(Of ICardTypeGeneratorCardModel)
End Interface
