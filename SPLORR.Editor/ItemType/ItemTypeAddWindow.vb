Imports SPLORR.Data
Imports Terminal.Gui

Friend Class ItemTypeAddWindow
    Inherits Window

    Private ReadOnly dataStore As Data.IDataStore
    Private nameTextField As TextField

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New("Add Item Type...")
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
        GoToWindow(New ItemTypeListWindow(dataStore))
    End Sub

    Private Sub OnAddButtonClicked()
        Dim itemTypeName = nameTextField.Text.ToString
        If String.IsNullOrEmpty(itemTypeName) Then
            MessageBox.ErrorQuery("Error!", "Item Type must have a name!", "Ok")
            Return
        End If
        If dataStore.ItemTypeNameExists(itemTypeName) Then
            MessageBox.ErrorQuery("Duplicate!", "Item Type Name must be unique!", "Ok")
            Return
        End If
        Dim itemType As IItemTypeStore = dataStore.CreateItemType(itemTypeName)
        GoToWindow(New ItemTypeListWindow(dataStore))
    End Sub
End Class
