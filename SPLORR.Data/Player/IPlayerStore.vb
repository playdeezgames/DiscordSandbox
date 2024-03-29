﻿Public Interface IPlayerStore
    ReadOnly Property HasCharacter As Boolean
    Function CreateCharacter(
                            characterName As String,
                            location As ILocationStore,
                            characterType As ICharacterTypeStore,
                            statistics As IReadOnlyDictionary(Of IStatisticTypeStore, (Value As Integer, Minimum As Integer?, Maximum As Integer?))) As ICharacterStore
    Function GetCharacterTypeGenerator() As IReadOnlyDictionary(Of ICharacterTypeStore, Integer)
    Function GetLocationGenerator() As IReadOnlyDictionary(Of ILocationStore, Integer)
    Property Character As ICharacterStore
    ReadOnly Property Store As IDataStore
End Interface
