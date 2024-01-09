Imports SPLORR.Data

Public Class StatisticTypeListItem
    Public ReadOnly Property StatisticTypeStore As IStatisticTypeStore

    Public Sub New(store As IStatisticTypeStore)
        Me.StatisticTypeStore = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{StatisticTypeStore.Name}(Id:{StatisticTypeStore.Id})"
    End Function
End Class
