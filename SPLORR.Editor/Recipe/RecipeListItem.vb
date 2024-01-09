Imports SPLORR.Data

Friend Class RecipeListItem
    Friend ReadOnly Property Store As IRecipeStore

    Public Sub New(item As IRecipeStore)
        Me.Store = item
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
