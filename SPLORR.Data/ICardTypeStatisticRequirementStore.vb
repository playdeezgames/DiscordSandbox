﻿Public Interface ICardTypeStatisticRequirementStore
    ReadOnly Property Statistic As IStatisticTypeStore
    ReadOnly Property Minimum As Integer?
    ReadOnly Property Maximum As Integer?
End Interface
