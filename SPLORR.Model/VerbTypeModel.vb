Imports SPLORR.Data

Friend Class VerbTypeModel
    Implements IVerbTypeModel
    Private ReadOnly verbTypeStore As IVerbTypeStore
    Sub New(verbTypeStore As IVerbTypeStore)
        Me.verbTypeStore = verbTypeStore
    End Sub

    Public ReadOnly Property Store As IVerbTypeStore Implements IVerbTypeModel.Store
        Get
            Return verbTypeStore
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IVerbTypeModel.Name
        Get
            Return verbTypeStore.Name
        End Get
    End Property
End Class
