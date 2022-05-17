Public Class XGraphics

    'used by an XCanvas object

    Private g As Graphics
    Private buffer As BufferedGraphics
    Private context As BufferedGraphicsContext

    Sub New(ByRef gin As Graphics, width As Integer, height As Integer)  'doesnt need to be a form?!!?
        Me.g = gin
        Me.context = BufferedGraphicsManager.Current
        Me.context.MaximumBuffer = New Size(width + 1, height + 1)
        Me.buffer = context.Allocate(g, New Rectangle(0, 0, width, height))
    End Sub
    Private Sub Clear(C As Color)
        buffer.Graphics.Clear(C)
    End Sub
    Private Sub DrawEntity(Entity As XEntity)
        buffer.Graphics.FillEllipse(Brushes.Black, CInt(Entity.GetPosition.X) - CInt(Entity.GetRadius),
                                         CInt(Entity.GetPosition.Y) - CInt(Entity.GetRadius),
                                         CInt(Entity.GetRadius * 2), CInt(Entity.GetRadius * 2))
    End Sub
    Public Sub Draw(Session As Session)
        Clear(Color.White)

        For Each Entity As XEntity In Session.GetEntityList
            DrawEntity(Entity)
        Next

        Render()
    End Sub
    Private Sub Render()
        buffer.Render(Me.g)
    End Sub
End Class
