Friend Class CharacterModel
    Implements ICharacterModel

    Public ReadOnly Property Name As String Implements ICharacterModel.Name
        Get
            Return "N00b"
        End Get
    End Property
End Class
