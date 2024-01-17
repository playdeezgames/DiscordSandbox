Public Interface ICharacterTypeStatisticStore
    Inherits IBaseTypeStore
    Property Value As Integer
    ReadOnly Property CharacterType As ICharacterTypeStore
    ReadOnly Property StatisticType As IStatisticTypeStore
End Interface
