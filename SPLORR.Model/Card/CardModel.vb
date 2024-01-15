Imports SPLORR.Data

Friend Class CardModel
    Implements ICardModel

    Public ReadOnly Property Store As ICardStore Implements ICardModel.Store

    Public ReadOnly Property Name As String Implements ICardModel.Name
        Get
            Return Store.Name
        End Get
    End Property

    Public Sub New(store As ICardStore)
        Me.Store = store
    End Sub
End Class
