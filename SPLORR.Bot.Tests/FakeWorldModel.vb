Imports SPLORR.Model

Friend Class FakeWorldModel
    Implements IWorldModel
    Friend ReadOnly Property InitializeCalled As Boolean
        Get
            Return True
        End Get
    End Property
    Friend ReadOnly Property CleanUpCalled As Boolean
        Get
            Return True
        End Get
    End Property
End Class
