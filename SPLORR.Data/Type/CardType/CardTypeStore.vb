Imports Microsoft.Data.SqlClient

Friend Class CardTypeStore
    Inherits BaseTypeStore(Of IDataStore)
    Implements ICardTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CARD_TYPES,
            COLUMN_CARD_TYPE_ID,
            COLUMN_CARD_TYPE_NAME,
            New DataStore(connectionSource()))
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property SelfDestructs As Boolean Implements ICardTypeStore.SelfDestructs
        Get
            Return connectionSource.ReadIntegerForValues(
                TABLE_CARD_TYPES,
                {(COLUMN_CARD_TYPE_ID, Id)},
                COLUMN_SELF_DESTRUCT) <> 0
        End Get
    End Property

    Public ReadOnly Property Limit As Integer? Implements ICardTypeStore.Limit
        Get
            Return connectionSource.FindIntegerForValues(
                TABLE_CARD_TYPES,
                {(COLUMN_CARD_TYPE_ID, Id)},
                COLUMN_CARD_LIMIT)
        End Get
    End Property

    Public Function CreateCard(character As ICharacterStore) As ICardStore Implements ICardTypeStore.CreateCard
        Return New CardStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CARDS,
                (COLUMN_CARD_TYPE_ID, Id),
                (COLUMN_CHARACTER_ID, character.Id)))
    End Function

    Public Function CanCreateCard(character As ICharacterStore) As Boolean Implements ICardTypeStore.CanCreateCard
        Return If(Limit, Integer.MaxValue) > character.CardTypeCount(Me)
    End Function
End Class
