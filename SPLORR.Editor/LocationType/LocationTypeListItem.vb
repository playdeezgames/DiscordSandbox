Imports SPLORR.Data

Friend Class LocationTypeListItem
    Public ReadOnly Store As ILocationTypeStore
    Sub New(locationTypeStore As ILocationTypeStore)
        Me.Store = locationTypeStore
    End Sub
    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
