Imports Terminal.Gui

Friend MustInherit Class BaseEditTypeWindow
    Inherits Window
    Private ReadOnly nameTextField As TextField
    Private ReadOnly cancelWindowSource As Func(Of Window)
    Private ReadOnly deleteWindowSource As Func(Of Window)
    Private ReadOnly updateWindowSource As Func(Of String, Window)
    Private ReadOnly canRenameCheck As Func(Of String, Boolean)
    Private ReadOnly typeName As String
    Public Sub New(
                  title As String,
                  typeName As String,
                  id As Integer,
                  name As String,
                  canDelete As Boolean,
                  canRenameCheck As Func(Of String, Boolean),
                  cancelWindowSource As Func(Of Window),
                  deleteWindowSource As Func(Of Window),
                  updateWindowSource As Func(Of String, Window))
        MyBase.New(title)
        Me.typeName = typeName
        Me.cancelWindowSource = cancelWindowSource
        Me.deleteWindowSource = deleteWindowSource
        Me.updateWindowSource = updateWindowSource
        Me.canRenameCheck = canRenameCheck
        Dim idLabel As New Label("Id:") With
            {
                .X = 1,
                .Y = 1
            }
        Dim idTextField As New TextField(id.ToString) With
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
        nameTextField = New TextField(name) With
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
                .Enabled = canDelete
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
        Program.GoToWindow(cancelWindowSource())
    End Sub

    Private Sub OnDeleteButtonClicked()
        Program.GoToWindow(deleteWindowSource())
    End Sub

    Private Sub OnUpdateButtonClicked()
        Dim newName = nameTextField.Text.ToString
        If Not canRenameCheck(newName) Then
            MessageBox.ErrorQuery("Invalid!", $"You cannot rename the {typeName} to that.", "Ok")
            Return
        End If
        Program.GoToWindow(updateWindowSource(newName))
    End Sub

End Class
