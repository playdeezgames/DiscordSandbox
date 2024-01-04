Imports SPLORR.Data

Friend Class VerbTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(verbTypeStore As IVerbTypeStore)
        MyBase.New(
            $"Edit Verb Type: {verbTypeStore.Name}",
            "Verb Type",
            verbTypeStore.Id,
            verbTypeStore.Name,
            verbTypeStore.CanDelete,
            Function(x) verbTypeStore.CanRenameTo(x),
            Function() New VerbTypeListWindow(verbTypeStore.Store),
            Function()
                verbTypeStore.Delete()
                Return New VerbTypeListWindow(verbTypeStore.Store)
            End Function,
            Function(x)
                verbTypeStore.Name = x
                Return New VerbTypeEditWindow(verbTypeStore)
            End Function)
    End Sub
End Class
