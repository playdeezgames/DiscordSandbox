Imports NStack
Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationTypeListWindow
    Inherits Window

    Private ReadOnly dataStore As Data.IDataStore
    Private ReadOnly filterTextField As TextField
    Private ReadOnly resultsListView As ListView

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New("Location Types")
        Me.dataStore = dataStore
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

    Private Sub OnResultsListViewOpenSelectedItem(e As ListViewItemEventArgs)
        Program.GoToWindow(New LocationTypeEditWindow(CType(e.Value, LocationTypeListItem).LocationTypeStore))
    End Sub

    Private Sub OnFilterTextChanged(filterText As ustring)
        UpdateResultsListView()
    End Sub

    Private Sub UpdateResultsListView()
        Dim filter = "%"
        If filterTextField.Text.ToString.Length <> 0 Then
            filter += filterTextField.Text.ToString
            filter += "%"
        End If
        Dim items As IEnumerable(Of ILocationTypeStore) = dataStore.FilterLocationTypes(filter)
        resultsListView.SetSource(items.Select(AddressOf ToListViewItem).ToList)
    End Sub

    Private Function ToListViewItem(item As ILocationTypeStore) As Object
        Return New LocationTypeListItem(item)
    End Function
End Class
