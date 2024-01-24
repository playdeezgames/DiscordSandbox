Imports SPLORR.Data

Friend Class CardTypeCardTypeGeneratorEditWindow
    Inherits BaseListWindow(Of ICardTypeStore, ICardTypeGeneratorStore)

    Public Sub New(store As ICardTypeStore)
        MyBase.New(
            $"Generator for Card Type `{store.Name}` (currently {If(store.Generator Is Nothing, "n/a", store.Generator.Name)})",
            store,
            Function(x, y) store.Store.CardTypeGenerators.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.Generator = x
                Return New CardTypeEditWindow(store)
            End Function,
            {
                (
                    "Clear",
                    Function() True,
                    Sub()
                        store.Generator = Nothing
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
