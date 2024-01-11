Imports SPLORR.Data

Friend Class LocationTypeListWindow
    Inherits BaseListWindow(Of Data.IDataStore, Data.ILocationTypeStore)
    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Location Types",
            store,
            Function(x, y) x.LocationTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New LocationTypeEditWindow(x),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New LocationTypeAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
