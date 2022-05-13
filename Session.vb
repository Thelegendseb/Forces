Public Class Session

    Protected EntityList As New List(Of Entity)

    Protected Bounds As Rectangle

    Sub New(Control As Control)

        Me.Bounds = Control.ClientRectangle

        Dim TestEntity1 As New Entity(0.5, 10)
        TestEntity1.SetPosition(New Vector(50, 100))
        TestEntity1.SetVelocity(New Vector(20, -10))
        TestEntity1.SetAcceleration(0, True)
        Me.EntityList.Add(TestEntity1)

        Dim TestEntity2 As New Entity(0.5, 30)
        TestEntity2.SetPosition(New Vector(300, 100))
        TestEntity2.SetVelocity(New Vector(-40, -10))
        TestEntity2.SetAcceleration(0, True)
        Me.EntityList.Add(TestEntity2)

    End Sub
    Public Sub Start()
        Do
            For Each Entity As Entity In Me.EntityList
                Entity.Update(Me)
                Form1.DrawEntity(Entity) 'testing purposes rn
            Next
            System.Threading.Thread.Sleep(30)
            Application.DoEvents()
            Form1.Clear()
        Loop
    End Sub


    '===GETTERS/SETTERS====
    Public Function GetEntityList() As List(Of Entity)
        Return Me.EntityList
    End Function
    Public Sub SetBounds(val As Rectangle)
        Me.Bounds = val
    End Sub
    Public Function GetBounds() As Rectangle
        Return Me.Bounds
    End Function

End Class
