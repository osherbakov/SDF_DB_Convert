Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Text
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic

Public Class FullSupport

    Private Shared MonthAbbrev As String() = New String() _
        {"UNK", "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"}

    Public Shared Function MonthToString(ByVal nMonth As Integer) As String
        Return MonthAbbrev(nMonth)
    End Function


    Private Shared BinB32Table As String = "0123456789ABCDEFGHIJKLMNOPQRSTUV"

    ' FUNCTION: Convert Binary to Base 32 
    ' PURPOSE: To convert binary to ASCII string representing a Base 32 number
    Public Shared Function BintoB32(ByVal Bin As Double, Optional ByVal Length As Integer = 0) As String
        Dim res As String = String.Empty
        Dim reminder As Double
        Dim quotient As Double
        Bin = Math.Abs(Math.Floor(Bin))
        Do
            quotient = Bin \ 32
            reminder = Bin - (quotient * 32)
            res = BinB32Table(reminder) & res
            Bin = quotient
            Length -= 1
        Loop Until (Length = 0) Or ((Length < 0) AndAlso (Bin = 0))
        Return res
    End Function

    ' FUNCTION: Convert Base 32 to Binary
    ' PURPOSE: To convert ASCII string representing a Base 32 number to binary
    ' ARGUMENTS:
    ' B32: A k-digit Base 32 number string (range of digits: 0-V)
    ' RETURN B32: A binary integer, or –1 for an error
    Public Shared Function B32toBin(ByVal B32 As String) As Double
        Dim BinNr As Double
        Dim B32Chr As Integer
        BinNr = 0 ' Clear binary accumulator
        For Each iChr As Char In B32
            B32Chr = BinB32Table.IndexOf(iChr)
            If B32Chr <> -1 Then
                BinNr = BinNr * 32 + B32Chr ' Shift accumulator 5 bits left and add new 5-bit digit
            End If
        Next
        Return BinNr
    End Function

    Public Shared Function Date_to_Days(ByVal vDate As Date) As Long
        Dim mo As Integer = vDate.Month     ' Get a month  
        Dim da As Integer = vDate.Day       ' ... Day   
        Dim yr As Integer = vDate.Year      '     year
        Dim ce As Integer = yr \ 100        '  and a century...
        yr = yr Mod 100
        If mo > 2 Then
            mo -= 3
        Else
            mo += 9
            If yr = 0 Then
                yr -= 1
            Else
                yr = 99
                ce -= 1
            End If
        End If
        ' To be honest  -  I have no clue what is going on, but that 's how it was in a standard...
        Return ((146097L * ce) / 4L + _
                (1461L * yr) / 4L + _
                (153L * mo + 2L) / 5L + _
                           da + 1721119L)
    End Function

    '******************************************************************************************************************
    ' FUNCTION: Days_to_Date
    ' SYNOPSIS: Converts a number of days since some distant but unspecified epoch into a date. You can
    ' use this function to calculate differences between dates, and forward dates. Use date_to_days() to
    ' calculate the reverse function. Author: Robert G. Tantzen, translated from the Algol original in
    ' Collected Algorithms of the CACM (algorithm 199). Original translation into C by Nat Howard,
    ' posted to Usenet 5 Jul 1985.
    ' --------------------------------------------------------------------------------------------------------------------------------
    ' SOURCE: Extracted from Standard Function Library (SFL) -- Date and time functions
    ' NAME: sfldate.h / sfldate.c WRITTEN: 1996/01/06 REVISED: 2000/01/19
    ' AUTHOR: iMatix SFL project team sfl@imatix.com
    ' Copyright: Copyright (c) 1996-2000 iMatix Corporation
    ' LICENSE: This is free software; you can redistribute it and/or modify it under the terms of the
    ' SFL License Agreement as provided in the file LICENSE.TXT. This software is distributed
    ' in the hope that it will be useful, but without any warranty.
    '******************************************************************************************************************
    Public Shared Function Days_to_Date(ByVal days As Long) As Date
        Dim century As Long, year As Long, month As Long, day As Long
        days = days - 1721119 ' 1/1/0001 AD/CE
        century = (4 * days - 1) \ 146097
        days = 4 * days - 1 - 146097 * century
        day = days \ 4
        year = (4 * day + 3) \ 1461
        day = 4 * day + 3 - 1461 * year
        day = (day + 4) \ 4
        month = (5 * day - 3) \ 153
        day = 5 * day - 3 - 153 * month
        day = (day + 5) \ 5
        If (month < 10) Then
            month = month + 3
        Else
            month = month - 9
            If (year + 1 = 99) Then
                year = 0
                century = century + 1
            End If
        End If  ' 
        Return New Date((century * 100) + year, month, day) ' YYYYMMDD
    End Function

    ' Index in that string is equal to the binary encoding for that character
    Private Shared PDF417LetterCode As String = "ABCDEFabcdefghijklmnopqrstuvwxyz"

    ' Index in that string will reference the appropriate bit-mask for the symbol
    Private Shared PDF417SymbolCode As String = " *+-"
    Private Shared PDF417SymbolValue As Integer() = {&H4000000, &H2000001, &H1200FF54, &H1307E8A4}

    Public Shared Function PDFTranString(ByVal AlphaString As String) As String()
        Dim ret As New Collections.Specialized.StringCollection()
        Dim idx As Integer
        Dim iSymb As Integer
        Dim sLine As String = String.Empty

        For Each iCh As Char In AlphaString
            iSymb = 0

            idx = PDF417LetterCode.IndexOf(iCh)
            If idx <> -1 Then
                iSymb = idx + &H5000000
            End If

            idx = PDF417SymbolCode.IndexOf(iCh)
            If idx <> -1 Then
                iSymb = PDF417SymbolValue(idx)
            End If

            If iCh = Chr(10) Then
                ret.Add(sLine)
                sLine = String.Empty
            End If

            If iSymb <> 0 Then
                Dim NumBits = (iSymb >> 24) And &HFF
                Dim sChar As String = String.Empty
                For i As Integer = 1 To NumBits
                    If iSymb And &H1 Then
                        sChar = "1" + sChar
                    Else
                        sChar = "0" + sChar
                    End If
                    iSymb >>= 1
                Next
                sLine += sChar
            End If
        Next
        If sLine <> String.Empty Then ret.Add(sLine)
        Dim result(ret.Count - 1) As String
        ret.CopyTo(result, 0)
        Return result
    End Function

    Public Shared Function RenderSymbolBitmap(ByVal Dims As Size, ByVal Data() As String, ByVal XYFactor As Integer, _
            ByVal Orientation As Integer, ByVal BkgrBrush As Brush, ByVal OneBrush As Brush, ByVal ZeroBrush As Brush) As System.Drawing.Bitmap

        Dim bm As New Bitmap(Dims.Width, Dims.Height, Imaging.PixelFormat.Format32bppArgb)
        Dim gr As Graphics = Graphics.FromImage(bm)
        gr.FillRectangle(BkgrBrush, 0, 0, bm.Width, bm.Height)

        Dim x, y As Integer         ' Current running values
        Dim Nx, Ny As Integer       ' Number of elements in X and Y
        Dim xbeg, ybeg As Integer   ' Beginning of the drawing
        Dim dx, dy As Integer       ' Steps in X and Y directions
        Dim xdim, ydim As Integer   ' Dimensions of the drawing in X and Y directions
        Dim angle As Double

        ' Calculate how many pixels will have a minimal bitmap 
        Nx = Data(0).Length : Ny = Data.Length

        gr.SmoothingMode = SmoothingMode.None
        gr.PixelOffsetMode = PixelOffsetMode.None
        gr.InterpolationMode = InterpolationMode.NearestNeighbor

        ' If XYFactor < 0 - stretch image to the target rectangle
        If XYFactor < 0 Then
            Using bms As Bitmap = New Bitmap(Nx, Ny, Imaging.PixelFormat.Format32bppArgb)
                Using grs As Graphics = Graphics.FromImage(bms)
                    For Each iRow As String In Data
                        If String.IsNullOrEmpty(iRow) Then Continue For
                        x = 0
                        For Each iCol As Char In iRow
                            If iCol = "1"c Then
                                grs.FillRectangle(OneBrush, x, y, 1, 1)
                            Else
                                grs.FillRectangle(ZeroBrush, x, y, 1, 1)
                            End If
                            x += 1
                        Next
                        y += 1
                    Next
                End Using
                Select Case Orientation
                    Case 0
                    Case 90
                        bms.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    Case 180
                        bms.RotateFlip(RotateFlipType.Rotate180FlipNone)
                    Case 270
                        bms.RotateFlip(RotateFlipType.Rotate270FlipNone)
                End Select
                gr.DrawImage(bms, bm.GetBounds(GraphicsUnit.Pixel), bms.GetBounds(GraphicsUnit.Pixel), GraphicsUnit.Pixel)
            End Using
        Else
            angle = (2 * Math.PI * Orientation) / 360

            xdim = Math.Abs(bm.Width * Math.Cos(angle) + bm.Height * Math.Sin(angle))
            ydim = Math.Abs(bm.Height * Math.Cos(angle) + bm.Width * Math.Sin(angle))

            ' Calculate ratio of sides for the target bitmap
            dx = xdim \ Nx : dy = ydim \ Ny

            ' If XYFactor == 0 - just fit image inside the target rectangle
            If XYFactor <> 0 Then
                If (dx * XYFactor) > dy Then
                    dx = dy / XYFactor
                Else
                    dy = dx * XYFactor
                End If
            End If
            ' Center of Coordinates will be in the middle of the rectangle 
            xbeg = -(dx * Nx) / 2
            ybeg = -(dy * Ny) / 2

            gr.TranslateTransform(bm.Width / 2, bm.Height / 2)
            gr.RotateTransform(Orientation)

            y = ybeg
            For Each iRow As String In Data
                If String.IsNullOrEmpty(iRow) Then Continue For
                x = xbeg
                For Each iCol As Char In iRow
                    If iCol = "1"c Then
                        gr.FillRectangle(OneBrush, x, y, dx, dy)
                    Else
                        gr.FillRectangle(ZeroBrush, x, y, dx, dy)
                    End If
                    x += dx
                Next
                y += dy
            Next
        End If

        gr.Dispose()
        Return bm
    End Function

    Private Shared RefDate As New Date(1000, 1, 1)

    Private Shared rxCACver1 As New Regex _
        ("1(?<SSN>.{6})[NSPDFT](?<ID>.{7})(?<FName>.{20})(?<LName>.{26})(?<DOB>.{4})....(?<Rank>.{6})(?<Pay>.{4})(?<Issued>.{4})(?<Expires>.{4}).", RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Compiled)

    Private Shared rxCACverN As New Regex _
        ("N(?<SSN>.{6})[NSPDFT](?<ID>.{7})(?<FName>.{20})(?<LName>.{26})(?<DOB>.{4})....(?<Rank>.{6})(?<Pay>.{4})(?<Issued>.{4})(?<Expires>.{4}).(?<MI>.)", RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Compiled)
    Public Shared Function DecodeCACPDF417Data(ByRef idCard As IDCardData, ByVal scannedData As String) As Boolean
        Dim ret As Boolean = False
        Dim rm As Match = rxCACverN.Match(scannedData)
        If rm.Success Then
            idCard.MI = rm.Groups("MI").Value
            ret = True
        Else
            rm = rxCACver1.Match(scannedData)
            If rm.Success Then
                idCard.MI = ""
                ret = True
            End If
        End If
        If ret Then
            With idCard
                .SSN = String.Format("{0:###-##-####}", B32toBin(rm.Groups("SSN").Value))
                .IdNumber = B32toBin(rm.Groups("ID").Value)
                ' Check if license has special encoding for A, B < c so 01 = A, 02 = B, 03 = C and so on.....
                If (.IdNumber(0) = "0"c) Or (.IdNumber(0) = "1"c) Then
                    Dim sFirstChar As String = .IdNumber.Substring(0, 2)
                    Dim nFirstChar As Integer = Integer.Parse(sFirstChar) + Convert.ToInt32("A"c) - 1
                    .IdNumber = Convert.ToChar(nFirstChar) + .IdNumber.Substring(2)
                End If
                .FirstName = rm.Groups("FName").Value.Trim()
                .LastName = rm.Groups("LName").Value.Trim
                .DOB = RefDate.AddDays(B32toBin(rm.Groups("DOB").Value))
                .Rank = rm.Groups("Rank").Value.Trim
                .PayGrade = rm.Groups("Pay").Value.Trim
                .IssueDate = RefDate.AddDays(B32toBin(rm.Groups("Issued").Value))
                .ExpirationDate = RefDate.AddDays(B32toBin(rm.Groups("Expires").Value))
                .DLData = .IdNumber
            End With
        End If

        Return ret
    End Function



    Public Shared Function EncodeCACPDF417Data(ByVal data As IDCardData) As String
        Dim Result As String = String.Empty
        Dim txt As String
        Dim Num As Double

        If data Is Nothing Then Return String.Empty

        ' Start with the Code version - currently it is N
        Result += "N"

        ' Second field - encoded SSN, 6 chars
        Num = ExtractNumber(data.SSN)
        Result += BintoB32(Num, 6)

        ' Designator code - S - Social Security
        Result += "S"

        ' Person DEERS Code - get it from DL
        Dim IDNumber As String = ExtractIDNumber(data)
        Num = ExtractNumber(IDNumber)
        Result += BintoB32(Num, 7)

        ' First name limited and/or padded to 20 chars
        txt = data.FirstName.PadRight(20, " "c).Substring(0, 20)
        Result += txt

        ' Last name limited and/or padded to 26 chars
        txt = data.LastName.PadRight(26, " "c).Substring(0, 26)
        Result += txt

        ' Date of birth - in days, encoded
        txt = BintoB32((data.DOB - RefDate).TotalDays, 4)
        Result += txt

        ' Category - Y - service affiliate
        Result += "Y"

        ' Branch code - X - other
        Result += "X"

        ' Entitlements - PECT - 08 - other 
        Result += "08"

        ' Rank - padded to 6
        txt = data.Rank.ToUpper.PadRight(6, " "c).Substring(0, 6)
        Result += txt

        ' Payplan Code and Grade - 4 chars (2 for code + 2 for grade)
        If data.PayGrade.Length = 3 Then
            txt = data.PayGrade(0) + " " + data.PayGrade(2) + " "
        Else
            txt = data.PayGrade.PadRight(4).Substring(0, 4)
        End If
        Result += txt.ToUpper

        ' Card issue date - in days, encoded
        txt = BintoB32((data.IssueDate - RefDate).TotalDays, 4)
        Result += txt

        ' Card expiration date - in days, encoded
        txt = BintoB32((data.ExpirationDate - RefDate).TotalDays, 4)
        Result += txt

        ' Issue ID - initially 0
        txt = "0"
        Result += txt

        ' Middle initial
        txt = data.MI.PadRight(1, " "c).Substring(0, 1).ToUpper
        Result += txt

        Return Result.ToUpper()
    End Function


    Private Shared rxANSIHeader As New Regex("@(?<DS>.)(?<RS>.)(?<SR>.)ANSI \d{6}....(?<NSub>\d\d)", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Compiled)
    Private Shared rxSubfileHeader As New Regex("(?<ID>..)(?<Offset>\d{4})(?<Length>\d{4})", RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Compiled)
    Private Shared ElementTemplate As String = "{0}(?<Data>.*?)\u{1:X0004}"

    Public Shared Function IsValidAAMVAFile(ByVal scannedString As String) As Boolean
        Return rxANSIHeader.Match(scannedString).Success
    End Function

    Public Shared Function ExtractAAMVATag(ByVal scannedString As String, ByVal subFile As String, ByVal requestedTag As String) As String
        Dim ret As String = ""
        ' First find the header and extract delimiters
        Dim DS, RS, SR As String
        Dim NSub As Integer
        Dim offset, length As Integer
        Dim Found As Boolean


        Dim rm As Match = rxANSIHeader.Match(scannedString)
        If rm.Success Then
            DS = rm.Groups("DS").Value
            RS = rm.Groups("RS").Value
            SR = rm.Groups("SR").Value
            NSub = Integer.Parse(rm.Groups("NSub").Value)

            Found = False
            Dim sm As Match = rxSubfileHeader.Match(scannedString, rm.Length, NSub * 10)
            While sm.Success AndAlso Not Found
                If sm.Groups("ID").Value = subFile Then
                    offset = Integer.Parse(sm.Groups("Offset").Value)
                    length = Integer.Parse(sm.Groups("Length").Value)
                    Found = True
                End If
                sm = sm.NextMatch()
            End While
            If Not Found Then Return ret

            ' OK, the subfile is found. Now create a regex string to parse this subfile
            Dim rxStr As String = String.Format(ElementTemplate, requestedTag, Convert.ToUInt32(DS(0)))
            Dim rxElement As Regex = New Regex(rxStr, RegexOptions.IgnoreCase Or RegexOptions.Singleline)

            'Extra check if the subfile has it's tag in the beginning
            If scannedString.Substring(offset, subFile.Length) <> subFile Then Return ret
            Dim em As Match = rxElement.Match(scannedString, offset + subFile.Length, length)
            If em.Success Then ret = em.Groups("Data").Value
        End If
        Return ret.Trim
    End Function

    Private Shared Function DecodeDate(ByVal StringDate As String) As Date
        Dim Year As String
        Dim Mo As String
        Dim Day As String
        Dim Num As Double
        Dim result As New Date(1900, 1, 1)

        If Double.TryParse(StringDate, Num) Then
            Year = Num Mod 10000
            Day = (Num \ 10000) Mod 100
            Mo = (Num \ 1000000) Mod 100
            If (Year < Now.Year - 80) OrElse (Year > Now.Year + 80) Then
                Year = (Num \ 10000) Mod 10000
                Day = (Num) Mod 100
                Mo = (Num \ 100) Mod 100
            End If
            result = New Date(Year, Mo, Day)
        End If
        Return result
    End Function

    Private Shared Function EncodeDate(ByVal DateToConvert As Date) As String
        Dim Year As String
        Dim Mo As String
        Dim Day As String

        Year = DateToConvert.Year.ToString("D04")
        Mo = DateToConvert.Month.ToString("D02")
        Day = DateToConvert.Day.ToString("D02")
        Return Mo + Day + Year
    End Function

    Public Shared Function DecodeAAMVAPDF417Data(ByRef idCard As IDCardData, ByVal scannedString As String) As Boolean
        Dim ret As Boolean = False
        Try
            If Not IsValidAAMVAFile(scannedString) Then Return ret

            With idCard
                .IdNumber = ExtractAAMVATag(scannedString, "DL", "DAQ")
                .DLData = .IdNumber
                .LastName = ExtractAAMVATag(scannedString, "DL", "DCS")
                .FirstName = ExtractAAMVATag(scannedString, "DL", "DCT")
                Dim names() As String = .FirstName.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
                If names.Length > 1 Then
                    .FirstName = names(0)
                    .MI = names(1)
                End If
                .Sex = ExtractAAMVATag(scannedString, "DL", "DBC")
                If .Sex = "1"c Then .Sex = "M"c
                If .Sex = "2"c Then .Sex = "F"c
                .Eyes = ExtractAAMVATag(scannedString, "DL", "DAY")
                .Hair = ExtractAAMVATag(scannedString, "DL", "DAZ")

                .Address = ExtractAAMVATag(scannedString, "DL", "DAG") & VB.vbCrLf & _
                    ExtractAAMVATag(scannedString, "DL", "DAI") & ", " & _
                    ExtractAAMVATag(scannedString, "DL", "DAJ") & " " & ExtractAAMVATag(scannedString, "DL", "DAK")

                .SSN = String.Format("{0:000-00-0000}", B32toBin(ExtractAAMVATag(scannedString, "ZC", "ZCN")))

                .Rank = ExtractAAMVATag(scannedString, "ZC", "ZCO")
                .PayGrade = ExtractAAMVATag(scannedString, "ZC", "ZCP")
                .BloodType = ExtractAAMVATag(scannedString, "ZC", "ZCQ")

                .ExpirationDate = DecodeDate(ExtractAAMVATag(scannedString, "DL", "DBA"))
                .DOB = DecodeDate(ExtractAAMVATag(scannedString, "DL", "DBB"))
                .IssueDate = DecodeDate(ExtractAAMVATag(scannedString, "DL", "DBD"))

                .Height = ExtractAAMVATag(scannedString, "DL", "DAU").Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)(0)
                .Weight = ExtractAAMVATag(scannedString, "DL", "DAW").Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)(0)
            End With
            If Not String.IsNullOrEmpty(idCard.LastName) Then ret = True
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Public Shared Function EncodeAAMVAPDF417Data(ByVal Data As IDCardData) As String
        Dim Subf1 As New StringBuilder()
        Dim Subf2 As New StringBuilder()
        Dim result As New StringBuilder()

        Dim Streets(), Street, City, ZIP As String
        Dim tm As Match

        Dim ht As Integer

        ' Start building DL Subfile
        With Data
            Subf1.Append("DL")
            Subf1.Append("DAQ" + ExtractIDNumber(Data) + VB.vbLf)
            Subf1.Append("DAA" + .LastName)
            If Not String.IsNullOrEmpty(.FirstName) Then Subf1.Append(", " + .FirstName)
            If Not String.IsNullOrEmpty(.MI) Then Subf1.Append(", " + .MI)
            Subf1.Append(VB.vbLf)
            Subf1.Append("DCS" + .LastName + VB.vbLf)
            Subf1.Append("DCT" + .FirstName)
            If Not String.IsNullOrEmpty(.MI) Then
                Subf1.Append(" " + .MI)
            End If
            Subf1.Append(VB.vbLf)

            Subf1.Append("DBC" + .Sex + VB.vbLf)
            Subf1.Append("DAY" + .Eyes + VB.vbLf)
            Subf1.Append("DAZ" + .Hair + VB.vbLf)
            Subf1.Append("DCG" + "USA" + VB.vbLf)

            Subf1.Append("DBA" + EncodeDate(.ExpirationDate) + VB.vbLf)
            Subf1.Append("DBB" + EncodeDate(.DOB) + VB.vbLf)
            Subf1.Append("DBD" + EncodeDate(.IssueDate) + VB.vbLf)

            Streets = .Address.Split(New Char() {VB.vbCr, VB.vbLf}, StringSplitOptions.RemoveEmptyEntries)
            Street = ""
            City = String.Empty
            ZIP = New String(" ", 11)

            If Streets.Length = 2 Then
                Street = Streets(0).Trim
                tm = rxCityStateZip.Match(Streets(1))
                City = tm.Groups("City").Value
                ZIP = ""
                For Each iCh As Char In tm.Groups("ZIP").Value
                    If Char.IsLetterOrDigit(iCh) Then
                        ZIP += iCh
                    End If
                Next
                If ZIP.Length < 9 Then ZIP = ZIP.PadRight(9, "0"c)
                ZIP = ZIP.PadRight(11).Substring(0, 11)
            End If
            Subf1.Append("DAG" + Street + VB.vbLf)
            Subf1.Append("DAI" + City + VB.vbLf)
            Subf1.Append("DAJ" + "CA" + VB.vbLf)

            Subf1.Append("DAK" + ZIP + VB.vbLf)
            ht = 70
            If Integer.TryParse(.Height, ht) Then
                If ht > 100 Then
                    ht = (ht \ 100) * 12 + (ht Mod 100)
                End If
            End If
            Subf1.Append("DAU" + ht.ToString("D03") + " IN" + VB.vbLf)
            Subf1.Append("DAW" + .Weight + " LB" + VB.vbLf)
            Subf1.Append("DCF" + .IdNumber + "/" + .SerialNumber + VB.vbLf)
            Subf1.Append(VB.vbCr)

            ' Start second subfile
            Subf2.Append("ZC")
            Subf2.Append("ZCM" + "CSMR" + VB.vbLf)
            Dim SSN As Double = ExtractNumber(.SSN)
            Subf2.Append("ZCN" + BintoB32(SSN, 6) + VB.vbLf)
            Subf2.Append("ZCO" + .Rank + VB.vbLf)
            Subf2.Append("ZCP" + .PayGrade + VB.vbLf)
            Subf2.Append("ZCQ" + .BloodType + VB.vbLf)

            Subf2.Append(VB.vbCr)

            Dim nSubFields As Integer = 2
            Dim SubfieldStart As Integer = 0

            result.Append("@" + VB.vbLf + Chr(&H1E) + VB.vbCr)
            result.Append("ANSI " + "636014")
            result.Append("0300")       '  Version
            result.Append(nSubFields.ToString("D02"))     ' Number of subfields

            SubfieldStart = result.Length + nSubFields * 10
            result.Append("DL")     ' Subfield DL
            result.Append(SubfieldStart.ToString("D04"))     ' Start
            result.Append(Subf1.Length.ToString("D04"))     ' Size


            SubfieldStart += Subf1.Length
            result.Append("ZC")     ' Subfield ZC
            result.Append(SubfieldStart.ToString("D04"))     ' Start
            result.Append(Subf2.Length.ToString("D04"))     ' Size
            result.Append(Subf1)
            result.Append(Subf2)

        End With
        Return result.ToString.ToUpper
    End Function

    Private Shared rxtrk1 As New Regex("^%(?<State>..)(?<City>.{1,12}\^|.{13})(?<Name>.{1,34}\^|.{35})(?<Street>.{1,28}\^|.{29})", RegexOptions.IgnoreCase Or RegexOptions.Compiled)
    Private Shared rxtrk2 As New Regex("^;(?<CD>.{6})(?<DL>.{1,13})=(?<Year>\d{2})(?<Month>\d{2})(?<DOB>\d{8})", RegexOptions.IgnoreCase Or RegexOptions.Compiled)
    Private Shared rxtrk3 As New Regex("^%..(?<ZIP>.{11})(?<Class>..)(?<Restr>.{10})(?<Endor>.{4})(?<Sex>.)(?<Height>\d{3})(?<Weight>\d{3})(?<Hair>.{3})(?<Eyes>.{3})(?<Fill1>.{12})(?<IDStation>.{4})(?<IssueDate>.{8})(?<Fill2>.{2})(?<SSN>.{6})(?<Rank>.{3})(?<Grade>.{2})", RegexOptions.IgnoreCase Or RegexOptions.Compiled)

    Public Shared Function DecodeAAMVAMagData(ByRef IDData As IDCardData, ByVal track1 As String, ByVal track2 As String, ByVal track3 As String) As Boolean
        Dim Names() As String
        Dim LastN, FirstN, MI As String
        Dim Dob, ExpMonth, ExpYear As Integer
        Dim IssueDate As Integer
        Dim Street(), City, State, ZIP As String
        Dim Height, Weight As Integer
        Dim Hair, Eyes As String
        Dim Sex As String
        Dim IDStation, IDNumber As String

        Dim ret As Boolean = False

        If String.IsNullOrEmpty(track1) OrElse String.IsNullOrEmpty(track2) OrElse String.IsNullOrEmpty(track3) Then Exit Function
        Try
            Dim tm As Match

            ' Process track1
            ' Skip any non-CALIFORNIA card
            tm = rxtrk1.Match(track1)
            State = tm.Groups("State").Value
            If State <> "CA" Then Return False

            City = tm.Groups("City").Value.Split("^")(0)
            Street = tm.Groups("Street").Value.Split(New Char() {"$"c, "^"c})

            Names = tm.Groups("Name").Value.Split(New Char() {"$"c, "^"c})
            LastN = Names(0)
            If Names.Length > 1 Then FirstN = Names(1) Else FirstN = ""
            If Names.Length > 2 Then MI = Names(2) Else MI = ""

            ' Process track2
            tm = rxtrk2.Match(track2)
            IDNumber = tm.Groups("DL").Value
            ' Check if license has special encoding for A, B < c so 01 = A, 02 = B, 03 = C and so on.....
            If (IDNumber(0) = "0"c) Or (IDNumber(0) = "1"c) Then
                Dim sFirstChar As String = IDNumber.Substring(0, 2)
                Dim nFirstChar As Integer = Integer.Parse(sFirstChar) + Convert.ToInt32("A"c) - 1
                IDNumber = Convert.ToChar(nFirstChar) + IDNumber.Substring(2)
            End If
            Dob = CInt(tm.Groups("DOB").Value)
            ExpMonth = CInt(tm.Groups("Month").Value)
            ExpYear = CInt(tm.Groups("Year").Value)

            ' Process track3
            tm = rxtrk3.Match(track3)
            ZIP = tm.Groups("ZIP").Value.Split(New Char() {"$"c, "^"c, " "c})(0)
            If ZIP.Length > 5 Then
                ZIP = ZIP.Substring(0, 5) + "-" + ZIP.Substring(5)
            End If

            Hair = tm.Groups("Hair").Value
            Eyes = tm.Groups("Eyes").Value
            Height = CInt(tm.Groups("Height").Value)
            If (Height > 100) Then
                Height = (Height \ 100) * 12 + (Height Mod 100)
            End If
            Weight = CInt(tm.Groups("Weight").Value)
            Sex = tm.Groups("Sex").Value
            If Sex = "1" Then
                Sex = "M"
            ElseIf Sex = "2" Then
                Sex = "F"
            End If
            IDStation = tm.Groups("IDStation").Value
            IDNumber = IDStation + "-" + IDNumber
            IssueDate = CInt(tm.Groups("IssueDate").Value)

            Dim Grade As String = tm.Groups("Grade").Value
            If (Grade(0) = "O" Or Grade(0) = "E") AndAlso Grade(1) > "1" AndAlso Grade(1) <= "9" Then
                IDData.PayGrade = Grade(0) & " " & Grade(1)
                IDData.Rank = tm.Groups("Rank").Value
                IDData.SSN = String.Format("{0:000-00-0000}", B32toBin(tm.Groups("SSN").Value))
            End If

            With IDData
                Dim Year As Integer = Dob \ 10000
                Dim Month As Integer = (Dob - Year * 10000) \ 100
                Dim Day As Integer = (Dob - Year * 10000 - Month * 100)
                If Month > 12 Then
                    .DOB = New Date(Year, ExpMonth, Day)
                Else
                    .DOB = New Date(Year, Month, Day)
                End If

                ' Now extract the issue date from the 8-digit chunk YYYYMMDD
                Year = IssueDate \ 10000
                Month = (IssueDate - Year * 10000) \ 100
                Day = (IssueDate - Year * 10000 - Month * 100)
                .IssueDate = New Date(Year, Month, Day)

                .ExpirationDate = New Date(2000 + ExpYear, ExpMonth, Math.Min(Date.DaysInMonth(2000 + ExpYear, ExpMonth), Day))

                .Address = ""
                For Each iSt As String In Street
                    .Address += iSt + " "
                Next
                .Address += VB.vbCrLf + City + ", " + State + " " + ZIP
                .LastName = LastN
                .FirstName = FirstN
                .MI = MI
                .Eyes = Eyes
                .Hair = Hair
                .Weight = Weight
                .Height = Height
                .Sex = Sex.Chars(0)
                .IdNumber = IDNumber
            End With
            ret = True
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Public Shared rxCityStateZip As New Regex("\s*(?<City>.+?)\s*,*\s*CA\s*(?<ZIP>\d{5}[- ]\d{4}|\d{9}|\d{5})\s*", RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Compiled)

    Public Shared Sub EncodeAAMVAMagData(ByVal IDData As IDCardData, ByRef track1 As String, ByRef track2 As String, ByRef track3 As String)
        Dim FullName As String
        Dim IDStation, IDNumber As String
        Dim Streets(), Street, City, State, ZIP As String
        Dim Height, Weight As String
        Dim Hair, Eyes As String

        Dim tm As RegularExpressions.Match
        ' 
        ' %CAMOUNTAIN VIEWSHERBAKOV$OLEG$A^1446 WILDROSE WAY^?
        ' ;636014015868735=110219589912?
        ' %!!94043      C 01            M602190BRNGRY            D51820001012  [^&)HL,/ 1(?

        If track1 Is Nothing OrElse track2 Is Nothing OrElse track3 Is Nothing OrElse IDData Is Nothing Then Exit Sub

        Dim strbldr As New StringBuilder()

        State = "CA"
        strbldr.Append(State)
        Streets = IDData.Address.Split(New Char() {VB.vbCr, VB.vbLf}, StringSplitOptions.RemoveEmptyEntries)

        Street = ""
        City = String.Empty
        ZIP = New String(" ", 11)

        If Streets.Length = 2 Then
            Street = Streets(0).Trim
            tm = rxCityStateZip.Match(Streets(1))
            City = tm.Groups("City").Value
            ZIP = ""
            For Each iCh As Char In tm.Groups("ZIP").Value
                If Char.IsLetterOrDigit(iCh) Then
                    ZIP += iCh
                End If
            Next
            ZIP = ZIP.PadRight(11).Substring(0, 11)
        End If
        If City.Length < 13 Then
            City += "^"
        Else
            City = City.Substring(0, 13)
        End If
        strbldr.Append(City)

        FullName = String.Empty
        FullName = IDData.LastName & "$" & IDData.FirstName
        If Not String.IsNullOrEmpty(IDData.MI) Then
            FullName += "$" & IDData.MI
        End If
        If FullName.Length < 35 Then
            FullName += "^"
        Else
            FullName = FullName.Substring(0, 35)
        End If
        strbldr.Append(FullName)

        If City.Length + FullName.Length + Street.Length < 77 Then
            Street += "^"
        Else
            Street = Street.Substring(0, 77 - City.Length + FullName.Length)
        End If
        strbldr.Append(Street)

        track1 = strbldr.ToString().ToUpper()
        strbldr = New StringBuilder()

        strbldr.Append("636014")    ' ISO Code for California

        IDStation = ExtractIDStation(IDData)
        IDNumber = ExtractIDNumber(IDData)
        If IDNumber.Length <= 13 Then
            strbldr.Append(IDNumber)
        Else
            strbldr.Append(IDNumber.Substring(0, 13))
        End If
        strbldr.Append("=")


        Dim Year As String = (IDData.ExpirationDate.Year Mod 100).ToString("D02")
        Dim Mo As String = IDData.ExpirationDate.Month.ToString("D02")
        Dim Day As String

        strbldr.Append(Year + Mo)

        Year = IDData.DOB.Year.ToString("D04")
        Mo = IDData.DOB.Month.ToString("D02")
        Day = IDData.DOB.Day.ToString("D02")
        strbldr.Append(Year + Mo + Day)

        If IDNumber.Length > 13 Then
            IDNumber = IDNumber.Substring(13)
            If IDNumber.Length > 5 Then
                IDNumber = IDNumber.Substring(0, 5)
            End If
            strbldr.Append(IDNumber)
        End If


        track2 = strbldr.ToString().ToUpper
        strbldr = New StringBuilder()

        strbldr.Append("!!")  ' Version
        strbldr.Append(ZIP)
        strbldr.Append(New String(" ", 2))  ' Class
        strbldr.Append(New String(" ", 10)) ' Restrictions
        strbldr.Append(New String(" ", 4))  ' Endorcements

        strbldr.Append(IDData.Sex)

        Height = IDData.Height.PadRight(3).Substring(0, 3)
        Dim ht As Integer
        If Not Integer.TryParse(IDData.Height, ht) Then ht = 0
        If ht < 100 Then
            Height = (ht \ 12).ToString("D1") + (ht Mod 12).ToString("D02")
        End If
        strbldr.Append(Height)

        Weight = IDData.Weight.PadRight(3).Substring(0, 3)
        strbldr.Append(Weight)

        Hair = IDData.Hair.PadRight(3).Substring(0, 3)
        strbldr.Append(Hair)

        Eyes = IDData.Eyes.PadRight(3).Substring(0, 3)
        strbldr.Append(Eyes)

        strbldr.Append(New String(" ", 12))

        IDStation = IDStation.PadRight(4).Substring(0, 4)
        strbldr.Append(IDStation)

        Year = IDData.IssueDate.Year.ToString("D04")
        Mo = IDData.IssueDate.Month.ToString("D02")
        Day = IDData.IssueDate.Day.ToString("D02")
        strbldr.Append(Year + Mo + Day)

        strbldr.Append(New String(" ", 2))

        Dim SSN As Double = ExtractNumber(IDData.SSN)
        strbldr.Append(BintoB32(SSN, 6))
        strbldr.Append(IDData.Rank.PadRight(3).Substring(0, 3))

        If (IDData.PayGrade(0) = "O" Or IDData.PayGrade(0) = "E" Or IDData.PayGrade(0) = "W") _
                AndAlso IDData.PayGrade(2) > "1" AndAlso IDData.PayGrade(2) <= "9" Then
            strbldr.Append(IDData.PayGrade.Substring(0, 1))
            strbldr.Append(IDData.PayGrade.Substring(2, 1))
        Else
            strbldr.Append(New String(" ", 2))
        End If

        '37 - 12 - 4 - 8 - 2 - 6 - 3 - 2 = 0
        track3 = strbldr.ToString().ToUpper

        Try
        Catch ex As Exception
            track1 = "" : track2 = "" : track3 = ""
        End Try
    End Sub

    Public Shared Function ExtractIDStation(ByVal data As IDCardData) As String
        Dim IDStation As String = ""

        If Not String.IsNullOrEmpty(data.IdNumber) Then
            Dim IDNums() As String = data.IdNumber.Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
            If IDNums.Length > 1 Then
                IDStation = IDNums(0)
            End If
        End If
        Return IDStation
    End Function

    Public Shared Function ExtractIDNumber(ByVal data As IDCardData) As String
        Dim IDNumber As String = ""
        If String.IsNullOrEmpty(data.DLData) Then
            Dim IDNums() As String = data.IdNumber.Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
            If IDNums.Length > 1 Then
                IDNumber = IDNums(1)
            Else
                IDNumber = data.IdNumber
            End If
        Else
            IDNumber = data.DLData
        End If

        Dim IDN As String = ""
        For Each iCH As Char In IDNumber
            iCH = Char.ToUpper(iCH)
            If Char.IsDigit(iCH) Then
                IDN += iCH
            ElseIf Char.IsLetter(iCH) Then
                IDN += (Convert.ToInt32(iCH) - Convert.ToInt32("A"c) + 1).ToString("D02")
            Else
                ' Skip it
            End If
        Next
        Return IDN
    End Function

    Public Shared Function ExtractNumber(ByVal serialNumber As String) As Double
        If String.IsNullOrEmpty(serialNumber) Then Return 0

        Dim IDN As String = ""
        For Each iCH As Char In serialNumber
            If Char.IsDigit(iCH) Then
                IDN += iCH
            Else
                '  Just skip it
            End If
        Next

        Dim ret As Double = 0
        If Not Double.TryParse(IDN, ret) Then
            ret = 0
        End If

        Return ret
    End Function


    Private Shared rxSerinc As New Regex("\D*(?<Grp1>\d+)\D+(?<Grp2>\d+)\D*|\D*(?<Grp2>\d+)\D*", RegexOptions.IgnoreCase Or RegexOptions.Compiled)


    Public Shared Function IncrementSerialNumber(ByVal serialNumber As String) As String
        ' Accepted format is ABCXXXX-YYYYYZZ, where XXXX and YYYYYY may be digits
        If String.IsNullOrEmpty(serialNumber) Then Return 0

        Dim ret As String = serialNumber
        Dim carry As Integer = 0
        Dim im As Match = rxSerinc.Match(serialNumber)

        If im.Groups("Grp2").Success Then
            Dim sNum As String = im.Groups("Grp2").Value
            Dim nDigits = sNum.Length
            Dim Num As Integer = Integer.Parse(sNum)
            Dim MaxNum As Integer = (10.0 ^ nDigits)
            Num = Num + 1
            carry = Num \ MaxNum
            Num = Num Mod MaxNum
            ret = ret.Replace(sNum, Num.ToString("D0" + nDigits.ToString))
        End If
        If im.Groups("Grp1").Success Then
            Dim sNum As String = im.Groups("Grp1").Value
            Dim nDigits = sNum.Length
            Dim Num As Integer = Integer.Parse(sNum)
            Dim MaxNum As Integer = (10.0 ^ nDigits)
            Num = Num + carry
            carry = Num \ MaxNum
            Num = Num Mod MaxNum
            ret = ret.Replace(sNum, Num.ToString("D0" + nDigits.ToString))
        End If

        Return ret
    End Function
End Class


