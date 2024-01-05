Imports Microsoft.Data.SqlClient

Friend MustInherit Class BaseTypeStore
    Implements IBaseTypeStore
    Protected ReadOnly connectionSource As Func(Of SqlConnection)
    Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        Me.connectionSource = connectionSource
        Me.Id = id
    End Sub
    Public ReadOnly Property Store As IDataStore Implements IBaseTypeStore.Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property
    Public ReadOnly Property Id As Integer Implements IBaseTypeStore.Id

    Public MustOverride Property Name As String Implements IBaseTypeStore.Name
    Public MustOverride ReadOnly Property CanDelete As Boolean Implements IBaseTypeStore.CanDelete
    Public MustOverride Sub Delete() Implements IBaseTypeStore.Delete
    Public MustOverride Function CanRenameTo(x As String) As Boolean Implements IBaseTypeStore.CanRenameTo
End Class
