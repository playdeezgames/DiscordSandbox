Public Interface ICardTypeGeneratorCardModel
    ReadOnly Property Name As String
    ReadOnly Property GeneratorWeight As Integer
    Function AsPercentage(totalWeight As Integer) As Double
End Interface
