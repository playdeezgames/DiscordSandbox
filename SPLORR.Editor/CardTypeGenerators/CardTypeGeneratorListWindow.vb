Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CardTypeGeneratorListWindow
    Inherits BaseListWindow(Of IDataStore, ICardTypeGeneratorStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Card Type Generators",
            store,
            Function(x, y) x.CardTypeGenerators.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New CardTypeGeneratorEditWindow(x),
            {
                (
                    "Add...",
                    Function() True,
                    Sub() Program.GoToWindow(New CardTypeGeneratorAddWindow(store))
                ),
                (
                    "Close",
                    Function() True,
                    Sub() Program.GoToWindow(Nothing)
                )
            })
    End Sub
End Class
