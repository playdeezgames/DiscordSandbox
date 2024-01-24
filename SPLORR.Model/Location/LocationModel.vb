Imports SPLORR.Data
Imports SPLORR.Game

Friend Class LocationModel
    Implements ILocationModel

    Private _locationStore As Data.ILocationStore


    Public Sub New(locationStore As Data.ILocationStore)
        Me._locationStore = locationStore
    End Sub

    Public ReadOnly Property Name As String Implements ILocationModel.Name
        Get
            Return _locationStore.Name
        End Get
    End Property

    Public ReadOnly Property LocationStore As ILocationStore Implements ILocationModel.LocationStore
        Get
            Return _locationStore
        End Get
    End Property

    Public Function IsSameAs(otherLocation As ILocationModel) As Boolean Implements ILocationModel.IsSameAs
        Return LocationStore.Id = otherLocation.LocationStore.Id
    End Function
End Class
