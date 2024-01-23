Imports SPLORR.Data

Friend Class CardTypeGeneratorEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICardTypeGeneratorStore)
        MyBase.New(
            "Edit Card Type Generator",
            "Card Type Generator",
            (
                "Id",
                store.Id.ToString
            ),
            (
                "Name",
                store.Name
            ),
            (
                True,
                "Update",
                Function(x) store.CanRenameTo(x),
                Function(x)
                    store.Name = x
                    Return New CardTypeGeneratorEditWindow(store)
                End Function
            ),
            (
                store.CanDelete,
                "Delete",
                Function()
                    store.Delete()
                    Return New CardTypeGeneratorListWindow(store.Store)
                End Function
            ),
            (
                "Cancel",
                Function() New CardTypeGeneratorListWindow(store.Store)
            ))
    End Sub
End Class
