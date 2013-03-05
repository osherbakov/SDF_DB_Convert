Imports System.Threading
Imports System.IO.Ports
Imports SerialBuffer
Imports System.Collections.Generic


Public Class HHPScanner

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


    Public Delegate Sub DataReceivedEventHandler(ByVal sender As System.Object, ByVal e As HHPScanner.DataReceivedEventArgs)
    Public Event DataReceived As DataReceivedEventHandler

    Private Const ESC As Byte = &H1B
    Private Const FS As Byte = &H1C
    Private Const DigitZero As Byte = &H30

    Private Const SYN As Byte = &H16
    Private Const CR As Byte = &HD
    Private Const M As Byte = &H4D

    Private Const ACK As Byte = &H6
    Private Const ENQ As Byte = &H5
    Private Const NAK As Byte = &H15

    Private Const DEFAULTVALUE As Byte = &H5E   ' ^
    Private Const CURRENTVALUE As Byte = &H3F   ' ?
    Private Const RANGEOFVALUES As Byte = &H2A  ' *

    Private Const NVRAM As Byte = &H2E      ' .
    Private Const RAM As Byte = &H21        ' !


    '^ What is the default value for the setting(s).
    '? What is the device’s current value for the setting(s).
    '* What is the range of possible values for the setting(s). (The device’s
    'response uses a dash (-) to indicate a continuous range of
    'values. A pipe (|) separates items in a list of non-continuous values.)
    ' Activate: SYN T CR
    ' Deactivate: SYN U CR

    ' Command - enable all symbols - ALLENA0


    Private PREFIX As Byte() = {SYN, M, CR}

    Private Const TRIG As Byte = &H54
    Private Const UNTRIG As Byte = &H55

    Private ACTIVATETRIGGER As Byte() = {SYN, TRIG, CR}
    Private DEACTIVATETRIGGER As Byte() = {SYN, UNTRIG, CR}

    Private ENABLEALL As String = "ALLENA" + "1"
    Private SETPDFMIN As String = "PDFMIN" + "1"
    Private SETPDFMAX As String = "PDFMAX" + "2750"
    Private ADDCRSUFFIX As String = "VSUFCR"
    Private TRIGGERMODE As String = "TRGMOD" + "0"


#Region "Private members"
    Private m_ScannerFoundOnPort As String
    Private m_DataReady As New ManualResetEvent(False)
    Private m_CancelFlag As Boolean = False
    Private m_SerialBuffer As New SerialBuffer()
    Private m_Timer As New Timer(New TimerCallback(AddressOf TimerCallback))
