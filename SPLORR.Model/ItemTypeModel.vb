Imports SPLORR.Data

Friend Class ItemTypeModel
    Implements IItemTypeModel

    Private store As IItemTypeStore

    Public Sub New(key As IItemTypeStore)
        Me.store = key
    End Sub

    Public ReadOnly Property Name As String Implements IItemTypeModel.Name
        Get
            Return store.Name
        End Get
    End Property
End Class
