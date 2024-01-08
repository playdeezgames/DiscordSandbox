Imports Microsoft.Data.SqlClient

Friend Class ItemTypeGeneratorStore
    Inherits BaseTypeStore
    Implements IItemTypeGeneratorStore

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
            Return Not connectionSource.CheckForValue(
                    TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                    (COLUMN_ITEM_TYPE_GENERATOR_ID, Id)) AndAlso
                Not connectionSource.CheckForValue(
                    TABLE_LOCATION_TYPES,
                    (COLUMN_ITEM_TYPE_GENERATOR_ID, Id))
        End Get
    End Property

    Public ReadOnly Property TotalWeight As Integer Implements IItemTypeGeneratorStore.TotalWeight
        Get
            Using command = connectionSource().CreateCommand
                command.CommandText = $"SELECT SUM({COLUMN_GENERATOR_WEIGHT}) FROM {TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES} WHERE {COLUMN_ITEM_TYPE_GENERATOR_ID}={PARAMETER_ITEM_TYPE_GENERATOR_ID};"
                command.Parameters.AddWithValue(PARAMETER_ITEM_TYPE_GENERATOR_ID, Id)
                Return CInt(command.ExecuteScalar)
            End Using
        End Get
    End Property

    Public ReadOnly Property HasItemTypes As Boolean Implements IItemTypeGeneratorStore.HasItemTypes
        Get
            Return connectionSource.CheckForValue(
                TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES,
                (COLUMN_ITEM_TYPE_GENERATOR_ID, Id))
        End Get
    End Property

    Public ReadOnly Property CanAddItemType As Boolean Implements IItemTypeGeneratorStore.CanAddItemType
        Get
            Using command = connectionSource().CreateCommand
                command.CommandText = $"SELECT COUNT(1) FROM {VIEW_ITEM_TYPE_GENERATOR_AVAILABLE_ITEM_TYPES} WHERE {COLUMN_ITEM_TYPE_GENERATOR_ID}={PARAMETER_ITEM_TYPE_GENERATOR_ID} AND {COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID} IS NULL;"
                command.Parameters.AddWithValue(PARAMETER_ITEM_TYPE_GENERATOR_ID, Id)
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

    Public Function Generate(generated As Integer) As IItemTypeStore Implements IItemTypeGeneratorStore.Generate
        If generated < 0 Then
            Return Nothing
        End If
        Using command = connectionSource().CreateCommand
            command.CommandText = $"SELECT {COLUMN_ITEM_TYPE_ID},{COLUMN_GENERATOR_WEIGHT} FROM {TABLE_ITEM_TYPE_GENERATOR_ITEM_TYPES} WHERE {COLUMN_ITEM_TYPE_GENERATOR_ID}={PARAMETER_ITEM_TYPE_GENERATOR_ID} ORDER BY {COLUMN_ITEM_TYPE_GENERATOR_ITEM_TYPE_ID} ASC;"
            command.Parameters.AddWithValue(PARAMETER_ITEM_TYPE_GENERATOR_ID, Id)
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
