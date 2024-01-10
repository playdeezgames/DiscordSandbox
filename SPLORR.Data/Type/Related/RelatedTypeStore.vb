Imports Microsoft.Data.SqlClient

Public Class RelatedTypeStore(Of TTypeStore, TRelatedValue)
    Implements IRelatedTypeStore(Of TTypeStore)

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly tableName As String
    Private ReadOnly idColumnName As String
    Private ReadOnly nameColumnName As String
    Private ReadOnly convertor As Func(Of Func(Of SqlConnection), Integer, TTypeStore)
    Private ReadOnly relatedColumnName As String
    Private ReadOnly relatedColumnValue As TRelatedValue

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
End Class
