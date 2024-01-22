Imports Microsoft.Data.SqlClient

Friend Class TypeStore(Of TTypeStore As IBaseTypeStore(Of IDataStore))
    Implements ITypeStore(Of TTypeStore)

    Private ReadOnly connectionSource As Func(Of SqlConnection)
    Private ReadOnly tableName As String
    Private ReadOnly idColumnName As String
    Private ReadOnly nameColumnName As String
    Private ReadOnly convertor As Func(Of Func(Of SqlConnection), Integer, TTypeStore)

    Public Sub New(
                  connectionSource As Func(Of SqlConnection),
                  tableName As String,
                  idColumnName As String,
                  nameColumnName As String,
                  convertor As Func(Of Func(Of SqlConnection), Integer, TTypeStore))
        Me.connectionSource = connectionSource
        Me.tableName = tableName
        Me.idColumnName = idColumnName
        Me.nameColumnName = nameColumnName
        Me.convertor = convertor
    End Sub

    Public ReadOnly Property All As IEnumerable(Of TTypeStore) Implements IRelatedTypeStore(Of TTypeStore).All
        Get
            Return Filter("%")
        End Get
    End Property

    Public Function Create(name As String) As TTypeStore Implements ITypeStore(Of TTypeStore).Create
        Return convertor(
            connectionSource,
            connectionSource.Insert(
                tableName,
                (nameColumnName, name)))
    End Function

    Public Function Filter(textFilter As String) As IEnumerable(Of TTypeStore) Implements ITypeStore(Of TTypeStore).Filter
        Return connectionSource.ReadIntegersForValues(
            tableName,
            Array.Empty(Of (Name As String, Value As Object))(),
            {(nameColumnName, textFilter)},
            idColumnName).
            Select(Function(x) convertor(connectionSource, x))
    End Function

    Public Function NameExists(name As String) As Boolean Implements ITypeStore(Of TTypeStore).NameExists
        Return connectionSource.ReadIntegerForValues(tableName, {(nameColumnName, name)}, "COUNT(1)") > 0
    End Function

    Public Function FromName(name As String) As TTypeStore Implements IRelatedTypeStore(Of TTypeStore).FromName
        Dim id = connectionSource.FindIntegerForValues(tableName, {(nameColumnName, name)}, idColumnName)
        If Not id.HasValue Then
            Return Nothing
        End If
        Return convertor(connectionSource, id.Value)
    End Function
End Class
