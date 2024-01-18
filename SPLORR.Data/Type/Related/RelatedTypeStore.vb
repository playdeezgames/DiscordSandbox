Imports Microsoft.Data.SqlClient

Public Class RelatedTypeStore(Of TTypeStore, TRelatedValue)
    Implements IRelatedTypeStore(Of TTypeStore)

    Protected ReadOnly connectionSource As Func(Of SqlConnection)
    Protected ReadOnly tableName As String
    Protected ReadOnly idColumnName As String
    Protected ReadOnly nameColumnName As String
    Private ReadOnly convertor As Func(Of Func(Of SqlConnection), Integer, TTypeStore)
    Protected ReadOnly relatedColumnName As String
    Protected ReadOnly relatedColumnValue As TRelatedValue

    Public ReadOnly Property All As IEnumerable(Of TTypeStore) Implements IRelatedTypeStore(Of TTypeStore).All
        Get
            Return Filter("%")
        End Get
    End Property

    Public Sub New(
                  connectionSource As Func(Of SqlConnection),
                  tableName As String,
                  idColumnName As String,
                  nameColumnName As String,
                  relatedColumn As (Name As String, Value As TRelatedValue),
                  convertor As Func(Of Func(Of SqlConnection), Integer, TTypeStore))
        Me.connectionSource = connectionSource
        Me.tableName = tableName
        Me.idColumnName = idColumnName
        Me.nameColumnName = nameColumnName
        Me.convertor = convertor
        relatedColumnName = relatedColumn.Name
        relatedColumnValue = relatedColumn.Value
    End Sub

    Public Function Filter(textFilter As String) As IEnumerable(Of TTypeStore) Implements IRelatedTypeStore(Of TTypeStore).Filter
        Dim result As New List(Of TTypeStore)
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {idColumnName} 
FROM 
    {tableName} 
WHERE 
    {relatedColumnName} = @{relatedColumnName}
    AND {nameColumnName} LIKE @{nameColumnName};"
            command.Parameters.AddWithValue($"@{nameColumnName}", textFilter)
            command.Parameters.AddWithValue($"@{relatedColumnName}", relatedColumnValue)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(convertor(connectionSource, reader.GetInt32(0)))
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function FromName(name As String) As TTypeStore Implements IRelatedTypeStore(Of TTypeStore).FromName
        Dim id = connectionSource.FindIntegerForValues(tableName, {(nameColumnName, name), (relatedColumnName, relatedColumnValue)}, idColumnName)
        If Not id.HasValue Then
            Return Nothing
        End If
        Return convertor(connectionSource, id.Value)
    End Function
End Class
