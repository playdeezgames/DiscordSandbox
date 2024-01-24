Imports SPLORR.Data

Friend Class CardTypeLocationEditWindow
    Inherits BaseListWindow(Of ICardTypeStore, ILocationStore)

    Public Sub New(store As ICardTypeStore)
        MyBase.New(
            $"Location for Card Type `{store.Name}` (currently {If(store.Location Is Nothing, "n/a", store.Location.Name)})",
            store,
            Function(x, y) store.Store.Locations.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.Location = x
                Return New CardTypeEditWindow(store)
            End Function,
            {
                (
                    "Clear",
                    Function() True,
                    Sub()
                        store.Location = Nothing
                        Program.GoToWindow(New CardTypeEditWindow(store))
                    End Sub
                ),
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CardTypeEditWindow(store))
                )
            })
    End Sub
End Class
