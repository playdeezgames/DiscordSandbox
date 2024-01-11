Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationTypeSetItemTypeGeneratorWindow
    Inherits Window

    Private ReadOnly locationTypeStore As Data.ILocationTypeStore
    Private ReadOnly itemTypeGenerators As New List(Of IItemTypeGeneratorStore)
    Private ReadOnly itemTypeGeneratorComboBox As ComboBox

    Public Sub New(locationTypeStore As Data.ILocationTypeStore)
        MyBase.New($"Set Item Type Generator for Location Type: {locationTypeStore.Name}")
        Me.locationTypeStore = locationTypeStore
        Dim itemTypeGeneratorLabel As New Label("Item Type Generator:") With
            {
                .X = 1,
                .Y = 1
            }
        itemTypeGeneratorComboBox = New ComboBox() With
            {
                .X = Pos.Right(itemTypeGeneratorLabel) + 1,
                .Y = itemTypeGeneratorLabel.Y,
                .Width = [Dim].Fill - 1
            }
        itemTypeGenerators.AddRange(locationTypeStore.Store.ItemTypeGenerators.Filter("%"))
        itemTypeGeneratorComboBox.SetSource(itemTypeGenerators.Select(Function(x) New ListItem(Of IItemTypeGeneratorStore)(x, $"{x.Name}(Id:{x.Id})")).ToList)
        Dim itemTypeGenerator = locationTypeStore.ItemTypeGenerator
        If itemTypeGenerator IsNot Nothing Then
            itemTypeGeneratorComboBox.SelectedItem = itemTypeGenerators.FindIndex(Function(x) x.Id = itemTypeGenerator.Id)
        End If
        Dim updateButton As New Button("Update") With
            {
                .X = 1,
                .Y = Pos.Bottom(itemTypeGeneratorLabel) + 1
            }
        AddHandler updateButton.Clicked, AddressOf OnUpdateButtonClicked
        Dim cancelButton As New Button("Cancel") With
            {
                .X = Pos.Right(updateButton) + 1,
                .Y = updateButton.Y
            }
        AddHandler cancelButton.Clicked, AddressOf OnCancelButtonClicked
        Add(itemTypeGeneratorLabel, itemTypeGeneratorComboBox, updateButton, cancelButton)
    End Sub

    Private Sub OnCancelButtonClicked()
        Program.GoToWindow(New LocationTypeEditWindow(locationTypeStore))
    End Sub

    Private Sub OnUpdateButtonClicked()
        Dim selectedItem = itemTypeGeneratorComboBox.SelectedItem
        If selectedItem = -1 Then
            locationTypeStore.ItemTypeGenerator = Nothing
        Else
            locationTypeStore.ItemTypeGenerator = itemTypeGenerators(selectedItem)
        End If
        Program.GoToWindow(New LocationTypeEditWindow(locationTypeStore))
    End Sub
End Class
