Imports SPLORR.Data

Public Class LocationTypeListItem
    Public ReadOnly LocationTypeStore As ILocationTypeStore
    Sub New(locationTypeStore As ILocationTypeStore)
        Me.LocationTypeStore = locationTypeStore
    End Sub
    Public Overrides Function ToString() As String
        Return $"{LocationTypeStore.Name}(Id:{LocationTypeStore.Id})"
    End Function
End Class
