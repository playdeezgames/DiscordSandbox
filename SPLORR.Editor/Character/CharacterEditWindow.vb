﻿Imports SPLORR.Data
Imports Terminal.Gui

Friend Class CharacterEditWindow
    Inherits BaseEditTypeWindow
    Public Sub New(store As ICharacterStore)
        MyBase.New(
            $"Edit Character: {store.Name}",
            "Character",
            store.Id,
            ("Name", store.Name),
            store.CanDelete,
            Function(x) store.CanRenameTo(x),
            Function() New CharacterListWindow(store.Store),
            Function()
                store.Delete()
                Return New CharacterListWindow(store.Store)
            End Function,
            Function(x)
                store.Name = x
                Return New CharacterEditWindow(store)
            End Function)
    End Sub
End Class