#End Region

    Private Sub TimerCallback(ByVal state As Object)
        Dim ReceivedData As Byte()
        ' Check if we got the full datablock - should end with {CR]
        Dim term As Integer = m_SerialBuffer.LastIndexOf(CR)
        If term <> -1 AndAlso term = (m_SerialBuffer.Count - 1) Then
            SyncLock m_SerialBuffer
                ReceivedData = m_SerialBuffer.ToArray()
                m_SerialBuffer.Clear()
            End SyncLock
            RaiseEvent DataReceived(Me, New DataReceivedEventArgs(ReceivedData))
        End If
    End Sub

    Public Function DetectScanner() As Boolean
        Dim bFound As Boolean = False
        m_ScannerFoundOnPort = Nothing
        For Each iPort As String In IO.Ports.SerialPort.GetPortNames
            Try
                InitComm(iPort)
                If CMD_Test(200) <> -1 Then
                    m_ScannerFoundOnPort = iPort
                    bFound = True
                End If
            Catch ex As Exception
                m_ScannerFoundOnPort = Nothing
            End Try
            If bFound Then Exit For
        Next
        Return bFound
    End Function

    Public Function IsScannerDetected() As Boolean
        Return m_ScannerFoundOnPort IsNot Nothing
    End Function

    Public Sub InitComm()
        If String.IsNullOrEmpty(m_ScannerFoundOnPort) Then Exit Sub
        If m_SerialPort.IsOpen Then
            m_SerialPort.DataBits = 8
            m_SerialPort.Parity = IO.Ports.Parity.None
            m_SerialPort.DiscardNull = False
            m_SerialPort.DtrEnable = True
            m_SerialPort.RtsEnable = True
            m_SerialPort.Handshake = Handshake.None
            m_SerialPort.BaudRate = 921600
            m_CancelFlag = False
            m_SerialBuffer.Clear()
            m_SerialPort.DiscardInBuffer()
            m_SerialPort.DiscardOutBuffer()
            m_SerialPort.ReceivedBytesThreshold = 1
            m_SerialPort.ReadTimeout = SerialPort.InfiniteTimeout
            m_SerialPort.WriteTimeout = SerialPort.InfiniteTimeout
            m_SerialPort.NewLine = Microsoft.VisualBasic.vbCr
            m_SerialPort.ReadExisting()
        End If
    End Sub

    Private Sub InitComm(ByVal Port As String)

        If m_SerialPort.IsOpen Then
            m_SerialPort.Close()
        End If

        m_SerialPort.PortName = Port
        m_SerialPort.DataBits = 8
        m_SerialPort.Parity = IO.Ports.Parity.None
        m_SerialPort.DiscardNull = False
        m_SerialPort.DtrEnable = True
        m_SerialPort.RtsEnable = True
        m_SerialPort.Handshake = Handshake.None
        m_SerialPort.BaudRate = 9600
        m_SerialPort.NewLine = Microsoft.VisualBasic.vbCr
        m_SerialPort.Open()
        If m_SerialPort.IsOpen Then
            m_SerialBuffer.Clear()
            m_CancelFlag = False
            m_SerialPort.DiscardInBuffer()
            m_SerialPort.DiscardOutBuffer()
            m_SerialPort.ReceivedBytesThreshold = 1
            m_SerialPort.ReadTimeout = 300
            m_SerialPort.WriteTimeout = 300
            m_SerialPort.ReadExisting()
        End If
    End Sub

    Public Function CMD_Send(ByVal ByteData() As Byte) As Integer
        m_SerialPort.DiscardInBuffer()
        m_SerialBuffer.Clear()
        m_SerialPort.Write(ByteData, 0, ByteData.Length)
    End Function


    Public Function CMD_Send(ByVal ByteData As SerialBuffer) As Integer
        m_SerialPort.DiscardInBuffer()
        m_SerialBuffer.Clear()
        m_SerialPort.Write(CType(ByteData, Byte()), 0, ByteData.Length)
    End Function


    Private Function CMD_Wait_Response() As Integer
        Dim rdy As Boolean
        Dim idx As Integer
        Dim ret As Integer = -1

        rdy = False
        Do
            m_DataReady.Reset()
            m_DataReady.WaitOne()
            If m_CancelFlag Then Exit Do

            idx = m_SerialBuffer.LastIndexOf(ACK)
            If idx <> -1 Then
                rdy = True
                ret = m_SerialBuffer(idx)
                m_SerialBuffer.Clear()
            End If
        Loop Until rdy
        Return ret
    End Function

    Private Function CMD_Wait_AnyResponse() As Integer
        Dim rdy As Boolean
        Dim idx As Integer
        Dim ret As Integer = -1

        rdy = False
        Do
            m_DataReady.Reset()
            m_DataReady.WaitOne()
            If m_CancelFlag Then Exit Do
            idx = m_SerialBuffer.LastIndexOf(ACK)
            If idx = -1 Then idx = m_SerialBuffer.LastIndexOf(NAK)
            If idx = -1 Then idx = m_SerialBuffer.LastIndexOf(ENQ)
            If idx <> -1 Then
                rdy = True
                ret = m_SerialBuffer(idx)
                m_SerialBuffer.Clear()
            End If
        Loop Until rdy
        Return ret
    End Function

    Private Function CMD_Wait_AnyResponse(ByVal Timeout As Integer) As Integer
        Dim rdy As Boolean
        Dim idx As Integer
        Dim ret As Integer = -1
        Dim Signalled As Boolean

        rdy = False
        Do
            m_DataReady.Reset()
            Signalled = m_DataReady.WaitOne(Timeout, False)
            If m_CancelFlag OrElse Not Signalled Then
                rdy = True
            Else
                idx = m_SerialBuffer.LastIndexOf(ACK)
                If idx = -1 Then idx = m_SerialBuffer.LastIndexOf(NAK)
                If idx = -1 Then idx = m_SerialBuffer.LastIndexOf(ENQ)
                If idx <> -1 Then
                    rdy = True
                    ret = m_SerialBuffer(idx)
                    m_SerialBuffer.Clear()
                End If
            End If
        Loop Until rdy
        Return ret
    End Function

    Public Function CMD_Reset() As Integer
        Dim ret As Integer = -1
        Dim Cmd As New SerialBuffer
        Try
            Cmd += ACTIVATETRIGGER
            CMD_Send(Cmd)
            Thread.Sleep(300)
            Cmd.Clear()
            Cmd += DEACTIVATETRIGGER
            CMD_Send(Cmd)
            ret = 0
        Catch ex As Exception
            m_ScannerFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_Test(ByVal Timeout As Integer) As Integer
        Dim ret As Integer = -1
        Dim Cmd As New SerialBuffer
        Try
            Cmd += PREFIX
            Cmd += ENABLEALL
            Cmd += NVRAM
            CMD_Send(Cmd)    ' Send assembled command
            ret = CMD_Wait_AnyResponse(Timeout)
        Catch ex As Exception
            m_ScannerFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Public Function CMD_Setup() As Integer
        Dim ret As Integer = -1
        Dim Cmd As New SerialBuffer
        Try
            Cmd += PREFIX
            Cmd += ENABLEALL
            Cmd += ";"
            Cmd += SETPDFMIN
            Cmd += ";"
            Cmd += SETPDFMAX
            Cmd += ";"
            Cmd += ADDCRSUFFIX
            Cmd += ";"
            Cmd += TRIGGERMODE
            Cmd += NVRAM
            CMD_Send(Cmd)    ' Send assembled command
            ret = CMD_Wait_Response()
        Catch ex As Exception
            m_ScannerFoundOnPort = Nothing
        End Try
        Return ret
    End Function

    Private Sub SerialPort_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles m_SerialPort.DataReceived
        Try
            Dim RawBuffer(4096) As Byte
            Dim nBytesRead As Integer = m_SerialPort.Read(RawBuffer, 0, RawBuffer.Length)
            SyncLock m_SerialBuffer
                m_SerialBuffer.Add(RawBuffer, nBytesRead)
                m_DataReady.Set()
                m_Timer.Change(100, Timeout.Infinite)
            End SyncLock
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Cancel()
        m_CancelFlag = True
        m_DataReady.Set()
        Thread.Sleep(100)
    End Sub

End Class


