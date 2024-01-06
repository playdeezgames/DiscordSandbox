Imports SPLORR.Data

Friend Class ItemModel
    Implements IItemModel

    Public ReadOnly Property ItemStore As IItemStore Implements IItemModel.ItemStore

    Public Sub New(itemStore As IItemStore)
        Me.itemStore = itemStore
    End Sub

    Public ReadOnly Property Name As String Implements IItemModel.Name
        Get
            Return ItemStore.Name
        End Get
    End Property
End Class
