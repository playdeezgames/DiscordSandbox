﻿Imports SPLORR.Data
Imports Terminal.Gui

Friend Class LocationEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ILocationStore)
        MyBase.New(
            $"Edit Location: {store.Name}",
            "Item Type",
            ("Id", store.Id.ToString),
            ("Name", store.Name),
            (True, "Update",
            Function(x) store.CanRenameTo(x),
            Function(x)
                store.Name = x
                Return New LocationEditWindow(store)
            End Function),
            (store.CanDelete, "Delete",
            Function()
                store.Delete()
                Return New LocationListWindow(store.Store)
            End Function),
            ("Cancel", Function() New LocationListWindow(store.Store)),
            {
                (
                    $"Type: {store.LocationType.Name}",
                    Function() True,
                    Sub() Program.GoToWindow(New LocationLocationTypeEditWindow(store))
                ),
                (
                    "Characters...",
                    Function() store.HasCharacter,
                    Sub() Program.GoToWindow(New LocationCharacterListWindow(store))
                )
            })
    End Sub
End Class
