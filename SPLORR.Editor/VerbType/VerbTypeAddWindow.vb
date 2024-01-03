Imports Terminal.Gui

Friend Class VerbTypeAddWindow
    Inherits Window

    Private ReadOnly dataStore As Data.IDataStore
    Private nameTextField As TextField

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New("Add Verb Type...")
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
        GoToWindow(New VerbTypeListWindow(dataStore))
    End Sub

    Private Sub OnAddButtonClicked()
        Dim verbTypeName = nameTextField.Text.ToString
        If String.IsNullOrEmpty(verbTypeName) Then
            MessageBox.ErrorQuery("Error!", "Verb Type must have a name!", "Ok")
            Return
        End If
        If dataStore.VerbTypeNameExists(verbTypeName) Then
            MessageBox.ErrorQuery("Duplicate!", "Verb Type Name must be unique!", "Ok")
            Return
        End If
        dataStore.CreateVerbType(verbTypeName)
        GoToWindow(New VerbTypeListWindow(dataStore))
    End Sub
End Class
