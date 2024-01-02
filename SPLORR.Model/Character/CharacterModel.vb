Imports SPLORR.Data

Friend Class CharacterModel
    Implements ICharacterModel
    Private Shared ReadOnly verbTypeHandlers As IReadOnlyDictionary(Of String, Action(Of ICharacterModel, Action(Of String))) =
        New Dictionary(Of String, Action(Of ICharacterModel, Action(Of String))) From
        {
            {VERB_FORAGE, AddressOf Verbs.OnCharacterForage}
        }

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
            _characterStore.SetLocation(value.LocationStore, DateTimeOffset.Now)
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

    Public Sub DoVerb(verbType As IVerbTypeModel, outputter As Action(Of String)) Implements ICharacterModel.DoVerb
        verbTypeHandlers(verbType.Name)(Me, outputter)
    End Sub

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

    Public Function CanDoVerb(verbType As IVerbTypeModel) As Boolean Implements ICharacterModel.CanDoVerb
        Return _characterStore.CanDoVerb(verbType.Store)
    End Function
End Class
