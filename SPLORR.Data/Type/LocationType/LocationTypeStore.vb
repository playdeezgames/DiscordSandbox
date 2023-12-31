﻿Imports Microsoft.Data.SqlClient

Friend Class LocationTypeStore
    Inherits BaseTypeStore
    Implements ILocationTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), locationTypeId As Integer)
        MyBase.New(
            connectionSource,
            locationTypeId,
            TABLE_LOCATION_TYPES,
            COLUMN_LOCATION_TYPE_ID,
            COLUMN_LOCATION_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not HasLocations
        End Get
    End Property

    Public ReadOnly Property HasLocations As Boolean Implements ILocationTypeStore.HasLocations
        Get
            Return connectionSource.CheckForValue(
                TABLE_LOCATIONS,
                (COLUMN_LOCATION_TYPE_ID, Id))
        End Get
    End Property

    Public Property ItemTypeGenerator As IItemTypeGeneratorStore Implements ILocationTypeStore.ItemTypeGenerator
        Get
            Dim itemTypeGeneratorId = connectionSource.FindIntegerForValue(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, Id), COLUMN_ITEM_TYPE_GENERATOR_ID)
            If Not itemTypeGeneratorId.HasValue Then
                Return Nothing
            End If
            Return New ItemTypeGeneratorStore(connectionSource, itemTypeGeneratorId.Value)
        End Get
        Set(value As IItemTypeGeneratorStore)
            If value Is Nothing Then
                connectionSource.ClearColumnForValue(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, Id), COLUMN_ITEM_TYPE_GENERATOR_ID)
            Else
                connectionSource.WriteValueForInteger(TABLE_LOCATION_TYPES, (COLUMN_LOCATION_TYPE_ID, Id), (COLUMN_ITEM_TYPE_GENERATOR_ID, value.Id))
            End If
        End Set
    End Property

    Public Function FilterLocations(filter As String) As IEnumerable(Of ILocationStore) Implements ILocationTypeStore.FilterLocations
        Dim result As New List(Of ILocationStore)
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {COLUMN_LOCATION_ID} 
FROM 
    {TABLE_LOCATIONS} 
WHERE 
    {COLUMN_LOCATION_ID}={PARAMETER_LOCATION_TYPE_ID} 
    AND {COLUMN_LOCATION_NAME} LIKE {PARAMETER_LOCATION_NAME};"
            command.Parameters.AddWithValue(PARAMETER_LOCATION_TYPE_ID, Id)
            command.Parameters.AddWithValue(PARAMETER_LOCATION_NAME, filter)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(New LocationStore(connectionSource, reader.GetInt32(0)))
                End While
            End Using
        End Using
        Return result
    End Function
End Class
