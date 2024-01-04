Imports System.Runtime.CompilerServices
Imports Microsoft.Data.SqlClient

Friend Module ConnectionSourceExtensions
    Private Const PARAMETER_FOR_COLUMN = "@ForColumn"
    Private Const PARAMETER_FIRST_FOR_COLUMN = "@FirstForColumn"
    Private Const PARAMETER_SECOND_FOR_COLUMN = "@SecondForColumn"
    Private Const PARAMETER_WRITTEN_COLUMN = "@WrittenColumn"
    <Extension>
    Function ReadStringForInteger(connectionSource As Func(Of SqlConnection), tableName As String, inputColumn As (Name As String, Value As Integer), outputColumnName As String) As String
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
    Sub WriteStringForInteger(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             forColumn As (Name As String, Value As Integer),
                             writtenColumn As (Name As String, Value As String))
        Using command = connectionSource().CreateCommand
            command.CommandText = $"UPDATE {tableName} SET {writtenColumn.Name}={PARAMETER_WRITTEN_COLUMN} WHERE {forColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_WRITTEN_COLUMN, writtenColumn.Value)
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, forColumn.Value)
            command.ExecuteNonQuery()
        End Using
    End Sub
    <Extension>
    Function FindIntegerForString(
                             connectionSource As Func(Of SqlConnection),
                             tableName As String,
                             forColumn As (Name As String, Value As String),
                             foundColumnName As String) As Integer?
        Using command = connectionSource().CreateCommand
            command.CommandText = $"SELECT {foundColumnName} FROM {tableName} WHERE {forColumn.Name}={PARAMETER_FOR_COLUMN};"
            command.Parameters.AddWithValue(PARAMETER_FOR_COLUMN, forColumn.Value)
            Using reader = command.ExecuteReader
                If reader.Read Then
                    Return reader.GetInt32(0)
                End If
            End Using
        End Using
        Return Nothing
    End Function
    <Extension>
    Function ReadIntegerForInteger(connectionSource As Func(Of SqlConnection), tableName As String, inputColumn As (Name As String, Value As Integer), outputColumnName As String) As Integer
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
    Function CheckForInteger(
                            connectionSource As Func(Of SqlConnection),
                            tableName As String,
                            inputColumn As (Name As String, Value As Integer)) As Boolean
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
    Friend Function GetLastIdentity(connectionSource As Func(Of SqlConnection)) As Integer
        Using command = connectionSource().CreateCommand
            command.CommandText = $"SELECT @@IDENTITY;"
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
End Module
