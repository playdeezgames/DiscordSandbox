﻿Public Interface ICharacterStore
    Inherits IBaseTypeStore(Of IDataStore)
    Property Location As ILocationStore
    Sub SetLocation(location As ILocationStore, lastModified As DateTimeOffset)
    Sub ClearPlayer()
    Function AddStatistic(statisticType As IStatisticTypeStore, statisticValue As Integer, minimumValue As Integer?, maximumValue As Integer?) As ICharacterStatisticStore
    ReadOnly Property HasOtherCharacters As Boolean
    ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterStore)
    Property CharacterType As ICharacterTypeStore
    ReadOnly Property Cards As IDeckStore
    ReadOnly Property Statistics As IRelatedTypeStore(Of ICharacterStatisticStore)
    ReadOnly Property HasPlayer As Boolean
    ReadOnly Property AvailableStatistics As IRelatedTypeStore(Of IStatisticTypeStore)
    Function CardTypeCount(cardType As ICardTypeStore) As Integer
    Function SatisfiesRequirements(effectType As IEffectTypeStore) As Boolean
    ReadOnly Property EffectiveHandSize As Integer
End Interface
