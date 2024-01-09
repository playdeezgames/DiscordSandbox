Imports SPLORR.Data

Public Class StatisticTypeListItem
    Public ReadOnly Property Store As IStatisticTypeStore

    Public Sub New(store As IStatisticTypeStore)
        Me.Store = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
