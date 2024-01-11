Imports SPLORR.Data

Friend Class LocationTypeLocationListWindow
    Inherits BaseListWindow(Of Data.ILocationTypeStore, Data.ILocationStore)
    Public Sub New(store As Data.ILocationTypeStore)
        MyBase.New(
            $"Locations for Location Type: {store.Name}",
            store,
            Function(x, y) x.FilterLocations(y),
            Function(x) New ListItem(Of ILocationStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(x) New LocationEditWindow(CType(x, ListItem(Of ILocationStore)).Store),
            AdditionalButtons:=
            {
                (
                    "Location Type",
                    Function() True,
                    Sub() Program.GoToWindow(New LocationTypeEditWindow(store))
                )
            })
    End Sub
End Class
