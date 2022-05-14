Public Class Session

    Private Graphics As XGraphics
    Private Parent As Form

    Private Timer As Stopwatch
    Const FPS As Integer = 60

    Protected EntityList As List(Of XEntity)
    Protected Running As Boolean
    Protected Bounds As Rectangle
    Sub New(ByRef Control As Form) 'has to be a form for key down etc.

        Me.Parent = Control

        Me.Timer = New Stopwatch

        Me.EntityList = New List(Of XEntity)

        Me.Graphics = New XGraphics(Control.CreateGraphics)
        Me.Bounds = Control.ClientRectangle

        AddHandlers()

        AddTests()

        GravityToggle(True)

    End Sub
    Private Sub AddTests()

        Me.EntityList.Add(New XEntity(1))
        Me.EntityList(0).SetPosition(New XVector(50, 100))
        Me.EntityList(0).SetVelocity(New XVector(5, 3))
        Me.EntityList(0).SetAcceleration(0, True)

        Me.EntityList.Add(New XEntity(1.5))
        Me.EntityList(1).SetPosition(New XVector(300, 100))
        Me.EntityList(1).SetVelocity(New XVector(2, 2))
        Me.EntityList(1).SetAcceleration(0, True)

        Me.EntityList.Add(New XEntity(2))
        Me.EntityList(2).SetPosition(New XVector(550, 100))
        Me.EntityList(2).SetVelocity(New XVector(20, 1))
        Me.EntityList(2).SetAcceleration(0, True)

        Me.EntityList.Add(New XEntity(0.5))
        Me.EntityList(3).SetPosition(New XVector(50, 300))
        Me.EntityList(3).SetVelocity(New XVector(10, 4))
        Me.EntityList(3).SetAcceleration(0, True)

        Me.EntityList.Add(New XEntity(0.75))
        Me.EntityList(4).SetPosition(New XVector(300, 300))
        Me.EntityList(4).SetVelocity(New XVector(5, -3))
        Me.EntityList(4).SetAcceleration(0, True)

        Me.EntityList.Add(New XEntity(0.5))
        Me.EntityList(5).SetPosition(New XVector(550, 300))
        Me.EntityList(5).SetVelocity(New XVector(-2, -2))
        Me.EntityList(5).SetAcceleration(0, True)

        Me.EntityList.Add(New XEntity(0.25))
        Me.EntityList(6).SetPosition(New XVector(50, 500))
        Me.EntityList(6).SetVelocity(New XVector(8, -4))
        Me.EntityList(6).SetAcceleration(0, True)
    End Sub
    Public Sub Start()
        Me.Running = True
        Do
            Me.Timer.Restart()

            Me.Graphics.Clear()
            For Each Entity As XEntity In Me.EntityList
                Entity.Update(Me)
                Me.Graphics.DrawEntity(Entity) 'testing purposes rn
            Next


            If 1000 / FPS < Me.Timer.ElapsedMilliseconds / 1000 Then Throw New Exception("Time taken to execute exceeded Frame Rate")
            System.Threading.Thread.Sleep(1000 / FPS - (Timer.ElapsedMilliseconds / 1000))
            Application.DoEvents()
        Loop Until Me.Running = False
    End Sub

    'ALL ENTITY OPS
    Private Sub GravityToggle(G As Boolean)
        For Each Entity As XEntity In Me.EntityList
            Entity.SetAcceleration(0, G)
        Next
    End Sub
    Private Sub AccelerationToggleX(val As Double)
        For Each Entity As XEntity In Me.EntityList
            Entity.SetAcceleration(val, Entity.GetAcceleration.Y)
        Next
    End Sub
    Private Sub AccelerationToggleY(val As Double)
        For Each Entity As XEntity In Me.EntityList
            Entity.SetAcceleration(Entity.GetAcceleration.X, val)
        Next
    End Sub

    '======HANDLERS=======
    Private Sub AddHandlers()
        AddHandler Me.Parent.MouseMove, AddressOf Me.MouseMove
        AddHandler Me.Parent.FormClosing, AddressOf Me.FormClosing
        AddHandler Me.Parent.ResizeEnd, AddressOf Me.ResizeEnd
    End Sub
    Private Sub MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.EntityList(0).SetPosition(New XVector(e.X, e.Y))
        End If
    End Sub
    Private Sub FormClosing(sender As Object, e As FormClosingEventArgs)
        Me.Halt()
    End Sub
    Private Sub ResizeEnd(sender As Object, e As EventArgs)
        Me.Resize()
    End Sub

    '===GETTERS/SETTERS/OTHERS====
    Public Sub Resize()
        Me.Graphics = New XGraphics(Parent.CreateGraphics)
        Me.Bounds = Parent.ClientRectangle
    End Sub
    Public Function GetEntityList() As List(Of XEntity)
        Return Me.EntityList
    End Function
    Public Sub SetBounds(val As Rectangle)
        Me.Bounds = val
    End Sub
    Public Function GetBounds() As Rectangle
        Return Me.Bounds
    End Function
    Public Sub Halt()
        Me.Running = False
    End Sub
End Class
