Imports Microsoft.Data.SqlClient

Friend Class RecipeStore
    Inherits BaseTypeStore
    Implements IRecipeStore

    Public Sub New(
                  connectionSource As Func(Of SqlConnection),
                  id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_RECIPES,
            COLUMN_RECIPE_ID,
            COLUMN_RECIPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForValue(TABLE_RECIPE_ITEM_TYPES, (COLUMN_RECIPE_ID, Id))
        End Get
    End Property
End Class
