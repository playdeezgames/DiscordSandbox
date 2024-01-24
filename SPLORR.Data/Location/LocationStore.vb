Imports System.Diagnostics.Eventing
Imports Microsoft.Data.SqlClient

Friend Class LocationStore
    Implements ILocationStore

    Private ReadOnly connectionSource As Func(Of SqlConnection)

    Public Sub New(connectionSource As Func(Of SqlConnection), locationId As Integer)
        Me.connectionSource = connectionSource
        Me.Id = locationId
    End Sub

    Public ReadOnly Property Id As Integer Implements ILocationStore.Id

    Public Property Name As String Implements ILocationStore.Name
        Get
            Return connectionSource.ReadStringForValues(
                TABLE_LOCATIONS,
                {(COLUMN_LOCATION_ID, Id)},
                COLUMN_LOCATION_NAME)
        End Get
        Set(value As String)
            connectionSource.WriteValuesForValues(
                TABLE_LOCATIONS,
                {(COLUMN_LOCATION_ID, Id)},
                {(COLUMN_LOCATION_NAME, value)})
        End Set
    End Property

    Public Property LocationType As ILocationTypeStore Implements ILocationStore.LocationType
        Get
            Return New LocationTypeStore(
                connectionSource,
                connectionSource.ReadIntegerForValues(
                    TABLE_LOCATIONS,
                    {(COLUMN_LOCATION_ID, Id)},
                    COLUMN_LOCATION_TYPE_ID))
        End Get
        Set(value As ILocationTypeStore)
            connectionSource.WriteValuesForValues(
                TABLE_LOCATIONS,
                {(COLUMN_LOCATION_ID, Id)},
                {(COLUMN_LOCATION_TYPE_ID, value.Id)})
        End Set
    End Property

    Public ReadOnly Property CanDelete As Boolean Implements IBaseTypeStore(Of IDataStore).CanDelete
        Get
            Return Not HasCharacters AndAlso Not HasCardTypes
        End Get
    End Property

    Private ReadOnly Property HasCardTypes As Boolean
        Get
            Return connectionSource.CheckForValues(TABLE_CARD_TYPES, (COLUMN_LOCATION_ID, Id))
        End Get
    End Property

    Private ReadOnly Property HasCharacters As Boolean
        Get
            Return connectionSource.CheckForValues(TABLE_CHARACTERS, (COLUMN_LOCATION_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Store As IDataStore Implements IBaseTypeStore(Of IDataStore).Store
        Get
            Return New DataStore(connectionSource())
        End Get
    End Property

    Public ReadOnly Property HasCharacter As Boolean Implements ILocationStore.HasCharacter
        Get
            Return connectionSource.CheckForValues(TABLE_CHARACTERS, (COLUMN_LOCATION_ID, Id))
        End Get
    End Property

    Public ReadOnly Property Characters As IRelatedTypeStore(Of ICharacterStore) Implements ILocationStore.Characters
        Get
            Return New RelatedTypeStore(Of ICharacterStore, Integer)(
                connectionSource,
                TABLE_CHARACTERS,
                COLUMN_CHARACTER_ID,
                COLUMN_CHARACTER_NAME,
                (COLUMN_LOCATION_ID, Id),
                Function(x, y) New CharacterStore(x, y))
        End Get
    End Property

    Public Sub Delete() Implements IBaseTypeStore(Of IDataStore).Delete
        connectionSource.DeleteForValues(TABLE_LOCATIONS, (COLUMN_LOCATION_ID, Id))
    End Sub

    Public Function CanRenameTo(x As String) As Boolean Implements IBaseTypeStore(Of IDataStore).CanRenameTo
        Return True
    End Function
End Class
