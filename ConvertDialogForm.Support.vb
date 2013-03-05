﻿Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic

Partial Public Class ConvertDialogForm
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
    Private Shared BloodTypes() As String = {"AB NEG", "AB POS", "A NEG", "A POS", "B NEG", "B POS", "O NEG", "O POS", "UNK"}
    Private Shared Ranks() As String

    ' Regex to extract the First, Last names from the comma-separated list
    Private Shared np_rx As New Regex("\s*(?<LN>[a-zA-Z\-\(\)]+)\s*(,|\s+)\s*(?<FN>[a-zA-Z\-\(\)]+)\s*(,*|\s+)\s*(?<MI>[a-zA-Z\-\(\)]*)", _
                                      RegexOptions.Compiled Or RegexOptions.IgnoreCase)

    Private Sub InitLists()
        ' Populate the Ranks list to be used in comboBoxes
        Dim r As New List(Of String)
        For Each rankgrade As String In RankToGrade
            r.Add(rankgrade.Substring(0, 6))
        Next
        Ranks = r.ToArray()

        RANKComboBox.DataSource = Ranks
        HairComboBox.DataSource = HairColors
        EyesComboBox.DataSource = EyesColors
        RankComboBox_ID.DataSource = Ranks
        BloodTypeComboBox.DataSource = BloodTypes

    End Sub

    Private Sub CheckInputRecords()
        ' We need this TextInfo to do proper capitalizing
        Dim ti As System.Globalization.TextInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo

        ' Do some data checking and formatting
        For Each dr As CSMR_ID_DataSet.CSMR_IDRow In CSMR_ID_DataSet.CSMR_ID

            ' If only NAME_IND is provided - extract it, and populate other fields
            If (dr.IsFIRST_NAMENull OrElse dr.IsLAST_NAMENull) And Not dr.IsNAME_INDNull Then
                Dim m As Match = np_rx.Match(dr.NAME_IND)
                dr.LAST_NAME = m.Groups("LN").Value
                dr.FIRST_NAME = m.Groups("FN").Value
                dr.MIDDLE_NAME = m.Groups("MI").Value
            End If

            ' Make MiddleName Valid
            If dr.IsMIDDLE_NAMENull Then
                dr.MIDDLE_NAME = String.Empty
            End If

            ' Remove all dots from the names and addresses
            dr.MIDDLE_NAME = dr.MIDDLE_NAME.Replace(".", "")
            dr.H_ADDR = dr.H_ADDR.Replace(".", "").Replace(",", "")

            ' Remove NMN (No Middle Name) abbreviation 
            If dr.MIDDLE_NAME.Contains("NMN") Then
                dr.MIDDLE_NAME = String.Empty
            End If

            ' If NAME_IND is not provided - make it
            If dr.IsNAME_INDNull And _
                Not (dr.IsFIRST_NAMENull AndAlso dr.IsLAST_NAMENull) Then
                dr.NAME_IND = dr.LAST_NAME.ToUpper() + ", " + dr.FIRST_NAME.ToUpper() + " " + dr.MIDDLE_NAME.ToUpper()
            End If

            ' Capitalize all letters in the address and First-last  names
            dr.H_ADDR = ti.ToTitleCase(dr.H_ADDR.ToLower())
            dr.H_CITY = ti.ToTitleCase(dr.H_CITY.ToLower())

            dr.FIRST_NAME = ti.ToTitleCase(dr.FIRST_NAME.ToLower())
            dr.LAST_NAME = ti.ToTitleCase(dr.LAST_NAME.ToLower())
            dr.MIDDLE_NAME = ti.ToTitleCase(dr.MIDDLE_NAME.ToLower())

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
                dr.PAY_GR = RankToGrade(0).Substring(6)
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
        Next
    End Sub

    Private Function MakeFullNumber(ByVal Station As String, ByVal SSN As String, ByVal LastName As String) As String
        Return IssuingStation.Text + "-" + MakeIDNumber(SSN, LastName)
    End Function

    Private Function MakeIDNumber(ByVal SSN As String, ByVal LastName As String) As String
        Dim hash As New System.Security.Cryptography.HMACSHA256(System.Text.Encoding.UTF8.GetBytes("California State Military Reserve"))
        hash.Initialize()
        Dim BattleRosterNumber As String = LastName.ToUpper().Substring(0, 1) + SSN.Substring(SSN.Length() - 4, 4)
        Dim idn() As Byte = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(BattleRosterNumber))
        Dim byte_result1() As Byte = {idn(5), idn(0), idn(1), idn(11)}
        Dim byte_result2() As Byte = {idn(15), idn(3), idn(22), idn(19)}
        Dim int_result As UInt32 = BitConverter.ToUInt32(byte_result1, 0)
        int_result = int_result Xor BitConverter.ToUInt32(byte_result2, 0)
        Return (int_result Mod 100000000).ToString("D8")
    End Function

    Private Function MakeSerial() As String
        Dim g() As Byte = Guid.NewGuid.ToByteArray()
        Dim int_result As UInt32 = BitConverter.ToUInt32(g, 0)
        int_result = int_result Xor BitConverter.ToUInt32(g, 4)
        int_result = int_result Xor BitConverter.ToUInt32(g, 8)
        int_result = int_result Xor BitConverter.ToUInt32(g, 12)
        Return (int_result Mod 10000000000).ToString("D10")
    End Function

    Private Function GetImageFile(ByVal LastName As String, ByVal FirstName As String, ByVal MI As String) As Byte()
        '
        ' See if photo exists - use LAST nams, then LAST_FIRST, then FIRST_LAST
        '
        Dim FileFound As Boolean = False
        Dim CurrDir As String = IO.Path.GetDirectoryName(CSMR_ID_OpenFileDialog.FileName())
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
            Dim stream As New IO.FileStream(FileName, IO.FileMode.Open)
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