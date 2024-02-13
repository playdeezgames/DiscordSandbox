Friend Class CharacterCardCountModel
    Implements ICharacterCardCountModel
    Sub New(name As String, quantity As Integer, limit As Integer?)
        Me.Name = name
        Me.Quantity = quantity
        Me.Limit = limit
    End Sub

    Public ReadOnly Property Name As String Implements ICharacterCardCountModel.Name

    Public ReadOnly Property Quantity As Integer Implements ICharacterCardCountModel.Quantity

    Public ReadOnly Property Limit As Integer? Implements ICharacterCardCountModel.Limit
End Class
