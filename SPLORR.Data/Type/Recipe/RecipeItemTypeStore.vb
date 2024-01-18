Imports Microsoft.Data.SqlClient

Friend Class RecipeItemTypeStore
    Implements IRecipeItemTypeStore

    Private connectionSource As Func(Of SqlConnection)

    Public Sub New(x As Func(Of SqlConnection), y As Integer)
        Me.connectionSource = x
        Me.Id = y
    End Sub

    Public ReadOnly Property Id As Integer Implements IRecipeItemTypeStore.Id

    Public ReadOnly Property ItemType As IItemTypeStore Implements IRecipeItemTypeStore.ItemType
        Get
            Return New ItemTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_RECIPE_ITEM_TYPES,
                    {(COLUMN_RECIPE_ITEM_TYPE_ID, Id)},
                    COLUMN_ITEM_TYPE_ID))
        End Get
    End Property

    Public ReadOnly Property QuantityIn As Integer Implements IRecipeItemTypeStore.QuantityIn
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_RECIPE_ITEM_TYPES,
                {(COLUMN_RECIPE_ITEM_TYPE_ID, Id)},
                COLUMN_QUANTITY_IN)
        End Get
    End Property

    Public ReadOnly Property QuantityOut As Integer Implements IRecipeItemTypeStore.QuantityOut
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_RECIPE_ITEM_TYPES,
                {(COLUMN_RECIPE_ITEM_TYPE_ID, Id)},
                COLUMN_QUANTITY_OUT)
        End Get
    End Property

    Public ReadOnly Property Recipe As IRecipeStore Implements IRecipeItemTypeStore.Recipe
        Get
            Return New RecipeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_RECIPE_ITEM_TYPES,
                    {(COLUMN_RECIPE_ITEM_TYPE_ID, Id)},
                    COLUMN_RECIPE_ID))
        End Get
    End Property

    Public Sub Delete() Implements IRecipeItemTypeStore.Delete
        connectionSource.DeleteForValues(TABLE_RECIPE_ITEM_TYPES, (COLUMN_RECIPE_ITEM_TYPE_ID, Id))
    End Sub
End Class
