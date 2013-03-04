Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic



Public Class ConvertDialogForm

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
            End With

            ID_CARDS_DataSet.ID_CARDS.AddID_CARDSRow(id_row)
            ProgressBar1.PerformStep()
        Next
        TabControl_ID.TabPages(0).Hide()
        TabControl_ID.TabPages(1).Show()
        TabControl_ID.SelectTab(1)
    End Sub

    Private Sub Button_CreateDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CreateDB.Click

        Me.Validate()

        ID_CARDS_SaveFileDialog.FileName = IO.Path.ChangeExtension("ID_CARDS_" + Date.Today().ToString("ddMMMMyyyy"), "mdb")
        If ID_CARDS_SaveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Support.CreateAccessDatabase(ID_CARDS_SaveFileDialog.FileName)
            Me.ID_CARDSTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ID_CARDS_SaveFileDialog.FileName
            Me.ID_CARDSTableAdapter.Connection.Open()

            For Each dr As ID_CARDS_DataSet.ID_CARDSRow In ID_CARDS_DataSet.ID_CARDS
                Dim card_data As New IDCardData()
                With card_data
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
End Class
