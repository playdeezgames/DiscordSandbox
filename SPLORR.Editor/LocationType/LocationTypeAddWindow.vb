Imports Terminal.Gui

Friend Class LocationTypeAddWindow
    Inherits Window

    Private ReadOnly dataStore As Data.IDataStore
    Private nameTextField As TextField

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New("Add Location Type...")
        Me.dataStore = dataStore
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
        Program.GoToWindow(Nothing)
    End Sub

    Private Sub OnAddButtonClicked()
        Dim locationTypeName = nameTextField.Text.ToString
        If String.IsNullOrEmpty(locationTypeName) Then
            MessageBox.ErrorQuery("Error!", "Location Type must have a name!", "Ok")
            Return
        End If
        If dataStore.LocationTypeNameExists(locationTypeName) Then
            MessageBox.ErrorQuery("Duplicate!", "Location Type Name must be unique!", "Ok")
            Return
        End If
        dataStore.CreateLocationType(locationTypeName)
        Program.GoToWindow(Nothing)
    End Sub
End Class
