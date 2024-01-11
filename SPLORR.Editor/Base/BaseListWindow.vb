Imports NStack
Imports Terminal.Gui

Friend MustInherit Class BaseListWindow(Of TStore, TResultStore)
    Inherits Window
    Protected ReadOnly store As TStore
    Protected ReadOnly filterTextField As TextField
    Protected ReadOnly resultsListView As ListView
    Private ReadOnly FilterItems As Func(Of TStore, String, IEnumerable(Of TResultStore))
    Private ReadOnly ToListViewItemName As Func(Of TResultStore, String)
    Private ReadOnly ToResultWindow As Func(Of Object, Window)
    Protected Sub New(
                     title As String,
                     store As TStore,
                     FilterItems As Func(Of TStore, String, IEnumerable(Of TResultStore)),
                     ToListViewItemName As Func(Of TResultStore, String),
                     Optional ToResultWindow As Func(Of Object, Window) = Nothing,
                     Optional AdditionalButtons As IEnumerable(Of (Title As String, IsEnabled As Func(Of Boolean), OnClicked As Action)) = Nothing)
        MyBase.New(title)
        Me.store = store
        Me.ToListViewItemName = ToListViewItemName
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
        Add(filterLabel, filterTextField)
        Dim resultsListViewY = Pos.Bottom(filterLabel) + 1
        If AdditionalButtons IsNot Nothing AndAlso AdditionalButtons.Any Then
            Dim buttonX As Pos = 1
            For Each additionalButton In AdditionalButtons
                Dim button As New Button(additionalButton.Title) With
                    {
                        .X = buttonX,
                        .Y = Pos.Bottom(filterLabel) + 1,
                        .Enabled = additionalButton.IsEnabled()
                    }
                AddHandler button.Clicked, additionalButton.OnClicked
                buttonX = Pos.Right(button) + 1
                resultsListViewY = Pos.Bottom(button) + 1
                Add(button)
            Next
        End If
        resultsListView = New ListView() With
            {
            .X = 1,
            .Y = resultsListViewY,
            .Width = [Dim].Fill - 1,
            .Height = [Dim].Fill - 1
            }
        AddHandler resultsListView.OpenSelectedItem, AddressOf OnResultsListViewOpenSelectedItem
        UpdateResultsListView()
        Add(resultsListView)
    End Sub

    Private Sub UpdateResultsListView()
        Dim filter = "%"
        If filterTextField.Text.ToString.Length <> 0 Then
            filter += filterTextField.Text.ToString
            filter += "%"
        End If
        Dim items As IEnumerable(Of TResultStore) = FilterItems(store, filter)
        resultsListView.SetSource(items.Select(Function(x) New ListItem(Of TResultStore)(x, ToListViewItemName(x))).ToList)
    End Sub

    Private Sub OnResultsListViewOpenSelectedItem(args As ListViewItemEventArgs)
        If ToResultWindow IsNot Nothing Then
            Program.GoToWindow(ToResultWindow(args.Value))
        End If
    End Sub

    Private Sub OnFilterTextChanged(text As ustring)
        UpdateResultsListView()
    End Sub
End Class
