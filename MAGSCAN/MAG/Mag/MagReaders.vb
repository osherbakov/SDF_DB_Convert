Public Class MagReaders
    Public Class DataReceivedEventArgs
        Inherits System.EventArgs
        Private m_Track1(0) As Byte
        Private m_Track2(0) As Byte
        Private m_Track3(0) As Byte

        Public ReadOnly Property Track1() As Byte()
            Get
                Return m_Track1
            End Get
        End Property
        Public ReadOnly Property Track2() As Byte()
            Get
                Return m_Track2
            End Get
        End Property
        Public ReadOnly Property Track3() As Byte()
            Get
                Return m_Track3
            End Get
        End Property
        Public ReadOnly Property StringData() As String
            Get
                Return MSR206.DecodeTrack(m_Track1, MSR206.Encoding.BITS6, 8) + MSR206.DecodeTrack(m_Track2, MSR206.Encoding.BITS4, 8) + MSR206.DecodeTrack(m_Track3, MSR206.Encoding.BITS6, 8)
            End Get
        End Property

        Sub New(ByVal track1 As Byte(), ByVal track2 As Byte(), ByVal track3 As Byte())
            m_Track1 = track1
            m_Track2 = track2
            m_Track3 = track3
        End Sub
    End Class
End Class

