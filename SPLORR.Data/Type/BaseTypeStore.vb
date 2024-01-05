Friend MustInherit Class BaseTypeStore
    Implements IBaseTypeStore

    Public MustOverride ReadOnly Property Id As Integer Implements IBaseTypeStore.Id
    Public MustOverride Property Name As String Implements IBaseTypeStore.Name
    Public MustOverride ReadOnly Property CanDelete As Boolean Implements IBaseTypeStore.CanDelete
    Public MustOverride ReadOnly Property Store As IDataStore Implements IBaseTypeStore.Store
    Public MustOverride Sub Delete() Implements IBaseTypeStore.Delete
    Public MustOverride Function CanRenameTo(x As String) As Boolean Implements IBaseTypeStore.CanRenameTo
End Class
