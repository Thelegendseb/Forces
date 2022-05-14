Public Class Form1

    Private Session As Session
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Session = New Session(Me)
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Session.Start()
    End Sub
    '=================================
    Public Sub DrawEntity(Entity As XEntity)
        Using g As Graphics = Me.CreateGraphics
            g.FillEllipse(Brushes.Black, CInt(Entity.GetPosition.X) - CInt(Entity.GetRadius),
                                         CInt(Entity.GetPosition.Y) - CInt(Entity.GetRadius),
                                         CInt(Entity.GetRadius * 2), CInt(Entity.GetRadius * 2))
        End Using
    End Sub
    Public Sub Clear()
        Using g As Graphics = Me.CreateGraphics()
            g.Clear(Me.BackColor)
        End Using
    End Sub
    '=================================
    'EVENTS

    'close event
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Session.Halt()
    End Sub
End Class
