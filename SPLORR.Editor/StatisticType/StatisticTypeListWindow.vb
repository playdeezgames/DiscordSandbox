Imports SPLORR.Data

Friend Class StatisticTypeListWindow
    Inherits BaseListWindow(Of IDataStore, IStatisticTypeStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Statistic Types",
            store,
            Function(x, y) x.StatisticTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New StatisticTypeEditWindow(CType(x, ListItem(Of IStatisticTypeStore)).Store),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New StatisticTypeAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
