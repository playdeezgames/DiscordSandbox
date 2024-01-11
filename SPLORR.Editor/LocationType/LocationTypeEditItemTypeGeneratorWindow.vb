Imports SPLORR.Data

Friend Class LocationTypeEditItemTypeGeneratorWindow
    Inherits BaseListWindow(Of ILocationTypeStore, IItemTypeGeneratorStore)

    Public Sub New(store As ILocationTypeStore)
        MyBase.New(
            $"Set Item Type Generator For Location Type `{store.Name}` (Currently {If(store.ItemTypeGenerator Is Nothing, "not set", $"`{store.ItemTypeGenerator.Name}`")})",
            store,
            Function(x, y) x.Store.ItemTypeGenerators.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x)
                store.ItemTypeGenerator = x
                Return New LocationTypeEditWindow(store)
            End Function,
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New LocationTypeEditWindow(store))
                ),
                (
                    "Clear",
                    Function() True,
                    Sub()
                        store.ItemTypeGenerator = Nothing
                        Program.GoToWindow(New LocationTypeEditWindow(store))
                    End Sub
                )
            })
    End Sub
End Class
