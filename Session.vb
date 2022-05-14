Public Class Session

    Private Parent As Control

    Protected EntityList As New List(Of XEntity)

    Protected Running As Boolean


    Protected Bounds As Rectangle


    Sub New(ByRef Control As Control)

        Me.Parent = Control

        Me.Bounds = Control.ClientRectangle

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
            For Each Entity As XEntity In Me.EntityList
                Entity.Update(Me)
                Form1.DrawEntity(Entity) 'testing purposes rn
            Next
            System.Threading.Thread.Sleep(20)
            Application.DoEvents()
            Form1.Clear()
        Loop Until Me.Running = False
    End Sub


    '===GETTERS/SETTERS/OTHERS====
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
