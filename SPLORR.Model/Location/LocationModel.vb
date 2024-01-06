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

    Public ReadOnly Property HasRoutes As Boolean Implements ILocationModel.HasRoutes
        Get
            Return _locationStore.HasRoutes
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRouteModel) Implements ILocationModel.Routes
        Get
            Return _locationStore.Routes.Select(Function(x) New RouteModel(x))
        End Get
    End Property

    Public ReadOnly Property LocationStore As ILocationStore Implements ILocationModel.LocationStore
        Get
            Return _locationStore
        End Get
    End Property

    Public ReadOnly Property Inventory As IInventoryModel Implements ILocationModel.Inventory
        Get
            Return New InventoryModel(_locationStore)
        End Get
    End Property

    Public Function FindRouteByDirectionName(directionName As String) As IRouteModel Implements ILocationModel.FindRouteByDirectionName
        Dim routeStore As IRouteStore = _locationStore.FindRouteByDirectionName(directionName)
        Return If(routeStore IsNot Nothing, New RouteModel(routeStore), Nothing)
    End Function

    Public Function IsSameAs(otherLocation As ILocationModel) As Boolean Implements ILocationModel.IsSameAs
        Return LocationStore.Id = otherLocation.LocationStore.Id
    End Function

    Public Function GenerateForageItem(destination As IInventoryModel) As IItemModel Implements ILocationModel.GenerateForageItem
        Dim generator As IItemTypeGeneratorStore = LocationStore.LocationType.ItemTypeGenerator
        If generator Is Nothing Then
            Return Nothing
        End If
        Dim totalWeight As Integer = generator.TotalWeight
        If totalWeight < 1 Then
            Return Nothing
        End If
        Dim generated = RNG.FromRange(0, totalWeight - 1)
        Dim itemType As IItemTypeStore = generator.Generate(generated)
        If itemType Is Nothing Then
            Return Nothing
        End If
        Return New ItemModel(itemType.CreateItem(destination.InventoryStore))
    End Function
End Class
