
Public Module SizeExtensions
    Function SizesMultiply(first As (Width As Integer, Height As Integer), second As (Width As Integer, Height As Integer)) As (Width As Integer, Height As Integer)
        Return (first.Width * second.Width, first.Height * second.Height)
    End Function
End Module
