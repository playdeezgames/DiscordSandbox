Imports SPLORR.Data

Friend Class StatisticTypeListWindow
    Inherits BaseListWindow(Of IDataStore, IStatisticTypeStore)

    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Statistic Types",
            dataStore,
            Function(store, filter) store.StatisticTypes.Filter(filter),
            Function(x) New ListItem(Of IStatisticTypeStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(item) New StatisticTypeEditWindow(CType(item, ListItem(Of IStatisticTypeStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New StatisticTypeAddWindow(dataStore))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
