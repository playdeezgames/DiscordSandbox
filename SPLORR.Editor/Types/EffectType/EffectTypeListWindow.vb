Imports SPLORR.Data

Friend Class EffectTypeListWindow
    Inherits BaseListWindow(Of IDataStore, IEffectTypeStore)

    Public Sub New(store As Data.IDataStore)
        MyBase.New(
            "Effect Types",
            store,
            Function(x, y) x.EffectTypes.Filter(y),
            Function(x) $"{x.Name}(Id:{x.Id})",
            Function(x) New EffectTypeEditWindow(x),
            AdditionalButtons:=
            {
                ("Add...", Function() True, Sub() Program.GoToWindow(New EffectTypeAddWindow(store))),
                ("Close", Function() True, Sub() Program.GoToWindow(Nothing))
            })
    End Sub
End Class
