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
                .MI = ""
                If Not String.IsNullOrEmpty(dr.MIDDLE_NAME) Then
                    .MI = dr.MIDDLE_NAME.ToUpper().Substring(0, 1)
                End If

                .Sex = "M"
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
                .AAMVAPDF = FullSupport.EncodeAAMVAPDF417Data(card_data)
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
                    .AAMVAPDF = FullSupport.EncodeAAMVAPDF417Data(card_data)
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

    Private Sub RANKComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RANKComboBox.SelectedIndexChanged
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
        IDCardDataBindingSource.DataSource = m_curr_id
        IDCardDataBindingSource.ResumeBinding()
        IDCardDataBindingSource.ResetItem(0)

        ' Start with un-initialized Readers
        MSR206_Enc.Close()
        HHP4600_Scan.Close()

        'Attach handlers
        AddHandler MSR206_Enc.DataReceived, AddressOf MagReaderDataReady
        AddHandler HHP4600_Scan.DataReceived, AddressOf ScannerDataReady
        Timer_Reader.Enabled = True
    End Sub


    Private Sub TabPage_Scanner_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage_Scanner.Leave
        Timer_Reader.Enabled = False
        ' Stop and close MAG Reader 
        MSR206_Enc.Cancel()
        If MSR206_Enc.IsMSR206Detected Then MSR206_Enc.CMD_Reset()
        MSR206_Enc.Close()

        ' Stop and close Scanner
        HHP4600_Scan.Cancel()
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
        DataSourceLabel.Text = "Data scanned from AAMVA MagReader..."
    End Sub

    Private Sub UpdateDataSourceCAC()
        DataSourceLabel.Text = "Data scanned from Federal ID barcode..."
    End Sub

    Private Sub UpdateDataSourceAAMVA()
        DataSourceLabel.Text = "Data scanned from State AAMVA barcode..."
    End Sub

    ' This is the event handler for the Scanner received data event
    Private Sub ScannerDataReady(ByVal sender As Object, ByVal e As HHPScanner.DataReceivedEventArgs)
        If FullSupport.DecodeAAMVAPDF417Data(m_curr_id, e.StringData) Then
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataFileds))
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceAAMVA))
        ElseIf FullSupport.DecodeCACPDF417Data(m_curr_id, e.StringData) Then
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataFileds))
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceCAC))
        End If
    End Sub

    ' This is the event handler for the MagReader received data event
    Private Sub MagReaderDataReady(ByVal sender As Object, ByVal e As MSR206.DataReceivedEventArgs)
        If FullSupport.DecodeAAMVAMagData(m_curr_id, MSR206.DecodeTrack(e.Track1, MSR206.Encoding.BITS6, 8), _
                    MSR206.DecodeTrack(e.Track2, MSR206.Encoding.BITS4, 8), MSR206.DecodeTrack(e.Track3, MSR206.Encoding.BITS6, 8)) Then
            ' If successfully received - display it
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataFileds))
            Me.BeginInvoke(New MethodInvoker(AddressOf UpdateDataSourceMag))
        End If
        MSR206_Enc.CMD_StartRead()
    End Sub


    Private Sub Timer_Reader_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Reader.Tick
        ' Check if the Mag Reader is connected
        If Not MSR206_Enc.IsMSR206Detected Then
            m_Mag_Status = STATUS.DISCONNECTED
            UpdateReaderStatus()
            MSR206_Enc.DetectMSR206()
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


        If Not HHP4600_Scan.IsScannerDetected() Then
            m_Scan_Status = STATUS.DISCONNECTED
            UpdateScannerStatus()
            HHP4600_Scan.DetectScanner()
            If HHP4600_Scan.IsScannerDetected() Then
                m_Scan_Status = STATUS.CONNECTED
                UpdateScannerStatus()
                HHP4600_Scan.CMD_Setup()
            End If
        End If

    End Sub

    Private Sub ConvertDialogForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Timer_Reader.Enabled = False
        MSR206_Enc.Cancel()
        If MSR206_Enc.IsMSR206Detected Then MSR206_Enc.CMD_Reset()
        MSR206_Enc.Close()

        HHP4600_Scan.Cancel()
        If HHP4600_Scan.IsScannerDetected Then HHP4600_Scan.CMD_Reset()
        HHP4600_Scan.Close()
    End Sub
End Class
