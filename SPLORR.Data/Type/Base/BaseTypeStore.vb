Imports Microsoft.Data.SqlClient

Friend MustInherit Class BaseTypeStore
    Implements IBaseTypeStore
    Protected ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly tableName As String
    Private ReadOnly idColumnName As String
    Private ReadOnly nameColumnName As String
    Private ReadOnly deleteTableName As String
    Private cachedName As String = Nothing
    Sub New(
           connectionSource As Func(Of SqlConnection),
           id As Integer,
           tableName As String,
           idColumnName As String,
           nameColumnName As String,
           Optional deleteTableName As String = Nothing)
        Me.connectionSource = connectionSource
        Me.Id = id
        Me.tableName = tableName
        Me.idColumnName = idColumnName
        Me.nameColumnName = nameColumnName
        Me.deleteTableName = If(deleteTableName, tableName)
    End Sub
    Public ReadOnly Property Store As IDataStore Implements IBaseTypeStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property
    Public ReadOnly Property Id As Integer Implements IBaseTypeStore.Id
    Public Property Name As String Implements IBaseTypeStore.Name
        Get
            If cachedName Is Nothing Then
                cachedName = connectionSource.ReadStringForValue(
                    tableName,
                    (idColumnName, Id),
                    nameColumnName)
            End If
            Return cachedName
        End Get
        Set(value As String)
            connectionSource.WriteValueForInteger(
                tableName,
                (idColumnName, Id),
                (nameColumnName, value))
            cachedName = value
        End Set
    End Property
    Public Sub Delete() Implements IBaseTypeStore.Delete
        connectionSource.DeleteForValue(
            deleteTableName,
            (idColumnName, Id))
    End Sub
    Public Function CanRenameTo(x As String) As Boolean Implements IBaseTypeStore.CanRenameTo
        Return Not connectionSource.FindIntegerForValue(tableName, (nameColumnName, x), idColumnName).HasValue
    End Function
    Public MustOverride ReadOnly Property CanDelete As Boolean Implements IBaseTypeStore.CanDelete
End Class
