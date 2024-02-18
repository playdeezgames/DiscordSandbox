Imports SPLORR.Data

Public Interface ICharacterModel
    Property Name As String
    Property Location As ILocationModel
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterModel)
    Sub RefreshHand()
    Sub Die()
    Function HandCardByName(cardName As String) As ICardModel
    ReadOnly Property Cards As IEnumerable(Of ICardModel)
    ReadOnly Property CardCounts As IEnumerable(Of ICharacterCardCountModel)
    ReadOnly Property Hand As IEnumerable(Of ICardModel)
    ReadOnly Property Health As Integer
    ReadOnly Property MaximumHealth As Integer
    ReadOnly Property Satiety As Integer
    ReadOnly Property MaximumSatiety As Integer
    ReadOnly Property Energy As Integer
    ReadOnly Property MaximumEnergy As Integer
    ReadOnly Property HandSize As Integer
    ReadOnly Property Rocks As Integer
    ReadOnly Property PlantFibers As Integer
    ReadOnly Property Store As ICharacterStore
    Function AddCard(cardType As ICardTypeModel) As Boolean
    ReadOnly Property Inventory As IReadOnlyDictionary(Of String, Integer)
    ReadOnly Property GetStatistic(statisticType As IStatisticTypeModel) As ICharacterStatisticModel
    Sub DiscardHand()
End Interface
