Imports SPLORR.Model

Friend Class FakeWorldModel
    Implements IWorldModel
    Private _cleanUpCalled As Boolean = False
    Friend ReadOnly Property InitializeCalled As Boolean
        Get
            Return True
        End Get
    End Property
    Friend ReadOnly Property CleanUpCalled As Boolean
        Get
            Return _cleanUpCalled
        End Get
    End Property

    Public Sub CleanUp() Implements IWorldModel.CleanUp
        _cleanUpCalled = True
    End Sub
End Class
