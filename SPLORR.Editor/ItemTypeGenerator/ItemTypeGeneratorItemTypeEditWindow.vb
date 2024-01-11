Friend Class ItemTypeGeneratorItemTypeEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(itemTypeGeneratorItemTypeStore As Data.IItemTypeGeneratorItemTypeStore)
        MyBase.New(
            $"Edit Item Type `{itemTypeGeneratorItemTypeStore.ItemType.Name}` for Item Type Generator `{itemTypeGeneratorItemTypeStore.ItemTypeGenerator.Name}`:",
            "Item Type Generator Item Type",
            itemTypeGeneratorItemTypeStore.Id,
            ("Generator Weight", itemTypeGeneratorItemTypeStore.GeneratorWeight.ToString),
            itemTypeGeneratorItemTypeStore.CanDelete,
            Function(x)
                Dim generatorWeight As Integer = 0
                If Integer.TryParse(x, generatorWeight) Then
                    Return generatorWeight > 0
                End If
                Return False
            End Function,
            Function() New ItemTypeGeneratorItemTypeListWindow(itemTypeGeneratorItemTypeStore.ItemTypeGenerator),
            Function()
                Dim itemTypeGenerator = itemTypeGeneratorItemTypeStore.ItemTypeGenerator
                itemTypeGeneratorItemTypeStore.Delete()
                Return New ItemTypeGeneratorItemTypeListWindow(itemTypeGenerator)
            End Function,
            Function(x)
                itemTypeGeneratorItemTypeStore.GeneratorWeight = CInt(x)
                Return New ItemTypeGeneratorItemTypeListWindow(itemTypeGeneratorItemTypeStore.ItemTypeGenerator)
            End Function)
    End Sub
End Class
