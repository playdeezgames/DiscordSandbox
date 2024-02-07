Public Class CharacterStatisticModel
    Implements ICharacterStatisticModel
    Private store As Data.ICharacterStatisticStore

    Public Sub New(characterStatisticStore As Data.ICharacterStatisticStore)
        Me.store = characterStatisticStore
    End Sub

    Public Property Value As Integer Implements ICharacterStatisticModel.Value
        Get
            Return store.Value
        End Get
        Set(value As Integer)
            store.Value = value
        End Set
    End Property
End Class
