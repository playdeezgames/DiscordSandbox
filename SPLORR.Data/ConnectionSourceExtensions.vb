Imports System.Runtime.CompilerServices
Imports Microsoft.Data.SqlClient

Friend Module ConnectionSourceExtensions
    <Extension>
    Function ReadStringForInteger(connectionSource As Func(Of SqlConnection), tableName As String, inputColumn As (Name As String, Value As Integer), outputColumnName As String) As String
        Const PARAMETER_INPUT = "@Input"
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {outputColumnName} 
FROM 
    {tableName} 
WHERE 
    {inputColumn.Name}={PARAMETER_INPUT};"
            command.Parameters.AddWithValue(PARAMETER_INPUT, inputColumn.Value)
            Return CStr(command.ExecuteScalar)
        End Using
    End Function
    <Extension>
    Function ReadIntegerForInteger(connectionSource As Func(Of SqlConnection), tableName As String, inputColumn As (Name As String, Value As Integer), outputColumnName As String) As Integer
        Const PARAMETER_INPUT = "@Input"
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {outputColumnName} 
FROM 
    {tableName} 
WHERE 
    {inputColumn.Name}={PARAMETER_INPUT};"
            command.Parameters.AddWithValue(PARAMETER_INPUT, inputColumn.Value)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
End Module
