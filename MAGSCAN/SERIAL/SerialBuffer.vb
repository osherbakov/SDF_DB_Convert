''' <summary>
''' 
''' This class implements the serial buffer made out of 8-bit bytes
''' </summary>
Public Class SerialBuffer
    Private m_Buffer As New System.Collections.Generic.List(Of Byte)

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As Char)
        m_Buffer.Add(Convert.ToByte(value))
    End Sub

    Public Sub New(ByVal value As Byte)
        m_Buffer.Add(value)
    End Sub

    Public Shared Operator +(ByVal a As SerialBuffer, ByVal b As Char) As SerialBuffer
        a.m_Buffer.Add(Convert.ToByte(b))
        Return a
    End Operator

    Public Shared Operator +(ByVal a As SerialBuffer, ByVal b As Integer) As SerialBuffer
        a.m_Buffer.Add(b)
        Return a
    End Operator

    Public Shared Operator +(ByVal a As SerialBuffer, ByVal b() As Byte) As SerialBuffer
        a.m_Buffer.AddRange(b)
        Return a
    End Operator

    Public Shared Operator +(ByVal a As SerialBuffer, ByVal b As String) As SerialBuffer
        For Each iCh As Char In b
            a.m_Buffer.Add(Convert.ToByte(iCh))
        Next
        Return a
    End Operator

    Public Sub Add(ByVal bytes() As Byte, ByVal count As Integer)
        Dim index As Integer
        For index = 0 To count - 1
            m_Buffer.Add(bytes(index))
        Next
    End Sub

    Public Sub Add(ByVal value As Byte)
        m_Buffer.Add(value)
    End Sub

    Public Sub Add(ByVal value As String)
        For Each iCh As Char In value
            m_Buffer.Add(Convert.ToByte(iCh))
        Next
    End Sub

    Public ReadOnly Property Length() As Integer
        Get
            Return m_Buffer.Count
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return m_Buffer.Count
        End Get
    End Property

    Public Sub Clear()
        m_Buffer.Clear()
    End Sub

    Default Public ReadOnly Property Index(ByVal idx As Integer) As Byte
        Get
            Return m_Buffer(idx)
        End Get
    End Property

    Public Shared Widening Operator CType(ByVal a As SerialBuffer) As Byte()
        Return a.m_Buffer.ToArray()
    End Operator

    Public Function IndexOf(ByVal search() As Byte) As Integer
        Return IndexOf(search, 0)
    End Function

    Public Function ToArray() As Byte()
        Return m_Buffer.ToArray()
    End Function

    Public Function IndexOf(ByVal search() As Byte, ByVal index As Integer) As Integer
        If search Is Nothing Then Return -1
        If search.Length = 0 Then Return 0
        Dim idx As Integer = m_Buffer.IndexOf(search(0), index)
        Dim found As Boolean = False
        Do While idx <> -1
            If idx + search.Length > m_Buffer.Count Then Return -1
            Dim cnt As Integer = idx
            found = True
            For Each iBy As Byte In search
                If iBy <> m_Buffer(cnt) Then
                    found = False
                    Exit For
                End If
                cnt += 1
            Next
            If found Then Exit Do
            idx = m_Buffer.IndexOf(search(0), idx + 1)
        Loop
        Return idx
    End Function

    Public Function IndexOf(ByVal search As Byte, ByVal index As Integer) As Integer
        Return m_Buffer.IndexOf(search, index)
    End Function

    Public Function IndexOf(ByVal search As Byte) As Integer
        Return m_Buffer.IndexOf(search)
    End Function

    Public Function LastIndexOf(ByVal search As Byte) As Integer
        Dim idx As Integer = m_Buffer.LastIndexOf(search)
        Return idx
    End Function


    Public Function LastIndexOf(ByVal search() As Byte) As Integer
        If search Is Nothing Then Return -1
        If search.Length = 0 Then Return 0
        Dim idx As Integer = m_Buffer.LastIndexOf(search(0))
        If idx = -1 Then Return -1
        If idx + search.Length > m_Buffer.Count Then Return -1
        Dim cnt As Integer = idx
        For Each iBy As Byte In search
            If iBy <> m_Buffer(cnt) Then Return -1
            cnt += 1
        Next
        Return idx
    End Function

    Public Shadows Function ToString(ByVal index As Integer, ByVal length As Integer) As String
        If index = -1 OrElse length = 0 Then Return ""
        Dim str As New System.Text.StringBuilder
        Do While length <> 0
            str.Append(Convert.ToString(m_Buffer(index)))
            index += 1
            length -= 1
        Loop
        Return str.ToString()
    End Function

    Public Shadows Function ToString() As String
        Dim str As New System.Text.StringBuilder
        For Each iBy As Byte In m_Buffer
            str.Append(Convert.ToChar(iBy))
        Next
        Return str.ToString()
    End Function

    Public Shared Function ASCII(ByVal value As Byte) As Char
        Return Convert.ToChar(value)
    End Function

    Public Shared Function ASCII(ByVal value As String) As Byte
        Return Convert.ToByte(value(0))
    End Function

    Public Shared Function ASCII(ByVal value As Char) As Byte
        Return Convert.ToByte(value)
    End Function

End Class
