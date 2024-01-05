Imports Microsoft.Data.SqlClient

Friend Class VerbTypeStore
    Inherits BaseTypeStore
    Implements IVerbTypeStore

    Private ReadOnly _verbTypeId As Integer

    Public Sub New(connectionSource As Func(Of SqlConnection), verbTypeId As Integer)
        MyBase.New(connectionSource)
        Me._verbTypeId = verbTypeId
    End Sub

    Public Overrides ReadOnly Property Id As Integer
        Get
            Return _verbTypeId
        End Get
    End Property

    Public Overrides Property Name As String
        Get
            Return connectionSource.ReadStringForInteger(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId), COLUMN_VERB_TYPE_NAME)
        End Get
        Set(value As String)
            connectionSource.WriteStringForInteger(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId), (COLUMN_VERB_TYPE_NAME, value))
        End Set
    End Property

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not HasLocationTypes
        End Get
    End Property

    Private ReadOnly Property HasLocationTypes As Boolean
        Get
            Return connectionSource.CheckForInteger(TABLE_LOCATION_TYPE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId))
        End Get
    End Property

    Public Overrides Sub Delete()
        connectionSource.DeleteForInteger(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_ID, _verbTypeId))
    End Sub

    Public Overrides Function CanRenameTo(newName As String) As Boolean
        Return Not connectionSource.FindIntegerForString(TABLE_VERB_TYPES, (COLUMN_VERB_TYPE_NAME, newName), COLUMN_VERB_TYPE_ID).HasValue
    End Function
End Class
