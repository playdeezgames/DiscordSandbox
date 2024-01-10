﻿Imports SPLORR.Data

Friend Class CharacterLocationEditWindow
    Inherits BaseListWindow(Of IDataStore, ILocationStore)

    Public Sub New(store As Data.ICharacterStore)
        MyBase.New(
            $"Location for Character `{store.Name}` (current:`{store.Location.Name}`):",
            store.Store,
            Function(x, y) x.Locations.Filter(y),
            Function(x) New LocationListItem(x),
            Function(x)
                store.SetLocation(CType(x, LocationListItem).Store, DateTimeOffset.Now)
                Return New CharacterEditWindow(store)
            End Function,
            AdditionalButtons:=
            {
                (
                    "Cancel",
                    Function() True,
                    Sub() Program.GoToWindow(New CharacterEditWindow(store))
                )
            })
    End Sub
End Class
