Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationTypeVerbTypeListWindow
    Inherits BaseListWindow(Of ILocationTypeStore, IVerbTypeStore)

    Public Sub New(locationTypeStore As Data.ILocationTypeStore)
        MyBase.New(
            $"Verb Types for Location Type: {locationTypeStore.Name}",
            locationTypeStore,
            Function(store, filter) store.FilterVerbTypes(filter),
            Function(item) New VerbTypeListItem(item),
            Function(item) New VerbTypeEditWindow(CType(item, VerbTypeListItem).VerbTypeStore))
    End Sub
End Class
