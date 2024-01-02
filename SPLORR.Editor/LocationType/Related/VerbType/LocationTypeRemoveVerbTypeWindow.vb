Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationTypeRemoveVerbTypeWindow
    Inherits Window

    Private ReadOnly locationTypeStore As Data.ILocationTypeStore
    Private ReadOnly verbTypeComboBox As ComboBox
    Private ReadOnly verbTypes As List(Of IVerbTypeStore)

    Public Sub New(locationTypeStore As Data.ILocationTypeStore)
        MyBase.New($"Remove Verb Type from Location Type: {locationTypeStore.Name}")
        Me.locationTypeStore = locationTypeStore
        Dim verbTypeLabel As New Label("Verb Type:") With
            {
                .X = 1,
                .Y = 1
            }
        verbTypeComboBox = New ComboBox With
            {
                .X = Pos.Right(verbTypeLabel) + 1,
                .Y = verbTypeLabel.Y,
                .Width = [Dim].Fill - 1
            }
        verbTypes = locationTypeStore.VerbTypes.ToList
        verbTypeComboBox.SetSource(verbTypes.Select(Function(x) New VerbTypeListItem(x)).ToList)
        Dim removeButton As New Button("Remove") With
            {
                .X = 1,
                .Y = Pos.Bottom(verbTypeLabel) + 1
            }
        AddHandler removeButton.Clicked, AddressOf OnRemoveButtonClicked
        Dim cancelButton As New Button("Cancel") With
            {
                .X = Pos.Right(removeButton) + 1,
                .Y = removeButton.Y
            }
        AddHandler cancelButton.Clicked, AddressOf OnCancelButtonClicked
        Add(
            verbTypeLabel,
            verbTypeComboBox,
            removeButton,
            cancelButton)
    End Sub

    Private Sub OnCancelButtonClicked()
        Program.GoToWindow(New LocationTypeEditWindow(locationTypeStore))
    End Sub

    Private Sub OnRemoveButtonClicked()
        Dim selectedItem = verbTypeComboBox.SelectedItem
        If selectedItem = -1 Then
            MessageBox.ErrorQuery("Invalid!", "Please select a valid verb type!", "Ok")
            Return
        End If
        locationTypeStore.RemoveVerb(verbTypes(selectedItem))
        Program.GoToWindow(New LocationTypeEditWindow(locationTypeStore))
    End Sub
End Class
