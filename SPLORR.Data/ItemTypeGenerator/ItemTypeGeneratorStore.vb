Imports Microsoft.Data.SqlClient

Friend Class ItemTypeGeneratorStore
    Inherits BaseTypeStore
    Implements IItemTypeGeneratorStore
    Const NOTHING_GENERATOR_WEIGHT_MINIMUM = 0

    Public Sub New(connectionSource As Func(Of SqlConnection), itemTypeGeneratorId As Integer)
        MyBase.New(
            connectionSource,
            itemTypeGeneratorId,
            TABLE_ITEM_TYPE_GENERATORS,
            COLUMN_ITEM_TYPE_GENERATOR_ID,
            COLUMN_ITEM_TYPE_GENERATOR_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForValues(
                    TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                    (COLUMN_ITEM_TYPE_GENERATOR_ID, Id)) AndAlso
                Not connectionSource.CheckForValues(
                    TABLE_LOCATION_TYPES,
                    (COLUMN_ITEM_TYPE_GENERATOR_ID, Id))
        End Get
    End Property

    Public ReadOnly Property TotalWeight As Integer Implements IItemTypeGeneratorStore.TotalWeight
        Get
            Dim total = NothingGeneratorWeight
            Using command = connectionSource().CreateCommand
                command.CommandText = $"
SELECT 
    SUM({COLUMN_GENERATOR_WEIGHT}) 
FROM 
    {TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES} 
WHERE 
    {COLUMN_ITEM_TYPE_GENERATOR_ID}=@{COLUMN_ITEM_TYPE_GENERATOR_ID};"
                command.Parameters.AddWithValue($"@{COLUMN_ITEM_TYPE_GENERATOR_ID}", Id)
                Return CInt(command.ExecuteScalar) + total
            End Using
        End Get
    End Property

    Public ReadOnly Property HasItemTypes As Boolean Implements IItemTypeGeneratorStore.HasItemTypes
        Get
            Return connectionSource.CheckForValues(
                TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_GENERATOR_ID, Id))
        End Get
    End Property

    Public ReadOnly Property CanAddItemType As Boolean Implements IItemTypeGeneratorStore.CanAddItemType
        Get
            Using command = connectionSource().CreateCommand
                command.CommandText = $"SELECT COUNT(1) FROM {VIEW_ITEM_TYPE_GENERATOR_AVAILABLE_ITEM_TYPES} WHERE {COLUMN_ITEM_TYPE_GENERATOR_ID}=@{COLUMN_ITEM_TYPE_GENERATOR_ID};"
                command.Parameters.AddWithValue($"@{COLUMN_ITEM_TYPE_GENERATOR_ID}", Id)
                Return CInt(command.ExecuteScalar) > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property ItemTypes As ITypeStore(Of IItemTypeGeneratorItemTypeStore) Implements IItemTypeGeneratorStore.ItemTypes
        Get
            Return New TypeStore(Of IItemTypeGeneratorItemTypeStore)(
                connectionSource,
                VIEW_ITEM_TYPE_GENERATOR_ITEM_TYPE_DETAILS,
                COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID,
                COLUMN_ITEM_TYPE_NAME,
                Function(x, y) New ItemTypeGeneratorItemTypeStore(x, y))
        End Get
    End Property

    Public ReadOnly Property AvailableItemTypes As ITypeStore(Of IItemTypeStore) Implements IItemTypeGeneratorStore.AvailableItemTypes
        Get
            Return New TypeStore(Of IItemTypeStore)(
                connectionSource,
                VIEW_ITEM_TYPE_GENERATOR_AVAILABLE_ITEM_TYPES,
                COLUMN_ITEM_TYPE_ID,
                COLUMN_ITEM_TYPE_NAME,
                Function(x, y) New ItemTypeStore(x, y))
        End Get
    End Property

    Public Property NothingGeneratorWeight As Integer Implements IItemTypeGeneratorStore.NothingGeneratorWeight
        Get
            Return connectionSource.ReadIntegerForValue(
                TABLE_ITEM_TYPE_GENERATORS,
                (COLUMN_ITEM_TYPE_GENERATOR_ID, Id),
                COLUMN_NOTHING_GENERATOR_WEIGHT)
        End Get
        Set(value As Integer)
            connectionSource.WriteValuesForValues(
                TABLE_ITEM_TYPE_GENERATORS,
                {(COLUMN_ITEM_TYPE_GENERATOR_ID, Id)},
                {(COLUMN_NOTHING_GENERATOR_WEIGHT, Math.Max(NOTHING_GENERATOR_WEIGHT_MINIMUM, value))})
        End Set
    End Property

    Public Function AddItemType(itemType As IItemTypeStore, quantity As Integer) As IItemTypeGeneratorItemTypeStore Implements IItemTypeGeneratorStore.AddItemType
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
INSERT INTO 
    {TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES}
    (
        {COLUMN_ITEM_TYPE_ID},
        {COLUMN_ITEM_TYPE_GENERATOR_ID},
        {COLUMN_GENERATOR_WEIGHT}
    ) 
    VALUES 
    (
        @{COLUMN_ITEM_TYPE_ID},
        @{COLUMN_ITEM_TYPE_GENERATOR_ID},
        @{COLUMN_GENERATOR_WEIGHT}
    );"
            command.Parameters.AddWithValue($"@{COLUMN_ITEM_TYPE_ID}", itemType.Id)
            command.Parameters.AddWithValue($"@{COLUMN_ITEM_TYPE_GENERATOR_ID}", Id)
            command.Parameters.AddWithValue($"@{COLUMN_GENERATOR_WEIGHT}", quantity)
            command.ExecuteNonQuery()
        End Using
        Return New ItemTypeGeneratorItemTypeStore(connectionSource, connectionSource.ReadLastIdentity)
    End Function

    Public Function Generate(generated As Integer) As IItemTypeStore Implements IItemTypeGeneratorStore.Generate
        If generated < 0 Then
            Return Nothing
        End If
        Dim nothingWeight = NothingGeneratorWeight
        If generated < nothingWeight Then
            Return Nothing
        End If
        generated -= nothingWeight
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {COLUMN_ITEM_TYPE_ID},
    {COLUMN_GENERATOR_WEIGHT} 
FROM 
    {TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES} 
WHERE 
    {COLUMN_ITEM_TYPE_GENERATOR_ID}=@{COLUMN_ITEM_TYPE_GENERATOR_ID} 
ORDER BY 
    {COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID} ASC;"
            command.Parameters.AddWithValue($"@{COLUMN_ITEM_TYPE_GENERATOR_ID}", Id)
            Using reader = command.ExecuteReader
                While reader.Read
                    Dim generatorWeight = reader.GetInt32(1)
                    If generated < generatorWeight Then
                        If reader.IsDBNull(0) Then
                            Return Nothing
                        End If
                        Return New ItemTypeStore(connectionSource, reader.GetInt32(0))
                    End If
                    generated -= generatorWeight
                End While
            End Using
        End Using
        Return Nothing
    End Function
End Class
