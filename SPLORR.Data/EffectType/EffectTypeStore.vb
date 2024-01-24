Imports Microsoft.Data.SqlClient

Friend Class EffectTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements IEffectTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_EFFECT_TYPES,
            COLUMN_EFFECT_TYPE_ID,
            COLUMN_EFFECT_TYPE_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property
End Class
