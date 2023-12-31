Imports Microsoft.Data.SqlClient

Friend Class VerbTypeStore
    Implements IVerbTypeStore

    Private ReadOnly _connectionSource As Func(Of SqlConnection)
    Private ReadOnly _verbTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), verbTypeId As Integer)
        Me._connectionSource = connectionSource
        Me._verbTypeId = verbTypeId
    End Sub

    Public ReadOnly Property Id As Integer Implements IVerbTypeStore.Id
        Get
            Return _verbTypeId
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IVerbTypeStore.Name
        Get
            Return _connectionSource.ReadStringForInteger(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId), COLUMN_VERB_TYPE_NAME)
        End Get
    End Property
End Class
