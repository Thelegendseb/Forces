﻿Public Class Form1

    Private Session As Session
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Session = New Session(Me)
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Session.Start()
    End Sub

End Class
