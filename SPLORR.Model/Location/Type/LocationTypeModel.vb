Friend Class LocationTypeModel
    Implements ILocationTypeModel

    Private ReadOnly store As Data.ILocationTypeStore

    Public Sub New(store As Data.ILocationTypeStore)
        Me.store = store
    End Sub

    Public ReadOnly Property Name As String Implements ILocationTypeModel.Name
        Get
            Return store.Name
        End Get
    End Property
End Class
