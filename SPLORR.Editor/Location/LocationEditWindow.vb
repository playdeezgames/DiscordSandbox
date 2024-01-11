Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ILocationStore)
        MyBase.New(
            $"Edit Location: {store.Name}",
            "Item Type",
            store.Id,
            ("Name", store.Name),
            store.CanDelete,
            Function(x) store.CanRenameTo(x),
            Function() New LocationListWindow(store.Store),
            Function()
                store.Delete()
                Return New LocationListWindow(store.Store)
            End Function,
            Function(x)
                store.Name = x
                Return New LocationEditWindow(store)
            End Function,
            {
                (
                    $"Type: {store.LocationType.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New LocationLocationTypeEditWindow(store))
                ),
                (
                    "Characters...",
                    Function() store.HasCharacter,
                    Sub() Program.GoToWindow(New LocationCharacterListWindow(store))
                ),
                (
                    "Inventory...",
                    Function() True,
                    Sub() Program.GoToWindow(New InventoryEditWindow(store.Inventory))
                )
            })
    End Sub
End Class
