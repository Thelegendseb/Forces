Public Class Form1
    Dim WithEvents Time As New Timer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EntityInit()

        Time.Interval = 20  'Put into a session
        Time.Start()
    End Sub
    Private Sub Time_Tick(sender As Object, e As EventArgs) Handles Time.Tick
        TestEntity.Update(New Rectangle(0, 0, Me.ClientSize.Width, Me.ClientSize.Height))
        DrawEntity(TestEntity)
    End Sub
    '=================================
    Dim TestEntity As Entity

    Sub EntityInit()
        TestEntity = New Entity(1)
        TestEntity.SetPosition(New Vector(100, 150))
        TestEntity.SetVelocity(New Vector(10, 5))
        'TestEntity.SetAcceleration(New Vector(0, 1))
        TestEntity.SetAcceleration(0, True)
    End Sub
    Sub DrawEntity(Entity As Entity)
        Using g As Graphics = Me.CreateGraphics
            g.Clear(Me.BackColor)
            g.FillEllipse(Brushes.Black, CSng(Entity.GetPosition.X) - 10, CSng(Entity.GetPosition.Y) - 10, 20, 20)
        End Using
    End Sub
    '=================================
End Class
