Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic



Public Class ConvertDialogForm
    ' Regex to extract the First, Last names from the comma-separated list
    Private Shared np_rx As New Regex("\s*(?<LN>[a-zA-Z]+)\s*(,|\s+)\s*(?<FN>[a-zA-Z]+)\s*(,*|\s+)\s*(?<MI>[a-zA-Z]*)", _
                                      RegexOptions.Compiled Or RegexOptions.IgnoreCase)


    Private Sub ConvertDialogForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.InitLists()

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

    End Sub


    Private Sub Convert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Convert.Click
        ' Start converting data into ID_CARDS format
        Dim id_card As New IDCardData()
        Dim id_row As ID_CARDS_DataSet.ID_CARDSRow

        If Not Me.Validate() Then
            Exit Sub
        End If

        For Each dr As CSMR_ID_DataSet.CSMR_IDRow In CSMR_ID_DataSet.CSMR_ID
            With id_card
                .Address = dr.H_ADDR + VB.vbCrLf + dr.H_CITY + ", CA " + dr.H_ZIP

                .FirstName = dr.FIRST_NAME
                .LastName = dr.LAST_NAME.ToUpper()
                .MI = dr.MIDDLE_NAME.ToUpper()

                .Sex = dr.GENDER.ToUpper()
                .DOB = dr.DOB
                .BloodType = dr.BLOOD_TYPE
                .SSN = dr.SSN.ToString("000-00-0000")

                .Rank = dr.RANK
                .PayGrade = dr.PAY_GR.ToUpper()

                .IssueDate = Date.Today()
                .ExpirationDate = .IssueDate.AddYears(3)

                .Hair = dr.HAIR
                .Eyes = dr.EYES

                .Height = dr.HEIGHT
                .Weight = dr.WEIGHT

                .DLData = dr.DL_NUMBER

                '
                ' See if photo exists - use LAST nams, then LAST_FIRST, then FIRST_LAST
                '
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

                ' Try with a Middle Initial
                If Not IO.File.Exists(FileName) AndAlso Not String.IsNullOrEmpty(.MI) Then
                    FileName = IO.Path.Combine(CurrDir, .FirstName) + "_" + .LastName + "_" + .MI.Substring(0, 1) + ".jpg"
                End If
                If Not IO.File.Exists(FileName) AndAlso Not String.IsNullOrEmpty(.MI) Then
                    FileName = IO.Path.Combine(CurrDir, .FirstName) + "_" + .LastName + "_" + .MI.Substring(0, 1) + ".jpeg"
                End If

                If Not IO.File.Exists(FileName) AndAlso Not String.IsNullOrEmpty(.MI) Then
                    FileName = IO.Path.Combine(CurrDir, .LastName) + "_" + .FirstName + "_" + .MI.Substring(0, 1) + ".jpg"
                End If
                If Not IO.File.Exists(FileName) AndAlso Not String.IsNullOrEmpty(.MI) Then
                    FileName = IO.Path.Combine(CurrDir, .LastName) + "_" + .FirstName + "_" + .MI.Substring(0, 1) + ".jpeg"
                End If

                If IO.File.Exists(FileName) Then
                    Dim fi As IO.FileInfo = New IO.FileInfo(FileName)
                    Dim stream As New IO.FileStream(FileName, IO.FileMode.Open)
                    Dim photo(fi.Length) As Byte
                    stream.Read(photo, 0, fi.Length())
                    .Photo = photo
                    stream.Close()
                    stream = Nothing
                    fi = Nothing
                    photo = Nothing
                End If
            End With
            id_card.IdNumber = MakeIDNumber(id_card)

            id_row = ID_CARDS_DataSet.ID_CARDS.NewID_CARDSRow()
            With id_row
                .Address = id_card.Address
                .H_Address = dr.H_ADDR
                .H_City = dr.H_CITY
                .H_ZIP = dr.H_ZIP

                .DOB = id_card.DOB
                .Sex = id_card.Sex
                .SSN = id_card.SSN
                .BloodType = id_card.BloodType

                .FirstName = id_card.FirstName
                .LastName = id_card.LastName
                .MI = id_card.MI

                .IssueDate = id_card.IssueDate
                .ExpirationDate = id_card.ExpirationDate

                .PayGrade = id_card.PayGrade
                .Rank = id_card.Rank

                .Hair = id_card.Hair
                .Eyes = id_card.Eyes

                .Height = id_card.Height
                .Weight = id_card.Weight

                .IDNumber = id_card.IdNumber
                .SerialNumber = id_card.SerialNumber

                .AAMVAMAG = ""
                .AAMVAPDF = ""
                .CACPDF = ""
                .AAMVACode39 = ""
                .CACCode39 = ""
                .Photo = id_card.Photo
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

        Dim timestamp As Date = Date.Today()

        ID_CARDS_SaveFileDialog.FileName = IO.Path.ChangeExtension("ID_CARDS_" + timestamp.ToString("ddMMMMyyyy"), "mdb")
        If ID_CARDS_SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Support.CreateAccessDatabase(ID_CARDS_SaveFileDialog.FileName)
            Me.ID_CARDSTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ID_CARDS_SaveFileDialog.FileName
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

        End If
    End Sub

    Private Sub RANKComboBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RANKComboBox.SelectedValueChanged, RANKComboBox.SelectedIndexChanged
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
