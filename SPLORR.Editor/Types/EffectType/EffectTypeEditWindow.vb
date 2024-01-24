Imports SPLORR.Data

Friend Class EffectTypeEditWindow
    Inherits BaseEditTypeWindow

    Public Sub New(store As IEffectTypeStore)
        MyBase.New(
            $"Edit Effect Type: {store.Name}",
            "Effect Type",
            ("Id", store.Id.ToString),
            ("Name", store.Name),
            (True, "Update",
            Function(x) store.CanRenameTo(x),
            Function(x)
                store.Name = x
                Return New EffectTypeEditWindow(store)
            End Function),
            (store.CanDelete, "Delete",
            Function()
                store.Delete()
                Return New EffectTypeListWindow(store.Store)
            End Function),
            ("Cancel", Function() New EffectTypeListWindow(store.Store)))
    End Sub
End Class
