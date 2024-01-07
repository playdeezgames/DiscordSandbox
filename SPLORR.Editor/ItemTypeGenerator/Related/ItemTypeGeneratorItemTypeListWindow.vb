Imports Terminal.Gui

Friend Class ItemTypeGeneratorItemTypeListWindow
    Inherits Window

    Private itemTypeGeneratorStore As Data.IItemTypeGeneratorStore

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New($"List Item Types For: {itemTypeGeneratorStore.Name}")
        Me.itemTypeGeneratorStore = itemTypeGeneratorStore
    End Sub
End Class
