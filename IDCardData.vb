Imports Microsoft.VisualBasic

Public Class IDCardData
    Private m_IDNumber As New String("")
    Private m_LastName As New String("")
    Private m_FirstName As New String("")
    Private m_MI As New String("")
    Private m_SSN As New String("")
    Private m_PayGrade As New String("")
    Private m_Rank As New String("")
    Private m_Address As New String("")
    Private m_DOB As New Date
    Private m_IssueDate As New Date
    Private m_ExpirationDate As New Date
    Private m_Hair As New String("")
    Private m_Eyes As New String("")
    Private m_Height As New String("")
    Private m_Weight As New String("")
    Private m_BloodType As New String("")
    Private m_Photo() As Byte
    Private m_DLData As New String("")
    Private m_Sex As Char = "M"c
    Private m_SerialNumber As New String("")

    Public Sub New(ByVal originalID As IDCardData)
        With originalID
            m_IDNumber = .IdNumber
            m_LastName = .LastName
            m_FirstName = .FirstName
            m_MI = .MI
            m_SSN = .SSN
            m_PayGrade = .PayGrade
            m_Rank = .Rank
            m_Address = .Address
            m_DOB = .DOB
            m_IssueDate = .IssueDate
            m_ExpirationDate = .ExpirationDate
            m_Hair = .Hair
            m_Eyes = .Eyes
            m_Height = .Height
            m_Weight = .Weight
            m_BloodType = .BloodType
            m_Photo = .Photo
            m_DLData = .DLData
            m_Sex = .Sex
            m_SerialNumber = .SerialNumber
        End With
    End Sub

    Public Sub New()
        m_IssueDate = Date.Today()
        m_ExpirationDate = m_IssueDate.AddYears(3)
    End Sub

    Public Property Address() As String
        Get
            Return m_Address
        End Get
        Set(ByVal value As String)
            m_Address = value
        End Set
    End Property

    Public Property BloodType() As String
        Get
            Return m_BloodType
        End Get
        Set(ByVal value As String)
            m_BloodType = value
        End Set
    End Property

    Public Property DOB() As Date
        Get
            Return m_DOB
        End Get
        Set(ByVal value As Date)
            m_DOB = value
        End Set
    End Property

    Public Property ExpirationDate() As Date
        Get
            Return m_ExpirationDate
        End Get
        Set(ByVal value As Date)
            m_ExpirationDate = value
        End Set
    End Property

    Public Property Eyes() As String
        Get
            Return m_Eyes
        End Get
        Set(ByVal value As String)
            m_Eyes = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set(ByVal value As String)
            m_FirstName = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set(ByVal value As String)
            m_LastName = value
        End Set
    End Property

    Public Property Height() As String
        Get
            Return m_Height
        End Get
        Set(ByVal value As String)
            m_Height = value
        End Set
    End Property

    Public Property IssueDate() As Date
        Get
            Return m_IssueDate
        End Get
        Set(ByVal value As Date)
            m_IssueDate = value
        End Set
    End Property

    Public Property Hair() As String
        Get
            Return m_Hair
        End Get
        Set(ByVal value As String)
            m_Hair = value
        End Set
    End Property

    Public Property IdNumber() As String
        Get
            Return m_IDNumber
        End Get
        Set(ByVal value As String)
            m_IDNumber = value
        End Set
    End Property

    Public Property MI() As String
        Get
            Return m_MI
        End Get
        Set(ByVal value As String)
            m_MI = value
        End Set
    End Property

    Public Property PayGrade() As String
        Get
            Return m_PayGrade
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                If value.Length = 2 Then
                    m_PayGrade = value(0) + " " + value(1) + " "
                ElseIf value.Length = 3 Then
                    m_PayGrade = value(0) + " " + value(2) + " "
                Else
                    m_PayGrade = value
                End If
            End If
        End Set
    End Property

    Public Property Photo() As Byte()
        Get
            Return m_Photo
        End Get
        Set(ByVal value As Byte())
            m_Photo = value.Clone()
        End Set
    End Property

    Public Property Rank() As String
        Get
            Return (m_Rank)
        End Get
        Set(ByVal value As String)
            m_Rank = value
        End Set
    End Property

    Public Property Weight() As String
        Get
            Return m_Weight
        End Get
        Set(ByVal value As String)
            m_Weight = value
        End Set
    End Property

    Public Property SSN() As String
        Get
            Return m_SSN
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then Exit Property
            m_SSN = value
        End Set
    End Property

    Public Property DLData() As String
        Get
            Return m_DLData
        End Get
        Set(ByVal value As String)
            m_DLData = value
        End Set
    End Property

    Public Property Sex() As Char
        Get
            Return m_Sex
        End Get
        Set(ByVal value As Char)
            m_Sex = value
        End Set
    End Property

    Public Property SerialNumber() As String
        Get
            Return m_SerialNumber
        End Get
        Set(ByVal value As String)
            m_SerialNumber = value
        End Set
    End Property

End Class

