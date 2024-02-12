Public Interface IEffectTypeCardTypeGeneratorStore
    ReadOnly Property Name As String
    ReadOnly Property CardCount As Integer
    ReadOnly Property CardTypes As IEnumerable(Of ICardTypeGeneratorCardTypeStore)
End Interface
