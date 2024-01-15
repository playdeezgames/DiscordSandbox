Imports Microsoft.Data.SqlClient

Friend Class CardStore
    Inherits BaseTypeStore
    Implements ICardStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            VIEW_CARD_DETAILS,
            COLUMN_CARD_ID,
            COLUMN_CARD_TYPE_NAME,
            TABLE_CARDS)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property Character As ICharacterStore Implements ICardStore.Character
        Get
            Return New CharacterStore(
                connectionSource,
                connectionSource.ReadIntegerForValue(
                    TABLE_CARDS,
                    (COLUMN_CARD_ID, Id),
                    COLUMN_CHARACTER_ID))
        End Get
    End Property
End Class
