Imports System.Xml.Serialization

Public Class ZCL_MERE026_IDLE_CAUSE
    Public Property MT_IDLE_CAUSE As MT_IDLE_CAUSE
    Public Property MT_CAUSE_LONG_TXT As MT_CAUSE_LONG_TXT

    Public Overloads Function Equals(obj As ZCL_MERE026_IDLE_CAUSE) As Boolean
        If obj Is Nothing Then Return False

        Return Object.Equals(MT_IDLE_CAUSE, obj.MT_IDLE_CAUSE) AndAlso
               Object.Equals(MT_CAUSE_LONG_TXT, obj.MT_CAUSE_LONG_TXT)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, ZCL_MERE026_IDLE_CAUSE))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return If(MT_IDLE_CAUSE?.GetHashCode(), 0)
    End Function
End Class

Public Class MT_IDLE_CAUSE
    Public Property QMUR As QMUR

    Public Overloads Function Equals(obj As MT_IDLE_CAUSE) As Boolean
        If obj Is Nothing Then Return False

        Return Object.Equals(QMUR, obj.QMUR)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, MT_IDLE_CAUSE))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return If(QMUR?.GetHashCode(), 0)
    End Function
End Class

Public Class QMUR
    Public Property MANDT As String
    Public Property QMNUM As String
    Public Property FENUM As String
    Public Property URNUM As String
    Public Property ERNAM As String
    Public Property ERDAT As String
    Public Property AENAM As String
    Public Property AEDAT As String
    Public Property URTXT As String
    Public Property URKAT As String
    Public Property URGRP As String
    Public Property URCOD As String
    Public Property URVER As String
    Public Property INDTX As String
    Public Property KZMLA As String
    Public Property ERZEIT As String
    Public Property AEZEIT As String
    Public Property VUKAT As String
    Public Property VUGRP As String
    Public Property VUCOD As String
    Public Property PARVW As String
    Public Property PARNR As String
    Public Property BAUTL As String
    Public Property URMENGE As String
    Public Property URMGEIN As String
    Public Property KZLOESCH As String
    Public Property QURNUM As String
    Public Property AUTKZ As String
    Public Property INVOLVPERC As String

    Public Overloads Function Equals(obj As QMUR) As Boolean
        If obj Is Nothing Then Return False

        Return String.Equals(MANDT, obj.MANDT) AndAlso
               String.Equals(QMNUM, obj.QMNUM) AndAlso
               String.Equals(FENUM, obj.FENUM) AndAlso
               String.Equals(URNUM, obj.URNUM) AndAlso
               String.Equals(ERNAM, obj.ERNAM) AndAlso
               String.Equals(ERDAT, obj.ERDAT) AndAlso
               String.Equals(AENAM, obj.AENAM) AndAlso
               String.Equals(AEDAT, obj.AEDAT) AndAlso
               String.Equals(URTXT, obj.URTXT) AndAlso
               String.Equals(URKAT, obj.URKAT) AndAlso
               String.Equals(URGRP, obj.URGRP) AndAlso
               String.Equals(URCOD, obj.URCOD) AndAlso
               String.Equals(URVER, obj.URVER) AndAlso
               String.Equals(INDTX, obj.INDTX) AndAlso
               String.Equals(KZMLA, obj.KZMLA) AndAlso
               String.Equals(ERZEIT, obj.ERZEIT) AndAlso
               String.Equals(AEZEIT, obj.AEZEIT) AndAlso
               String.Equals(VUKAT, obj.VUKAT) AndAlso
               String.Equals(VUGRP, obj.VUGRP) AndAlso
               String.Equals(VUCOD, obj.VUCOD) AndAlso
               String.Equals(PARVW, obj.PARVW) AndAlso
               String.Equals(PARNR, obj.PARNR) AndAlso
               String.Equals(BAUTL, obj.BAUTL) AndAlso
               String.Equals(URMENGE, obj.URMENGE) AndAlso
               String.Equals(URMGEIN, obj.URMGEIN) AndAlso
               String.Equals(KZLOESCH, obj.KZLOESCH) AndAlso
               String.Equals(QURNUM, obj.QURNUM) AndAlso
               String.Equals(AUTKZ, obj.AUTKZ) AndAlso
               String.Equals(INVOLVPERC, obj.INVOLVPERC)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, QMUR))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return If(MANDT?.GetHashCode(), 0)
    End Function
End Class

Public Class MT_CAUSE_LONG_TXT
    Public Property ZTLINE As ZTLINE

    Public Overloads Function Equals(obj As MT_CAUSE_LONG_TXT) As Boolean
        If obj Is Nothing Then Return False

        Return Object.Equals(ZTLINE, obj.ZTLINE)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, MT_CAUSE_LONG_TXT))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return If(ZTLINE?.GetHashCode(), 0)
    End Function
End Class

Public Class ZTLINE
    Public Property POSITION_ID As String
    Public Property TDFORMAT As String
    Public Property TDLINE As String

    Public Overloads Function Equals(obj As ZTLINE) As Boolean
        If obj Is Nothing Then Return False

        Return String.Equals(POSITION_ID, obj.POSITION_ID) AndAlso
               String.Equals(TDFORMAT, obj.TDFORMAT) AndAlso
               String.Equals(TDLINE, obj.TDLINE)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, ZTLINE))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return If(POSITION_ID?.GetHashCode(), 0)
    End Function
End Class
