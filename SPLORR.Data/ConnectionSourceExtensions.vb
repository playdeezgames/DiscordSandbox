Imports System.Runtime.CompilerServices
Imports Microsoft.Data.SqlClient

Friend Module ConnectionSourceExtensions
    Private Const PARAMETER_FOR_COLUMN = "@ForColumn"
    Private Const PARAMETER_FIRST_FOR_COLUMN = "@FirstForColumn"
    Private Const PARAMETER_SECOND_FOR_COLUMN = "@SecondForColumn"
    Private Const PARAMETER_WRITTEN_COLUMN = "@WrittenColumn"
    <Extension>
    Function ReadStringForValue(Of TValue)(connectionSource As Func(Of SqlConnection), tableName As String, inputColumn As (Name As String, Value As TValue), outputColumnName As String) As String
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {outputColumnName} 
FROM 
    {tableName} 
WHERE 
    {inputColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, inputColumn.Value)
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
    Function ReadIntegerForValue(Of TValue)(connectionSource As Func(Of SqlConnection), tableName As String, inputColumn As (Name As String, Value As TValue), outputColumnName As String) As Integer
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {outputColumnName} 
FROM 
    {tableName} 
WHERE 
    {inputColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, inputColumn.Value)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
    <Extension>
    Function CheckForValue(Of TValue)(
                            connectionSource As Func(Of SqlConnection),
                            tableName As String,
                            inputColumn As (Name As String, Value As TValue)) As Boolean
        Using command = connectionSource().CreateCommand()
            command.CommandText = $"SELECT COUNT(1) FROM {tableName} WHERE {inputColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, inputColumn.Value)
            Return CInt(command.ExecuteScalar) > 0
        End Using
    End Function
    <Extension>
    Sub DeleteForInteger(connectionSource As Func(Of SqlConnection),
                            tableName As String,
                            inputColumn As (Name As String, Value As Integer))
        Using command = connectionSource().CreateCommand()
            command.CommandText = $"DELETE FROM {tableName} WHERE {inputColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, inputColumn.Value)
            command.ExecuteNonQuery()
        End Using
    End Sub
    <Extension>
    Sub DeleteForIntegers(connectionSource As Func(Of SqlConnection),
                            tableName As String,
                            firstInputColumn As (Name As String, Value As Integer),
                            secondInputColumn As (Name As String, Value As Integer))
        Using command = connectionSource().CreateCommand()
            command.CommandText = $"
DELETE FROM 
    {tableName} 
WHERE 
    {firstInputColumn.Name}={PARAMETER_FIRST_FOR_COLUMN}
    AND {secondInputColumn.Name}={PARAMETER_SECOND_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FIRST_FOR_COLUMN, firstInputColumn.Value)
            command.Parameters.AddWithValue(PARAMETER_SECOND_FOR_COLUMN, secondInputColumn.Value)
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
End Module
