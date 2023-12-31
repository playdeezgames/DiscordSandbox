Imports NStack
Imports SPLORR.Data
Imports Terminal.Gui

Friend MustInherit Class BaseListWindow(Of TStore, TResultStore)
    Inherits Window
    Protected ReadOnly store As TStore
    Protected ReadOnly filterTextField As TextField
    Protected ReadOnly resultsListView As ListView
    Private ReadOnly FilterItems As Func(Of TStore, String, IEnumerable(Of TResultStore))
    Private ReadOnly ToListViewItem As Func(Of TResultStore, Object)
    Private ReadOnly ToResultWindow As Func(Of Object, Window)
    Protected Sub New(
                     title As String,
                     store As TStore,
                     FilterItems As Func(Of TStore, String, IEnumerable(Of TResultStore)),
                     ToListViewItem As Func(Of TResultStore, Object),
                     ToResultWindow As Func(Of Object, Window))
        MyBase.New(title)
        Me.store = store
        Me.ToListViewItem = ToListViewItem
        Me.FilterItems = FilterItems
        Me.ToResultWindow = ToResultWindow
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
        Dim items As IEnumerable(Of TResultStore) = FilterItems(store, filter)
        resultsListView.SetSource(items.Select(ToListViewItem).ToList)
    End Sub

    Private Sub OnResultsListViewOpenSelectedItem(args As ListViewItemEventArgs)
        Program.GoToWindow(ToResultWindow(args.Value))
    End Sub

    Private Sub OnFilterTextChanged(text As ustring)
        UpdateResultsListView()
    End Sub
End Class
