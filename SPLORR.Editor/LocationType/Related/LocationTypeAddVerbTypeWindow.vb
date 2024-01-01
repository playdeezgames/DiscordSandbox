Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationTypeAddVerbTypeWindow
    Inherits Window

    Private ReadOnly locationTypeStore As Data.ILocationTypeStore
    Private ReadOnly verbTypeComboBox As ComboBox
    Private ReadOnly availableVerbTypes As List(Of IVerbTypeStore)

    Public Sub New(locationTypeStore As Data.ILocationTypeStore)
        MyBase.New($"Add Verb Type fo Location Type: {locationTypeStore.Name}")
        Me.locationTypeStore = locationTypeStore
        Dim verbTypeLabel = New Label("Verb Type:")
        With verbTypeLabel
            .X = 1
            .Y = 1
        End With
        verbTypeComboBox = New ComboBox
        With verbTypeComboBox
            .X = Pos.Right(verbTypeLabel) + 1
            .Y = verbTypeLabel.Y
            .Width = [Dim].Fill - 1
        End With
        availableVerbTypes = locationTypeStore.AvailableVerbTypes.ToList
        verbTypeComboBox.SetSource(availableVerbTypes.Select(Function(x) ToComboBoxItem(x)).ToList)
        Dim addButton As New Button("Add")
        With addButton
            .X = 1
            .Y = Pos.Bottom(verbTypeLabel) + 1
        End With
        AddHandler addButton.Clicked, AddressOf OnAddButtonClicked
        Dim cancelButton As New Button("Cancel")
        With cancelButton
            .X = Pos.Right(addButton) + 1
            .Y = addButton.Y
        End With
        AddHandler cancelButton.Clicked, AddressOf OnCancelButtonClicked
        Add(verbTypeLabel, verbTypeComboBox, addButton, cancelButton)
    End Sub

    Private Sub OnCancelButtonClicked()
        Program.GoToWindow(Nothing)
    End Sub

    Private Sub OnAddButtonClicked()
        Dim item = verbTypeComboBox.SelectedItem
        If item = -1 Then
            MessageBox.ErrorQuery("Invalid!", "Pick a valid verb type!", "Ok")
            Return
        End If
        locationTypeStore.AddVerb(availableVerbTypes(item))
    End Sub
    Private Function ToComboBoxItem(verbTypeStore As IVerbTypeStore) As Object
        Return New VerbTypeListItem(verbTypeStore)
    End Function
End Class
