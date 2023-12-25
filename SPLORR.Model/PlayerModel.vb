Friend Class PlayerModel
    Implements IPlayerModel

    Public ReadOnly Property HasCharacter As Boolean Implements IPlayerModel.HasCharacter
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Sub CreateCharacter() Implements IPlayerModel.CreateCharacter
        Throw New NotImplementedException()
    End Sub
End Class
