Imports Terminal.Gui

Friend Class ItemTypeGeneratorItemTypeAddWindow
    Inherits Window

    Private itemTypeGeneratorStore As Data.IItemTypeGeneratorStore

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New($"Add Item Types To: {itemTypeGeneratorStore.Name}")
        Me.itemTypeGeneratorStore = itemTypeGeneratorStore
    End Sub
End Class
