Imports SPLORR.Data

Friend Class LocationTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(locationTypeStore As ILocationTypeStore)
        MyBase.New(
            $"Edit Location Type: {locationTypeStore.Name}",
            "Location Type",
            locationTypeStore.Id,
            ("Name", locationTypeStore.Name),
            (True, "Update",
            Function(x) locationTypeStore.CanRenameTo(x),
            Function(x)
                locationTypeStore.Name = x
                Return New LocationTypeEditWindow(locationTypeStore)
            End Function),
            (locationTypeStore.CanDelete, "Delete",
            Function()
                locationTypeStore.Delete()
                Return New LocationTypeListWindow(locationTypeStore.Store)
            End Function),
            ("Cancel", Function() New LocationTypeListWindow(locationTypeStore.Store)),
            {
                (
                    "List Locations...",
                    Function() locationTypeStore.HasLocations,
                    Sub() Program.GoToWindow(New LocationTypeLocationListWindow(locationTypeStore))
                ),
                (
                    "Create Location...",
                    Function() True,
                    Sub() Program.GoToWindow(New LocationEditWindow(locationTypeStore.CreateLocation("New Location")))
                )
            },
            {
                (
                    "Set Item Type Generator...",
                    Function() True,
                    Sub() Program.GoToWindow(New LocationTypeEditItemTypeGeneratorWindow(locationTypeStore))
                ),
                (
                    "Clear Item Type Generator",
                    Function() locationTypeStore.ItemTypeGenerator IsNot Nothing,
                    Sub()
                        locationTypeStore.ItemTypeGenerator = Nothing
                        Program.GoToWindow(New LocationTypeEditWindow(locationTypeStore))
                    End Sub
                )
            })
    End Sub
End Class
