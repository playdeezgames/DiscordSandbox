Imports SPLORR.Data

Friend Class CardTypeGeneratorCardModel
    Implements ICardTypeGeneratorCardModel

    Private ReadOnly store As ICardTypeGeneratorCardTypeStore

    Public Sub New(store As ICardTypeGeneratorCardTypeStore)
        Me.store = store
    End Sub

    Public ReadOnly Property Name As String Implements ICardTypeGeneratorCardModel.Name
        Get
            Return store.Name
        End Get
    End Property

    Public ReadOnly Property GeneratorWeight As Integer Implements ICardTypeGeneratorCardModel.GeneratorWeight
        Get
            Return store.GeneratorWeight
        End Get
    End Property

    Public ReadOnly Property CardType As ICardTypeModel Implements ICardTypeGeneratorCardModel.CardType
        Get
            Return New CardTypeModel(store.CardType)
        End Get
    End Property

    Public Function AsPercentage(totalWeight As Integer) As Double Implements ICardTypeGeneratorCardModel.AsPercentage
        Return GeneratorWeight * 100.0 / totalWeight
    End Function
End Class
