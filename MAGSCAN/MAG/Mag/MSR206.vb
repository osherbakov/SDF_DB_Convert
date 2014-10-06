Imports System.Threading
Imports SerialBuffer
Imports System.Collections.Generic
Imports Microsoft.VisualBasic


Public Class MSR206

    Public Delegate Sub DataReceivedEventHandler(ByVal sender As System.Object, ByVal e As MagReaders.DataReceivedEventArgs)
    Public Event DataReceived As DataReceivedEventHandler


    Private Shared Table64 As String = " !""#$%&/()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_"
    Private Shared Table16 As String = "0123456789:;<=>?"

    Private m_TrackStart() As Byte = New Byte() {ASCII("%"c), ASCII(";"c), ASCII("%"c)}
    Private m_TrackEnd() As Byte = New Byte() {ASCII("?"c), ASCII("?"c), ASCII("?"c)}
    Private m_TrackSeparator() As Byte = New Byte() {ASCII("^"c), ASCII("="c), ASCII("^"c)}

    Private Const ESC As Byte = &H1B
    Private Const FS As Byte = &H1C
    Private Const DigitZero As Byte = &H30

    Private Const TRK1 As Byte = &H1
    Private Const TRK2 As Byte = &H2
    Private Const TRK3 As Byte = &H3

    Private m_EncoderFoundOnPort As String
    Private m_DataReady As New ManualResetEvent(False)
    Private m_CancelFlag As Boolean = False
    Private m_SerialBuffer As New SerialBuffer()
    Private m_Timer As New Timer(New TimerCallback(AddressOf TimerCallback), Nothing, Timeout.Infinite, Timeout.Infinite)

    Public ReadOnly Property Port() As String
        Get
            Return m_EncoderFoundOnPort
        End Get
    End Property


    Public Enum Parity
        NO_PARITY
        ODD_PARITY
        EVEN_PARITY
        DONT_CARE
    End Enum

    <Flags()> _
    Public Enum LEDs
        RED = 1
        YELLOW = 2
        GREEN = 4
    End Enum

    <Flags()> _
    Public Enum Tracks
        TRACK1 = 1
        TRACK2 = 2
        TRACK3 = 4
    End Enum

    Public Enum Coercity
        LO
        HIGH
    End Enum

    Public Enum Encoding
        BITS4 = 4
        BITS6 = 6
    End Enum

    Private m_density As Integer = 75
    Private m_coercity As Coercity = Coercity.HIGH
    Private m_packing() As Integer = {8, 8, 8}
    Private m_parity() As Parity = {Parity.ODD_PARITY, Parity.ODD_PARITY, Parity.ODD_PARITY}
    Private m_encoding() As Integer = {Encoding.BITS6, Encoding.BITS4, Encoding.BITS6}

    Private Sub TimerCallback(ByVal state As Object)
        Dim track1(0), track2(0), track3(0) As Byte
        Dim Do_RaiseEvent As Boolean = False
        SyncLock m_SerialBuffer
            If DecodeRaw(track1, track2, track3) <> -1 Then
                m_SerialBuffer.Clear()
                Do_RaiseEvent = True
            End If
        End SyncLock
        If Do_RaiseEvent Then
            RaiseEvent DataReceived(Me, New MagReaders.DataReceivedEventArgs(track1, track2, track3))
        End If
    End Sub

    Public Sub DetectMSR206()
        m_EncoderFoundOnPort = Nothing
        For Each Port As String In IO.Ports.SerialPort.GetPortNames
            Try
                InitComm(Port)
                CMD_Reset()
                If m_CancelFlag Then Exit For
                If CMD_Test(300) <> -1 Then
                    m_EncoderFoundOnPort = Port
                    Exit For
                Else
                    Me.Close()
                End If
            Catch ex As Exception
            End Try
            If m_CancelFlag Then Exit For
        Next
    End Sub


    Public Function IsMSR206Detected() As Boolean
        Return m_EncoderFoundOnPort IsNot Nothing
    End Function

    Public Sub Close()
        Try
            m_Timer.Change(Timeout.Infinite, Timeout.Infinite)
            If m_SerialPort.IsOpen Then
                m_SerialPort.DiscardInBuffer()
                m_SerialPort.DiscardOutBuffer()
                m_SerialPort.ReadExisting()
                m_SerialPort.ReceivedBytesThreshold = 1
                m_SerialPort.ReadTimeout = 300
                m_SerialPort.WriteTimeout = 300
                m_SerialPort.Close()
            End If
        Finally
            m_EncoderFoundOnPort = Nothing
        End Try
    End Sub

    Public Sub InitComm()

        If String.IsNullOrEmpty(m_EncoderFoundOnPort) Then Exit Sub

        If m_SerialPort.IsOpen Then
            SyncLock m_SerialBuffer
                m_SerialPort.BaudRate = 9600
                m_SerialPort.DataBits = 8
                m_SerialPort.Parity = IO.Ports.Parity.None

                m_SerialPort.DiscardNull = False
                m_SerialPort.DtrEnable = True
                m_SerialPort.RtsEnable = True
                m_SerialPort.Handshake = IO.Ports.Handshake.None
                m_CancelFlag = False
                m_SerialBuffer.Clear()
                m_SerialPort.DiscardInBuffer()
                m_SerialPort.DiscardOutBuffer()
                m_SerialPort.ReadExisting()
                m_SerialPort.ReceivedBytesThreshold = 1
                m_SerialPort.ReadTimeout = 500
                m_SerialPort.WriteTimeout = 500
            End SyncLock
        End If
    End Sub

    Private Sub InitComm(ByVal Port As String)

        If m_SerialPort.IsOpen Then m_SerialPort.Close()

        m_SerialPort.PortName = Port
        m_SerialPort.Open()
        If m_SerialPort.IsOpen Then
            SyncLock m_SerialBuffer
                m_SerialPort.BaudRate = 9600
                m_SerialPort.DataBits = 8
                m_SerialPort.Parity = IO.Ports.Parity.None

                m_SerialPort.DiscardNull = False
                m_SerialPort.DtrEnable = True
                m_SerialPort.RtsEnable = True
                m_SerialPort.Handshake = IO.Ports.Handshake.None
                m_SerialBuffer.Clear()
                m_CancelFlag = False
                m_SerialPort.DiscardInBuffer()
                m_SerialPort.DiscardOutBuffer()
                m_SerialPort.ReadExisting()
                m_SerialPort.ReceivedBytesThreshold = 1
                m_SerialPort.ReadTimeout = 500
                m_SerialPort.WriteTimeout = 500
            End SyncLock
        End If
    End Sub


    Private Shared Function ReverseByte(ByVal value As Byte) As Byte
        Dim result As Integer = 0

        For i As Integer = 0 To 7
            result <<= 1
            If (value And &H1) = &H1 Then result = result Or &H1
            value >>= 1
        Next
        Return result
    End Function

    Public Shared Function DecodeTrack(ByVal data() As Byte, ByVal Encoding As Encoding, _
                ByVal BitPacking As Integer, Optional ByVal SymbolParity As Parity = Parity.ODD_PARITY) As String
        Dim ret As New System.Text.StringBuilder
        Dim bitcount As Integer = 0
        Dim nSymbolBits As Integer
        Dim nDataBits As Integer
        Dim Num As Integer
        Dim ParityBit As Integer
        Dim LRC As Integer
        Dim TableMask As Integer
        Dim ParityMask As Integer
        Dim InitialParityBit As Integer

        Dim BitMask As Integer = (1 << BitPacking) - 1

        Select Case Encoding
            Case MSR206.Encoding.BITS4
                nSymbolBits = 4
            Case MSR206.Encoding.BITS6
                nSymbolBits = 6
        End Select
        ParityMask = 1 << nSymbolBits
        TableMask = ParityMask - 1

        Select Case SymbolParity
            Case Parity.NO_PARITY
                InitialParityBit = 0
                nDataBits = nSymbolBits
                ParityMask = 0
            Case Parity.EVEN_PARITY
                InitialParityBit = 0
                nDataBits = nSymbolBits + 1
            Case Parity.ODD_PARITY
                InitialParityBit = 1
                nDataBits = nSymbolBits + 1
            Case Parity.DONT_CARE
                InitialParityBit = 0
                nDataBits = nSymbolBits + 1
                ParityMask = 0
        End Select


        LRC = 0
        Num = 0
        bitcount = 0
        For Each iBy As Byte In data
            iBy = ReverseByte(iBy)
            Num = Num Or ((iBy And BitMask) << bitcount)
            bitcount += BitPacking

            Do While bitcount >= nDataBits
                ' Calculate Parity bit
                ParityBit = InitialParityBit
                For i As Integer = 0 To nSymbolBits - 1
                    ParityBit = ParityBit Xor (Num >> i)
                Next i
                ParityBit = (ParityBit And &H1) << nSymbolBits
                ' Check if parity bit is OK
                If (ParityBit And ParityMask) = (Num And ParityMask) Then
                    Select Case Encoding
                        Case MSR206.Encoding.BITS4
                            ret.Append(Table16(Num And TableMask))
                        Case MSR206.Encoding.BITS6
                            ret.Append(Table64(Num And TableMask))
                    End Select
                End If
                LRC = LRC Xor Num
                Num >>= nDataBits
                bitcount -= nDataBits
            Loop
        Next
        LRC = LRC And TableMask

        If LRC = 0 OrElse SymbolParity = Parity.DONT_CARE Then
            Return ret.ToString
        Else
            Return ""
        End If

    End Function

    Public Shared Function EncodeTrack64(ByVal AsciiData As String, ByVal BitPacking As Integer, Optional ByVal SymbolParity As Parity = Parity.ODD_PARITY) As Byte()
        Dim bitcount As Integer = 0
        Dim res As New Collections.Generic.List(Of Byte)
        Dim dbyte As Integer = 0
        Dim BitMask As Integer = (1 << BitPacking) - 1
        Dim nBits As Integer
        Dim Num As Integer
        Dim ParityBit As Integer
        Dim LRC As Integer

        Select Case SymbolParity
            Case Parity.NO_PARITY
                nBits = 6
            Case Parity.EVEN_PARITY, Parity.ODD_PARITY, Parity.DONT_CARE
                nBits = 7
        End Select

        LRC = 0
        For Each iCh As Char In AsciiData.ToUpper()
            Num = Table64.IndexOf(iCh)
            If Num <> -1 Then
                Select Case SymbolParity
                    Case Parity.NO_PARITY, Parity.DONT_CARE
                        ParityBit = 0
                    Case Parity.EVEN_PARITY
                        ParityBit = 0
                        For i As Integer = 0 To 5
                            ParityBit = ParityBit Xor (Num >> i)
                        Next i
                    Case Parity.ODD_PARITY
                        ParityBit = 1
                        For i As Integer = 0 To 5
                            ParityBit = ParityBit Xor (Num >> i)
                        Next i
                End Select
                ParityBit = (ParityBit And &H1) << 6

                Num = Num Or ParityBit
                LRC = LRC Xor Num

                Num <<= bitcount
                dbyte = dbyte Or Num
                bitcount += nBits
                If bitcount >= BitPacking Then
                    res.Add(dbyte And BitMask)
                    dbyte >>= BitPacking
                    bitcount -= BitPacking
                End If
            End If
        Next

        ParityBit = 0
        If SymbolParity <> Parity.NO_PARITY Then
            ParityBit = 1
            For i As Integer = 0 To 5
                ParityBit = ParityBit Xor (LRC >> i)
            Next i
            ParityBit = (ParityBit And &H1) << 6
        End If

        LRC = ((LRC Or (&H1 << 6)) Xor (&H1 << 6)) Or ParityBit

        LRC <<= bitcount
        dbyte = dbyte Or LRC
        bitcount += nBits
        If bitcount >= BitPacking Then
            res.Add(dbyte And BitMask)
            dbyte >>= BitPacking
            bitcount -= BitPacking
        End If
        If bitcount <> 0 Then res.Add(dbyte And BitMask)

        Dim FinalResult(res.Count - 1) As Byte
        res.CopyTo(FinalResult)
        Return FinalResult
    End Function

    Public Shared Function EncodeTrack16(ByVal AsciiData As String, ByVal BitPacking As Integer, Optional ByVal SymbolParity As Parity = Parity.ODD_PARITY) As Byte()
        Dim bitcount As Integer = 0
        Dim res As New Collections.Generic.List(Of Byte)
        Dim dbyte As Integer = 0
        Dim BitMask As Integer = (1 << BitPacking) - 1
        Dim nBits As Integer
        Dim Num As Integer
        Dim ParityBit As Integer
        Dim LRC As Integer

        Select Case SymbolParity
            Case Parity.NO_PARITY
                nBits = 4
            Case Parity.EVEN_PARITY, Parity.ODD_PARITY, Parity.DONT_CARE
                nBits = 5
        End Select

        LRC = 0
        For Each iCh As Char In AsciiData.ToUpper()
            Num = Table16.IndexOf(iCh)
            If Num <> -1 Then
                Select Case SymbolParity
                    Case Parity.NO_PARITY, Parity.DONT_CARE
                        ParityBit = 0
                    Case Parity.EVEN_PARITY
                        ParityBit = 0
                        For i As Integer = 0 To 3
                            ParityBit = ParityBit Xor (Num >> i)
                        Next i
                    Case Parity.ODD_PARITY
                        ParityBit = 1
                        For i As Integer = 0 To 3
                            ParityBit = ParityBit Xor (Num >> i)
                        Next i
                End Select
                ParityBit = (ParityBit And &H1) << 4

                Num = Num Or ParityBit
                LRC = LRC Xor Num

                Num <<= bitcount
                dbyte = dbyte Or Num
                bitcount += nBits
                If bitcount >= BitPacking Then
                    res.Add(dbyte And BitMask)
                    dbyte >>= BitPacking
                    bitcount -= BitPacking
                End If
            End If
        Next

        ParityBit = 0
        If SymbolParity <> Parity.NO_PARITY Then
            ParityBit = 1
            For i As Integer = 0 To 3
                ParityBit = ParityBit Xor (LRC >> i)
            Next i
            ParityBit = (ParityBit And &H1) << 4
        End If

        LRC = ((LRC Or (&H1 << 4)) Xor (&H1 << 4)) Or ParityBit

        LRC <<= bitcount
        dbyte = dbyte Or LRC
        bitcount += nBits
        If bitcount >= BitPacking Then
            res.Add(dbyte And BitMask)
            dbyte >>= BitPacking
            bitcount -= BitPacking
        End If
        If bitcount <> 0 Then res.Add(dbyte And BitMask)

        Dim FinalResult(res.Count - 1) As Byte
        res.CopyTo(FinalResult)
        Return FinalResult
    End Function

    Public Function CMD_Send(ByVal ByteData() As Byte) As Integer
        Thread.Sleep(100)
        m_SerialPort.DiscardInBuffer()
        m_SerialPort.ReadExisting()
        SyncLock m_SerialBuffer
            m_DataReady.Reset()
            m_CancelFlag = False
            m_SerialBuffer.Clear()
        End SyncLock
        m_SerialPort.Write(ByteData, 0, ByteData.Length)
        Return 0
    End Function

    Public Function CMD_Send(ByVal ByteData As SerialBuffer) As Integer
        Thread.Sleep(100)
        m_SerialPort.DiscardInBuffer()
        m_SerialPort.ReadExisting()
        SyncLock m_SerialBuffer
            m_DataReady.Reset()
            m_CancelFlag = False
            m_SerialBuffer.Clear()
        End SyncLock
        m_SerialPort.Write(CType(ByteData, Byte()), 0, ByteData.Length)
        Return 0
    End Function


    Private Function CMD_Wait_Response() As Integer
        Dim ret As Integer = -1
        Do
            m_DataReady.WaitOne(Timeout.Infinite, False)
            SyncLock m_SerialBuffer
                If m_CancelFlag Then Exit Do
                Dim idx As Integer = m_SerialBuffer.LastIndexOf(ESC)
                If idx <> -1 AndAlso m_SerialBuffer.Length = (idx + 2) Then
                    ret = (m_SerialBuffer(idx + 1) - DigitZero)
                    m_SerialBuffer.Clear()
                    Exit Do
                End If
                m_DataReady.Reset()
            End SyncLock
        Loop
        Return ret
    End Function

    Private Function CMD_Wait_Response(ByVal responceExpected As Byte(), ByVal Timeout As Integer) As Integer
        Dim Signalled As Boolean
        Dim ret As Integer = -1
        Do
            Signalled = m_DataReady.WaitOne(Timeout, False)
            SyncLock m_SerialBuffer
                If Not Signalled OrElse m_CancelFlag Then Exit Do
                Dim idx As Integer = m_SerialBuffer.LastIndexOf(responceExpected)
                If idx <> -1 Then
                    ret = 0
                    m_SerialBuffer.Clear()
                End If
                m_DataReady.Reset()
            End SyncLock
        Loop
        Return ret
    End Function


    Public Function CMD_Reset() As Integer
        Dim ret As Integer = -1
        Dim Cmd As New SerialBuffer
        Try
            Cmd += ESC
            Cmd += ASCII("a")
            CMD_Send(Cmd)
            ret = 0
            m_DataReady.WaitOne(500, False)
        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_Read(ByRef Track1 As String, ByRef Track2 As String, ByRef Track3 As String) As Integer
        Dim idx, idxe As Integer
        Dim ret As Integer = -1

        If m_EncoderFoundOnPort Is Nothing Then Return -1

        Try
            CMD_Send(New Byte() {ESC, ASCII("r")})

            ' Loop until you get all bytes of the response
            Do
                m_DataReady.WaitOne()
                SyncLock m_SerialBuffer
                    If m_CancelFlag Then Return ret
                    idx = m_SerialBuffer.LastIndexOf(New Byte() {ASCII("?"), FS, ESC})
                    If idx <> -1 AndAlso m_SerialBuffer.Length = idx + 4 Then
                        ret = m_SerialBuffer(idx + 3) - DigitZero
                        Exit Do
                    End If
                    m_DataReady.Reset()
                End SyncLock
            Loop

            ' Analyze all track data
            If Track1 IsNot Nothing Then
                Track1 = String.Empty
                idx = m_SerialBuffer.IndexOf(New Byte() {ESC, ASCII("s"), ESC, TRK1, m_TrackStart(0)})
                If idx <> -1 Then
                    idxe = m_SerialBuffer.IndexOf(m_TrackEnd(0), idx)
                    If idxe <> -1 Then
                        Track1 = m_SerialBuffer.ToString(idx + 5, idxe - idx - 5)
                    End If
                End If
            End If


            If Track2 IsNot Nothing Then
                Track2 = String.Empty
                idx = m_SerialBuffer.IndexOf(New Byte() {ESC, TRK2, m_TrackStart(1)})
                If idx <> -1 Then
                    idxe = m_SerialBuffer.IndexOf(m_TrackEnd(1), idx)
                    If idxe <> -1 Then
                        Track2 = m_SerialBuffer.ToString(idx + 3, idxe - idx - 3)
                    End If
                End If
            End If

            If Track3 IsNot Nothing Then
                Track3 = String.Empty
                idx = m_SerialBuffer.IndexOf(New Byte() {ESC, TRK3, m_TrackStart(2)})
                If idx <> -1 Then
                    idxe = m_SerialBuffer.IndexOf(m_TrackEnd(2), idx)
                    If idxe <> -1 Then
                        Track3 = m_SerialBuffer.ToString(idx + 3, idxe - idx - 3)
                    End If
                End If
            End If

        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try

        Return ret
    End Function

    Public Function CMD_Write(ByVal Track1 As String, ByVal Track2 As String, ByVal Track3 As String) As Integer
        Dim Cmd As New SerialBuffer
        Dim ret As Integer = -1

        If m_EncoderFoundOnPort Is Nothing Then Return -1

        Try
            Cmd += New Byte() {ESC, ASCII("w")}

            ' Begin DataBlock
            Cmd += New Byte() {ESC, ASCII("s")}

            Cmd += New Byte() {ESC, TRK1}
            If Not String.IsNullOrEmpty(Track1) Then
                Cmd += Track1
            End If

            Cmd += New Byte() {ESC, TRK2}
            If Not String.IsNullOrEmpty(Track2) Then
                Cmd += Track2
            End If

            Cmd += New Byte() {ESC, TRK3}
            If Not String.IsNullOrEmpty(Track3) Then
                Cmd += Track3
            End If

            Cmd += New Byte() {ASCII("?"), FS}  ' Terminate DataBlock

            '       Dim cc() As Byte = New Byte() {&H1B, &H77, &H1B, &H73, &H1B, &H1, &H30, &H31, &H1B, _
            '      &H2, &H32, &H33, &H1B, &H3, &H34, &H35, &H3F, &H1C}

            CMD_Send(Cmd)    ' Send assembled command
            ret = CMD_Wait_Response()

        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_Test(ByVal Timeout As Integer) As Integer
        Dim ret As Integer = -1
        Try
            CMD_Send(New Byte() {ESC, ASCII("e")})    ' Send assembled command
            ret = CMD_Wait_Response(New Byte() {ESC, ASCII("y")}, Timeout)
        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_LED(ByVal leds As LEDs) As Integer
        Dim ret As Integer = -1
        If m_EncoderFoundOnPort Is Nothing Then Return -1

        Try
            CMD_Send(New Byte() {ESC, &H81})    ' turn off all LEDs first

            If leds And MSR206.LEDs.GREEN Then
                CMD_Send(New Byte() {ESC, &H83})    ' turn on appropriate LED
            End If
            If leds And MSR206.LEDs.YELLOW Then
                CMD_Send(New Byte() {ESC, &H84})    ' turn on appropriate LED
            End If
            If leds And MSR206.LEDs.RED Then
                CMD_Send(New Byte() {ESC, &H85})    ' turn on appropriate LED
            End If

            If leds = (MSR206.LEDs.YELLOW Or MSR206.LEDs.GREEN Or MSR206.LEDs.RED) Then
                CMD_Send(New Byte() {ESC, &H82})    ' turn on all LEDs
            End If
            ret = m_DataReady.WaitOne(500, False)

        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function


    Public Function CMD_SetBPI(ByVal density As Integer) As Integer
        Dim ret As Integer = -1
        Dim Cmd As New SerialBuffer
        If m_EncoderFoundOnPort Is Nothing Then Return -1
        Try
            If density = 210 Or density = 75 Then
                m_density = density
                Cmd += New Byte() {ESC, ASCII("b")}
                Cmd += m_density
                CMD_Send(Cmd)    ' Send density command
                ret = CMD_Wait_Response()
            End If
        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_StartRead() As Integer
        Dim ret As Integer = -1
        If m_EncoderFoundOnPort Is Nothing Then Return -1
        Try
            CMD_Send(New Byte() {ESC, ASCII("m")})
            ret = 0
        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Private Function DecodeRaw(ByRef Track1() As Byte, ByRef Track2() As Byte, ByRef Track3() As Byte) As Integer
        Dim idx, len As Integer
        Dim ret As Integer = -1

        Dim data As New System.Collections.Generic.List(Of Byte)

        idx = m_SerialBuffer.LastIndexOf(New Byte() {ASCII("?"), FS, ESC, DigitZero})
        If idx = -1 OrElse m_SerialBuffer.Length <> (idx + 4) Then
            Return ret
        End If

        ret = 0     ' Success - end of data is found

        data.Clear()
        If Track1 IsNot Nothing Then
            idx = m_SerialBuffer.IndexOf(New Byte() {ESC, TRK1})
            If idx <> -1 Then
                len = m_SerialBuffer(idx + 2)
                For i As Integer = 0 To len - 1
                    data.Add(m_SerialBuffer(idx + 3 + i))
                Next
                Track1 = data.ToArray()
            End If
        End If

        data.Clear()
        If Track2 IsNot Nothing Then
            idx = m_SerialBuffer.IndexOf(New Byte() {ESC, TRK2}, idx + len + 3)
            If idx <> -1 Then
                len = m_SerialBuffer(idx + 2)
                For i As Integer = 0 To len - 1
                    data.Add(m_SerialBuffer(idx + 3 + i))
                Next
                Track2 = data.ToArray()
            End If
        End If

        data.Clear()
        If Track3 IsNot Nothing Then
            idx = m_SerialBuffer.IndexOf(New Byte() {ESC, TRK3}, idx + len + 3)
            If idx <> -1 Then
                len = m_SerialBuffer(idx + 2)
                For i As Integer = 0 To len - 1
                    data.Add(m_SerialBuffer(idx + 3 + i))
                Next
                Track3 = data.ToArray()
            End If
        End If
        Return ret
    End Function


    Public Function CMD_ReadRaw(ByRef Track1() As Byte, ByRef Track2() As Byte, ByRef Track3() As Byte) As Integer
        Dim Cmd As New SerialBuffer
        Dim idx, len As Integer
        Dim ret As Integer = -1
        Dim data As New System.Collections.Generic.List(Of Byte)

        If m_EncoderFoundOnPort Is Nothing Then Return -1

        Try
            CMD_Send(New Byte() {ESC, ASCII("m")})

            Do
                m_DataReady.WaitOne()
                SyncLock m_SerialBuffer
                    If m_CancelFlag Then Return ret
                    idx = m_SerialBuffer.LastIndexOf(New Byte() {ASCII("?"), FS, ESC})
                    If idx <> -1 AndAlso m_SerialBuffer.Length = idx + 4 Then
                        ret = m_SerialBuffer(idx + 3) - DigitZero
                        Exit Do
                    End If
                    m_DataReady.Reset()
                End SyncLock
            Loop

            data.Clear()
            If Track1 IsNot Nothing Then
                idx = m_SerialBuffer.IndexOf(New Byte() {ESC, TRK1})
                If idx <> -1 Then
                    len = m_SerialBuffer(idx + 2)
                    For i As Integer = 0 To len - 1
                        data.Add(m_SerialBuffer(idx + 3 + i))
                    Next
                    Track1 = data.ToArray()
                End If
            End If

            data.Clear()
            If Track2 IsNot Nothing Then
                idx = m_SerialBuffer.IndexOf(New Byte() {ESC, TRK2}, idx + len + 3)
                If idx <> -1 Then
                    len = m_SerialBuffer(idx + 2)
                    For i As Integer = 0 To len - 1
                        data.Add(m_SerialBuffer(idx + 3 + i))
                    Next
                    Track2 = data.ToArray()
                End If
            End If

            data.Clear()
            If Track3 IsNot Nothing Then
                idx = m_SerialBuffer.IndexOf(New Byte() {ESC, TRK3}, idx + len + 3)
                If idx <> -1 Then
                    len = m_SerialBuffer(idx + 2)
                    For i As Integer = 0 To len - 1
                        data.Add(m_SerialBuffer(idx + 3 + i))
                    Next
                    Track3 = data.ToArray()
                End If
            End If

        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_WriteRaw(ByVal Track1 As String, ByVal Track2 As String, ByVal Track3 As String) As Integer
        Dim data() As Byte
        Dim ret As Integer = -1
        Dim Cmd As New SerialBuffer

        If m_EncoderFoundOnPort Is Nothing Then Return -1

        Try

            Cmd += New Byte() {ESC, ASCII("n")}
            ' Begin DataBlock
            Cmd += New Byte() {ESC, ASCII("s")}

            ' Track 1
            Cmd += New Byte() {ESC, TRK1}
            If Not String.IsNullOrEmpty(Track1) Then
                If m_encoding(0) = Encoding.BITS6 Then
                    data = MSR206.EncodeTrack64(ASCII(m_TrackStart(0)) + Track1 + ASCII(m_TrackEnd(0)), m_packing(0), m_parity(0))
                Else
                    data = MSR206.EncodeTrack16(ASCII(m_TrackStart(0)) + Track1 + ASCII(m_TrackEnd(0)), m_packing(0), m_parity(0))
                End If

                ' Specify the size of the data block
                Cmd += data.Length
                Cmd += data
            Else
                Cmd += 0
            End If

            ' Track 2
            Cmd += New Byte() {ESC, TRK2}
            If Not String.IsNullOrEmpty(Track2) Then
                If m_encoding(1) = Encoding.BITS6 Then
                    data = MSR206.EncodeTrack64(ASCII(m_TrackStart(1)) + Track2 + ASCII(m_TrackEnd(1)), m_packing(1), m_parity(1))
                Else
                    data = MSR206.EncodeTrack16(ASCII(m_TrackStart(1)) + Track2 + ASCII(m_TrackEnd(1)), m_packing(1), m_parity(1))
                End If

                ' Specify the size of the data block
                Cmd += data.Length
                Cmd += data
            Else
                Cmd += 0
            End If

            ' Track 3
            Cmd += New Byte() {ESC, TRK3}
            If Not String.IsNullOrEmpty(Track3) Then
                If m_encoding(2) = Encoding.BITS6 Then
                    data = MSR206.EncodeTrack64(ASCII(m_TrackStart(2)) + Track3 + ASCII(m_TrackEnd(2)), m_packing(2), m_parity(2))
                Else
                    data = MSR206.EncodeTrack16(ASCII(m_TrackStart(2)) + Track3 + ASCII(m_TrackEnd(2)), m_packing(2), m_parity(2))
                End If

                ' Specify the size of the data block
                Cmd += data.Length
                Cmd += data
            Else
                Cmd += 0
            End If

            Cmd += New Byte() {ASCII("?"), FS}  ' Terminate DataBlock
            CMD_Send(Cmd)    ' Send assembled command
            ret = CMD_Wait_Response()

        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function


    Public Function CMD_Erase(ByVal tracks As Tracks) As Integer
        Dim cmd As New SerialBuffer
        Dim ret As Integer = -1

        If m_EncoderFoundOnPort Is Nothing Then Return -1

        Try
            cmd += New Byte() {ESC, ASCII("c")}
            cmd += Convert.ToChar(tracks)
            CMD_Send(cmd)    ' Send erase command
            ret = CMD_Wait_Response()
        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function


    Public Function CMD_SetBPC(ByVal track1 As Integer, ByVal track2 As Integer, ByVal track3 As Integer) As Integer
        Dim ret As Integer = -1
        Dim cmd As New SerialBuffer
        Try
            m_packing(0) = track1
            m_packing(1) = track2
            m_packing(2) = track3
            cmd += New Byte() {ESC, ASCII("o")}
            cmd += track1
            cmd += track2
            cmd += track3
            CMD_Send(cmd)    ' Send Bits per track command
            ret = CMD_Wait_Response(New Byte() {ESC, DigitZero, track1, track2, track3}, 2000)
        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_SetParity(ByVal track1 As Parity, ByVal track2 As Parity, ByVal track3 As Parity) As Integer
        m_parity(0) = track1
        m_parity(1) = track2
        m_parity(2) = track3
        Return 0
    End Function
    Public Function CMD_SetParity(ByVal track As Tracks, ByVal parity As Parity) As Integer

        If track And Tracks.TRACK1 Then
            m_parity(0) = parity
        End If
        If track And Tracks.TRACK2 Then
            m_parity(1) = parity
        End If
        If track And Tracks.TRACK3 Then
            m_parity(2) = parity
        End If

        Return 0
    End Function


    Public Function CMD_SetSpecialChars(ByVal track As Tracks, ByVal startChar As String, ByVal endChar As String, ByVal sepChar As String) As Integer
        If startChar Is Nothing OrElse endChar Is Nothing OrElse sepChar Is Nothing Then Return -1

        If track And Tracks.TRACK1 Then
            m_TrackStart(0) = ASCII(startChar)
            m_TrackEnd(0) = ASCII(endChar)
            m_TrackSeparator(0) = ASCII(sepChar)
        End If
        If track And Tracks.TRACK2 Then
            m_TrackStart(1) = ASCII(startChar)
            m_TrackEnd(1) = ASCII(endChar)
            m_TrackSeparator(1) = ASCII(sepChar)
        End If
        If track And Tracks.TRACK3 Then
            m_TrackStart(2) = ASCII(startChar)
            m_TrackEnd(2) = ASCII(endChar)
            m_TrackSeparator(2) = ASCII(sepChar)
        End If

        Return 0
    End Function

    Public Function CMD_SetCo(ByVal value As Coercity) As Integer
        Dim ret As Integer = -1

        If m_EncoderFoundOnPort Is Nothing Then Return -1

        Try
            m_coercity = value
            Select Case value
                Case Coercity.HIGH
                    CMD_Send(New Byte() {ESC, ASCII("x")})
                Case Coercity.LO
                    CMD_Send(New Byte() {ESC, ASCII("y")})
            End Select
            ret = CMD_Wait_Response()
        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_SetEncoding(ByVal track As Tracks, ByVal encoding As Encoding) As Integer

        If track And Tracks.TRACK1 Then
            m_encoding(0) = encoding
        End If
        If track And Tracks.TRACK2 Then
            m_encoding(1) = encoding
        End If
        If track And Tracks.TRACK3 Then
            m_encoding(2) = encoding
        End If

        Return 0
    End Function
    Public Function CMD_SetEncoding(ByVal track1 As Encoding, ByVal track2 As Encoding, ByVal track3 As Encoding) As Integer
        m_encoding(0) = track1
        m_encoding(1) = track2
        m_encoding(2) = track3
        Return 0
    End Function


    Private Sub SerialPort_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles m_SerialPort.DataReceived
        Try
            Dim RawBuffer(4096) As Byte
            Dim nBytesRead As Integer = m_SerialPort.Read(RawBuffer, 0, RawBuffer.Length)
            SyncLock m_SerialBuffer
                m_SerialBuffer.Add(RawBuffer, nBytesRead)
                m_DataReady.Set()
                m_Timer.Change(200, Timeout.Infinite)
            End SyncLock
        Catch ex As Exception
            m_EncoderFoundOnPort = Nothing
        End Try
    End Sub

    Public Sub Cancel()
        m_Timer.Change(Timeout.Infinite, Timeout.Infinite)
        SyncLock m_SerialBuffer
            m_CancelFlag = True
            m_DataReady.Set()
        End SyncLock
        Thread.Sleep(300)
    End Sub
End Class

