Imports SPLORR.Model

Friend Class FakeCharacterModel
    Implements ICharacterModel

    Public ReadOnly Property Name As String Implements ICharacterModel.Name
        Get
            Throw New NotImplementedException()
        End Get
    End Property
End Class
