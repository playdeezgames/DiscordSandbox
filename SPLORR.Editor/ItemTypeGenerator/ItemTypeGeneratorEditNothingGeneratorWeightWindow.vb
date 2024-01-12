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
            (True, "Zero",
            Function()
                itemTypeGeneratorStore.NothingGeneratorWeight = 0
                Return New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore)
            End Function),
            Function(x)
                Dim generatorWeight As Integer = 0
                If Integer.TryParse(x, generatorWeight) Then
                    Return generatorWeight >= 0
                End If
                Return False
            End Function,
            ("Cancel", Function() New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore)),
            Function(x)
                itemTypeGeneratorStore.NothingGeneratorWeight = CInt(x)
                Return New ItemTypeGeneratorEditWindow(itemTypeGeneratorStore)
            End Function)
    End Sub
End Class
