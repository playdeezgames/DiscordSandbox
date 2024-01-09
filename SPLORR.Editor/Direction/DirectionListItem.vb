﻿Imports SPLORR.Data

Public Class DirectionListItem
    Public ReadOnly Property Store As IDirectionStore

    Public Sub New(store As IDirectionStore)
        Me.Store = store
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
