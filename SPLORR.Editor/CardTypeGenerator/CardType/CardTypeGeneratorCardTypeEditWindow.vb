Imports SPLORR.Data

Friend Class CardTypeGeneratorCardTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICardTypeGeneratorCardTypeStore)
        MyBase.New(
            $"Edit Generator Weight for Generator {store.Generator.Name}",
            "Generator Weight",
            ("Card Type", store.CardType.Name),
            ("Weight", store.GeneratorWeight.ToString),
            (
                True,
                "Update",
                Function(x)
                    Dim weight As Integer = 0
                    If Not Integer.TryParse(x, weight) Then
                        Return False
                    End If
                    Return weight > 0
                End Function,
                Function(x)
                    store.GeneratorWeight = Integer.Parse(x)
                    Return New CardTypeGeneratorEditWindow(store.Generator)
                End Function
            ),
            (
                store.CanDelete,
                "Delete",
                Function()
                    Dim generator = store.Generator
                    store.Delete()
                    Return New CardTypeGeneratorEditWindow(Generator)
                End Function
            ),
            (
                "Cancel",
                Function() New CardTypeGeneratorEditWindow(store.Generator)
            ))
    End Sub
End Class
