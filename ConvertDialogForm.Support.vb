Imports System.Text.RegularExpressions
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
    Private Shared Ranks As New List(Of String)

    Private Sub InitLists()
        ' Populate the Ranks list to be used in comboBoxes
        For Each rankgrade As String In RankToGrade
            Ranks.Add(rankgrade.Substring(0, 6))
        Next

        RANKComboBox.DataSource = Ranks
        HairComboBox.DataSource = HairColors
        EyesComboBox.DataSource = EyesColors
        RankComboBox_ID.DataSource = Ranks
        BloodTypeComboBox.DataSource = BloodTypes

    End Sub

    Private Sub CheckInputRecords()
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

            ' If NAME_IND is not provided - make it
            If dr.IsNAME_INDNull And _
                Not (dr.IsFIRST_NAMENull AndAlso dr.IsLAST_NAMENull) Then
                dr.NAME_IND = dr.LAST_NAME.ToUpper() + ", " + dr.FIRST_NAME.ToUpper() + " " + dr.MIDDLE_NAME
            End If

            ' Rank cannot be Null
            If dr.IsRANKNull Then
                dr.RANK = String.Empty
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

    Private Function MakeIDNumber(ByVal data As IDCardData) As String
        Dim hash As New System.Security.Cryptography.HMACSHA256(System.Text.Encoding.UTF8.GetBytes("Sollecon, Inc. 2013 - Oleg Sherbakov"))
        hash.Initialize()
        Dim BattleRosterNum = data.LastName.ToUpper().Substring(0, 1) + data.SSN.Substring(data.SSN.Length() - 4, 4)
        BattleRosterNum += Date.Today.Year.ToString()
        Dim idn() As Byte = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(BattleRosterNum))
        Dim byte_result() As Byte = {idn(5), idn(0), idn(1), idn(11)}
        Dim int_result As UInt32 = BitConverter.ToUInt32(byte_result, 0)
        Return IssuingStation.Text + "-" + "CSMR" + (int_result Mod 100000000).ToString("D00000000")
    End Function

End Class