Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic



Public Class ConvertDialogForm

    Private Sub ConvertToUpper(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If cevent.DesiredType Is GetType(String) Then
            cevent.Value = cevent.Value.ToString.ToUpper
        End If
    End Sub

    Private Sub ConvertToMILDate(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If cevent.DesiredType Is GetType(String) Then
            Dim d As Date = CType(cevent.Value, Date)
            cevent.Value = d.ToString("yyyyMMMdd").ToUpper
        End If
    End Sub

    Private Sub ConvertDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.InitLists()

        AddHandler LastName_Enc.DataBindings(0).Format, AddressOf ConvertToUpper
        AddHandler FirstName_Enc.DataBindings(0).Format, AddressOf ConvertToUpper
        AddHandler MI_Enc.DataBindings(0).Format, AddressOf ConvertToUpper

        AddHandler ExpirationDate_Enc.DataBindings(0).Format, AddressOf ConvertToMILDate
        AddHandler AAMVAMAGTextBox_Enc.DataBindings(0).Format, AddressOf ConvertToMAG

        '
        ' On start present the FileOpen dialog and get the Database File
        '
        If CSMR_ID_OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso _
            Not String.IsNullOrEmpty(CSMR_ID_OpenFileDialog.FileName()) AndAlso _
            IO.File.Exists(CSMR_ID_OpenFileDialog.FileName()) Then
            ' Open thedatabase and fill the data
            Try
                Me.CSMR_IDTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _
                         CSMR_ID_OpenFileDialog.FileName()
                Me.CSMR_IDTableAdapter.Fill(Me.CSMR_ID_DataSet.CSMR_ID)
                Me.CSMR_IDTableAdapter.Connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            Me.CheckInputRecords()
        End If
        TabControl_ID.SelectTab(0)
    End Sub


    Private Sub Convert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Convert.Click
        ' Start converting data into ID_CARDS format
        '        Dim id_card As New IDCardData()
        Dim id_row As ID_CARDS_DataSet.ID_CARDSRow

        If Not Me.Validate() Then
            Exit Sub
        End If

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = CSMR_ID_DataSet.CSMR_ID.Count()

        For Each dr As CSMR_ID_DataSet.CSMR_IDRow In CSMR_ID_DataSet.CSMR_ID
            '           id_card = New IDCardData()
            id_row = ID_CARDS_DataSet.ID_CARDS.NewID_CARDSRow()

            With id_row
                .Address = dr.H_ADDR + VB.vbCrLf + dr.H_CITY + ", CA " + dr.H_ZIP
                .H_Address = dr.H_ADDR
                .H_City = dr.H_CITY
                .H_ZIP = dr.H_ZIP
                .FirstName = dr.FIRST_NAME
                .LastName = dr.LAST_NAME.ToUpper()
                If Not String.IsNullOrEmpty(dr.MIDDLE_NAME) Then
                    .MI = dr.MIDDLE_NAME.ToUpper().Substring(0, 1)
                End If

                If Not String.IsNullOrEmpty(dr.GENDER) Then
                    .Sex = dr.GENDER.ToUpper().Substring(0, 1)
                End If
                .DOB = dr.DOB
                .BloodType = dr.BLOOD_TYPE.ToUpper()
                .SSN = dr.SSN.ToString("000-00-0000")
                .DLData = dr.DL_NUMBER.ToUpper()

                .Rank = dr.RANK
                .PayGrade = dr.PAY_GR.ToUpper()

                .IssueDate = Date.Today()
                .ExpirationDate = .IssueDate.AddYears(3)

                .Hair = dr.HAIR.ToUpper()
                .Eyes = dr.EYES.ToUpper()

                .Height = dr.HEIGHT
                .Weight = dr.WEIGHT

                .Photo = GetImageFile(.LastName, .FirstName, .MI)
                .IDNumber = MakeFullNumber(IssuingStation.Text, .SSN, .LastName)
                .SerialNumber = MakeSerial()

                Dim card_data As IDCardData = GetIDCardData(id_row)
                .AAMVAMAG = Support.EncodeAAMVAMagData(card_data)
                .AAMVAPDF = Support.EncodeAAMVAPDF417Data(card_data)
                .CACPDF = Support.EncodeCACPDF417Data(card_data)
            End With

            ID_CARDS_DataSet.ID_CARDS.AddID_CARDSRow(id_row)
            ProgressBar1.PerformStep()
        Next
        TabControl_ID.SelectTab(1)
    End Sub

    Private Sub Button_CreateDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CreateDB.Click

        Me.Validate()

        ID_CARDS_SaveFileDialog.FileName = IO.Path.ChangeExtension("ID_CARDS_" + Date.Today().ToString("ddMMMMyyyy"), "mdb")
        If ID_CARDS_SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CreateAccessDatabase(ID_CARDS_SaveFileDialog.FileName)
            Me.ID_CARDSTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ID_CARDS_SaveFileDialog.FileName
            Me.ID_CARDSTableAdapter.Connection.Open()

            For Each dr As ID_CARDS_DataSet.ID_CARDSRow In ID_CARDS_DataSet.ID_CARDS

                Dim card_data As IDCardData = GetIDCardData(dr)
                With dr
                    ' Update all MAG and PDF field
                    .AAMVAMAG = Support.EncodeAAMVAMagData(card_data)
                    .AAMVAPDF = Support.EncodeAAMVAPDF417Data(card_data)
                    .CACPDF = Support.EncodeCACPDF417Data(card_data)
                    .AAMVACode39 = ""
                    .CACCode39 = ""
                    Me.ID_CARDSTableAdapter.Insert(MakeIDNumber(.SSN, .LastName), .LastName, .FirstName, .MI, _
                                                    .DOB, "XXX-XX-" + .SSN.Substring(.SSN.Length() - 4, 4), .Address, .H_Address, .H_City, .H_ZIP, _
                                                    .IssueDate, .ExpirationDate, .Photo, .Hair, .Eyes, _
                                                    .BloodType, .Rank, .PayGrade, .Height, .Weight, .DLData, _
                                                    .Sex, .SerialNumber, .CACPDF, .AAMVAPDF, .AAMVAMAG, _
                                                    .AAMVACode39, .CACCode39)
                End With
            Next
            Me.ID_CARDSTableAdapter.Connection.Close()
            TabControl_ID.SelectTab(2)
        End If
    End Sub

    Private Sub RANKComboBox_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RANKComboBox.SelectedIndexChanged
        Dim new_rank = RANKComboBox.SelectedValue
        For Each rankgrade As String In RankToGrade
            If Not String.IsNullOrEmpty(new_rank) AndAlso rankgrade.Contains(new_rank) Then
                PAY_GRTextBox.Text = rankgrade.Substring(6)
            End If
        Next
    End Sub

    Private Sub RankComboBox_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RankComboBox_ID.SelectedIndexChanged
        Dim new_rank = RankComboBox_ID.SelectedValue
        For Each rankgrade As String In RankToGrade
            If Not String.IsNullOrEmpty(new_rank) AndAlso rankgrade.Contains(new_rank) Then
                PayGradeTextBox.Text = rankgrade.Substring(6)
            End If
        Next
    End Sub

    Private Sub TabPage_Scanner_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Scanner.Enter
        m_curr_id.LastName = "aaaaaa"
        m_curr_id.FirstName = "sssss"
        IDCardDataBindingSource.DataSource = m_curr_id
        IDCardDataBindingSource.ResumeBinding()
        m_curr_id.Hair = "SSSS"
        IDCardDataBindingSource.ResetItem(0)
        While BackgroundWorkerThread.IsBusy
            Application.DoEvents()
        End While
        AddHandler BackgroundWorkerThread.DoWork, AddressOf BackgroundWorkerThread_DoWorkSCAN
        BackgroundWorkerThread.RunWorkerAsync()

    End Sub


    Private Sub TabPage_Scanner_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Scanner.Leave
        MSR206_Enc.Cancel()
        BackgroundWorkerThread.CancelAsync()
        While BackgroundWorkerThread.IsBusy
            Application.DoEvents()
        End While
        IDCardDataBindingSource.SuspendBinding()
        RemoveHandler BackgroundWorkerThread.DoWork, AddressOf BackgroundWorkerThread_DoWorkSCAN
    End Sub

    Private m_curr_id As New IDCardData()

    Private Sub UpdateScanStatus()
        If MagReader_Status.InvokeRequired Then
            MagReader_Status.BeginInvoke(New MethodInvoker(AddressOf UpdateScanStatus))
        Else
            If m_Mag_Status = STATUS.DISCONNECTED Then
                MagReader_Status.ForeColor = Color.Red
                MagReader_Status.Text = "Please connect MagReader"
            Else
                MagReader_Status.ForeColor = Color.DarkBlue
                MagReader_Status.Text = "Please swipe ID Card thru the Reader"
            End If
        End If
    End Sub

    Private Sub UpdateDataFileds()
        IDCardDataBindingSource.ResetCurrentItem()
    End Sub

    Private Sub UpdateDataSourceMag()
        DataSourceLabel.Text = "Data scanned from AAMVA MagReader..."
    End Sub

    Private Sub UpdateDataSourceCAC()
        DataSourceLabel.Text = "Data scanned from FederalID barcode..."
    End Sub

    Private Sub UpdateDataSourceAAMVA()
        DataSourceLabel.Text = "Data scanned from State AAMVA barcode..."
    End Sub


    Private Sub BackgroundWorkerThread_DoWorkSCAN(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        MSR206_Enc.InitComm()
        MSR206_Enc.CMD_Reset()
        m_curr_id.Height = "123"
        m_curr_id.IdNumber = "666GGGFF"
        m_curr_id.LastName = "SHERBAKOV"

        Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataFileds))
        Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceMag))

        Do
            ' Loop until the Mag Encoder is connected
            If MSR206_Enc.CMD_Test(300) <> 0 Then
                m_Mag_Status = STATUS.DISCONNECTED
                UpdateScanStatus()
                Do
                    If BackgroundWorkerThread.CancellationPending Then
                        e.Cancel = True
                        Exit Do
                    End If
                    MSR206_Enc.DetectMSR206()
                    MSR206_Enc.InitComm()
                    MSR206_Enc.CMD_Reset()
                Loop Until MSR206_Enc.IsMSR206Detected
            End If

            If BackgroundWorkerThread.CancellationPending Then
                e.Cancel = True
                Exit Do
            End If
            ' Found - update status
            m_Mag_Status = STATUS.CONNECTED
            UpdateScanStatus()

            ' get the current selected/displaying record
            '   and extract the data
            Dim track1(1), track2(1), track3(1) As Byte
            Dim g1 As String = ""
            Dim g2 As String = ""
            Dim g3 As String = ""
            ' Try to program the MAG stripe 
            Dim Result As Integer = 0
            Result += MSR206_Enc.CMD_SetCo(MSR206.Coercity.HIGH)
            Result += MSR206_Enc.CMD_SetBPI(75)
            Result += MSR206_Enc.CMD_SetBPC(8, 8, 8)
            Result += MSR206_Enc.CMD_SetEncoding(MSR206.Encoding.BITS6, MSR206.Encoding.BITS4, MSR206.Encoding.BITS6)
            Result += MSR206_Enc.CMD_SetParity(MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY, MSR206.Parity.ODD_PARITY)
            Result += MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK1 Or MSR206.Tracks.TRACK3, "%", "?", "^")
            Result += MSR206_Enc.CMD_SetSpecialChars(MSR206.Tracks.TRACK2, ";", "?", "=")

            Result += MSR206_Enc.CMD_LED(MSR206.LEDs.GREEN Or MSR206.LEDs.RED Or MSR206.LEDs.YELLOW)
            Result += MSR206_Enc.CMD_ReadRaw(track1, track2, track3)
            If BackgroundWorkerThread.CancellationPending Then
                e.Cancel = True
                Exit Do
            End If

            g1 = MSR206.DecodeTrack(track1, MSR206.Encoding.BITS6, 8)
            g2 = MSR206.DecodeTrack(track2, MSR206.Encoding.BITS4, 8)
            g3 = MSR206.DecodeTrack(track3, MSR206.Encoding.BITS6, 8)
            FullSupport.DecodeAAMVAMagData(m_curr_id, g1, g2, g3)
            If Result = 0 Then
                ' If successfully received - display it
                Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataFileds))
                Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceMag))
            End If
        Loop While True
    End Sub


End Class
