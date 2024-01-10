Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationListWindow
    Inherits BaseListWindow(Of IDataStore, ILocationStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Locations",
            dataStore,
            Function(store, filter) store.Locations.Filter(filter),
            Function(item) New LocationListItem(item),
            Function(item) New LocationEditWindow(CType(item, LocationListItem).Store),
            AdditionalButtons:=
            {
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
