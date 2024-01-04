Imports SPLORR.Data

Public Class DirectionListItem
    Public ReadOnly Property DirectionStore As IDirectionStore

    Public Sub New(store As IDirectionStore)
        Me.DirectionStore = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{DirectionStore.Name}(Id:{DirectionStore.Id})"
    End Function
End Class
