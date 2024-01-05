Imports Microsoft.Data.SqlClient

Friend MustInherit Class BaseTypeStore
    Implements IBaseTypeStore
    Protected ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly tableName As String
    Private ReadOnly idColumnName As String
    Private ReadOnly nameColumnName As String
    Sub New(
           connectionSource As Func(Of SqlConnection),
           id As Integer,
           tableName As String,
           idColumnName As String,
           nameColumnName As String)
        Me.connectionSource = connectionSource
        Me.Id = id
        Me.tableName = tableName
        Me.idColumnName = idColumnName
        Me.nameColumnName = nameColumnName
    End Sub
    Public ReadOnly Property Store As IDataStore Implements IBaseTypeStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property
    Public ReadOnly Property Id As Integer Implements IBaseTypeStore.Id
    Public Property Name As String Implements IBaseTypeStore.Name
        Get
            Return connectionSource.ReadStringForInteger(
                tableName,
                (idColumnName, Id),
                nameColumnName)
        End Get
        Set(value As String)
            connectionSource.WriteStringForInteger(
                tableName,
                (idColumnName, Id),
                (nameColumnName, value))
        End Set
    End Property
    Public Sub Delete() Implements IBaseTypeStore.Delete
        connectionSource.DeleteForInteger(
            tableName,
            (idColumnName, Id))
    End Sub
    Public Function CanRenameTo(x As String) As Boolean Implements IBaseTypeStore.CanRenameTo
        Return Not connectionSource.FindIntegerForString(tableName, (nameColumnName, x), idColumnName).HasValue
    End Function
    Public MustOverride ReadOnly Property CanDelete As Boolean Implements IBaseTypeStore.CanDelete
End Class
