Imports Terminal.Gui

Friend Class ItemTypeGeneratorEditNothingGeneratorWeightWindow
    Inherits BaseEditTypeWindow

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New(
            $"Edit Nothing Generator Weight for Item Type Generator: {itemTypeGeneratorStore.Name}",
            "Item Type Generator",
            itemTypeGeneratorStore.Id,
            ("Nothing Generator Weight", itemTypeGeneratorStore.NothingGeneratorWeight.ToString),
            True,
            Function(x)
                Dim generatorWeight As Integer = 0
                If Integer.TryParse(x, generatorWeight) Then
                    Return generatorWeight >= 0
                End If
                Return False
            End Function,
            Function() New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore),
            Function()
                itemTypeGeneratorStore.NothingGeneratorWeight = 0
                Return New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore)
            End Function,
            Function(x)
                itemTypeGeneratorStore.NothingGeneratorWeight = CInt(x)
                Return New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore)
            End Function)
    End Sub
End Class
