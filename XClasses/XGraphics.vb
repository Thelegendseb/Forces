Public Class XGraphics

    Private g As Graphics

    Sub New(ByRef g As Graphics)
        Me.g = g
    End Sub
    Public Sub Clear()
        g.Clear(Color.White)
    End Sub
    Public Sub DrawEntity(Entity As XEntity)
        g.FillEllipse(Brushes.Black, CInt(Entity.GetPosition.X) - CInt(Entity.GetRadius),
                                         CInt(Entity.GetPosition.Y) - CInt(Entity.GetRadius),
                                         CInt(Entity.GetRadius * 2), CInt(Entity.GetRadius * 2))

    End Sub
End Class
