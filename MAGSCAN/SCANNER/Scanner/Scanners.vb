Public Class Scanners

    Public Class DataReceivedEventArgs
        Inherits System.EventArgs
        Private m_Data As Byte()

        Public ReadOnly Property BinaryData() As Byte()
            Get
                Return m_Data
            End Get
        End Property
        Public ReadOnly Property StringData() As String
            Get
                Dim str As New System.Text.StringBuilder
                For Each iBy As Byte In m_Data
                    str.Append(Convert.ToChar(iBy))
                Next
                Return str.ToString()
            End Get
        End Property

        Sub New(ByVal value As Byte())
            m_Data = value
        End Sub
    End Class
End Class

