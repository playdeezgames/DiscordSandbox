Imports SPLORR.Data

Friend Class CardTypeStatisticDeltaAddDeltaWindow
    Inherits BaseAddTypeWindow
    Public Sub New(store As ICardTypeStore, statisticType As IStatisticTypeStore)
        MyBase.New(
            "Add Statistic Delta",
            "Invalid value!",
            (
                "Add",
                Function(x)
                    Dim value As Integer = 0
                    If Integer.TryParse(x, value) Then
                        Return value = 0
                    End If
                    Return True
                End Function,
                Function(x)
                    Dim statisticDelta As ICardTypeStatisticDeltaStore = store.AddStatisticDelta(statisticType, Integer.Parse(x))
                    Return New CardTypeStatisticDeltaEditWindow(statisticDelta)
                End Function
            ),
            (
                "Cancel",
                Function() New CardTypeStatisticDeltaListWindow(store)
            ))
    End Sub
End Class
