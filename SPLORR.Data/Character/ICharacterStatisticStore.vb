﻿Public Interface ICharacterStatisticStore
    Inherits IBaseTypeStore(Of IDataStore)
    Property Value As Integer
    Property Minimum As Integer?
    Property Maximum As Integer?
    ReadOnly Property Character As ICharacterStore
End Interface
