Imports SPLORR.Data
Imports Terminal.Gui

Friend Class VerbTypeEditWindow
    Inherits Window

    Private ReadOnly verbTypeStore As IVerbTypeStore
    Private ReadOnly nameTextField As TextField


    Public Sub New(verbTypeStore As IVerbTypeStore)
        MyBase.New($"Edit Verb Type: {verbTypeStore.Name}")
        Me.verbTypeStore = verbTypeStore
        Dim idLabel As New Label("Id:") With
            {
                .X = 1,
                .Y = 1
            }
        Dim idTextField As New TextField(verbTypeStore.Id.ToString) With
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
        nameTextField = New TextField(verbTypeStore.Name) With
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
                .Enabled = verbTypeStore.CanDelete
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
        Program.GoToWindow(Nothing)
    End Sub

    Private Sub OnDeleteButtonClicked()
        verbTypeStore.Delete()
        Program.GoToWindow(Nothing)
    End Sub

    Private Sub OnUpdateButtonClicked()
        Dim newName = nameTextField.Text.ToString
        If Not verbTypeStore.CanRenameTo(newName) Then
            MessageBox.ErrorQuery("Invalid!", "You cannot rename the verb type to that.", "Ok")
            Return
        End If
        verbTypeStore.Name = newName
        Program.GoToWindow(Nothing)
    End Sub
End Class
