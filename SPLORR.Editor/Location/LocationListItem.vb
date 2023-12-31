Imports SPLORR.Data

Friend Class LocationListItem
    Public ReadOnly Property LocationStore As ILocationStore

    Public Sub New(store As ILocationStore)
        Me.LocationStore = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{LocationStore.Name}(Id:{LocationStore.Id})"
    End Function
End Class
