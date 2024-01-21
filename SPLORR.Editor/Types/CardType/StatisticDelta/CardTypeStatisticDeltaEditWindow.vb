Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CardTypeStatisticDeltaEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICardTypeStatisticDeltaStore)
        MyBase.New(
            "Card Type Statistic Delta",
            "Statistic Delta",
            ("Card Type:", store.CardType.Name),
            ("Delta", store.Delta.ToString),
            (
                True,
                "Update",
                Function(x)
                    Dim value As Integer = 0
                    If Integer.TryParse(x, value) Then
                        Return value <> 0
                    End If
                    Return False
                End Function,
                Function(x)
                    store.Delta = Integer.Parse(x)
                    Return New CardTypeStatisticDeltaListWindow(store.CardType)
                End Function),
            (True, "Delete", Function()
                                 Dim cardType = store.CardType
                                 store.Delete()
                                 Return New CardTypeStatisticDeltaListWindow(cardType)
                             End Function),
            ("Cancel", Function() New CardTypeStatisticDeltaListWindow(store.CardType)),
            {
                (
                    $"Overage: {store.AllowOverage}",
                    Function() True,
                    Sub()
                        store.AllowOverage = Not store.AllowOverage
                        Program.GoToWindow(New CardTypeStatisticDeltaEditWindow(store))
                    End Sub),
                (
                    $"Deficit: {store.AllowDeficit}",
                    Function() True,
                    Sub()
                        store.AllowDeficit = Not store.AllowDeficit
                        Program.GoToWindow(New CardTypeStatisticDeltaEditWindow(store))
                    End Sub)
            })
    End Sub
End Class
