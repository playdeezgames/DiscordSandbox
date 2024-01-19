Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.Data.SqlClient

Friend Module ConnectionSourceExtensions
    <Extension>
    Function ReadStringForValues(
                                connectionSource As Func(Of SqlConnection),
                                tableName As String,
                                forColumns As (Name As String, Value As Object)(),
                                readColumnName As String) As String
        Using command = connectionSource().CreateCommand
            Dim builder As New StringBuilder
            builder.Append($"
SELECT 
    {readColumnName} 
FROM 
    {tableName} 
WHERE ")
            builder.Append(String.Join(" AND ", forColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            command.CommandText = builder.ToString
            For Each column In forColumns
                command.Parameters.AddWithValue($"@{column.Name}", column.Value)
            Next
            Return CStr(command.ExecuteScalar)
        End Using
    End Function
    <Extension>
    Sub WriteValuesForValues(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             forColumns As (Name As String, Value As Object)(),
                             writtenColumns As (Name As String, Value As Object)())
        Using command = connectionSource().CreateCommand
            Dim builder As New StringBuilder
            builder.Append($"UPDATE {tableName} SET ")
            builder.Append(String.Join(","c, writtenColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            builder.Append($" WHERE ")
            builder.Append(String.Join(" AND ", forColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            command.CommandText = builder.ToString
            For Each column In forColumns
                command.Parameters.AddWithValue($"{column.Name}", column.Value)
            Next
            For Each column In writtenColumns
                command.Parameters.AddWithValue($"{column.Name}", column.Value)
            Next
            command.ExecuteNonQuery()
        End Using
    End Sub
    <Extension>
    Sub ClearColumnForValues(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             forColumns As (Name As String, Value As Object)(),
                             clearedColumnName As String)
        Using command = connectionSource().CreateCommand
            Dim builder As New StringBuilder
            builder.Append($"UPDATE {tableName} SET {clearedColumnName}=NULL WHERE ")
            builder.Append(String.Join(" AND ", forColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            command.CommandText = builder.ToString
            For Each column In forColumns
                command.Parameters.AddWithValue($"@{column.Name}", column.Value)
            Next
            command.ExecuteNonQuery()
        End Using
    End Sub
    <Extension>
    Function FindIntegerForValues(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             forColumns As (Name As String, Value As Object)(),
                             foundColumnName As String,
                             Optional orders As (Name As String, Ascending As Boolean)() = Nothing) As Integer?
        Using command = connectionSource().CreateCommand
            Dim builder = New StringBuilder
            builder.Append($"
SELECT 
    {foundColumnName} 
FROM 
    {tableName} 
WHERE ")
            builder.Append(String.Join(" AND ", forColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            If orders IsNot Nothing AndAlso orders.Any Then
                builder.Append(" ORDER BY ")
                builder.Append(String.Join(",", orders.Select(Function(x) $"{x.Name} {If(x.Ascending, "ASC", "DESC")}")))
            End If
            command.CommandText = builder.ToString
            For Each column In forColumns
                command.Parameters.AddWithValue($"@{column.Name}", column.Value)
            Next
            Using reader = command.ExecuteReader
                If reader.Read Then
                    If reader.IsDBNull(0) Then
                        Return Nothing
                    End If
                    Return reader.GetInt32(0)
                End If
            End Using
        End Using
        Return Nothing
    End Function
    <Extension>
    Function ReadIntegerForValues(
                                connectionSource As Func(Of SqlConnection),
                                tableName As String,
                                forColumns As (Name As String, Value As Object)(),
                                readColumnName As String,
                                Optional orders As (Name As String, Ascending As Boolean)() = Nothing) As Integer
        Using command = connectionSource().CreateCommand
            Dim builder As New StringBuilder
            builder.Append($"
SELECT 
    {readColumnName} 
FROM 
    {tableName} 
WHERE ")
            builder.Append(String.Join(" AND ", forColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            If orders IsNot Nothing AndAlso orders.Any Then
                builder.Append(" ORDER BY ")
                builder.Append(String.Join(",", orders.Select(Function(x) $"{x.Name} {If(x.Ascending, "ASC", "DESC")}")))
            End If
            command.CommandText = builder.ToString
            For Each column In forColumns
                command.Parameters.AddWithValue($"@{column.Name}", column.Value)
            Next
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
    <Extension>
    Function ReadIntegersForValues(
                connectionSource As Func(Of SqlConnection),
                tableName As String,
                forColumns As (Name As String, Value As Object)(),
                likeColumns As (Name As String, Value As String)(),
                readColumnName As String) As IEnumerable(Of Integer)
        Dim result As New List(Of Integer)
        Using command = connectionSource().CreateCommand
            Dim builder As New StringBuilder
            builder.Append($"
SELECT 
    {readColumnName} 
FROM 
    {tableName} 
WHERE ")
            builder.Append(String.Join(" AND ", forColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            If forColumns.Length <> 0 AndAlso likeColumns.Length <> 0 Then
                builder.Append(" AND ")
            End If
            builder.Append(String.Join(" AND ", likeColumns.Select(Function(x) $"{x.Name} LIKE @{x.Name}")))
            command.CommandText = builder.ToString
            For Each column In forColumns
                command.Parameters.AddWithValue($"@{column.Name}", column.Value)
            Next
            For Each column In likeColumns
                command.Parameters.AddWithValue($"@{column.Name}", column.Value)
            Next
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(reader.GetInt32(0))
                End While
            End Using
        End Using
        Return result
    End Function
    <Extension>
    Function CheckForValues(
                           connectionSource As Func(Of SqlConnection),
                           tableName As String,
                           ParamArray forColumns As (Name As String, Value As Object)()) As Boolean
        Using command = connectionSource().CreateCommand
            Dim builder As New StringBuilder
            builder.Append($"SELECT COUNT(1) FROM {tableName} WHERE ")
            builder.Append(String.Join(" AND ", forColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            command.CommandText = builder.ToString
            For Each column In forColumns
                command.Parameters.AddWithValue($"@{column.Name}", column.Value)
            Next
            Return CInt(command.ExecuteScalar) > 0
        End Using
    End Function
    <Extension>
    Sub DeleteForValues(connectionSource As Func(Of SqlConnection),
                            tableName As String,
                            ParamArray forColumns As (Name As String, Value As Object)())
        Using command = connectionSource().CreateCommand
            Dim builder As New StringBuilder
            builder.Append($"
DELETE FROM 
    {tableName} 
WHERE ")
            builder.Append(String.Join(" AND ", forColumns.Select(Function(x) $"{x.Name}=@{x.Name}")))
            command.CommandText = builder.ToString
            For Each column In forColumns
                command.Parameters.AddWithValue($"@{column.Name}", column.Value)
            Next
            command.ExecuteNonQuery()
        End Using
    End Sub
    <Extension>
    Friend Function ReadLastIdentity(connectionSource As Func(Of SqlConnection)) As Integer
        Using command = connectionSource().CreateCommand
            command.CommandText = $"SELECT @@IDENTITY;"
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
    <Extension>
    Friend Function Insert(
                          connectionSource As Func(Of SqlConnection),
                          tableName As String,
                          ParamArray columns As (Name As String, Value As Object)()) As Integer
        Using command = connectionSource().CreateCommand
            Dim builder As New StringBuilder
            builder.Append($"INSERT INTO {tableName}(")
            builder.Append(String.Join(","c, columns.Select(Function(x) x.Name)))
            builder.Append(")VALUES(")
            builder.Append(String.Join(","c, columns.Select(Function(x) $"@{x.Name}")))
            builder.Append(");")
            command.CommandText = builder.ToString
            For Each column In columns
                command.Parameters.AddWithValue(column.Name, column.Value)
            Next
            command.ExecuteNonQuery()
        End Using
        Return connectionSource.ReadLastIdentity
    End Function
End Module
