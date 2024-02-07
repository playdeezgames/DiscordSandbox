Imports SPLORR.Data

Friend Class StatisticTypeModel
    Implements IStatisticTypeModel

    Private store As IStatisticTypeStore

    Public Sub New(store As IStatisticTypeStore)
        Me.store = store
    End Sub

    Public ReadOnly Property Name As String Implements IStatisticTypeModel.Name
        Get
            Return store.Name
        End Get
    End Property
End Class
