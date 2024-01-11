Imports SPLORR.Data
Imports Terminal.Gui

Friend Class InventoryEditWindow
    Inherits BaseListWindow(Of IInventoryStore, IItemStore)

    Public Sub New(store As Data.IInventoryStore)
        MyBase.New(
            $"Inventory for {If(store.HasCharacter, $"Character `{store.Character.Name}`", $"Location `{store.Location.Name}`")}",
            store,
            Function(x, y) x.Items.Filter(y),
            Function(x) New ItemListItem(x),
            Function(x) Nothing,
            AdditionalButtons:=
            {
                (
                    "Close",
                    Function() True,
                    Sub()
                        If store.HasCharacter Then
                            Program.GoToWindow(New CharacterEditWindow(store.Character))
                        Else
                            Program.GoToWindow(New LocationEditWindow(store.Location))
                        End If
                    End Sub
                ),
                (
                    "Delete",
                    Function() store.CanDelete,
                    Sub()
                        Dim window As Window = Nothing
                        If store.HasCharacter Then
                            window = New CharacterEditWindow(store.Character)
                        Else
                            window = New LocationEditWindow(store.Location)
                        End If
                        store.Delete()
                        Program.GoToWindow(window)
                    End Sub
                )
            })
    End Sub
End Class
