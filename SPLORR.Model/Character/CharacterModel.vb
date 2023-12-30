Imports SPLORR.Data

Friend Class CharacterModel
    Implements ICharacterModel
    Private ReadOnly _characterStore As ICharacterStore
    Sub New(characterStore As ICharacterStore)
        _characterStore = characterStore
    End Sub
    Public Property Name As String Implements ICharacterModel.Name
        Get
            Return _characterStore.Name
        End Get
        Set(value As String)
            _characterStore.Name = value
        End Set
    End Property
    Public Property Location As ILocationModel Implements ICharacterModel.Location
        Get
            Return New LocationModel(_characterStore.Location)
        End Get
        Set(value As ILocationModel)
            _characterStore.Location = value.LocationStore
        End Set
    End Property

    Public ReadOnly Property HasOtherCharacters As Boolean Implements ICharacterModel.HasOtherCharacters
        Get
            Return _characterStore.HasOtherCharacters
        End Get
    End Property

    Public ReadOnly Property OtherCharacters As IEnumerable(Of ICharacterModel) Implements ICharacterModel.OtherCharacters
        Get
            Return _characterStore.OtherCharacters.Select(Function(x) New CharacterModel(x))
        End Get
    End Property

    Public Function UseRoute(route As IRouteModel) As (Result As Boolean, Messages As String()) Implements ICharacterModel.UseRoute
        If route Is Nothing Then
            Return (False, {"The route does not exist!"})
        End If
        If Not route.FromLocation.IsSameAs(Location) Then
            Return (False, {"The route is not available!"})
        End If
        Location = route.ToLocation
        Return (True, Array.Empty(Of String))
    End Function
End Class
