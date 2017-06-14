Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic
Imports System.Data.OleDb



Public Class ConvertDialogForm

    Private Delegate Sub SaveOrAddToDB()
    Private m_SaveAdd As SaveOrAddToDB = AddressOf SaveAccessDatabase


    Private Sub ConvertDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ID_CARDS_2017DataSet.ID_CARDS' table. You can move, or remove it, as needed.
        ' Me.ID_CARDS_TA.Fill(Me.ID_CARDS_DS.ID_CARDS)

        Me.InitLists()

        ' Define special formatters for Names and Dates 
        AddHandler LastName_Enc.DataBindings(0).Format, AddressOf ConvertToUpper
        AddHandler FirstName_Enc.DataBindings(0).Format, AddressOf ConvertToUpper
        AddHandler MI_Enc.DataBindings(0).Format, AddressOf ConvertToUpper
        AddHandler ExpirationDate_Enc.DataBindings(0).Format, AddressOf ConvertToMILDate
        AddHandler AAMVAMAGTextBox_Enc.DataBindings(0).Format, AddressOf ConvertToMAG

    End Sub


    Private Sub Convert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Convert.Click
        ' Start converting data into ID_CARDS format
        '        Dim id_card As New IDCardData()
        Dim id_row As ID_CARDS_2017DataSet.ID_CARDSRow

        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = CSMR_ID_DS.CSMR_ID.Count()

        ID_CARDS_DS.ID_CARDS.BeginLoadData()
        For Each dr As CSMR_ID_DataSet.CSMR_IDRow In CSMR_ID_DS.CSMR_ID
            '           id_card = New IDCardData()
            id_row = ID_CARDS_DS.ID_CARDS.NewID_CARDSRow()

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
                .IDNumber = Support.MakeFullNumber(IssuingStation.Text, .SSN, .LastName)
                .SerialNumber = Support.MakeSerial()
                If .PayGrade.Contains("CIV") Then
                    .Affiliation = "Civilian"
                    .Abbreviation = "ESGR"
                Else
                    .Affiliation = "Reserve"
                    .Abbreviation = "CSMR"
                End If
            End With

            ID_CARDS_DS.ID_CARDS.AddID_CARDSRow(id_row)
            ProgressBar1.PerformStep()
        Next
        ID_CARDS_DS.ID_CARDS.EndLoadData()
        TabControl_ID.SelectTab(1)
    End Sub

    Private Sub Button_CreateDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CreateDB.Click
        m_SaveAdd()
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
        If PayGradeTextBox.Text.Contains("CIV") Then
            AbbreviationTextBox.Text = "ESGR"
        Else
            AbbreviationTextBox.Text = "CSMR"
        End If
    End Sub


    Private Sub ConvertDialogForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        BackgroundThread.CancelAsync()
        ' Stop and close MAG Reader 
        MSR206_Enc.Cancel()
        ' Stop and close Scanner
        HHP4600_Scan.Cancel()

        While BackgroundThread.IsBusy
            Application.DoEvents()
        End While

        If MSR206_Enc.IsMSR206Detected Then MSR206_Enc.CMD_Reset()
        MSR206_Enc.Close()

        If HHP4600_Scan.IsScannerDetected Then HHP4600_Scan.CMD_Reset()
        HHP4600_Scan.Close()

        If MS1690_Scan.IsScannerDetected Then MS1690_Scan.CMD_Reset()
        MS1690_Scan.Close()

        'Tell the system that Validation events CANNOT cancel closing!!!
        e.Cancel = False
    End Sub

    Private Sub TabPage_ID_CARDS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TabPage_ID_CARDS.Validating
        If Button_CreateDB.Enabled AndAlso Not ValidateRecord(ID_CARDS_DS.ID_CARDS(ID_CARDS_BS.Position)) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ConvertDialogForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim nextTab As Integer = 0 ' The next tab to switch to after the load
        TabControl_ID.SelectTab(nextTab)

        '
        ' On start present the FileOpen dialog and get the Database File
        '
        OpenFileDialog_CSMR_ID.Filter = "Access DB Files|*.mdb|Excel 97-03 Files|*.xls|Excel 2007 Files|*.xlsx"
        If OpenFileDialog_CSMR_ID.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso _
            Not String.IsNullOrEmpty(OpenFileDialog_CSMR_ID.FileName()) AndAlso _
                IO.File.Exists(OpenFileDialog_CSMR_ID.FileName()) Then

            ' Open the database and fill the data
            Dim FileName As String = OpenFileDialog_CSMR_ID.FileName()
            Dim extProp As String = ""
            Dim cb As OleDb.OleDbConnectionStringBuilder = New OleDbConnectionStringBuilder()
            cb.DataSource = FileName
            Try
                If IO.Path.GetExtension(FileName).ToUpper = ".MDB" Then
                    cb.Provider = "Microsoft.Jet.OLEDB.4.0"
                    extProp = ""
                ElseIf IO.Path.GetExtension(FileName).ToUpper = ".XLS" Then ' Excel 97-03 files
                    cb.Provider = "Microsoft.Jet.OLEDB.4.0"
                    extProp = "Excel 8.0;HDR=Yes;IMEX=1"
                ElseIf IO.Path.GetExtension(FileName).ToUpper = ".XLSX" Then ' Excel 2007 files
                    cb.Provider = "Microsoft.ACE.OLEDB.12.0"
                    extProp = "Excel 12.0;HDR=Yes;IMEX=1"
                End If

                cb.Add("Extended Properties", extProp)
                Using conn As OleDbConnection = New OleDbConnection(cb.ToString())
                    conn.Open()
                    Dim dtSchema As DataTable = conn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
                    For Each dr As DataRow In dtSchema.Rows
                        ' Get the table name
                        Dim TblName As String = dr("TABLE_NAME").ToString

                        ' Check if the Table in ID_CARDS format
                        If TblName.ToUpper().Contains("ID_CARDS") Then
                            Dim cmd As New OleDbCommand()
                            Dim od_data_set As New DataSet()
                            cmd.CommandText = "SELECT * FROM [" + TblName + "]"
                            cmd.Connection = conn

                            Dim oda As New OleDbDataAdapter(cmd)
                            oda.Fill(od_data_set)
                            ImportRecords(od_data_set, ID_CARDS_DS)
                            od_data_set.Dispose()
                            cmd.Dispose()
                            nextTab = 1
                            Button_CreateDB.Text = "Add to Main DB"
                            m_SaveAdd = AddressOf AddToAccessDatabase
                            Exit For
                        ElseIf Not TblName.ToUpper.Contains("MSYS") And _
                                Not TblName.ToUpper.Contains("PRINT_") Then
                            ' Try to load the table
                            Dim cmd As New OleDbCommand()
                            Dim od_data_set As New DataSet()
                            cmd.CommandText = "SELECT * FROM [" + TblName + "]"
                            cmd.Connection = conn

                            Dim oda As New OleDbDataAdapter(cmd)
                            oda.Fill(od_data_set)
                            ImportRecords(od_data_set, CSMR_ID_DS)
                            od_data_set.Dispose()
                            cmd.Dispose()
                            nextTab = 0
                            Button_CreateDB.Text = "Create Print DB"
                            m_SaveAdd = AddressOf SaveAccessDatabase
                        End If
                    Next
                    conn.Close()
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Me.CheckInputRecords()
        End If
        TabControl_ID.SelectTab(nextTab)
    End Sub

    Private Sub Button_ID_Photo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_ID_Photo.Click
        If OpenFileDialog_Photo.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso _
           Not String.IsNullOrEmpty(OpenFileDialog_Photo.FileName) AndAlso _
            IO.File.Exists(OpenFileDialog_Photo.FileName) Then

            Dim FileName As String = OpenFileDialog_Photo.FileName
            Dim fi As IO.FileInfo = New IO.FileInfo(FileName)
            Dim stream As New IO.FileStream(FileName, IO.FileMode.Open, IO.FileAccess.Read)
            Dim photo(fi.Length) As Byte
            stream.Read(photo, 0, fi.Length())
            ID_CARDS_DS.ID_CARDS(ID_CARDS_BS.Position).Photo = photo
            stream.Close()
            stream = Nothing
            fi = Nothing
            photo = Nothing
        End If
    End Sub
End Class
