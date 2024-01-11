Imports SPLORR.Data

Friend Class DirectionListWindow
    Inherits BaseListWindow(Of IDataStore, IDirectionStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Directions",
            dataStore,
            Function(store, filter) store.Directions.Filter(filter),
            Function(x) New ListItem(Of IDirectionStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(item) New DirectionEditWindow(CType(item, ListItem(Of IDirectionStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New DirectionAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
