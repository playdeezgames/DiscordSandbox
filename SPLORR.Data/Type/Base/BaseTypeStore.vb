Imports Microsoft.Data.SqlClient

Friend MustInherit Class BaseTypeStore
    Implements IBaseTypeStore
    Protected ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly tableName As String
    Private ReadOnly idColumnName As String
    Private ReadOnly nameColumnName As String
    Private ReadOnly deleteTableName As String
    Private ReadOnly relatedColumns As (Name As String, Value As Object)()
    Private cachedName As String = Nothing
    Sub New(
           connectionSource As Func(Of SqlConnection),
           id As Integer,
           tableName As String,
           idColumnName As String,
           nameColumnName As String,
           Optional deleteTableName As String = Nothing,
           Optional relatedColumns As (Name As String, Value As Object)() = Nothing)
        Me.connectionSource = connectionSource
        Me.Id = id
        Me.tableName = tableName
        Me.idColumnName = idColumnName
        Me.nameColumnName = nameColumnName
        Me.deleteTableName = If(deleteTableName, tableName)
        Me.relatedColumns = If(relatedColumns, Array.Empty(Of (Name As String, Value As Object))())
    End Sub
    Public ReadOnly Property Store As IDataStore Implements IBaseTypeStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property
    Public ReadOnly Property Id As Integer Implements IBaseTypeStore.Id
    Private Function ForIdColumns() As (Name As String, Value As Object)()
        Dim result As New List(Of (Name As String, Value As Object))(relatedColumns)
        result.Add((idColumnName, Id))
        Return result.ToArray
    End Function
    Protected Function ForNameColumns(name As String) As (Name As String, Value As Object)()
        Dim result As New List(Of (Name As String, Value As Object))(relatedColumns)
        result.Add((nameColumnName, name))
        Return result.ToArray
    End Function
    Public Property Name As String Implements IBaseTypeStore.Name
        Get
            If cachedName Is Nothing Then
                cachedName = connectionSource.ReadStringForValues(
                    tableName,
                    ForIdColumns,
                    nameColumnName)
            End If
            Return cachedName
        End Get
        Set(value As String)
            connectionSource.WriteValuesForValues(
                tableName,
                ForIdColumns,
                {(nameColumnName, value)})
            cachedName = value
        End Set
    End Property
    Public Sub Delete() Implements IBaseTypeStore.Delete
        connectionSource.DeleteForValues(
            deleteTableName,
            (idColumnName, Id))
    End Sub
    Public Function CanRenameTo(x As String) As Boolean Implements IBaseTypeStore.CanRenameTo
        Return Not connectionSource.FindIntegerForValues(
            tableName,
            ForNameColumns(x),
            idColumnName).HasValue
    End Function
    Public MustOverride ReadOnly Property CanDelete As Boolean Implements IBaseTypeStore.CanDelete
End Class
