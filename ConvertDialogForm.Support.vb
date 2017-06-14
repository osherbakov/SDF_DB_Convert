Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb


Partial Public Class ConvertDialogForm
    ' Rank is 6 characters, PayGrade is 4
    Private Shared RankToGrade() As String = { _
"AMB   CIV ", _
"PVT   E 1 ", "PV2   E 2 ", "PFC   E 3 ", "SPC   E 4 ", "CPL   E 4 ", _
"SGT   E 5 ", "SSG   E 6 ", "SFC   E 7 ", "MSG   E 8 ", "1SG   E 8 ", "SGM   E 9 ", "CSM   E 9 ", _
"WOC   E 5 ", _
"WO1   W 1 ", "CW2   W 2 ", "CW3   W 3 ", "CW4   W 4 ", "CW5   W 5 ", _
"OCS   E 6 ", _
"2LT   O 1 ", "1LT   O 2 ", "CPT   O 3 ", "MAJ   O 4 ", _
"LTC   O 5 ", "COL   O 6 ", "BG    O 7 ", "MG    O 8 ", "LG    O 9 ", _
"AB    E 1 ", "Amn   E 2 ", "A1C   E 3 ", "SrA   E 4 ", _
"SSgt  E 5 ", "TSgt  E 6 ", "MSgt  E 7 ", "SMSgt E 8 ", "CMSgt E 9 ", "CCM   E 9 ", _
"2d  LtO 1 ", "1st LtO 2 ", "Capt  O 3 ", "Maj   O 4 ", _
"Lt ColO 5 ", "Col   O 6 ", "Brig GO 7 ", "Maj GeO 8 ", "Lt GenO 9 ", _
"CWO2  W 2 ", "CWO3  W 3 ", "CWO4  W 4 ", "CWO5  W 5 ", _
"SR    E 1 ", "SA    E 2 ", "SN    E 3 ", "PO3   E 4 ", _
"PO2   E 5 ", "PO1   E 6 ", "CPO   E 7 ", "SCPO  E 8 ", "MCPO  E 9 ", _
"ENS   O 1 ", "LTJG  O 2 ", "LT    O 3 ", "LCDR  O 4 ", _
"CDR   O 5 ", "CAPT  O 6 ", "RDML  O 7 ", "RADM  O 8 ", "VADM  O 9 " _
}

    Private Shared EyesColors() As String = {"BLK", "BLU", "BRO", "BRN", "GRY", "GRN", "HAZ", "MAR", "PNK", "DIC", "UNK"}
    Private Shared HairColors() As String = {"BAL", "BLK", "BLN", "BRO", "BRN", "GRY", "RED", "SDY", "WHI", "UNK"}
    Private Shared BloodTypes() As String = {"AB NEG", "AB POS", "A NEG", "A POS", "B NEG", "B POS", "O NEG", "O POS", "UNK"}
    Private Shared Ranks() As String
    Private Shared RanksAll() As String
    Private Shared PayGrades() As String

    ' Regex to extract the First, Last names from the comma-separated list
    Private Shared np_rx As New Regex("\s*(?<LN>[a-zA-Z\-\(\)]+)\s*(,|\s+)\s*(?<FN>[a-zA-Z\-\(\)]+)\s*(,*|\s+)\s*(?<MI>[a-zA-Z\-\(\)]*)", _
                                      RegexOptions.Compiled Or RegexOptions.IgnoreCase)

    Private Sub InitLists()
        ' Populate the Ranks list to be used in comboBoxes
        Dim r As New List(Of String)
        Dim p As New List(Of String)
        Dim a As New List(Of String)

        For Each rankgrade As String In RankToGrade
            r.Add(rankgrade.Substring(0, 6))

            a.Add(rankgrade.Substring(0, 6))
            a.Add(rankgrade.Substring(0, 5))
            a.Add(rankgrade.Substring(0, 4))
            a.Add(rankgrade.Substring(0, 3))
            ' Add both versions of Paygrade - 4 and 3 letters
            p.Add(rankgrade.Substring(6, 4))
            p.Add(rankgrade.Substring(6, 4))
            p.Add(rankgrade.Substring(6, 4))
            p.Add(rankgrade.Substring(6, 3))
        Next
        Ranks = r.ToArray()
        RanksAll = a.ToArray()
        PayGrades = p.ToArray()

        RANKComboBox.DataSource = Ranks
        HairComboBox.DataSource = HairColors
        EyesComboBox.DataSource = EyesColors
        RankComboBox_ID.DataSource = Ranks
        BloodTypeComboBox.DataSource = BloodTypes

    End Sub

    '
    Private Structure colMap
        Dim srcIdx As Integer
        Dim dstIdx As Integer
        Dim doConvert As Boolean
        Sub New(ByVal s As Integer, ByVal d As Integer, ByVal c As Boolean)
            srcIdx = s
            dstIdx = d
            doConvert = c
        End Sub
    End Structure

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


    Private Sub ImportRecords(ByVal srcData As DataSet, ByVal dstData As DataSet)

        Dim dbMapping As New List(Of colMap)

        Dim srcColumns As DataColumnCollection = srcData.Tables(0).Columns
        Dim dstColumns As DataColumnCollection = dstData.Tables(0).Columns
        '
        ' Create the column mapping  src -> dst
        For src = 0 To srcColumns.Count - 1
            For dst = 0 To dstColumns.Count - 1
                If srcColumns(src).ColumnName.ToUpper() = dstColumns(dst).ColumnName.ToUpper Then
                    Dim conv As Boolean = srcColumns(src).DataType() Is GetType(String) And _
                                            dstColumns(dst).DataType() IsNot GetType(String)
                    dbMapping.Add(New colMap(src, dst, conv))
                    Exit For
                End If
            Next
        Next

        ' More than half of the fields should match
        If dbMapping.Count < dstColumns.Count / 2 Then
            Exit Sub
        End If
        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = srcData.Tables(0).Rows.Count

        dstData.Tables(0).BeginLoadData()   ' Stop indexing
        For Each dt As DataRow In srcData.Tables(0).Rows
            Dim dstRec As DataRow = dstData.Tables(0).NewRow()
            For Each map As colMap In dbMapping
                If map.doConvert AndAlso Not dt.IsNull(map.srcIdx) Then
                    dstRec(map.dstIdx) = Support.ExtractNumber(dt(map.srcIdx))
                Else
                    dstRec(map.dstIdx) = dt(map.srcIdx)
                End If
            Next
            dstData.Tables(0).Rows.Add(dstRec)
            ProgressBar1.PerformStep()
        Next
        dstData.Tables(0).EndLoadData()     ' Resume indexing
    End Sub

    Private Sub CheckInputRecords()
        ' We need this TextInfo to do proper capitalizing
        Dim ti As System.Globalization.TextInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo

        ' Do some data checking and formatting
        Dim EmptyRecords_CSMR_ID As New List(Of CSMR_ID_DataSet.CSMR_IDRow)

        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = CSMR_ID_DS.CSMR_ID.Rows.Count

        ' Freeze index updating
        CSMR_ID_DS.CSMR_ID.BeginLoadData()

        For Each dr As CSMR_ID_DataSet.CSMR_IDRow In CSMR_ID_DS.CSMR_ID
            '
            ' TODO: To check for empty records
            '
            'If dr.IsDOBNull OrElse dr.IsH_ADDRNull OrElse dr.SSN = 0 Then
            If dr.IsLAST_NAMENull Then
                EmptyRecords_CSMR_ID.Add(dr)
                Continue For
            End If

            ' If only NAME_IND is provided - extract it, and populate other fields
            If (dr.IsFIRST_NAMENull Or dr.IsLAST_NAMENull) And Not dr.IsNAME_INDNull Then
                Dim m As Match = np_rx.Match(dr.NAME_IND)
                dr.LAST_NAME = m.Groups("LN").Value
                dr.FIRST_NAME = m.Groups("FN").Value
                dr.MIDDLE_NAME = m.Groups("MI").Value
            End If

            ' Make MiddleName Valid
            If dr.IsMIDDLE_NAMENull Then
                dr.MIDDLE_NAME = String.Empty
            End If
            ' Remove NMN (No Middle Name) abbreviation 
            If dr.MIDDLE_NAME.ToUpper().Contains("NMN") Then
                dr.MIDDLE_NAME = String.Empty
            End If
            ' Remove all dots from the names and addresses
            dr.MIDDLE_NAME = dr.MIDDLE_NAME.Replace(".", "")

            If Not dr.IsH_ADDRNull Then
                dr.H_ADDR = dr.H_ADDR.Replace(".", "").Replace(",", "")
                dr.H_ADDR = ti.ToTitleCase(dr.H_ADDR.ToLower()).Trim()
            End If

            ' If NAME_IND is not provided - make it
            If dr.IsNAME_INDNull And _
                Not (dr.IsFIRST_NAMENull And dr.IsLAST_NAMENull) Then
                dr.NAME_IND = dr.LAST_NAME.ToUpper() + ", " + dr.FIRST_NAME.ToUpper() + " " + dr.MIDDLE_NAME.ToUpper()
            End If

            ' Capitalize all letters in the address and First-last  names
            If Not dr.IsH_CITYNull Then
                dr.H_CITY = ti.ToTitleCase(dr.H_CITY.ToLower()).Trim()
            End If

            dr.FIRST_NAME = ti.ToTitleCase(dr.FIRST_NAME.ToLower().Trim())
            dr.LAST_NAME = ti.ToTitleCase(dr.LAST_NAME.ToLower().Trim())
            dr.MIDDLE_NAME = ti.ToTitleCase(dr.MIDDLE_NAME.ToLower().Trim())

            ' Rank cannot be Null
            If dr.IsRANKNull Then
                dr.RANK = String.Empty
            End If
            ' If rank is provided - fill the Paygrade
            ' If not provided - make a civilian
            If Not String.IsNullOrEmpty(dr.RANK) Then
                For Each rankgrade As String In RankToGrade
                    If rankgrade.Contains(dr.RANK.Trim()) Then
                        dr.PAY_GR = rankgrade.Substring(6).Trim()
                        Exit For
                    End If
                Next
            Else
                dr.RANK = RankToGrade(0).Substring(0, 6)
                dr.PAY_GR = RankToGrade(0).Substring(6).Trim()
            End If

            If dr.IsBLOOD_TYPENull Then
                dr.BLOOD_TYPE = "UNK"
            End If

            If dr.IsDL_NUMBERNull Then
                dr.DL_NUMBER = String.Empty
            End If

            If dr.IsEYESNull Then
                dr.EYES = "UNK"
            End If

            If dr.IsHAIRNull Then
                dr.HAIR = "UNK"
            End If

            If dr.IsWEIGHTNull Then
                dr.WEIGHT = String.Empty
            End If

            If dr.IsHEIGHTNull Then
                dr.HEIGHT = String.Empty
            End If
            ProgressBar1.PerformStep()
        Next

        ' Remove empty records from the dataset
        For Each dr As CSMR_ID_DataSet.CSMR_IDRow In EmptyRecords_CSMR_ID
            CSMR_ID_DS.CSMR_ID.RemoveCSMR_IDRow(dr)
        Next
        CSMR_ID_DS.CSMR_ID.EndLoadData()

        '
        ' Do the same for the ID_CARDS records
        '
        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = ID_CARDS_DS.ID_CARDS.Rows.Count
        ID_CARDS_DS.ID_CARDS.BeginLoadData()   ' Freeze index updates

        Dim EmptyRecords_ID_CARDS As New List(Of ID_CARDS_DataSet.ID_CARDSRow)
        For Each dr As ID_CARDS_DataSet.ID_CARDSRow In ID_CARDS_DS.ID_CARDS
            ' Weed out empty records
            If dr.IsLastNameNull OrElse String.IsNullOrEmpty(dr.LastName) OrElse _
                dr.IsFirstNameNull OrElse String.IsNullOrEmpty(dr.FirstName) OrElse _
                        dr.IsRankNull OrElse String.IsNullOrEmpty(dr.Rank) Then
                EmptyRecords_ID_CARDS.Add(dr)
                Continue For
            End If

            If (dr.IsAddressNull OrElse String.IsNullOrEmpty(dr.Address) _
                        OrElse Not dr.Address.Contains(VB.vbCrLf)) AndAlso _
                        Not dr.IsH_AddressNull AndAlso Not String.IsNullOrEmpty(dr.H_Address) AndAlso _
                            Not dr.IsH_CityNull AndAlso Not String.IsNullOrEmpty(dr.H_City) AndAlso _
                                Not dr.IsH_ZIPNull AndAlso Not String.IsNullOrEmpty(dr.H_ZIP) Then
                dr.Address = ti.ToTitleCase(dr.H_Address.Replace(".", "").Replace(",", "")) + _
                VB.vbCrLf + ti.ToTitleCase(dr.H_City) + ", CA " + dr.H_ZIP
            End If
            If Not dr.IsPayGradeNull AndAlso Not String.IsNullOrEmpty(dr.PayGrade) AndAlso _
                dr.PayGrade.Length < 3 Then
                dr.PayGrade = dr.PayGrade(0) + " " + dr.PayGrade(1) + " "
            End If
            ProgressBar1.PerformStep()
        Next
        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = EmptyRecords_ID_CARDS.Count

        ' Remove empty records from the dataset
        For Each dr As ID_CARDS_DataSet.ID_CARDSRow In EmptyRecords_ID_CARDS
            dr.Delete()
            Application.DoEvents()
            ProgressBar1.PerformStep()
        Next
        ID_CARDS_DS.ID_CARDS.EndLoadData()
    End Sub

    Private Function ValidateRecord(ByVal dr As ID_CARDS_DataSet.ID_CARDSRow) As Boolean
        Dim IsValid As Boolean = True

        ' Clear all errors first
        For Each c As Control In TabPage_ID_CARDS.Controls()
            Form_error.SetError(c, "")
        Next

        If dr.IsBloodTypeNull OrElse String.IsNullOrEmpty(dr.BloodType) OrElse Not BloodTypes.Contains(dr.BloodType) Then
            Form_error.SetError(BloodTypeComboBox, "Incorrect BloodType")
            IsValid = False
        End If
        If dr.IsEyesNull OrElse String.IsNullOrEmpty(dr.Eyes) OrElse Not EyesColors.Contains(dr.Eyes) Then
            Form_error.SetError(EyesComboBox, "Incorrect Eyes Color")
            IsValid = False
        End If
        If dr.IsHairNull OrElse String.IsNullOrEmpty(dr.Hair) OrElse Not HairColors.Contains(dr.Hair) Then
            Form_error.SetError(HairComboBox, "Incorrect Hair Color")
            IsValid = False
        End If

        If dr.IsRankNull OrElse String.IsNullOrEmpty(dr.Rank) OrElse Not RanksAll.Contains(dr.Rank) Then
            Form_error.SetError(RankComboBox_ID, "Incorrect Rank")
            IsValid = False
        End If

        If dr.IsPayGradeNull OrElse String.IsNullOrEmpty(dr.PayGrade) OrElse Not PayGrades.Contains(dr.PayGrade) Then
            Form_error.SetError(PayGradeTextBox, "Incorrect Paygrade")
            IsValid = False
        End If

        If dr.IsFirstNameNull OrElse String.IsNullOrEmpty(dr.FirstName) Then
            Form_error.SetError(FirstNameTextBox, "First Name missing")
            IsValid = False
        End If

        If dr.IsLastNameNull OrElse String.IsNullOrEmpty(dr.LastName) Then
            Form_error.SetError(LastNameTextBox, "Last Name missing")
            IsValid = False
        End If

        If dr.IsSSNNull OrElse String.IsNullOrEmpty(dr.SSN) OrElse dr.SSN.Length <> 11 Then
            Form_error.SetError(SSNTextBox1, "Invalid SSN")
            IsValid = False
        End If

        Dim height As Integer
        If dr.IsHeightNull OrElse String.IsNullOrEmpty(dr.Height) OrElse _
              Not Integer.TryParse(dr.Height, height) OrElse height > 90 OrElse height < 48 Then
            Form_error.SetError(HeightTextBox, "Incorrect Height (48-90)")
            IsValid = False
        End If

        Dim weight As Integer
        If dr.IsWeightNull OrElse String.IsNullOrEmpty(dr.Weight) OrElse _
              Not Integer.TryParse(dr.Weight, weight) OrElse weight > 400 OrElse weight < 50 Then
            Form_error.SetError(WeightTextBox, "Incorrect Weight (50-400)")
            IsValid = False
        End If

        If dr.IsAddressNull OrElse String.IsNullOrEmpty(dr.Address) Then
            Form_error.SetError(AddressTextBox, "Incorrect Address")
            IsValid = False
        End If

        If dr.IsDOBNull OrElse dr.DOB > Date.Today().AddYears(-15) OrElse dr.DOB < Date.Today.AddYears(-80) Then
            Form_error.SetError(DOBDateTimePicker1, "Incorrect DOB")
            IsValid = False
        End If

        If dr.IsSexNull OrElse String.IsNullOrEmpty(dr.Sex) OrElse Not (dr.Sex = "M" Or dr.Sex = "F") Then
            Form_error.SetError(SexTextBox, "Invalid Gender (M or F)")
            IsValid = False
        End If
        Return IsValid
    End Function

    Private Function CheckOutputRecords() As Boolean
        Dim curr_idx As Integer
        Dim dr As ID_CARDS_DataSet.ID_CARDSRow

        ' Loop thru all records and do verification
        For curr_idx = 0 To ID_CARDS_DS.ID_CARDS.Count() - 1
            dr = ID_CARDS_DS.ID_CARDS(curr_idx)
            If Not ValidateRecord(dr) Then
                ID_CARDS_BS.Position = curr_idx
                ID_CARDS_BS.ResetItem(curr_idx)
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub SaveAccessDatabase()
        If Not CheckOutputRecords() Then Exit Sub
        SaveFileDialog_ID_CARDS.FileName = IO.Path.ChangeExtension("ID_CARDS_" + Date.Today().ToString("ddMMMMyyyy"), "mdb")
        SaveFileDialog_ID_CARDS.OverwritePrompt = True

        If SaveFileDialog_ID_CARDS.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim FileName As String = SaveFileDialog_ID_CARDS.FileName
            If FileIO.FileSystem.FileExists(FileName) Then
                FileIO.FileSystem.DeleteFile(FileName)
            End If

            CreateAccessDatabase(FileName)
            Me.ID_CARDS_TA.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName
            Me.ID_CARDS_TA.Connection.Open()

            For Each dr As ID_CARDS_DataSet.ID_CARDSRow In ID_CARDS_DS.ID_CARDS

                Dim id_card_data As IDCardData = GetIDCardData(dr)
                With dr
                    ' Update all MAG and PDF field
                    .IssueDate = Date.Today()
                    .ExpirationDate = .IssueDate.AddYears(2)
                    .AAMVAMAG = Support.EncodeAAMVAMagData(id_card_data)
                    .AAMVAPDF = Support.EncodeAAMVAPDF417Data(id_card_data)
                    .CACPDF = Support.EncodeCACPDF417Data(id_card_data)
                    .AAMVACode39 = ""
                    .CACCode39 = ""
                    Me.ID_CARDS_TA.Insert(.IDNumber, .LastName, .FirstName, .MI, _
                                                    .DOB, "XXX-XX-" + .SSN.Substring(.SSN.Length() - 4, 4), .Address, .H_Address, .H_City, .H_ZIP, _
                                                    .IssueDate, .ExpirationDate, .Photo, .Hair, .Eyes, _
                                                    .BloodType, .Rank, .PayGrade, .Height, .Weight, .DLData, _
                                                    .Sex, .SerialNumber, .Affiliation, .Abbreviation, .CACPDF, .AAMVAPDF, .AAMVAMAG, _
                                                    .AAMVACode39, .CACCode39)
                End With
            Next
            Me.ID_CARDS_TA.Connection.Close()
            '
            '    After Saving the DB switch into MagStripe programming
            '
            '            TabControl_ID.SelectTab(2)
        End If
    End Sub

    Private Sub AddToAccessDatabase()
        If Not CheckOutputRecords() Then Exit Sub
        SaveFileDialog_ID_CARDS.FileName = My.Settings.SummaryDBFile
        SaveFileDialog_ID_CARDS.Filter = "Access DB Files|*.mdb|All Files|*.*"
        SaveFileDialog_ID_CARDS.OverwritePrompt = False
        SaveFileDialog_ID_CARDS.CreatePrompt = True

        If SaveFileDialog_ID_CARDS.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim FileName As String = SaveFileDialog_ID_CARDS.FileName
            Dim extProp As String = ""
            If String.IsNullOrEmpty(FileName) OrElse Not FileIO.FileSystem.FileExists(FileName) Then Exit Sub

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
                            Dim cmdCheck As New OleDbCommand()
                            Dim dba As New ID_CARDS_DataSetTableAdapters.ID_CARDS_TableAdapter
                            dba.Connection = conn
                            cmdCheck.Connection = conn
                            cmdCheck.CommandText = "SELECT COUNT(1) FROM [" + TblName + "] WHERE " + _
                                "[IDNumber] = @IDNumber AND " + _
                                "[SSN] = @SSN AND " + _
                                "[IssueDate] = @IssueDate AND " + _
                                "[SerialNumber] = @SerialNumber AND " + _
                                "[AAMVAMAG] = @AAMVAMAG"

                            ' Go thru all records and only add unique ones
                            Dim rec_count As Integer = 0
                            For Each data_rec As ID_CARDS_DataSet.ID_CARDSRow In ID_CARDS_DS.ID_CARDS.Rows
                                With data_rec
                                    cmdCheck.Parameters.Clear()
                                    cmdCheck.Parameters.AddWithValue("@IDNumber", .IDNumber)
                                    cmdCheck.Parameters.AddWithValue("@SSN", .SSN)
                                    cmdCheck.Parameters.AddWithValue("@IssueDate", .IssueDate)
                                    cmdCheck.Parameters.AddWithValue("@SerialNumber", .SerialNumber)
                                    cmdCheck.Parameters.AddWithValue("@AAMVAMAG", .AAMVAMAG)
                                    If cmdCheck.ExecuteScalar() = 0 Then
                                        If data_rec.IsAAMVACode39Null Then data_rec.AAMVACode39 = ""
                                        If data_rec.IsCACCode39Null Then data_rec.CACCode39 = ""
                                        If data_rec.IsMINull Then data_rec.MI = ""
                                        dba.Insert(.IDNumber, .LastName, .FirstName, .MI, _
                                                        .DOB, .SSN, .Address, .H_Address, .H_City, .H_ZIP, _
                                                        .IssueDate, .ExpirationDate, .Photo, .Hair, .Eyes, _
                                                        .BloodType, .Rank, .PayGrade, .Height, .Weight, .DLData, _
                                                        .Sex, .SerialNumber, .Affiliation, .Abbreviation, .CACPDF, .AAMVAPDF, .AAMVAMAG, _
                                                        .AAMVACode39, .CACCode39)
                                        rec_count += 1
                                    End If
                                End With
                            Next
                            dba.Dispose()
                            cmdCheck.Dispose()
                            MessageBox.Show(String.Format("Added {0} records out of {1}", _
                                                          rec_count, ID_CARDS_DS.ID_CARDS.Rows.Count), _
                                                            "Records added to the Database")
                            My.Settings.SummaryDBFile = SaveFileDialog_ID_CARDS.FileName
                        End If
                    Next
                    conn.Close()
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub


    Private Function GetIDCardData(ByVal dr As CSMR_DB_Convert.ID_CARDS_DataSet.ID_CARDSRow) As IDCardData
        Dim card_data As New IDCardData()
        With card_data
            Try
                .Address = dr.Address

                .FirstName = dr.FirstName
                .LastName = dr.LastName
                .MI = dr.MI
                .DOB = dr.DOB

                .IssueDate = dr.IssueDate
                .ExpirationDate = dr.ExpirationDate

                .PayGrade = dr.PayGrade
                .Rank = dr.Rank
                .Sex = dr.Sex(0)

                .BloodType = dr.BloodType
                .Eyes = dr.Eyes
                .Hair = dr.Hair
                .Height = dr.Height
                .Weight = dr.Weight

                .SSN = dr.SSN
                .IdNumber = dr.IDNumber
                .DLData = dr.DLData
                .SerialNumber = dr.SerialNumber
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End With
        Return card_data
    End Function

    Private Function GetImageFile(ByVal LastName As String, ByVal FirstName As String, ByVal MI As String) As Byte()
        '
        ' See if photo exists - use LAST nams, then LAST_FIRST, then FIRST_LAST
        '
        Dim FileFound As Boolean = False
        Dim CurrDir As String = IO.Path.GetDirectoryName(OpenFileDialog_CSMR_ID.FileName())
        Dim FileName As String = ""
        Dim PossibleFiles As New List(Of String)
        Dim result() As Byte

        PossibleFiles.Add(IO.Path.Combine(CurrDir, LastName) + ".jpg")
        PossibleFiles.Add(IO.Path.Combine(CurrDir, LastName) + ".jpeg")
        PossibleFiles.Add(IO.Path.Combine(CurrDir, LastName) + "_" + FirstName + ".jpg")
        PossibleFiles.Add(IO.Path.Combine(CurrDir, LastName) + "_" + FirstName + ".jpeg")
        PossibleFiles.Add(IO.Path.Combine(CurrDir, LastName) + "_" + FirstName(0) + ".jpg")
        PossibleFiles.Add(IO.Path.Combine(CurrDir, LastName) + "_" + FirstName(0) + ".jpeg")
        PossibleFiles.Add(IO.Path.Combine(CurrDir, FirstName) + "_" + LastName + ".jpg")
        PossibleFiles.Add(IO.Path.Combine(CurrDir, FirstName) + "_" + LastName + ".jpeg")
        If Not String.IsNullOrEmpty(MI) Then
            PossibleFiles.Add(IO.Path.Combine(CurrDir, FirstName) + "_" + LastName + "_" + MI.Substring(0, 1) + ".jpg")
            PossibleFiles.Add(IO.Path.Combine(CurrDir, FirstName) + "_" + LastName + "_" + MI.Substring(0, 1) + ".jpeg")
            PossibleFiles.Add(IO.Path.Combine(CurrDir, LastName) + "_" + FirstName + "_" + MI.Substring(0, 1) + ".jpg")
            PossibleFiles.Add(IO.Path.Combine(CurrDir, LastName) + "_" + FirstName + "_" + MI.Substring(0, 1) + ".jpeg")
        End If

        For Each FileName In PossibleFiles
            If IO.File.Exists(FileName) Then
                FileFound = True
                Exit For
            End If
        Next

        If FileFound Then
            Dim fi As IO.FileInfo = New IO.FileInfo(FileName)
            Dim stream As New IO.FileStream(FileName, IO.FileMode.Open, IO.FileAccess.Read)
            Dim photo(fi.Length) As Byte
            stream.Read(photo, 0, fi.Length())
            result = photo
            stream.Close()
            stream = Nothing
            fi = Nothing
            photo = Nothing
        Else
            Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream()
            My.Resources.Empty.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            result = ms.ToArray()
            ms.Close()
        End If

        Return result
    End Function

    Public Shared Function CreateAccessDatabase(ByVal DatabaseFullPath As String) As Boolean
        Dim bAns As Boolean
        Dim cat As New ADOX.Catalog()
        Dim tName As String = "ID_CARDS"
        Dim sqlCommand1 As String = "CREATE TABLE ["
        Dim sqlCommand2 As String = "] (" + _
        "[IDNumber]       TEXT (255), " + _
        "[LastName]       TEXT(255), " + _
        "[FirstName]      TEXT (255)," + _
        "[MI]             TEXT (255)," + _
        "[DOB]            DATETIME,  " + _
        "[SSN]            TEXT (255)," + _
        "[Address]        TEXT (255)," + _
        "[H_Address]      TEXT (255)," + _
        "[H_City]         TEXT (255)," + _
        "[H_ZIP]          TEXT (255)," + _
        "[IssueDate]      DATETIME,  " + _
        "[ExpirationDate] DATETIME,  " + _
        "[Photo]          IMAGE,     " + _
        "[Hair]           TEXT (255)," + _
        "[Eyes]           TEXT (255)," + _
        "[BloodType]      TEXT (255)," + _
        "[Rank]           TEXT (255)," + _
        "[PayGrade]       TEXT (255)," + _
        "[Height]         TEXT (255)," + _
        "[Weight]         TEXT (255)," + _
        "[DLData]         TEXT (255)," + _
        "[Sex]            TEXT (255)," + _
        "[SerialNumber]   TEXT (255)," + _
        "[Affiliation]    TEXT (255)," + _
        "[Abbreviation]   TEXT (255)," + _
        "[CACPDF]         MEMO,     " + _
        "[AAMVAPDF]       MEMO,     " + _
        "[AAMVAMAG]       MEMO,     " + _
        "[AAMVACode39]    MEMO,     " + _
        "[CACCode39]      MEMO);"

        Try

            'Make sure the folder
            'provided in the path exists. If file name w/o path 
            'is  specified,  the database will be created in your
            'application folder.

            ' FIRST - Create the database file
            Dim sCreateString As String
            sCreateString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DatabaseFullPath
            sCreateString = sCreateString + ";Jet OLEDB:Engine Type=5"
            cat.Create(sCreateString)

            ' SECOND - Create the Table
            Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" + DatabaseFullPath)
            con.Open()
            'Get database schema
            Dim dbSchema As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, tName, "TABLE"})
            con.Close()

            ' If the table exists, the count = 1
            If dbSchema.Rows.Count > 0 Then
                ' do whatever you want to do if the table exists
            Else
                'do whatever you want to do if the table does not exist
                ' e.g. create a table
                Dim cmd As New OleDb.OleDbCommand(sqlCommand1 + tName + sqlCommand2, con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            bAns = True

        Catch Excep As System.Runtime.InteropServices.COMException
            bAns = False
            'do whatever else you need to do here, log, 
            'msgbox etc.
            MessageBox.Show(Excep.Message())
        Finally
            cat = Nothing
        End Try
        Return bAns
    End Function

End Class