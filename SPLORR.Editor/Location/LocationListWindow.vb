Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationListWindow
    Inherits BaseListWindow(Of IDataStore, ILocationStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Locations",
            store,
            Function(x, y) x.Locations.Filter(y),
            Function(x) $"{x.Name}(Id{x.Id})",
            Function(x) New LocationEditWindow(CType(x, ListItem(Of ILocationStore)).Store),
            AdditionalButtons:=
            {
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
