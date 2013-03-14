Imports System.Text
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic


Public Class Support
    Private Shared BinB32Table As String = "0123456789ABCDEFGHIJKLMNOPQRSTUV"
    Private Shared RefDate As New Date(1000, 1, 1)

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
    ' RETURN B32: A binary integer, or �1 for an error
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


    Public Shared rxCityStateZip As New Regex("\s*(?<City>.+?)\s*,*\s*CA\s*(?<ZIP>\d{5}[- ]\d{4}|\d{9}|\d{5})\s*", RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.Compiled)


    Public Shared Function EncodeAAMVAMagData(ByVal IDData As IDCardData) As String
        Dim trackData As String
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

        If IDData Is Nothing Then Return String.Empty

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

        trackData = "%" + strbldr.ToString().ToUpper() + "?"

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

        trackData += ";" + strbldr.ToString().ToUpper + "?"

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
        strbldr.Append(Support.BintoB32(SSN, 6))
        strbldr.Append(IDData.Rank.PadRight(3).Substring(0, 3))

        If (IDData.PayGrade(0) = "O" Or IDData.PayGrade(0) = "E" Or IDData.PayGrade(0) = "W") _
                AndAlso IDData.PayGrade(2) > "1" AndAlso IDData.PayGrade(2) <= "9" Then
            strbldr.Append(IDData.PayGrade.Substring(0, 1))
            strbldr.Append(IDData.PayGrade.Substring(2, 1))
        Else
            strbldr.Append(New String(" ", 2))
        End If

        '37 - 12 - 4 - 8 - 2 - 6 - 3 - 2 = 0
        trackData += "%" + strbldr.ToString().ToUpper + "?"

        Return trackData
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

    Public Shared Function ExtractDLNumber(ByVal data As IDCardData) As String
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

        Return IDNumber
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
        Result += txt.ToUpper()

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
        txt = data.MI.PadRight(1, " "c).Substring(0, 1)
        Result += txt

        Return Result.ToUpper()
    End Function
End Class
