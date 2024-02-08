Imports SPLORR.Data
Imports SPLORR.Game

Public Class CardTypeGeneratorModel
    Implements ICardTypeGeneratorModel

    Private store As ICardTypeGeneratorStore

    Public Sub New(store As ICardTypeGeneratorStore)
        Me.store = store
    End Sub

    Public Function GenerateCardType() As ICardTypeModel Implements ICardTypeGeneratorModel.GenerateCardType
        Return New CardTypeModel(
            RNG.FromGenerator(
                store.CardTypes.All.ToDictionary(
                    Function(x) x.CardType,
                    Function(x) x.GeneratorWeight)))
    End Function
End Class
