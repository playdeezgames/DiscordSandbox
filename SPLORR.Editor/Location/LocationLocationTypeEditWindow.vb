Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationLocationTypeEditWindow
    Inherits BaseListWindow(Of IDataStore, ILocationTypeStore)

    Public Sub New(store As Data.ILocationStore)
        MyBase.New(
            $"Type for Location `{store.Name}` (current:`{store.LocationType.Name}`):",
            store.Store,
            Function(x, y) x.LocationTypes.Filter(y),
            Function(x) New ListItem(Of ILocationTypeStore)(x, $"{x.Name}(Id:{x.Id})"),
            Function(x)
                store.LocationType = CType(x, ListItem(Of ILocationTypeStore)).Store
                Return New LocationEditWindow(store)
            End Function,
            AdditionalButtons:=
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New LocationEditWindow(store))
                )
            })
    End Sub
End Class
