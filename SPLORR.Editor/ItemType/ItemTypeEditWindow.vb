Imports SPLORR.Data
Imports Terminal.Gui

Friend Class ItemTypeEditWindow
    Inherits Window
    Private ReadOnly itemTypeStore As IItemTypeStore
    Private ReadOnly nameTextField As TextField
    Public Sub New(itemTypeStore As IItemTypeStore)
        MyBase.New($"Edit Item Type: {itemTypeStore.Name}")
        Me.itemTypeStore = itemTypeStore
        Dim idLabel As New Label("Id:") With
            {
                .X = 1,
                .Y = 1
            }
        Dim idTextField As New TextField(itemTypeStore.Id.ToString) With
            {
                .X = Pos.Right(idLabel) + 1,
                .Y = idLabel.Y,
                .Width = [Dim].Fill - 1,
                .[ReadOnly] = True
            }
        Dim nameLabel As New Label("Name:") With
            {
                .X = 1,
                .Y = Pos.Bottom(idLabel) + 1
            }
        nameTextField = New TextField(itemTypeStore.Name) With
            {
                .X = Pos.Right(nameLabel) + 1,
                .Y = nameLabel.Y,
                .Width = [Dim].Fill - 1
            }
        Dim updateButton = New Button("Update") With
            {
                .X = 1,
                .Y = Pos.Bottom(nameLabel) + 1
            }
        AddHandler updateButton.Clicked, AddressOf OnUpdateButtonClicked
        Dim deleteButton = New Button("Delete") With
            {
                .X = Pos.Right(updateButton) + 1,
                .Y = updateButton.Y,
                .Enabled = itemTypeStore.CanDelete
            }
        AddHandler deleteButton.Clicked, AddressOf OnDeleteButtonClicked
        Dim cancelButton = New Button("Cancel") With
            {
                .X = Pos.Right(deleteButton) + 1,
                .Y = updateButton.Y
            }
        AddHandler cancelButton.Clicked, AddressOf OnCancelButtonClicked
        Add(
            idLabel,
            idTextField,
            nameLabel,
            nameTextField,
            updateButton,
            deleteButton,
            cancelButton)
    End Sub

    Private Sub OnCancelButtonClicked()
        Program.GoToWindow(New ItemTypeListWindow(itemTypeStore.Store))
    End Sub

    Private Sub OnDeleteButtonClicked()
        itemTypeStore.Delete()
        Program.GoToWindow(New ItemTypeListWindow(itemTypeStore.Store))
    End Sub

    Private Sub OnUpdateButtonClicked()
        Dim newName = nameTextField.Text.ToString
        If Not itemTypeStore.CanRenameTo(newName) Then
            MessageBox.ErrorQuery("Invalid!", "You cannot rename the item type to that.", "Ok")
            Return
        End If
        itemTypeStore.Name = newName
        Program.GoToWindow(New ItemTypeEditWindow(itemTypeStore))
    End Sub
End Class
