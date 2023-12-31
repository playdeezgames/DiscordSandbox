Imports SPLORR.Data
Imports Terminal.Gui

Friend Class VerbTypeEditWindow
    Inherits Window

    Private ReadOnly verbTypeStore As IVerbTypeStore

    Public Sub New(verbTypeStore As IVerbTypeStore)
        MyBase.New($"Edit Verb Type: {verbTypeStore.Name}")
        Me.verbTypeStore = verbTypeStore
    End Sub
End Class
