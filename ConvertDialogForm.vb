Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic




Public Class ConvertDialogForm
    ' Regex to extract the First, Last names from the comma-separated list
    Private Shared np_rx As New Regex("\s*(?<LN>[a-zA-Z]+)\s*(,|\s+)\s*(?<FN>[a-zA-Z]+)\s*(,*|\s+)\s*(?<MI>[a-zA-Z]*)", _
                                      RegexOptions.Compiled Or RegexOptions.IgnoreCase)

    ' Rank is 6 characters, PayGrade is 4
    Private Shared RankToGrade() As String = { _
"CIV       ", _
"PVT   E 1 ", "PV2   E 2 ", "PFC   E 3 ", "SPC   E 4 ", "CPL   E 4 ", _
"SGT   E 5 ", "SSG   E 6 ", "SFC   E 7 ", "MSG   E 8 ", "1SG   E 8 ", "SGM   E 9 ", _
"CSM   E 9 ", "WOC   E 5 ", "WO1   W 1 ", "CW2   W 2 ", "CW3   W 3 ", "CW4   W 4 ", _
"CW5   W 5 ", "OCS   E 6 ", "2LT   O 1 ", "1LT   O 2 ", "CPT   O 3 ", "MAJ   O 4 ", _
"LTC   O 5 ", "COL   O 6 ", "BG    O 7 ", "MG    O 8 ", "LG    O 9 ", _
"AB    E 1 ", "Amn   E 2 ", "A1C   E 3 ", "SrA   E 4 ", _
"SSgt  E 5 ", "TSgt  E 6 ", "MSgt  E 7 ", "SMSgt E 8 ", "CMSgt E 9 ", "CCM   E 9 ", _
"2nd LtO 1 ", "1st LtO 2 ", "Cpt   O 3 ", "Maj   O 4 ", _
"Lt ColO 5 ", "Col   O 6 ", "Brig GO 7 ", "Maj GeO 8 ", "Lt GenO 9 "}

    Private Shared EyesColors() As String = {"BLK", "BLU", "BRO", "BRN", "GRY", "GRN", "HAZ", "MAR", "PNK", "DIC", "UNK"}
    Private Shared HairColors() As String = {"BAL", "BLK", "BLN", "BRO", "BRN", "GRY", "RED", "SDY", "WHI", "UNK"}
    Private Shared Ranks As New List(Of String)

    Private Sub ConvertDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Populate the Ranks list to be used in comboBoxes
        For Each rankgrade As String In RankToGrade
            Ranks.Add(rankgrade.Substring(0, 6))
        Next

        RANKComboBox.DataSource = Ranks
        HairComboBox.DataSource = HairColors
        EyesComboBox.DataSource = EyesColors
        RankComboBox_ID.DataSource = Ranks

        '
        ' On start present the FileOpen dialog and get the Database File
        '
        If CSMR_ID_OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso _
            Not String.IsNullOrEmpty(CSMR_ID_OpenFileDialog.FileName()) Then

            ' Open thedatabase and fill the data
            Try
                Me.CSMR_IDTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _
                         CSMR_ID_OpenFileDialog.FileName()
                Me.CSMR_IDTableAdapter.Fill(Me.CSMR_ID_DataSet.CSMR_ID)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            ' Do some data checking and formatting
            For Each dr As CSMR_ID_DataSet.CSMR_IDRow In CSMR_ID_DataSet.CSMR_ID

                ' If only NAME_IND is provided - extract it
                If (dr.IsFIRST_NAMENull Or dr.IsLAST_NAMENull) And Not dr.IsNAME_INDNull Then
                    Dim m As Match = np_rx.Match(dr.NAME_IND)
                    dr.LAST_NAME = m.Groups("LN").Value
                    dr.FIRST_NAME = m.Groups("FN").Value
                    dr.MIDDLE_NAME = m.Groups("MI").Value
                End If

                ' If NAME_IND is not provided - make it
                If dr.IsNAME_INDNull And _
                    Not (dr.IsFIRST_NAMENull And dr.IsLAST_NAMENull) Then
                    dr.NAME_IND = dr.LAST_NAME.ToUpper() + ", " + dr.FIRST_NAME.ToUpper() + " " + dr.MIDDLE_NAME
                End If

                ' If rank is provided - fill the Paygrade
                If Not String.IsNullOrEmpty(dr.RANK) Then
                    For Each rankgrade As String In RankToGrade
                        If rankgrade.Contains(dr.RANK.Trim()) Then
                            dr.PAY_GR = rankgrade.Substring(6).Trim()
                            Exit For
                        End If
                    Next
                End If
            Next
        End If

    End Sub


    Private Sub Convert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Convert.Click
        ' Start converting data into ID_CARDS format
        Dim id_card As New IDCardData()
        Dim id_row As ID_CARDS_DataSet.ID_CARDSRow

        Me.Validate()

        For Each dr As CSMR_ID_DataSet.CSMR_IDRow In CSMR_ID_DataSet.CSMR_ID
            With id_card
                .DOB = dr.DOB
                .Address = dr.H_ADDR + VB.vbCrLf + dr.H_CITY + ", CA " + dr.H_ZIP
                .FirstName = dr.FIRST_NAME
                .IssueDate = Date.Today()
                .ExpirationDate = .IssueDate.AddYears(3)
                .LastName = dr.LAST_NAME.ToUpper()
                .MI = dr.MIDDLE_NAME.ToUpper()
                .PayGrade = dr.PAY_GR.ToUpper()
                .Rank = dr.RANK
                .Sex = dr.GENDER.ToUpper()
                .SSN = dr.SSN.ToString("000-00-0000")
                .IdNumber = "CAB01-" + "0001AB"

                ' See if photo exists - use LAST nams, then LAST_FIRST, then FIRST_LAST
                Dim CurrDir As String = IO.Path.GetDirectoryName(CSMR_ID_OpenFileDialog.FileName())
                Dim FileName As String = IO.Path.Combine(CurrDir, .LastName) + ".jpg"
                If Not IO.File.Exists(FileName) Then
                    FileName = IO.Path.Combine(CurrDir, .LastName) + ".jpeg"
                End If
                If Not IO.File.Exists(FileName) Then
                    FileName = IO.Path.Combine(CurrDir, .LastName) + "_" + .FirstName + ".jpg"
                End If
                If Not IO.File.Exists(FileName) Then
                    FileName = IO.Path.Combine(CurrDir, .LastName) + "_" + .FirstName + ".jpeg"
                End If
                If Not IO.File.Exists(FileName) Then
                    FileName = IO.Path.Combine(CurrDir, .FirstName) + "_" + .LastName + ".jpg"
                End If
                If Not IO.File.Exists(FileName) Then
                    FileName = IO.Path.Combine(CurrDir, .FirstName) + "_" + .LastName + ".jpeg"
                End If

                If IO.File.Exists(FileName) Then
                    Dim fi As IO.FileInfo = New IO.FileInfo(FileName)
                    Dim stream As New IO.FileStream(FileName, IO.FileMode.Open)
                    Dim photo(fi.Length) As Byte
                    stream.Read(photo, 0, fi.Length())
                    .Photo = photo
                End If
            End With


            id_row = ID_CARDS_DataSet.ID_CARDS.NewID_CARDSRow()
            With id_row
                .H_Address = dr.H_ADDR
                .H_City = dr.H_CITY
                .H_ZIP = dr.H_ZIP
                .Address = id_card.Address

                .DOB = id_card.DOB
                .FirstName = id_card.FirstName
                .LastName = id_card.LastName
                .MI = id_card.MI

                .IssueDate = id_card.IssueDate
                .ExpirationDate = id_card.ExpirationDate

                .PayGrade = id_card.PayGrade
                .Rank = id_card.Rank

                .Sex = id_card.Sex
                .SSN = id_card.SSN

                .IDNumber = id_card.IdNumber
                .SerialNumber = id_card.SerialNumber

                .AAMVAMAG = ""
                .AAMVAPDF = ""
                .CACPDF = ""
                .AAMVACode39 = ""
                .CACCode39 = ""
                .Photo = id_card.Photo.Clone()
            End With
            ID_CARDS_DataSet.ID_CARDS.AddID_CARDSRow(id_row)
        Next
        TabControl_ID.TabPages(0).Hide()
        TabControl_ID.TabPages(1).Show()
        TabControl_ID.SelectTab(1)
    End Sub

    Private Sub Button_CreateDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CreateDB.Click

        Dim id_card As New IDCardData()

        Me.Validate()

        Support.CreateAccessDatabase("c:\AA.mdb")
        Me.ID_CARDSTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "c:\AA.mdb"
        Me.ID_CARDSTableAdapter.Connection.Open()

        For Each dr As ID_CARDS_DataSet.ID_CARDSRow In ID_CARDS_DataSet.ID_CARDS
            With id_card
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
            End With
            ' Update all MAG and PDF field
            dr.AAMVAMAG = Support.EncodeAAMVAMagData(id_card)
            dr.AAMVAPDF = Support.EncodeAAMVAPDF417Data(id_card)
            dr.CACPDF = Support.EncodeCACPDF417Data(id_card)
            With dr
                Me.ID_CARDSTableAdapter.Insert(.IDNumber, .LastName, .FirstName, .MI, _
                                               .DOB, .SSN, .Address, .H_Address, .H_City, .H_ZIP, _
                                               .IssueDate, .ExpirationDate, .Photo, .Hair, .Eyes, _
                                               .BloodType, .Rank, .PayGrade, .Height, .Weight, .DLData, _
                                               .Sex, .SerialNumber, .CACPDF, .AAMVAPDF, .AAMVAMAG, _
                                               .AAMVACode39, .CACCode39)
            End With
        Next
        Me.ID_CARDSTableAdapter.Connection.Close()
    End Sub

    Private Sub RANKComboBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RANKComboBox.SelectedValueChanged, RANKComboBox.SelectionChangeCommitted

        For Each rankgrade As String In RankToGrade
            If rankgrade.Contains(RANKComboBox.Text) Then
                PAY_GRTextBox.Text = rankgrade.Substring(6)
                PAY_GRTextBox.Modified = True
                Exit For
            End If
        Next
    End Sub

    Private Sub TextBoxNotEmpty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LAST_NAMETextBox.Validating, SSNTextBox.Validating, NAME_INDTextBox.Validating, H_ADDRTextBox.Validating, GENDERTextBox.Validating, FIRST_NAMETextBox.Validating, WeightTextBox.Validating, SSNTextBox1.Validating, LastNameTextBox.Validating, HeightTextBox.Validating, SexTextBox.Validating, SerialNumberTextBox.Validating, PayGradeTextBox.Validating, IDNumberTextBox.Validating, FirstNameTextBox.Validating, DLDataTextBox.Validating, AddressTextBox.Validating, RANKComboBox.Validating, RankComboBox_ID.Validating, HairComboBox.Validating, EyesComboBox.Validating
        Dim wc As Windows.Forms.Control = CType(sender, Windows.Forms.Control)
        If String.IsNullOrEmpty(wc.Text) Then
            Form_error.SetError(sender, "Cannot be empty")
            e.Cancel = True
        Else
            Form_error.SetError(sender, String.Empty)
        End If
    End Sub

    Private Sub RankComboBox_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RankComboBox_ID.SelectedIndexChanged, RankComboBox_ID.SelectedValueChanged
        For Each rankgrade As String In RankToGrade
            If rankgrade.Contains(RankComboBox_ID.Text) Then
                PayGradeTextBox.Text = rankgrade.Substring(6)
                PayGradeTextBox.Modified = True
                Exit For
            End If
        Next
    End Sub
End Class
