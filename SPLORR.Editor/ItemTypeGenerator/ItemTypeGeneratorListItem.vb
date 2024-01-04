Imports SPLORR.Data

Friend Class ItemTypeGeneratorListItem
    Private item As IItemTypeGeneratorStore

    Public Sub New(item As IItemTypeGeneratorStore)
        Me.item = item
    End Sub
    Friend ReadOnly Property ItemTypeGeneratorStore As IItemTypeGeneratorStore
        Get
            Return item
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return $"{item.Name}(Id:{item.Id})"
    End Function
End Class
