Imports System.Runtime.CompilerServices
Imports Microsoft.Data.SqlClient

Friend Module ConnectionSourceExtensions
    <Extension>
    Function ReadStringForInteger(connectionSource As Func(Of SqlConnection), tableName As String, inputField As (Name As String, Value As Integer), outputFieldName As String) As String
        Const PARAMETER_INPUT = "@Input"
        Using command = connectionSource().CreateCommand
            command.CommandText = $"
SELECT 
    {outputFieldName} 
FROM 
    {tableName} 
WHERE 
    {inputField.Name}={PARAMETER_INPUT};"
            command.Parameters.AddWithValue(PARAMETER_INPUT, inputField.Value)
            Return CStr(command.ExecuteScalar)
        End Using
    End Function
End Module
