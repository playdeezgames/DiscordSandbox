Imports Terminal.Gui

Friend Class LocationEditWindow
    Inherits Window

    Private ReadOnly locationStore As Data.ILocationStore

    Public Sub New(locationStore As Data.ILocationStore)
        MyBase.New("Edit Location")
        Me.locationStore = locationStore
    End Sub
End Class
