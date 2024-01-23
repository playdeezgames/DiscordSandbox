Imports Microsoft.Data.SqlClient

Friend Class CardTypeGeneratorStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements ICardTypeGeneratorStore

    Public Sub New(
                  connectionSource As Func(Of SqlConnection),
                  id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CARD_TYPE_GENERATORS,
            COLUMN_CARD_TYPE_GENERATOR_ID,
            COLUMN_CARD_TYPE_GENERATOR_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not HasCardTypes
        End Get
    End Property

    Private ReadOnly Property HasCardTypes As Boolean
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPE_GENERATOR_CARD_TYPES,
                (COLUMN_CARD_TYPE_GENERATOR_ID, Id))
        End Get
    End Property
End Class
