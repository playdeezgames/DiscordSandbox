﻿Imports Microsoft.Data.SqlClient

Friend Class CardTypeStore
    Inherits BaseTypeStore
    Implements ICardTypeStore

    Public Sub New(connectionSource As Func(Of SqlConnection), id As Integer)
        MyBase.New(
            connectionSource,
            id,
            TABLE_CARD_TYPES,
            COLUMN_CARD_TYPE_ID,
            COLUMN_CARD_TYPE_NAME)
    End Sub

    Public Overrides ReadOnly Property CanDelete As Boolean
        Get
            Return Not HasDeltas
        End Get
    End Property

    Private ReadOnly Property HasDeltas As Boolean
        Get
            Return connectionSource.CheckForValues(
                TABLE_CARD_TYPE_STATISTIC_DELTAS,
                (COLUMN_CARD_TYPE_ID, Id))
        End Get
    End Property

    Public Function CreateCard(store As ICharacterStore) As ICardStore Implements ICardTypeStore.CreateCard
        Return New CardStore(
            connectionSource,
            connectionSource.Insert(
                TABLE_CARDS,
                (COLUMN_CARD_TYPE_ID, Id),
                (COLUMN_CHARACTER_ID, store.Id)))
    End Function
End Class
