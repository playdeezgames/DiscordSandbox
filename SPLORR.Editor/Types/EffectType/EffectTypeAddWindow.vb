Friend Class EffectTypeAddWindow
    Inherits BaseAddTypeWindow
    Public Sub New(dataStore As Data.IDataStore)
        MyBase.New(
            "Add Effect Type...",
            "Effect Type Name must exist and be unique!",
            ("Add", Function(x) String.IsNullOrEmpty(x) OrElse dataStore.EffectTypes.NameExists(x),
            Function(x) New EffectTypeEditWindow(dataStore.EffectTypes.Create(x))),
            ("Cancel", Function() New EffectTypeListWindow(dataStore)))
    End Sub
End Class
