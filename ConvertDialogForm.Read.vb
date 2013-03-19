Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic

Partial Public Class ConvertDialogForm

    Private Sub TabPage_Scanner_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Scanner.Enter
        IDCardDataBindingSource.DataSource = m_curr_id
        IDCardDataBindingSource.ResumeBinding()
        IDCardDataBindingSource.ResetItem(0)

        While BackgroundWorkerThread.IsBusy
            Application.DoEvents()
        End While
        AddHandler BackgroundWorkerThread.DoWork, AddressOf BackgroundWorkerThread_DoWorkReader
        BackgroundWorkerThread.RunWorkerAsync()

        'Attach handlers
        AddHandler MSR206_Enc.DataReceived, AddressOf MagReaderDataReady
        AddHandler HHP4600_Scan.DataReceived, AddressOf ScannerDataReady
    End Sub

    Private Sub TabPage_Scanner_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Scanner.Leave
        BackgroundWorkerThread.CancelAsync()
        ' Stop and close MAG Reader 
        MSR206_Enc.Cancel()
        ' Stop and close Scanner
        HHP4600_Scan.Cancel()

        While BackgroundWorkerThread.IsBusy
            Application.DoEvents()
        End While
        RemoveHandler BackgroundWorkerThread.DoWork, AddressOf BackgroundWorkerThread_DoWorkReader
        If MSR206_Enc.IsMSR206Detected Then MSR206_Enc.CMD_Reset()
        MSR206_Enc.Close()
        If HHP4600_Scan.IsScannerDetected Then HHP4600_Scan.CMD_Reset()
        HHP4600_Scan.Close()

        IDCardDataBindingSource.SuspendBinding()
        RemoveHandler MSR206_Enc.DataReceived, AddressOf MagReaderDataReady
        RemoveHandler HHP4600_Scan.DataReceived, AddressOf ScannerDataReady
    End Sub

    Private m_curr_id As New IDCardData()

    Private Sub UpdateReaderStatus()
        If MagReader_Status.InvokeRequired Then
            MagReader_Status.BeginInvoke(New MethodInvoker(AddressOf UpdateReaderStatus))
        Else
            If m_Mag_Status = STATUS.DISCONNECTED Then
                MagReader_Status.ForeColor = Color.Red
                MagReader_Status.Text = "Please connect MagReader"
            Else
                MagReader_Status.ForeColor = Color.DarkBlue
                MagReader_Status.Text = "Please swipe ID Card thru MagReader"
            End If
        End If
    End Sub

    Private Sub UpdateScannerStatus()
        If Barcode_Status.InvokeRequired Then
            Barcode_Status.BeginInvoke(New MethodInvoker(AddressOf UpdateScannerStatus))
        Else
            If m_Scan_Status = STATUS.DISCONNECTED Then
                Barcode_Status.ForeColor = Color.Red
                Barcode_Status.Text = "Please connect Barcode Reader"
            Else
                Barcode_Status.ForeColor = Color.DarkBlue
                Barcode_Status.Text = "Please scan ID Card Barcode"
            End If
        End If
    End Sub


    Private Sub UpdateDataFileds()
        IDCardDataBindingSource.ResetCurrentItem()
    End Sub

    Private Sub UpdateDataSourceMag()
        DataSourceLabel.Text = "Valid Data from State AAMVA Reader..."
    End Sub

    Private Sub UpdateDataSourceError()
        DataSourceLabel.Text = "Error: Invalid ID Data format..."
    End Sub

    Private Sub UpdateDataSourceCAC()
        DataSourceLabel.Text = "Valid Data from Federal ID Barcode..."
    End Sub

    Private Sub UpdateDataSourceAAMVA()
        DataSourceLabel.Text = "Valid Data from State AAMVA Barcode..."
    End Sub

    ' This is the event handler for the Scanner received data event
    Private Sub ScannerDataReady(ByVal sender As Object, ByVal e As Scanners.DataReceivedEventArgs)
        m_curr_id.Clear()
        If Support.DecodeAAMVAPDF417Data(m_curr_id, e.StringData) Then
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceAAMVA))
        ElseIf Support.DecodeCACPDF417Data(m_curr_id, e.StringData) Then
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceCAC))
        Else
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceError))
        End If
        Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataFileds))
    End Sub

    ' This is the event handler for the MagReader received data event
    Private Sub MagReaderDataReady(ByVal sender As Object, ByVal e As MSR206.DataReceivedEventArgs)
        m_curr_id.Clear()
        If Support.DecodeAAMVAMagData(m_curr_id, MSR206.DecodeTrack(e.Track1, MSR206.Encoding.BITS6, 8), _
                    MSR206.DecodeTrack(e.Track2, MSR206.Encoding.BITS4, 8), MSR206.DecodeTrack(e.Track3, MSR206.Encoding.BITS6, 8)) Then
            ' If successfully received - display it
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceMag))
        Else
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceError))
        End If
        Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataFileds))
        MSR206_Enc.CMD_StartRead()
    End Sub


    Private Sub BackgroundWorkerThread_DoWorkReader(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        ' Start with un-initialized Readers
        MSR206_Enc.Close()
        HHP4600_Scan.Close()

        Do
            ' Check if the Mag Reader is connected
            If Not MSR206_Enc.IsMSR206Detected Then
                m_Mag_Status = STATUS.DISCONNECTED
                UpdateReaderStatus()
                MSR206_Enc.DetectMSR206()
                If BackgroundWorkerThread.CancellationPending Then e.Cancel = True : Exit Sub
                If MSR206_Enc.IsMSR206Detected Then
                    ' Found - update status
                    m_Mag_Status = STATUS.CONNECTED
                    UpdateReaderStatus()
                    ' Try to program the MAG stripe reader
                    Dim Result As Boolean
                    Result = MSR206_Enc.CMD_SetCo(MSR206.Coercity.HIGH) = 0 AndAlso _
                    MSR206_Enc.CMD_SetBPI(75) = 0 AndAlso _
                    MSR206_Enc.CMD_SetBPC(8, 8, 8) = 0 AndAlso _
                    MSR206_Enc.CMD_SetEncoding(MSR206.Encoding.BITS6, MSR206.Encoding.BITS4, MSR206.Encoding.BITS6) = 0 AndAlso _
                    MSR206_Enc.CMD_SetParity(MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY) = 0 AndAlso _
                    MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK1 Or MSR206.Tracks.TRACK3, "%", "?", "^") = 0 AndAlso _
                    MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK2, ";", "?", "=") = 0 AndAlso _
                    MSR206_Enc.CMD_LED(MSR206.LEDs.GREEN Or MSR206.LEDs.RED Or MSR206.LEDs.YELLOW) = 0 AndAlso _
                    MSR206_Enc.CMD_StartRead() = 0
                End If
            End If

            ' Check for the Cancel request
            If BackgroundWorkerThread.CancellationPending Then e.Cancel = True : Exit Sub

            ' Check for the Scanner connected
            If Not HHP4600_Scan.IsScannerDetected() Then
                m_Scan_Status = STATUS.DISCONNECTED
                UpdateScannerStatus()

                ' Try to detect the Scanner
                HHP4600_Scan.DetectScanner()
                If BackgroundWorkerThread.CancellationPending Then e.Cancel = True : Exit Sub
                If HHP4600_Scan.IsScannerDetected() Then
                    m_Scan_Status = STATUS.CONNECTED
                    UpdateScannerStatus()
                    HHP4600_Scan.CMD_Setup()
                End If
            End If

            Threading.Thread.Sleep(500)
            ' Check for the Cancel request
            If BackgroundWorkerThread.CancellationPending Then e.Cancel = True : Exit Sub
        Loop
    End Sub

End Class