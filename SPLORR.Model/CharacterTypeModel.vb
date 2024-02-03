Imports SPLORR.Data

Friend Class CharacterTypeModel
    Implements ICharacterTypeModel
    Public Sub New(store As ICharacterTypeStore)
        Me.Store = store
    End Sub

    Public ReadOnly Property Store As ICharacterTypeStore Implements ICharacterTypeModel.Store

    Public ReadOnly Property Name As String Implements ICharacterTypeModel.Name
        Get
            Return Store.Name
        End Get
    End Property
End Class
