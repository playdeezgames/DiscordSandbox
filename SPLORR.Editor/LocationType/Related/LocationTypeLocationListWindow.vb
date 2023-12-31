Friend Class LocationTypeLocationListWindow
    Inherits BaseListWindow(Of Data.ILocationTypeStore, Data.ILocationStore)

    Public Sub New(locationTypeStore As Data.ILocationTypeStore)
        MyBase.New(
            $"Locations for Location Type: {locationTypeStore.Name}",
            locationTypeStore,
            Function(store, filter) store.FilterLocations(filter),
            Function(item) New LocationListItem(item),
            Function(item) New LocationEditWindow(CType(item, LocationListItem).LocationStore))
    End Sub
End Class
