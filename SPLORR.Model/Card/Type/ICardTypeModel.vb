Imports SPLORR.Data

Public Interface ICardTypeModel
    ReadOnly Property Name As String
    ReadOnly Property Store As ICardTypeStore
    ReadOnly Property Limit As Integer?
End Interface
