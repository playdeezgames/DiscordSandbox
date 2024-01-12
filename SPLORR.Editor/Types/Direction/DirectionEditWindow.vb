Imports Terminal.Gui

Friend Class DirectionEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(directionStore As Data.IDirectionStore)
        MyBase.New(
            $"Edit Direction: {directionStore.Name}",
            "Direction",
            directionStore.Id,
            ("Name", directionStore.Name),
            True,
            (directionStore.CanDelete, "Delete",
            Function()
                directionStore.Delete()
                Return New DirectionListWindow(directionStore.Store)
            End Function),
            Function(x) directionStore.CanRenameTo(x),
            ("Cancel", Function() New DirectionListWindow(directionStore.Store)),
            Function(x)
                directionStore.Name = x
                Return New DirectionEditWindow(directionStore)
            End Function)
    End Sub
End Class
