﻿Imports Terminal.Gui

Friend Class ItemTypeGeneratorItemTypeRemoveWindow
    Inherits Window

    Private itemTypeGeneratorStore As Data.IItemTypeGeneratorStore

    Public Sub New(itemTypeGeneratorStore As Data.IItemTypeGeneratorStore)
        MyBase.New($"Remove Item Types From: {itemTypeGeneratorStore.Name}")
        Me.itemTypeGeneratorStore = itemTypeGeneratorStore
    End Sub
End Class
