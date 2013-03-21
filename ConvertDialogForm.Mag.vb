Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic

Partial Public Class ConvertDialogForm

    Private Enum STATUS
        DISCONNECTED = 0
        CONNECTED = 1
    End Enum

    Private m_Mag_Status As STATUS
    Private m_HHScan_Status As STATUS
    Private m_MSScan_Status As STATUS
    Private m_curr_Position As Integer

    Private Sub TabPage_Encoder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Encoder.Leave
        BackgroundWorkerThread.CancelAsync()
        MSR206_Enc.Cancel()
        While BackgroundWorkerThread.IsBusy
            Application.DoEvents()
        End While
        RemoveHandler BackgroundWorkerThread.DoWork, AddressOf BackgroundWorkerThread_DoWorkMAG
        If MSR206_Enc.IsMSR206Detected Then MSR206_Enc.CMD_Reset()
        MSR206_Enc.Close()
    End Sub

    Private Sub TabPage_Encoder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Encoder.Enter
        ID_CARDSBindingSource.MoveFirst()

        While BackgroundWorkerThread.IsBusy
            Application.DoEvents()
        End While
        AddHandler BackgroundWorkerThread.DoWork, AddressOf BackgroundWorkerThread_DoWorkMAG
        BackgroundWorkerThread.RunWorkerAsync()
    End Sub


    Private Sub ID_CARDSBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ID_CARDSBindingSource.PositionChanged
        If m_curr_Position <> ID_CARDSBindingSource.Position Then
            MSR206_Enc.Cancel()
        End If
    End Sub

    Private Shared rx_Split_Tracks As New Regex("%(?<Track1>.+?)\?;(?<Track2>.+?)\?%(?<Track3>.+?)\?", RegexOptions.Compiled Or RegexOptions.IgnoreCase)

    Private Sub ConvertToMAG(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If cevent.DesiredType Is GetType(String) Then
            Dim rm As Match = rx_Split_Tracks.Match(cevent.Value.ToString())
            If rm.Success Then
                cevent.Value = "%" + rm.Groups("Track1").Value + "?" + VB.vbCrLf + VB.vbCrLf + _
                                ";" + rm.Groups("Track2").Value + "?" + VB.vbCrLf + VB.vbCrLf + _
                                "%" + rm.Groups("Track3").Value + "?" + VB.vbCrLf
            End If
        End If
    End Sub

    Private Sub UpdateEncStatus()
        If MagEncoder_Status.InvokeRequired Then
            MagEncoder_Status.BeginInvoke(New MethodInvoker(AddressOf UpdateEncStatus))
        Else
            If m_Mag_Status = STATUS.DISCONNECTED Then
                MagEncoder_Status.ForeColor = Color.Red
                MagEncoder_Status.Text = "Please connect the MSR206 Encoder to the serial port of the computer"
            Else
                MagEncoder_Status.ForeColor = Color.DarkBlue
                MagEncoder_Status.Text = "Please select the printed ID Card and swipe it thru the MSR206 Encoder"
            End If
        End If
    End Sub

    Private Sub MoveNextRecord()
        ID_CARDSBindingSource.Position += 1
    End Sub

    Private Sub BackgroundWorkerThread_DoWorkMAG(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim g1 As String = ""
        Dim g2 As String = ""
        Dim g3 As String = ""

        ' Start with un-initialized Reader
        MSR206_Enc.Close()

        Dim Result As Boolean
        Do
            ' Check if the Mag Encoder is connected
            If Not MSR206_Enc.IsMSR206Detected Then
                m_Mag_Status = STATUS.DISCONNECTED
                UpdateEncStatus()

                ' Try to detect the Encoder
                MSR206_Enc.DetectMSR206()
                If BackgroundWorkerThread.CancellationPending Then e.Cancel = True : Exit Sub

                ' Found - update status and program Encoder
                If MSR206_Enc.IsMSR206Detected Then
                    m_Mag_Status = STATUS.CONNECTED
                    UpdateEncStatus()

                    Result = MSR206_Enc.CMD_SetCo(MSR206.Coercity.HIGH) = 0 AndAlso _
                    MSR206_Enc.CMD_SetBPI(75) = 0 AndAlso _
                    MSR206_Enc.CMD_SetBPC(8, 8, 8) = 0 AndAlso _
                    MSR206_Enc.CMD_SetEncoding(MSR206.Encoding.BITS6, MSR206.Encoding.BITS4, MSR206.Encoding.BITS6) = 0 AndAlso _
                    MSR206_Enc.CMD_SetParity(MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY) = 0 AndAlso _
                    MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK1 Or MSR206.Tracks.TRACK3, "%", "?", "^") = 0 AndAlso _
                    MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK2, ";", "?", "=")
                End If
            End If

            ' Encode card if detected and there are records to program
            If MSR206_Enc.IsMSR206Detected AndAlso ID_CARDSBindingSource.Count <> 0 Then
                If BackgroundWorkerThread.CancellationPending Then e.Cancel = True : Exit Sub
                m_Mag_Status = STATUS.CONNECTED
                UpdateEncStatus()

                Result = MSR206_Enc.CMD_LED(MSR206.LEDs.GREEN Or MSR206.LEDs.RED Or MSR206.LEDs.YELLOW) = 0
                If BackgroundWorkerThread.CancellationPending Then e.Cancel = True : Exit Sub

                ' Get the current selected/displaying record
                '   and extract the data
                m_curr_Position = ID_CARDSBindingSource.Position
                Dim curr_data As ID_CARDS_DataSet.ID_CARDSRow = ID_CARDS_DataSet.ID_CARDS.Rows(m_curr_Position)
                Dim rm As Match = rx_Split_Tracks.Match(curr_data.AAMVAMAG)
                If rm.Success Then
                    g1 = rm.Groups("Track1").Value
                    g2 = rm.Groups("Track2").Value
                    g3 = rm.Groups("Track3").Value
                End If

                ' Try to program the MAG stripe 
                Result = Result AndAlso MSR206_Enc.CMD_WriteRaw(g1, g2, g3) = 0
                If BackgroundWorkerThread.CancellationPending Then e.Cancel = True : Exit Sub

                ' If successfully programmed - move to the next
                If Result And (m_curr_Position = ID_CARDSBindingSource.Position) Then
                    Me.BeginInvoke(New MethodInvoker(AddressOf MoveNextRecord))
                End If
            End If
        Loop While True
    End Sub

End Class