Imports SPLORR.Data

Friend Class RouteTypeListItem
    Friend ReadOnly Property Store As IRouteTypeStore

    Public Sub New(item As IRouteTypeStore)
        Me.Store = item
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
