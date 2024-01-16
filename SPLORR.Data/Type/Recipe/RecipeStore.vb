Imports Microsoft.Data.SqlClient
Imports Microsoft.IdentityModel.Tokens

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

    Public ReadOnly Property ItemTypes As IRelatedTypeStore(Of IRecipeItemTypeStore) Implements IRecipeStore.ItemTypes
        Get
            Return New RelatedTypeStore(Of IRecipeItemTypeStore, Integer)(
                connectionSource,
                VIEW_RECIPE_ITEM_TYPE_DETAILS,
                COLUMN_RECIPE_ITEM_TYPE_ID,
                COLUMN_ITEM_TYPE_NAME,
                (COLUMN_RECIPE_ID, Id),
                Function(x, y) New RecipeItemTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property CanAddItemType As Boolean Implements IRecipeStore.CanAddItemType
        Get
            Return connectionSource.CheckForValue(VIEW_RECIPE_AVAILABLE_ITEM_TYPES, (COLUMN_RECIPE_ID, Id))
        End Get
    End Property

    Public ReadOnly Property AvailableItemTypes As IRelatedTypeStore(Of IItemTypeStore) Implements IRecipeStore.AvailableItemTypes
        Get
            Return New RelatedTypeStore(Of IItemTypeStore, Integer)(
                connectionSource,
                VIEW_RECIPE_AVAILABLE_ITEM_TYPES,
                COLUMN_ITEM_TYPE_ID,
                COLUMN_ITEM_TYPE_NAME,
                (COLUMN_RECIPE_ID, Id),
                Function(x, y) New ItemTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property Inputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore)) Implements IRecipeStore.Inputs
        Get
            Dim result As New List(Of (Quantity As Integer, ItemType As IItemTypeStore))
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {COLUMN_QUANTITY_IN},
    {COLUMN_ITEM_TYPE_ID} 
FROM 
    {TABLE_RECIPE_ITEM_TYPES} 
WHERE 
    {COLUMN_RECIPE_ID}=@{COLUMN_RECIPE_ID} 
    AND {COLUMN_QUANTITY_IN}>0;"
                command.Parameters.AddWithValue($"@{COLUMN_RECIPE_ID}", Id)
                Using reader = command.ExecuteReader
                    While reader.Read
                        result.Add((reader.GetInt32(0), New ItemTypeStore(connectionSource, reader.GetInt32(1))))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property

    Public ReadOnly Property Outputs As IEnumerable(Of (Quantity As Integer, ItemType As IItemTypeStore)) Implements IRecipeStore.Outputs
        Get
            Dim result As New List(Of (Quantity As Integer, ItemType As IItemTypeStore))
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    {COLUMN_QUANTITY_OUT},
    {COLUMN_ITEM_TYPE_ID} 
FROM 
    {TABLE_RECIPE_ITEM_TYPES} 
WHERE 
    {COLUMN_RECIPE_ID}=@{COLUMN_RECIPE_ID} 
    AND {COLUMN_QUANTITY_OUT}>0;"
                command.Parameters.AddWithValue($"@{COLUMN_RECIPE_ID}", Id)
                Using reader = command.ExecuteReader
                    While reader.Read
                        result.Add((reader.GetInt32(0), New ItemTypeStore(connectionSource, reader.GetInt32(1))))
                    End While
                End Using
            End Using
            Return result
        End Get
    End Property

    Public Function CreateRecipeItemType(itemType As IItemTypeStore, quantityIn As Integer, quantityOut As Integer) As IRecipeItemTypeStore Implements IRecipeStore.CreateRecipeItemType
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_RECIPE_ITEM_TYPES}
    (
        {COLUMN_RECIPE_ID},
        {COLUMN_ITEM_TYPE_ID},
        {COLUMN_QUANTITY_IN},
        {COLUMN_QUANTITY_OUT}
    ) 
    VALUES 
    (
        {PARAMETER_RECIPE_ID},
        {PARAMETER_ITEM_TYPE_ID},
        {PARAMETER_QUANTITY_IN},
        @{COLUMN_QUANTITY_OUT});"
            command.Parameters.AddWithValue(PARAMETER_RECIPE_ID, Id)
            command.Parameters.AddWithValue(PARAMETER_ITEM_TYPE_ID, itemType.Id)
            command.Parameters.AddWithValue(PARAMETER_QUANTITY_IN, quantityIn)
            command.Parameters.AddWithValue($"@{COLUMN_QUANTITY_OUT}", quantityOut)
            command.ExecuteNonQuery()
        End Using
        Return New RecipeItemTypeStore(connectionSource, connectionSource.ReadLastIdentity)
    End Function
End Class
