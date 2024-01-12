Imports Terminal.Gui

Friend MustInherit Class BaseAddTypeWindow
    Inherits Window
    Private ReadOnly nameTextField As TextField
    Private ReadOnly errorMessage As String
    Private ReadOnly cancelWindowSource As Func(Of Window)
    Private ReadOnly addWindowSource As Func(Of String, Window)
    Private ReadOnly isInputInvalid As Func(Of String, Boolean)
    Public Sub New(
                  title As String,
                  errorMessage As String,
                  onAdd As (Caption As String, IsInputInvalid As Func(Of String, Boolean), NextWindow As Func(Of String, Window)),
                  onCancel As (Caption As String, NextWindow As Func(Of Window)))
        MyBase.New(title)
        Me.errorMessage = errorMessage
        Me.addWindowSource = onAdd.NextWindow
        Me.cancelWindowSource = onCancel.NextWindow
        Me.isInputInvalid = onAdd.IsInputInvalid
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
        Dim addButton As New Button(onAdd.Caption) With
            {
                .X = 1,
                .Y = Pos.Bottom(nameLabel) + 1
            }
        AddHandler addButton.Clicked, AddressOf OnAddButtonClicked
        Dim cancelButton As New Button(onCancel.Caption) With
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
        If isInputInvalid(newTypeName) Then
            MessageBox.ErrorQuery("Error!", errorMessage, "Ok")
            Return
        End If
        GoToWindow(addWindowSource(newTypeName))
    End Sub
End Class
