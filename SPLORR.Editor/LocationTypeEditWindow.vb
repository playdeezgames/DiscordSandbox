Imports System.IO
Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationTypeEditWindow
    Inherits Window

    Private _locationTypeStore As ILocationTypeStore
    Private nameTextField As TextField

    Public Sub New(locationTypeStore As ILocationTypeStore)
        MyBase.New("Edit Location Type")
        Me._locationTypeStore = locationTypeStore
        Dim idLabel As New Label("Id:") With
            {
                .X = 1,
                .Y = 1
            }
        Dim idTextField As New TextField(_locationTypeStore.Id.ToString) With
            {
                .[ReadOnly] = True,
                .X = Pos.Right(idLabel) + 1,
                .Y = idLabel.Y,
                .Width = [Dim].Fill - 1
            }
        Dim nameLabel As New Label("Name:") With
            {
                .X = 1,
                .Y = Pos.Bottom(idLabel) + 1
            }
        nameTextField = New TextField(_locationTypeStore.Name) With
            {
                .X = Pos.Right(nameLabel) + 1,
                .Y = nameLabel.Y,
                .Width = [Dim].Fill - 1
            }
        Dim updateButton As New Button("Update") With
            {
                .X = 1,
                .Y = Pos.Bottom(nameLabel) + 1
            }
        Dim deleteButton As New Button("Delete") With
            {
                .X = Pos.Right(updateButton) + 1,
                .Y = updateButton.Y
            }
        AddHandler deleteButton.Clicked, AddressOf OnDeleteButtonClicked
        Dim cancelButton As New Button("Cancel") With
            {
                .X = Pos.Right(deleteButton) + 1,
                .Y = updateButton.Y
            }
        AddHandler cancelButton.Clicked, AddressOf OnCancelButtonClicked
        Add(idLabel, idTextField, nameLabel, nameTextField, updateButton, deleteButton, cancelButton)
    End Sub

    Private Sub OnDeleteButtonClicked()
        If Not _locationTypeStore.CanDelete Then
            MessageBox.ErrorQuery("Denied!", "You cannot delete this Location Type, for reasons.", "Ok")
            Return
        End If
        _locationTypeStore.Delete()
        Program.GoToWindow(Nothing)
    End Sub

    Private Sub OnCancelButtonClicked()
        Program.GoToWindow(Nothing)
    End Sub
End Class
