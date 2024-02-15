Public Interface ICardTypeGeneratorCardModel
    ReadOnly Property Name As String
    ReadOnly Property GeneratorWeight As Integer
    Function AsPercentage(totalWeight As Integer) As Double
    ReadOnly Property CardType As ICardTypeModel
End Interface
