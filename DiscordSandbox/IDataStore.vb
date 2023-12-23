Public Interface IDataStore
    ReadOnly Property Players As IPlayerStore
    Sub Close()
End Interface
