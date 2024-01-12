Imports Terminal.Gui

Friend MustInherit Class BaseEditTypeWindow
    Inherits Window
    Private ReadOnly nameTextField As TextField
    Private ReadOnly cancelWindowSource As Func(Of Window)
    Private ReadOnly deleteWindowSource As Func(Of Window)
    Private ReadOnly updateWindowSource As Func(Of String, Window)
    Private ReadOnly canRenameCheck As Func(Of String, Boolean)
    Private ReadOnly typeName As String
    Private ReadOnly nameColumnName As String
    Public Sub New(
                  title As String,
                  typeName As String,
                  id As Integer,
                  nameColumn As (Name As String, Value As String),
                  canUpdate As Boolean,
                  onDelete As (Enabled As Boolean, Caption As String, NextWindow As Func(Of Window)),
                  canRenameCheck As Func(Of String, Boolean),
                  onCancel As (Caption As String, NextWindow As Func(Of Window)),
                  updateWindowSource As Func(Of String, Window),
                  ParamArray AdditionalButtonRows As IEnumerable(Of (Title As String, IsEnabled As Func(Of Boolean), OnClicked As Action))())
        MyBase.New(title)
        Me.typeName = typeName
        Me.cancelWindowSource = onCancel.NextWindow
        Me.deleteWindowSource = onDelete.NextWindow
        Me.updateWindowSource = updateWindowSource
        Me.canRenameCheck = canRenameCheck
        Me.nameColumnName = nameColumn.Name
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
        Dim nameLabel As New Label($"{nameColumn.Name}:") With
            {
                .X = 1,
                .Y = Pos.Bottom(idLabel) + 1
            }
        nameTextField = New TextField(nameColumn.Value) With
            {
                .X = Pos.Right(nameLabel) + 1,
                .Y = nameLabel.Y,
                .Width = [Dim].Fill - 1,
                .[ReadOnly] = Not canUpdate
            }
        Dim buttonX As Pos = 1
        Add(
            idLabel,
            idTextField,
            nameLabel,
            nameTextField)

        Dim updateButton = New Button("Update") With
            {
                .X = buttonX,
                .Y = Pos.Bottom(nameLabel) + 1,
                .Enabled = canUpdate
            }
        AddHandler updateButton.Clicked, AddressOf OnUpdateButtonClicked
        buttonX = Pos.Right(updateButton) + 1
        Add(updateButton)

        If onDelete.Enabled Then
            Dim deleteButton = New Button("Delete") With
            {
                .X = buttonX,
                .Y = updateButton.Y
            }
            AddHandler deleteButton.Clicked, AddressOf OnDeleteButtonClicked
            buttonX = Pos.Right(deleteButton) + 1
            Add(deleteButton)
        End If

        Dim cancelButton = New Button("Cancel") With
            {
                .X = buttonX,
                .Y = updateButton.Y
            }
        AddHandler cancelButton.Clicked, AddressOf OnCancelButtonClicked
        buttonX = Pos.Right(cancelButton) + 1
        Add(cancelButton)

        Dim nextY = Pos.Bottom(updateButton) + 1
        If AdditionalButtonRows IsNot Nothing Then
            For Each additionalButtonRow In AdditionalButtonRows
                nextY = AddAdditionalButtonRow(additionalButtonRow, nextY)
            Next
        End If
    End Sub

    Private Function AddAdditionalButtonRow(additionalButtonRow As IEnumerable(Of (Title As String, IsEnabled As Func(Of Boolean), OnClicked As Action)), y As Pos) As Pos
        Dim nextY As Pos = y
        If additionalButtonRow IsNot Nothing Then
            Dim x As Pos = 1
            For Each additionalButton In additionalButtonRow
                Dim button As New Button(additionalButton.Title) With
                {
                    .X = x,
                    .Y = y,
                    .Enabled = additionalButton.IsEnabled()
                }
                AddHandler button.Clicked, additionalButton.OnClicked
                x = Pos.Right(button) + 1
                nextY = Pos.Bottom(button) + 1
                Add(button)
            Next
        End If
        Return nextY
    End Function

    Private Sub OnCancelButtonClicked()
        Program.GoToWindow(cancelWindowSource())
    End Sub

    Private Sub OnDeleteButtonClicked()
        Program.GoToWindow(deleteWindowSource())
    End Sub

    Private Sub OnUpdateButtonClicked()
        Dim newName = nameTextField.Text.ToString
        If Not canRenameCheck(newName) Then
            MessageBox.ErrorQuery("Invalid!", $"You cannot change the {typeName}'s {nameColumnName} to that value.", "Ok")
            Return
        End If
        Program.GoToWindow(updateWindowSource(newName))
    End Sub

End Class
