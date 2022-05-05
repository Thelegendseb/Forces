Public Class Entity

    Protected Position As Vector
    Protected Velocity As Vector
    Protected Acceleration As Vector

    Sub New()
        Me.Position = Vector.Zero
        Me.Velocity = Vector.Zero
        Me.Acceleration = Vector.Zero
    End Sub

    Public Sub Update(FormBounds As Rectangle)

        BorderCollisionChecks(FormBounds)
        Me.Velocity += Me.Acceleration
        Me.Position += Me.Velocity

    End Sub
    Private Sub BorderCollisionChecks(FormBounds As Rectangle)
        Dim CollisionOccured As Boolean = False
        If Me.Position.X > FormBounds.X + FormBounds.Width Then
            Me.Position.X = FormBounds.X + FormBounds.Width
            Me.Velocity.X *= -1
            CollisionOccured = True
        End If
        If Me.Position.X < FormBounds.X Then
            Me.Position.X = FormBounds.X
            Me.Velocity.X *= -1
            CollisionOccured = True
        End If
        If Me.Position.Y > FormBounds.Y + FormBounds.Height Then
            Me.Position.Y = FormBounds.Y + FormBounds.Height
            Me.Velocity.Y *= -1
            CollisionOccured = True
        End If
        If Me.Position.Y < FormBounds.Y Then
            Me.Position.Y = FormBounds.Y
            Me.Velocity.Y *= -1
            CollisionOccured = True
        End If

        If CollisionOccured Then
            Me.Velocity *= New Vector(0.8, 0.8) 'Friction/ Loss of Ek?
        End If
    End Sub

    '======GETTERS/SETTERS/MATHS OPS========
    Public Function GetPosition() As Vector
        Return Me.Position
    End Function
    Public Sub SetPosition(ByVal Position As Vector)
        Me.Position = Position
    End Sub
    Public Function GetVelocity() As Vector
        Return Me.Velocity
    End Function
    Public Sub SetVelocity(ByVal Velocity As Vector)
        Me.Velocity = Velocity
    End Sub
    Public Function GetAcceleration() As Vector
        Return Me.Acceleration
    End Function
    Public Sub SetAcceleration(ByVal Acceleration As Vector)
        Me.Acceleration = Acceleration
    End Sub
    '=============================
End Class
