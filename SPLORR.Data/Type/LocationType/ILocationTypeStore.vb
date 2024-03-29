﻿Public Interface ILocationTypeStore
    Inherits IBaseTypeStore(Of IDataStore)
    ReadOnly Property HasLocations As Boolean
    Function FilterLocations(filter As String) As IEnumerable(Of ILocationStore)
    Function CreateLocation(name As String) As ILocationStore
End Interface
