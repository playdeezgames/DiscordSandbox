Imports SPLORR.Data

Friend Class CardTypeGeneratorAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(store As IDataStore)
        MyBase.New(
            "Add Card Type Generator",
            "Card Type Generator name must be unique!",
            (
                "Add",
                Function(x) store.CardTypeGenerators.NameExists(x),
                Function(x) New CardTypeGeneratorEditWindow(store.CardTypeGenerators.Create(x))
            ),
            (
                "Cancel",
                Function() New CardTypeGeneratorListWindow(store)
            ))
    End Sub
End Class
