Imports SPLORR.Data

Friend Class CardTypeModel
    Implements ICardTypeModel
    ReadOnly Property Store As ICardTypeStore Implements ICardTypeModel.Store
    Sub New(store As ICardTypeStore)
        Me.store = store
    End Sub
    Public ReadOnly Property Name As String Implements ICardTypeModel.Name
        Get
            Return store.Name
        End Get
    End Property
End Class
