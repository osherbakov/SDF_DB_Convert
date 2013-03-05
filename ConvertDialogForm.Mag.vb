Partial Public Class ConvertDialogForm

    Private Shared lblSelectCard As String = "Please select the printed ID Card and Swipe it thru the MSR206 Encoder"
    Private Shared lblConnectMSR As String = "Please connect the MSR206 Encoder to the serial port of the computer"
    Private Enum STATUS
        DISCONNECTED = 0
        CONNECTED = 1
    End Enum

    Private m_Status As STATUS

    Private Sub TabPage_Encoder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Encoder.Leave
        MSR206_Enc.Cancel()
        BackgroundWorkerThread.CancelAsync()
    End Sub

    Private Sub TabPage_Encoder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Encoder.Enter
        While BackgroundWorkerThread.IsBusy
            Application.DoEvents()
        End While
        BackgroundWorkerThread.RunWorkerAsync()
    End Sub


    Private Sub UpdateStatus()
        If MagEncoder_Status.InvokeRequired Then
            MagEncoder_Status.BeginInvoke(New MethodInvoker(AddressOf UpdateStatus))
        Else
            If m_Status = STATUS.DISCONNECTED Then
                MagEncoder_Status.ForeColor = Color.Red
                MagEncoder_Status.Text = lblConnectMSR
            Else
                MagEncoder_Status.ForeColor = Color.DarkBlue
                MagEncoder_Status.Text = lblSelectCard
            End If
        End If
    End Sub

    Private Sub BackgroundWorkerThread_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerThread.DoWork
        Dim g1 As String = ""
        Dim g2 As String = ""
        Dim g3 As String = ""

        MSR206_Enc.InitComm()
        MSR206_Enc.CMD_Reset()

        If MSR206_Enc.CMD_Test(300) = -1 Then
            m_Status = STATUS.DISCONNECTED
            UpdateStatus()
            Do
                If BackgroundWorkerThread.CancellationPending Then
                    e.Cancel = True
                    Exit Sub
                End If
                MSR206_Enc.DetectMSR206()
                MSR206_Enc.InitComm()
                MSR206_Enc.CMD_Reset()
            Loop Until MSR206_Enc.IsMSR206Detected
        End If

        m_Status = STATUS.CONNECTED
        UpdateStatus()

        Do
            If BackgroundWorkerThread.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            Dim Result As Integer = 0
            Result += MSR206_Enc.CMD_SetCo(MSR206.Coercity.HIGH)
            Result += MSR206_Enc.CMD_SetBPI(75)
            Result += MSR206_Enc.CMD_SetBPC(8, 8, 8)
            Result += MSR206_Enc.CMD_SetEncoding(MSR206.Encoding.BITS6, MSR206.Encoding.BITS4, MSR206.Encoding.BITS6)
            Result += MSR206_Enc.CMD_SetParity(MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY)
            Result += MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK1 Or MSR206.Tracks.TRACK3, "%", "?", "^")
            Result += MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK2, ";", "?", "=")

            Result += MSR206_Enc.CMD_LED(MSR206.LEDs.GREEN Or MSR206.LEDs.RED Or MSR206.LEDs.YELLOW)

            ' EncodeAAMVAMagData(m_Data, g1, g2, g3)
        Loop While MSR206_Enc.CMD_WriteRaw(g1, g2, g3) <> 0

    End Sub


End Class