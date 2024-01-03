Imports Terminal.Gui

Friend MustInherit Class BaseAddTypeWindow
    Inherits Window
    Private ReadOnly nameTextField As TextField
    Private ReadOnly typeName As String
    Private ReadOnly cancelWindowSource As Func(Of Window)
    Private ReadOnly addWindowSource As Func(Of String, Window)
    Private ReadOnly nameExistsCheck As Func(Of String, Boolean)
    Public Sub New(
                  title As String,
                  typeName As String,
                  nameExistsCheck As Func(Of String, Boolean),
                  cancelWindowSource As Func(Of Window),
                  addWindowSource As Func(Of String, Window))
        MyBase.New(title)
        Me.typeName = typeName
        Me.addWindowSource = addWindowSource
        Me.cancelWindowSource = cancelWindowSource
        Me.nameExistsCheck = nameExistsCheck
        Dim nameLabel As New Label("Name:") With
            {
                .X = 1,
                .Y = 1
            }
        nameTextField = New TextField() With
            {
                .X = Pos.Right(nameLabel) + 1,
                .Y = nameLabel.Y,
                .Width = [Dim].Fill - 1
            }
        Dim addButton As New Button("Add") With
            {
                .X = 1,
                .Y = Pos.Bottom(nameLabel) + 1
            }
        AddHandler addButton.Clicked, AddressOf OnAddButtonClicked
        Dim cancelButton As New Button("Cancel") With
            {
                .X = Pos.Right(addButton) + 1,
                .Y = addButton.Y
            }
        AddHandler cancelButton.Clicked, AddressOf OnCancelButtonClicked
        Add(nameLabel, nameTextField, addButton, cancelButton)
    End Sub
    Private Sub OnCancelButtonClicked()
        GoToWindow(cancelWindowSource())
    End Sub
    Private Sub OnAddButtonClicked()
        Dim newTypeName = nameTextField.Text.ToString
        If String.IsNullOrEmpty(newTypeName) Then
            MessageBox.ErrorQuery("Error!", $"{typeName} must have a name!", "Ok")
            Return
        End If
        If nameExistsCheck(newTypeName) Then
            MessageBox.ErrorQuery("Duplicate!", $"{typeName} Name must be unique!", "Ok")
            Return
        End If
        GoToWindow(addWindowSource(newTypeName))
    End Sub
End Class
