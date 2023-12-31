Imports Microsoft.Identity.Client.Cache
Imports NStack
Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationTypeLocationListWindow
    Inherits Window

    Private ReadOnly locationTypeStore As Data.ILocationTypeStore
    Private filterTextField As TextField
    Private ReadOnly resultsListView As ListView

    Public Sub New(locationTypeStore As Data.ILocationTypeStore)
        MyBase.New($"Locations for Location Type: {locationTypeStore.Name}")
        Me.locationTypeStore = locationTypeStore
        Dim filterLabel As New Label("Filter:") With
            {
                .X = 1, .Y = 1
            }
        filterTextField = New TextField() With
            {
                .X = Pos.Right(filterLabel) + 1,
                .Y = filterLabel.Y,
                .Width = [Dim].Fill - 1
            }
        AddHandler filterTextField.TextChanged, AddressOf OnFilterTextChanged
        resultsListView = New ListView() With
            {
            .X = 1,
            .Y = Pos.Bottom(filterLabel) + 1,
            .Width = [Dim].Fill - 1,
            .Height = [Dim].Fill - 1
            }
        AddHandler resultsListView.OpenSelectedItem, AddressOf OnResultsListViewOpenSelectedItem
        UpdateResultsListView()
        Add(filterLabel, filterTextField, resultsListView)
    End Sub

    Private Sub UpdateResultsListView()
        Dim filter = "%"
        If filterTextField.Text.ToString.Length <> 0 Then
            filter += filterTextField.Text.ToString
            filter += "%"
        End If
        Dim items As IEnumerable(Of ILocationStore) = locationTypeStore.FilterLocations(filter)
        resultsListView.SetSource(items.Select(AddressOf ToListViewItem).ToList)
    End Sub

    Private Sub OnResultsListViewOpenSelectedItem(e As ListViewItemEventArgs)
        Program.GoToWindow(New LocationEditWindow(CType(e.Value, LocationListItem).LocationStore))
    End Sub

    Private Function ToListViewItem(store As ILocationStore) As Object
        Return New LocationListItem(store)
    End Function

    Private Sub OnFilterTextChanged(text As ustring)
        UpdateResultsListView()
    End Sub
End Class
