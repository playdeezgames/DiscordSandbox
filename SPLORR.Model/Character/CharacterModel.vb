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

    Public ReadOnly Property Location As ILocationModel Implements ICharacterModel.Location
        Get
            Return New LocationModel(_characterStore.GetLocation())
        End Get
    End Property
End Class
