Imports Microsoft.Data.SqlClient

Friend Class InventoryStore
    Implements IInventoryStore

    Private connectionSource As Func(Of SqlConnection)
    Private inventoryId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), value As Integer)
        Me.connectionSource = connectionSource
        Me.inventoryId = value
    End Sub
End Class
