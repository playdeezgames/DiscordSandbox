Imports SPLORR.Data
Imports Terminal.Gui

Friend Class ItemTypeGeneratorEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(itemTypeGeneratorStore As IItemTypeGeneratorStore)
        MyBase.New(
            $"Edit Item Type Generator: {itemTypeGeneratorStore.Name}",
            "Item Type Generator",
            ("Id", itemTypeGeneratorStore.Id.ToString),
            ("Name", itemTypeGeneratorStore.Name),
            (True, "Update",
            Function(x) itemTypeGeneratorStore.CanRenameTo(x),
            Function(x)
                itemTypeGeneratorStore.Name = x
                Return New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore)
            End Function),
            (itemTypeGeneratorStore.CanDelete, "Delete",
            Function()
                itemTypeGeneratorStore.Delete()
                Return New ItemTypeGeneratorListWindow(itemTypeGeneratorStore.Store)
            End Function),
            ("Cancel", Function() New ItemTypeGeneratorListWindow(itemTypeGeneratorStore.Store)),
            {
                (
                    "Item Types...",
                    Function() itemTypeGeneratorStore.HasItemTypes,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorItemTypeListWindow(itemTypeGeneratorStore))
                ),
                (
                    $"Nothing Generator Weight: {itemTypeGeneratorStore.NothingGeneratorWeight}",
                    Function() True,
                    Sub() Program.GoToWindow(New ItemTypeGeneratorEditNothingGeneratorWeightWindow(itemTypeGeneratorStore))
                )
            })
    End Sub
End Class
