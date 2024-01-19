﻿Public Interface ICharacterTypeStatisticStore
    Inherits IBaseTypeStore
    Property Value As Integer
    Property Minimum As Integer?
    Property Maximum As Integer?
    ReadOnly Property CharacterType As ICharacterTypeStore
    ReadOnly Property StatisticType As IStatisticTypeStore
End Interface
