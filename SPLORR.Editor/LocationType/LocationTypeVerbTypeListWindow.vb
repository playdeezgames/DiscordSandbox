Imports Terminal.Gui

Friend Class LocationTypeVerbTypeListWindow
    Inherits Window

    Private ReadOnly locationTypeStore As Data.ILocationTypeStore

    Public Sub New(locationTypeStore As Data.ILocationTypeStore)
        MyBase.New($"Verb Types for Location Type: {locationTypeStore.Name}")
        Me.locationTypeStore = locationTypeStore
    End Sub
End Class
