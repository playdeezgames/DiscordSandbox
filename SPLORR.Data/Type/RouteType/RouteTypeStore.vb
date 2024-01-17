Imports Microsoft.Data.SqlClient

Friend Class RouteTypeStore
    Inherits BaseTypeStore
    Implements IRouteTypeStore

    Public Sub New(
                  connectionSource As Func(Of SqlConnection),
                  id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_ROUTE_TYPES,
            COLUMN_ROUTE_TYPE_ID,
            COLUMN_ROUTE_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not connectionSource.CheckForValues(TABLE_ROUTES, (COLUMN_ROUTE_TYPE_ID, Id))
        End Get
    End Property
End Class
