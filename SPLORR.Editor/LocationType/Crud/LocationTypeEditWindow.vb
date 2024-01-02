Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationTypeEditWindow
    Inherits Window

    Private _locationTypeStore As ILocationTypeStore
    Private nameTextField As TextField

    Public Sub New(locationTypeStore As ILocationTypeStore)
        MyBase.New($"Edit Location Type: {locationTypeStore.Name}")
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
        AddHandler updateButton.Clicked, AddressOf OnUpdateButtonClicked
        Dim deleteButton As New Button("Delete") With
            {
                .X = Pos.Right(updateButton) + 1,
                .Y = updateButton.Y,
                .Enabled = _locationTypeStore.CanDelete
            }
        AddHandler deleteButton.Clicked, AddressOf OnDeleteButtonClicked
        Dim cancelButton As New Button("Cancel") With
            {
                .X = Pos.Right(deleteButton) + 1,
                .Y = updateButton.Y
            }
        AddHandler cancelButton.Clicked, AddressOf OnCancelButtonClicked
        Dim locationsButton As New Button("List Locations...") With
            {
                .X = 1,
                .Y = Pos.Bottom(updateButton) + 1,
                .Enabled = _locationTypeStore.HasLocations
            }
        AddHandler locationsButton.Clicked, AddressOf OnLocationsButtonClicked
        Dim verbsButton As New Button("List Verbs...") With
            {
                .X = 1,
                .Y = Pos.Bottom(locationsButton) + 1,
                .Enabled = _locationTypeStore.HasVerbs
            }
        AddHandler verbsButton.Clicked, AddressOf OnVerbsButtonClicked
        Dim addVerbButton As New Button("Add Verb...") With
            {
                .X = Pos.Right(verbsButton) + 1,
                .Y = verbsButton.Y,
                .Enabled = _locationTypeStore.CanAddVerb
            }
        AddHandler addVerbButton.Clicked, AddressOf OnAddVerbButtonClicked
        Dim removeVerbButton As New Button("Remove Verb...") With
            {
                .X = Pos.Right(addVerbButton) + 1,
                .Y = verbsButton.Y,
                .Enabled = _locationTypeStore.HasVerbs
            }
        AddHandler removeVerbButton.Clicked, AddressOf OnRemoveVerbButtonClicked
        Add(
            idLabel,
            idTextField,
            nameLabel,
            nameTextField,
            updateButton,
            deleteButton,
            cancelButton,
            locationsButton,
            verbsButton,
            addVerbButton,
            removeVerbButton)
    End Sub
    Private Sub OnRemoveVerbButtonClicked()
        Program.GoToWindow(New LocationTypeRemoveVerbTypeWindow(_locationTypeStore))
    End Sub
    Private Sub OnUpdateButtonClicked()
        Dim newName = nameTextField.Text.ToString
        If Not _locationTypeStore.CanRenameTo(newName) Then
            MessageBox.ErrorQuery("Invalid!", "You cannot rename the location type to that.", "Ok")
            Return
        End If
        _locationTypeStore.Name = newName
        Program.GoToWindow(New LocationTypeEditWindow(_locationTypeStore))
    End Sub

    Private Sub OnAddVerbButtonClicked()
        Program.GoToWindow(New LocationTypeAddVerbTypeWindow(_locationTypeStore))
    End Sub
    Private Sub OnVerbsButtonClicked()
        Program.GoToWindow(New LocationTypeVerbTypeListWindow(_locationTypeStore))
    End Sub
    Private Sub OnLocationsButtonClicked()
        Program.GoToWindow(New LocationTypeLocationListWindow(_locationTypeStore))
    End Sub
    Private Sub OnDeleteButtonClicked()
        If Not _locationTypeStore.CanDelete Then
            MessageBox.ErrorQuery("Denied!", "You cannot delete this Location Type, for reasons.", "Ok")
            Return
        End If
        _locationTypeStore.Delete()
        Program.GoToWindow(New LocationTypeListWindow(_locationTypeStore.Store))
    End Sub
    Private Sub OnCancelButtonClicked()
        Program.GoToWindow(New LocationTypeListWindow(_locationTypeStore.Store))
    End Sub
End Class
