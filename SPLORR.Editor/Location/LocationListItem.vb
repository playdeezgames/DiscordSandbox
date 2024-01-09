Imports SPLORR.Data

Friend Class LocationListItem
    Public ReadOnly Property Store As ILocationStore

    Public Sub New(store As ILocationStore)
        Me.Store = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
