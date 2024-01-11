Imports SPLORR.Data
Imports Terminal.Gui

Friend Class ItemListWindow
    Inherits BaseListWindow(Of IDataStore, IItemStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Items",
            store,
            Function(x, y) x.Items.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New ItemEditWindow(x),
            AdditionalButtons:=
            {
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
