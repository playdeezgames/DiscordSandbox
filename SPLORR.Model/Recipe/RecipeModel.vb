Imports SPLORR.Data

Friend Class RecipeModel
    Implements IRecipeModel
    ReadOnly Property Store As IRecipeStore Implements IRecipeModel.Store

    Public Sub New(recipe As IRecipeStore)
        Me.store = recipe
    End Sub
End Class
