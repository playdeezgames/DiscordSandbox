Imports SPLORR.Data

Public Class EffectTypeCardTypeGeneratorModel
    Implements IEffectTypeCardTypeGeneratorModel

    Private ReadOnly store As IEffectTypeCardTypeGeneratorStore

    Public Sub New(store As IEffectTypeCardTypeGeneratorStore)
        Me.store = store
    End Sub

    Public ReadOnly Property CardCount As Integer Implements IEffectTypeCardTypeGeneratorModel.CardCount
        Get
            Return store.CardCount
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IEffectTypeCardTypeGeneratorModel.Name
        Get
            Return store.Name
        End Get
    End Property

    Public ReadOnly Property CardTypes As IEnumerable(Of ICardTypeGeneratorCardModel) Implements IEffectTypeCardTypeGeneratorModel.CardTypes
        Get
            Return store.CardTypes.Select(Function(x) New CardTypeGeneratorCardModel(x))
        End Get
    End Property
End Class
