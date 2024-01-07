Imports SPLORR.Data
Imports Terminal.Gui

Friend Class ItemTypeGeneratorEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(itemTypeGeneratorStore As IItemTypeGeneratorStore)
        MyBase.New(
            $"Edit Item Type Generator: {itemTypeGeneratorStore.Name}",
            "Item Type Generator",
            itemTypeGeneratorStore.Id,
            itemTypeGeneratorStore.Name,
            itemTypeGeneratorStore.CanDelete,
            Function(x) itemTypeGeneratorStore.CanRenameTo(x),
            Function() New ItemTypeGeneratorListWindow(itemTypeGeneratorStore.Store),
            Function()
                itemTypeGeneratorStore.Delete()
                Return New ItemTypeGeneratorListWindow(itemTypeGeneratorStore.Store)
            End Function,
            Function(x)
                itemTypeGeneratorStore.Name = x
                Return New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore)
            End Function,
            {
                (
                    "List Item Type...",
                    Function() itemTypeGeneratorStore.HasItemTypes,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorItemTypeListWindow(itemTypeGeneratorStore))
                ),
                (
                    "Add Item Type...",
                    Function() itemTypeGeneratorStore.CanAddItemType,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorItemTypeAddWindow(itemTypeGeneratorStore))
                ),
                (
                    "Remove Item Type...",
                    Function() itemTypeGeneratorStore.HasItemTypes,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorItemTypeRemoveWindow(itemTypeGeneratorStore))
                )
            })
    End Sub
End Class
