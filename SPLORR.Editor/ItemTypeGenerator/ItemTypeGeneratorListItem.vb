﻿Imports SPLORR.Data

Friend Class ItemTypeGeneratorListItem
    Public Sub New(item As IItemTypeGeneratorStore)
        Me.Store = item
    End Sub
    Friend ReadOnly Property Store As IItemTypeGeneratorStore
    Public Overrides Function ToString() As String
        Return $"{Store.Name}(Id:{Store.Id})"
    End Function
End Class
