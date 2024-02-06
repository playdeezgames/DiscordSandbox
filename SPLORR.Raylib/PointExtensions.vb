Public Module PointExtensions
    Function PointsAdd(ParamArray points As (X As Integer, Y As Integer)()) As (X As Integer, Y As Integer)
        Return (points.Sum(Function(x) x.X), points.Sum(Function(x) x.Y))
    End Function
    Function PointSizeMultiply(first As (X As Integer, Y As Integer), second As (Width As Integer, Height As Integer)) As (X As Integer, Y As Integer)
        Return (first.X * second.Width, first.Y * second.Height)
    End Function
End Module
