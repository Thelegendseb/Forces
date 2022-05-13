Public Class Entity

    Protected Position As Vector
    Protected Velocity As Vector
    Protected Acceleration As Vector
    Protected Mass As Double
    Protected Radius As Double
    Sub New(Mass As Double, Radius As Double)
        Me.Mass = Mass
        Me.Radius = Radius
        Me.Position = Vector.Zero
        Me.Velocity = Vector.Zero
        Me.Acceleration = Vector.Zero
    End Sub

    Public Sub Update(Session As Session)

        BorderCollisionChecks(Session.GetBounds)
        EntityCollisionChecks(Session.GetEntityList)

        VectorSums()

    End Sub
    Private Sub VectorSums()
        Me.Velocity += Me.Acceleration
        Me.Position += Me.Velocity
    End Sub
    Private Sub EntityCollisionChecks(EntityList As List(Of Entity))

        'position needs to change to avoid another collision

        For Each Entity In EntityList
            If Me.GetBounds <> Entity.GetBounds Then

                If Me.GetBounds.IntersectsWith(Entity.GetBounds) Then

                    Me.SetVelocity(New Vector(Me.GetVelocity.X * -1, Me.GetVelocity.Y * -1))
                    Entity.SetVelocity(New Vector(Entity.GetVelocity.X * -1, Entity.GetVelocity.Y * -1))

                End If

            End If
        Next
    End Sub
    Private Sub BorderCollisionChecks(FormBounds As Rectangle)
        Dim CollisionOccured As Boolean = False
        If Me.Position.X + Me.Velocity.X > FormBounds.X + FormBounds.Width Then
            Me.Position.X = FormBounds.X + FormBounds.Width
            Me.Velocity.X *= -1
            CollisionOccured = True
        End If
        If Me.Position.X + Me.Velocity.X < FormBounds.X Then
            Me.Position.X = FormBounds.X
            Me.Velocity.X *= -1
            CollisionOccured = True
        End If
        If Me.Position.Y + Me.Velocity.Y > FormBounds.Y + FormBounds.Height Then
            Me.Position.Y = FormBounds.Y + FormBounds.Height
            Me.Velocity.Y *= -1
            CollisionOccured = True
        End If
        If Me.Position.Y + Me.Velocity.Y < FormBounds.Y Then
            Me.Position.Y = FormBounds.Y
            Me.Velocity.Y *= -1
            CollisionOccured = True
        End If

        If CollisionOccured Then
            Me.Velocity.Dissapate(0.8) 'Friction/ Loss of Ek?
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
    Public Sub SetAcceleration(XComponent As Double, EffectedByGravity As Boolean)
        Dim YComponent As Double = 0.0
        Dim Gravity As Double = 2.0 'Stored in Session
        If EffectedByGravity Then
            YComponent = Me.Mass * Gravity
        Else
            YComponent = 0
        End If
        Me.Acceleration = New Vector(XComponent, YComponent)
    End Sub
    Public Function GetRadius() As Double
        Return Me.Radius
    End Function
    Public Sub SetRadius(val As Double)
        Me.Radius = val
    End Sub
    Public Function GetBounds() As Rectangle
        Return New Rectangle(Me.Position.X, Me.Position.Y, Me.Radius * 2, Me.Radius * 2)
    End Function
    '=============================
End Class
