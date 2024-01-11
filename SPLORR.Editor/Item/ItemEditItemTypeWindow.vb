Imports SPLORR.Data

Friend Class ItemEditItemTypeWindow
    Inherits BaseListWindow(Of IItemStore, IItemTypeStore)

    Public Sub New(store As IItemStore)
        MyBase.New(
            $"Set Item Type For Item(Currently `{store.ItemType.Name}`)",
            store,
            Function(x, y) x.Store.ItemTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.ItemType = x
                Return New ItemEditWindow(store)
            End Function,
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New ItemEditWindow(store)))
            })
    End Sub
End Class
