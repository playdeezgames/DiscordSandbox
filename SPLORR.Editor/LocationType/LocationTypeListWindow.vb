Imports SPLORR.Data

Friend Class LocationTypeListWindow
    Inherits BaseListWindow(Of Data.IDataStore, Data.ILocationTypeStore)
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Location Types",
            dataStore,
            Function(store, filter) store.LocationTypes.Filter(filter),
            Function(x) New ListItem(Of ILocationTypeStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(item) New LocationTypeEditWindow(CType(item, ListItem(Of ILocationTypeStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New LocationTypeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
