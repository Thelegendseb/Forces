﻿Public Class XMath

    'compatibility with XVector,XEntity Class
    Public Shared Function Distance(v1 As XVector, v2 As XVector)
        Return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2))
    End Function

    Public Shared Function EECollisionCheck(e1 As XEntity, e2 As XEntity) As Boolean
        Dim Dist As Double = Distance(e1.GetPosition, e2.GetPosition)
        If Dist < e1.GetRadius + e2.GetRadius Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
