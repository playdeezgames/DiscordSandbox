Imports SPLORR.Data

Friend Class CharacterListItem
    Friend ReadOnly Property Store As ICharacterStore

    Public Sub New(item As ICharacterStore)
        Me.Store = item
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
