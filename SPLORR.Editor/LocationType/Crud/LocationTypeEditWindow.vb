Imports SPLORR.Data

Friend Class LocationTypeEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(locationTypeStore As ILocationTypeStore)
        MyBase.New(
            $"Edit Location Type: {locationTypeStore.Name}",
            "Location Type",
            locationTypeStore.Id,
            locationTypeStore.Name,
            locationTypeStore.CanDelete,
            Function(x) locationTypeStore.CanRenameTo(x),
            Function() New LocationTypeListWindow(locationTypeStore.Store),
            Function()
                locationTypeStore.Delete()
                Return New LocationTypeListWindow(locationTypeStore.Store)
            End Function,
            Function(x)
                locationTypeStore.Name = x
                Return New LocationTypeEditWindow(locationTypeStore)
            End Function,
            {
                (
                    "List Locations...",
                    Function() locationTypeStore.HasLocations,
                    Sub() Program.GoToWindow(New LocationTypeLocationListWindow(locationTypeStore))
                )
            },
            {
                (
                    "List Verbs...",
                    Function() locationTypeStore.HasVerbs,
                    Sub() Program.GoToWindow(New LocationTypeVerbTypeListWindow(locationTypeStore))
                ),
                (
                    "Add Verb...",
                    Function() locationTypeStore.CanAddVerb,
                    Sub() Program.GoToWindow(New LocationTypeAddVerbTypeWindow(locationTypeStore))
                ),
                (
                    "Remove Verb...",
                    Function() locationTypeStore.HasVerbs,
                    Sub() Program.GoToWindow(New LocationTypeRemoveVerbTypeWindow(locationTypeStore))
                )
            }
            )
    End Sub
End Class
