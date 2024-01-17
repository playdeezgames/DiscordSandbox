Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.Data.SqlClient

Friend Module ConnectionSourceExtensions
    Private Const PARAMETER_FOR_COLUMN = "@ForColumn"
    Private Const PARAMETER_FIRST_FOR_COLUMN = "@FirstForColumn"
    Private Const PARAMETER_SECOND_FOR_COLUMN = "@SecondForColumn"
    Private Const PARAMETER_WRITTEN_COLUMN = "@WrittenColumn"
    <Extension>
    Function ReadStringForValue(Of TValue)(
                                          connectionSource As Func(Of SqlConnection),
                                          tableName As String,
                                          forColumn As (Name As String, Value As TValue),
                                          readColumnName As String) As String
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {readColumnName} 
FROM 
    {tableName} 
WHERE 
    {forColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, forColumn.Value)
            Return CStr(command.ExecuteScalar)
        End Using
    End Function
    <Extension>
    Sub WriteValueForInteger(Of TValue)(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             forColumn As (Name As String, Value As Integer),
                             writtenColumn As (Name As String, Value As TValue))
        Using command = connectionSource().CreateCommand
            command.CommandText = $"UPDATE {tableName} SET {writtenColumn.Name}={PARAMETER_WRITTEN_COLUMN} WHERE {forColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_WRITTEN_COLUMN, writtenColumn.Value)
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, forColumn.Value)
            command.ExecuteNonQuery()
        End Using
    End Sub
    <Extension>
    Sub ClearColumnForValue(Of TValue)(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             forColumn As (Name As String, Value As TValue),
                             clearedColumnName As String)
        Using command = connectionSource().CreateCommand
            command.CommandText = $"UPDATE {tableName} SET {clearedColumnName}=NULL WHERE {forColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, forColumn.Value)
            command.ExecuteNonQuery()
        End Using
    End Sub
    <Extension>
    Function FindIntegerForValue(Of TValue)(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             forColumn As (Name As String, Value As TValue),
                             foundColumnName As String) As Integer?
        Using command = connectionSource().CreateCommand
            command.CommandText = $"SELECT {foundColumnName} FROM {tableName} WHERE {forColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, forColumn.Value)
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
    Function FindIntegerForValues(Of TFirstValue, TSecondValue)(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             firstForColumn As (Name As String, Value As TFirstValue),
                             secondForColumn As (Name As String, Value As TSecondValue),
                             foundColumnName As String) As Integer?
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {foundColumnName} 
FROM 
    {tableName} 
WHERE 
    {firstForColumn.Name}=@{firstForColumn.Name}
    AND {secondForColumn.Name}=@{secondForColumn.Name};"
            command.Parameters.AddWithValue($"@{firstForColumn.Name}", firstForColumn.Value)
            command.Parameters.AddWithValue($"@{secondForColumn.Name}", secondForColumn.Value)
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
    Function ReadIntegerForValue(Of TValue)(
                                           connectionSource As Func(Of SqlConnection),
                                           tableName As String,
                                           forColumn As (Name As String, Value As TValue),
                                           readColumnName As String) As Integer
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {readColumnName} 
FROM 
    {tableName} 
WHERE 
    {forColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, forColumn.Value)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
    <Extension>
    Function ReadIntegersForValue(Of TValue)(
                                            connectionSource As Func(Of SqlConnection),
                                            tableName As String,
                                            forColumn As (Name As String, Value As TValue),
                                            readColumnName As String) As IEnumerable(Of Integer)
        Dim result As New List(Of Integer)
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {readColumnName} 
FROM 
    {tableName} 
WHERE 
    {forColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, forColumn.Value)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(reader.GetInt32(0))
                End While
            End Using
        End Using
        Return result
    End Function
    <Extension>
    Function ReadIntegersForValues(Of TFirstValue, TSecondValue)(
                                                                connectionSource As Func(Of SqlConnection),
                                                                tableName As String,
                                                                firstForColumn As (Name As String, Value As TFirstValue),
                                                                secondForColumn As (Name As String, Value As TSecondValue),
                                                                readColumnName As String) As IEnumerable(Of Integer)
        Dim result As New List(Of Integer)
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {readColumnName} 
FROM 
    {tableName} 
WHERE 
    {firstForColumn.Name}={PARAMETER_FIRST_FOR_COLUMN} 
    AND {secondForColumn.Name}={PARAMETER_SECOND_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FIRST_FOR_COLUMN, firstForColumn.Value)
            command.Parameters.AddWithValue(PARAMETER_SECOND_FOR_COLUMN, secondForColumn.Value)
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
        Using command = connectionSource().CreateCommand()
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
    Sub DeleteForValue(Of TValue)(connectionSource As Func(Of SqlConnection),
                            tableName As String,
                            inputColumn As (Name As String, Value As TValue))
        Using command = connectionSource().CreateCommand()
            command.CommandText = $"DELETE FROM {tableName} WHERE {inputColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, inputColumn.Value)
            command.ExecuteNonQuery()
        End Using
    End Sub
    <Extension>
    Sub DeleteForValues(Of TFirstValue, TSecondValue)(connectionSource As Func(Of SqlConnection),
                            tableName As String,
                            firstForColumn As (Name As String, Value As TFirstValue),
                            secondForColumn As (Name As String, Value As TSecondValue))
        Using command = connectionSource().CreateCommand()
            command.CommandText = $"
DELETE FROM 
    {tableName} 
WHERE 
    {firstForColumn.Name}={PARAMETER_FIRST_FOR_COLUMN}
    AND {secondForColumn.Name}={PARAMETER_SECOND_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FIRST_FOR_COLUMN, firstForColumn.Value)
            command.Parameters.AddWithValue(PARAMETER_SECOND_FOR_COLUMN, secondForColumn.Value)
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
