Imports SPLORR.Data

Friend Class CharacterTypeListItem
    Friend ReadOnly Property Store As ICharacterTypeStore

    Public Sub New(item As ICharacterTypeStore)
        Me.Store = item
    End Sub
    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
