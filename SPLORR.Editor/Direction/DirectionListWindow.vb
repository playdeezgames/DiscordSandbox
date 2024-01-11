Imports SPLORR.Data

Friend Class DirectionListWindow
    Inherits BaseListWindow(Of IDataStore, IDirectionStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Directions",
            store,
            Function(x, y) x.Directions.Filter(y),
            Function(x) New ListItem(Of IDirectionStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(x) New DirectionEditWindow(CType(x, ListItem(Of IDirectionStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New DirectionAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
