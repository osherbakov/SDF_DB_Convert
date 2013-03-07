Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic

Partial Public Class ConvertDialogForm

    Private Enum STATUS
        DISCONNECTED = 0
        CONNECTED = 1
    End Enum

    Private m_Mag_Status As STATUS
    Private m_Scan_Status As STATUS

    Private Sub TabPage_Encoder_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Encoder.Leave
        BackgroundWorkerThread.CancelAsync()
        MSR206_Enc.Cancel()
        While BackgroundWorkerThread.IsBusy
            Application.DoEvents()
        End While
        RemoveHandler BackgroundWorkerThread.DoWork, AddressOf BackgroundWorkerThread_DoWorkMAG

        MSR206_Enc.CMD_Reset()
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
        MSR206_Enc.Cancel()
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
        MSR206_Enc.DetectMSR206()
        Dim Result As Integer = 0

        Do
            ' Loop until the Mag Encoder is connected
            If Not MSR206_Enc.IsMSR206Detected Then
                m_Mag_Status = STATUS.DISCONNECTED
                UpdateEncStatus()
                Do
                    If BackgroundWorkerThread.CancellationPending Then
                        e.Cancel = True
                        Exit Do
                    End If
                    MSR206_Enc.DetectMSR206()
                Loop Until MSR206_Enc.IsMSR206Detected

                ' Found - update status and program Encoder
                m_Mag_Status = STATUS.CONNECTED
                UpdateEncStatus()

                Result = 0
                Result += MSR206_Enc.CMD_SetCo(MSR206.Coercity.HIGH)
                Result += MSR206_Enc.CMD_SetBPI(75)
                Result += MSR206_Enc.CMD_SetBPC(8, 8, 8)
                Result += MSR206_Enc.CMD_SetEncoding(MSR206.Encoding.BITS6, MSR206.Encoding.BITS4, MSR206.Encoding.BITS6)
                Result += MSR206_Enc.CMD_SetParity(MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY)
                Result += MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK1 Or MSR206.Tracks.TRACK3, "%", "?", "^")
                Result += MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK2, ";", "?", "=")
            End If

            If BackgroundWorkerThread.CancellationPending Then
                e.Cancel = True
                Exit Do
            End If

            ' get the current selected/displaying record
            '   and extract the data
            Dim g1 As String = ""
            Dim g2 As String = ""
            Dim g3 As String = ""
            If ID_CARDSBindingSource.Count <> 0 Then
                m_Mag_Status = STATUS.CONNECTED
                UpdateEncStatus()

                Dim curr_data As ID_CARDS_DataSet.ID_CARDSRow = ID_CARDS_DataSet.ID_CARDS.Rows(ID_CARDSBindingSource.Position)
                Dim rm As Match = rx_Split_Tracks.Match(curr_data.AAMVAMAG)
                If rm.Success Then
                    g1 = rm.Groups("Track1").Value
                    g2 = rm.Groups("Track2").Value
                    g3 = rm.Groups("Track3").Value
                End If

                ' Try to program the MAG stripe 
                Result = 0
                Result += MSR206_Enc.CMD_LED(MSR206.LEDs.GREEN Or MSR206.LEDs.RED Or MSR206.LEDs.YELLOW)
                Result += MSR206_Enc.CMD_WriteRaw(g1, g2, g3)

                If BackgroundWorkerThread.CancellationPending Then
                    e.Cancel = True
                    Exit Do
                End If

                If Result = 0 Then
                    ' If successfully programmed - move to the next
                    Me.BeginInvoke(New MethodInvoker(AddressOf MoveNextRecord))
                End If
            End If
        Loop While True
    End Sub

End Class