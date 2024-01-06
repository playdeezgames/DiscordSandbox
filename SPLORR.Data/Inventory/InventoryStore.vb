Imports Microsoft.Data.SqlClient

Friend Class InventoryStore
    Implements IInventoryStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Public ReadOnly Property Id As Integer Implements IInventoryStore.Id

    Public Sub New(connectionSource As Func(Of SqlConnection), inventoryId As Integer)
        Me.connectionSource = connectionSource
        Me.Id = inventoryId
    End Sub
End Class
