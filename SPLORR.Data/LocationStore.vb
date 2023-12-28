Imports Microsoft.Data.SqlClient

Friend Class LocationStore
    Implements ILocationStore

    Private _connectionSource As Func(Of SqlConnection)
    Private _locationId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), locationId As Integer)
        Me._connectionSource = connectionSource
        Me._locationId = locationId
    End Sub
End Class
