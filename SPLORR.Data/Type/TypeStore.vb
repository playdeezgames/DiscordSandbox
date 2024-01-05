Imports Microsoft.Data.SqlClient

Friend Class TypeStore(Of TTypeStore As IBaseTypeStore)
    Implements ITypeStore(Of TTypeStore)

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly tableName As String
    Private ReadOnly idColumnName As String
    Private ReadOnly nameColumnName As String
    Private ReadOnly convertor As Func(Of Func(Of SqlConnection), Integer, TTypeStore)

    Public Sub New(connectionSource As Func(Of SqlConnection), tableName As String, idColumnName As String, nameColumnName As String, convertor As Func(Of Func(Of SqlConnection), Integer, TTypeStore))
        Me.connectionSource = connectionSource
        Me.tableName = tableName
        Me.idColumnName = idColumnName
        Me.nameColumnName = nameColumnName
        Me.convertor = convertor
    End Sub

    Public Function Create(name As String) As TTypeStore Implements ITypeStore(Of TTypeStore).Create
        Using command = connectionSource().CreateCommand
            command.CommandText = $"INSERT INTO {tableName}({nameColumnName}) VALUES(@{nameColumnName});"
            command.Parameters.AddWithValue($"@{nameColumnName}", name)
            command.ExecuteNonQuery()
        End Using
        Return convertor(connectionSource, connectionSource.ReadLastIdentity())
    End Function

    Public Function Filter(textFilter As String) As IEnumerable(Of TTypeStore) Implements ITypeStore(Of TTypeStore).Filter
        Dim result As New List(Of TTypeStore)
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {idColumnName} 
FROM 
    {tableName} 
WHERE 
    {nameColumnName} LIKE @{nameColumnName};"
            command.Parameters.AddWithValue($"@{nameColumnName}", textFilter)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(convertor(connectionSource, reader.GetInt32(0)))
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function NameExists(name As String) As Boolean Implements ITypeStore(Of TTypeStore).NameExists
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    COUNT(1) 
FROM 
    {tableName} 
WHERE 
    {nameColumnName}=@{nameColumnName};"
            command.Parameters.AddWithValue($"@{nameColumnName}", name)
            Return CInt(command.ExecuteScalar) > 0
        End Using
    End Function

    Public Function FromName(name As String) As TTypeStore Implements ITypeStore(Of TTypeStore).FromName
        Dim id = connectionSource.FindIntegerForString(tableName, (nameColumnName, name), idColumnName)
        If Not id.HasValue Then
            Return Nothing
        End If
        Return convertor(connectionSource, id.Value)
    End Function
End Class
