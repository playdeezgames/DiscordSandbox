Imports SPLORR.Data

Public Interface ICardModel
    ReadOnly Property Name As String
    ReadOnly Property Store As ICardStore
    ReadOnly Property CanPlay As Boolean
    Sub Play(outputter As Action(Of String))
End Interface
