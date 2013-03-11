<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConvertDialogForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim SSNLabel As System.Windows.Forms.Label
        Dim NAME_INDLabel As System.Windows.Forms.Label
        Dim LAST_NAMELabel As System.Windows.Forms.Label
        Dim FIRST_NAMELabel As System.Windows.Forms.Label
        Dim MIDDLE_NAMELabel As System.Windows.Forms.Label
        Dim PAY_GRLabel As System.Windows.Forms.Label
        Dim H_ADDRLabel As System.Windows.Forms.Label
        Dim H_CITYLabel As System.Windows.Forms.Label
        Dim H_ZIPLabel As System.Windows.Forms.Label
        Dim DOBLabel As System.Windows.Forms.Label
        Dim GENDERLabel As System.Windows.Forms.Label
        Dim IDNumberLabel As System.Windows.Forms.Label
        Dim LastNameLabel As System.Windows.Forms.Label
        Dim DOBLabel1 As System.Windows.Forms.Label
        Dim SSNLabel1 As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim IssueDateLabel As System.Windows.Forms.Label
        Dim ExpirationDateLabel As System.Windows.Forms.Label
        Dim PhotoLabel As System.Windows.Forms.Label
        Dim HairLabel As System.Windows.Forms.Label
        Dim EyesLabel As System.Windows.Forms.Label
        Dim BloodTypeLabel As System.Windows.Forms.Label
        Dim PayGradeLabel As System.Windows.Forms.Label
        Dim HeightLabel As System.Windows.Forms.Label
        Dim WeightLabel As System.Windows.Forms.Label
        Dim SexLabel As System.Windows.Forms.Label
        Dim SerialNumberLabel As System.Windows.Forms.Label
        Dim DLDataLabel As System.Windows.Forms.Label
        Dim RankLabel1 As System.Windows.Forms.Label
        Dim RANKLabel As System.Windows.Forms.Label
        Dim AddressLabel1 As System.Windows.Forms.Label
        Dim BloodTypeLabel1 As System.Windows.Forms.Label
        Dim DLDataLabel1 As System.Windows.Forms.Label
        Dim DOBLabel2 As System.Windows.Forms.Label
        Dim ExpirationDateLabel1 As System.Windows.Forms.Label
        Dim EyesLabel1 As System.Windows.Forms.Label
        Dim FirstNameLabel As System.Windows.Forms.Label
        Dim HairLabel1 As System.Windows.Forms.Label
        Dim HeightLabel1 As System.Windows.Forms.Label
        Dim IdNumberLabel1 As System.Windows.Forms.Label
        Dim IssueDateLabel1 As System.Windows.Forms.Label
        Dim PayGradeLabel1 As System.Windows.Forms.Label
        Dim RankLabel2 As System.Windows.Forms.Label
        Dim SerialNumberLabel1 As System.Windows.Forms.Label
        Dim SexLabel1 As System.Windows.Forms.Label
        Dim SSNLabel2 As System.Windows.Forms.Label
        Dim WeightLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConvertDialogForm))
        Me.TabControl_ID = New System.Windows.Forms.TabControl
        Me.TabPage_CSMR_ID = New System.Windows.Forms.TabPage
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.RANKComboBox = New System.Windows.Forms.ComboBox
        Me.CSMR_IDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CSMR_ID_DataSet = New CSMR_DB_Convert.CSMR_ID_DataSet
        Me.IssuingStation = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Convert = New System.Windows.Forms.Button
        Me.CSMR_IDBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CSMR_IDBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.GENDERTextBox = New System.Windows.Forms.TextBox
        Me.SSNTextBox = New System.Windows.Forms.TextBox
        Me.NAME_INDTextBox = New System.Windows.Forms.TextBox
        Me.LAST_NAMETextBox = New System.Windows.Forms.TextBox
        Me.FIRST_NAMETextBox = New System.Windows.Forms.TextBox
        Me.MIDDLE_NAMETextBox = New System.Windows.Forms.TextBox
        Me.PAY_GRTextBox = New System.Windows.Forms.TextBox
        Me.H_ADDRTextBox = New System.Windows.Forms.TextBox
        Me.H_CITYTextBox = New System.Windows.Forms.TextBox
        Me.H_ZIPTextBox = New System.Windows.Forms.TextBox
        Me.DOBDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.TabPage_ID_CARDS = New System.Windows.Forms.TabPage
        Me.RankComboBox_ID = New System.Windows.Forms.ComboBox
        Me.ID_CARDSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ID_CARDS_DataSet = New CSMR_DB_Convert.ID_CARDS_DataSet
        Me.DLDataTextBox = New System.Windows.Forms.TextBox
        Me.BloodTypeComboBox = New System.Windows.Forms.ComboBox
        Me.EyesComboBox = New System.Windows.Forms.ComboBox
        Me.HairComboBox = New System.Windows.Forms.ComboBox
        Me.ID_CARDSBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.AddItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.DeleteItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveItem = New System.Windows.Forms.ToolStripButton
        Me.IDNumberTextBox = New System.Windows.Forms.TextBox
        Me.LastNameTextBox = New System.Windows.Forms.TextBox
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox
        Me.MITextBox = New System.Windows.Forms.TextBox
        Me.DOBDateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.SSNTextBox1 = New System.Windows.Forms.TextBox
        Me.AddressTextBox = New System.Windows.Forms.TextBox
        Me.IssueDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ExpirationDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.PhotoPictureBox = New System.Windows.Forms.PictureBox
        Me.PayGradeTextBox = New System.Windows.Forms.TextBox
        Me.HeightTextBox = New System.Windows.Forms.TextBox
        Me.WeightTextBox = New System.Windows.Forms.TextBox
        Me.SexTextBox = New System.Windows.Forms.TextBox
        Me.SerialNumberTextBox = New System.Windows.Forms.TextBox
        Me.Button_CreateDB = New System.Windows.Forms.Button
        Me.TabPage_Encoder = New System.Windows.Forms.TabPage
        Me.MI_Enc = New System.Windows.Forms.Label
        Me.AAMVAMAGTextBox_Enc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BindingNavigator_Enc = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.FirstName_Enc = New System.Windows.Forms.Label
        Me.LastName_Enc = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PayGrade_Enc = New System.Windows.Forms.Label
        Me.ExpirationDate_Enc = New System.Windows.Forms.Label
        Me.Rank_Enc = New System.Windows.Forms.Label
        Me.PhotoPicture_Enc = New System.Windows.Forms.PictureBox
        Me.MagEncoder_Status = New System.Windows.Forms.Label
        Me.TabPage_Scanner = New System.Windows.Forms.TabPage
        Me.Barcode_Status = New System.Windows.Forms.Label
        Me.MagReader_Status = New System.Windows.Forms.Label
        Me.DataSourceLabel = New System.Windows.Forms.Label
        Me.AddressTextBox1 = New System.Windows.Forms.TextBox
        Me.IDCardDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BloodTypeTextBox = New System.Windows.Forms.TextBox
        Me.DLDataTextBox1 = New System.Windows.Forms.TextBox
        Me.DOBDateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.ExpirationDateDateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.EyesTextBox = New System.Windows.Forms.TextBox
        Me.FirstNameTextBox1 = New System.Windows.Forms.TextBox
        Me.HairTextBox = New System.Windows.Forms.TextBox
        Me.HeightTextBox1 = New System.Windows.Forms.TextBox
        Me.IdNumberTextBox1 = New System.Windows.Forms.TextBox
        Me.IssueDateDateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.LastNameTextBox1 = New System.Windows.Forms.TextBox
        Me.MITextBox1 = New System.Windows.Forms.TextBox
        Me.PayGradeTextBox1 = New System.Windows.Forms.TextBox
        Me.RankTextBox = New System.Windows.Forms.TextBox
        Me.SerialNumberTextBox1 = New System.Windows.Forms.TextBox
        Me.SexTextBox1 = New System.Windows.Forms.TextBox
        Me.SSNTextBox2 = New System.Windows.Forms.TextBox
        Me.WeightTextBox1 = New System.Windows.Forms.TextBox
        Me.CSMR_IDTableAdapter = New CSMR_DB_Convert.CSMR_ID_DataSetTableAdapters.CSMR_IDTableAdapter
        Me.TableAdapterManager = New CSMR_DB_Convert.CSMR_ID_DataSetTableAdapters.TableAdapterManager
        Me.ID_CARDSTableAdapter = New CSMR_DB_Convert.ID_CARDS_DataSetTableAdapters.ID_CARDSTableAdapter
        Me.TableAdapterManager1 = New CSMR_DB_Convert.ID_CARDS_DataSetTableAdapters.TableAdapterManager
        Me.CSMR_ID_OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Form_error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ID_CARDS_SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.BackgroundWorkerThread = New System.ComponentModel.BackgroundWorker
        Me.MSR206_Enc = New MSR206(Me.components)
        Me.HHP4600_Scan = New HHPScanner(Me.components)
        SSNLabel = New System.Windows.Forms.Label
        NAME_INDLabel = New System.Windows.Forms.Label
        LAST_NAMELabel = New System.Windows.Forms.Label
        FIRST_NAMELabel = New System.Windows.Forms.Label
        MIDDLE_NAMELabel = New System.Windows.Forms.Label
        PAY_GRLabel = New System.Windows.Forms.Label
        H_ADDRLabel = New System.Windows.Forms.Label
        H_CITYLabel = New System.Windows.Forms.Label
        H_ZIPLabel = New System.Windows.Forms.Label
        DOBLabel = New System.Windows.Forms.Label
        GENDERLabel = New System.Windows.Forms.Label
        IDNumberLabel = New System.Windows.Forms.Label
        LastNameLabel = New System.Windows.Forms.Label
        DOBLabel1 = New System.Windows.Forms.Label
        SSNLabel1 = New System.Windows.Forms.Label
        AddressLabel = New System.Windows.Forms.Label
        IssueDateLabel = New System.Windows.Forms.Label
        ExpirationDateLabel = New System.Windows.Forms.Label
        PhotoLabel = New System.Windows.Forms.Label
        HairLabel = New System.Windows.Forms.Label
        EyesLabel = New System.Windows.Forms.Label
        BloodTypeLabel = New System.Windows.Forms.Label
        PayGradeLabel = New System.Windows.Forms.Label
        HeightLabel = New System.Windows.Forms.Label
        WeightLabel = New System.Windows.Forms.Label
        SexLabel = New System.Windows.Forms.Label
        SerialNumberLabel = New System.Windows.Forms.Label
        DLDataLabel = New System.Windows.Forms.Label
        RankLabel1 = New System.Windows.Forms.Label
        RANKLabel = New System.Windows.Forms.Label
        AddressLabel1 = New System.Windows.Forms.Label
        BloodTypeLabel1 = New System.Windows.Forms.Label
        DLDataLabel1 = New System.Windows.Forms.Label
        DOBLabel2 = New System.Windows.Forms.Label
        ExpirationDateLabel1 = New System.Windows.Forms.Label
        EyesLabel1 = New System.Windows.Forms.Label
        FirstNameLabel = New System.Windows.Forms.Label
        HairLabel1 = New System.Windows.Forms.Label
        HeightLabel1 = New System.Windows.Forms.Label
        IdNumberLabel1 = New System.Windows.Forms.Label
        IssueDateLabel1 = New System.Windows.Forms.Label
        PayGradeLabel1 = New System.Windows.Forms.Label
        RankLabel2 = New System.Windows.Forms.Label
        SerialNumberLabel1 = New System.Windows.Forms.Label
        SexLabel1 = New System.Windows.Forms.Label
        SSNLabel2 = New System.Windows.Forms.Label
        WeightLabel1 = New System.Windows.Forms.Label
        Me.TabControl_ID.SuspendLayout()
        Me.TabPage_CSMR_ID.SuspendLayout()
        CType(Me.CSMR_IDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CSMR_ID_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CSMR_IDBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CSMR_IDBindingNavigator.SuspendLayout()
        Me.TabPage_ID_CARDS.SuspendLayout()
        CType(Me.ID_CARDSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ID_CARDS_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ID_CARDSBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_CARDSBindingNavigator.SuspendLayout()
        CType(Me.PhotoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Encoder.SuspendLayout()
        CType(Me.BindingNavigator_Enc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_Enc.SuspendLayout()
        CType(Me.PhotoPicture_Enc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Scanner.SuspendLayout()
        CType(Me.IDCardDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Form_error, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SSNLabel
        '
        SSNLabel.AutoSize = True
        SSNLabel.Location = New System.Drawing.Point(53, 44)
        SSNLabel.Name = "SSNLabel"
        SSNLabel.Size = New System.Drawing.Size(32, 13)
        SSNLabel.TabIndex = 0
        SSNLabel.Text = "SSN:"
        '
        'NAME_INDLabel
        '
        NAME_INDLabel.AutoSize = True
        NAME_INDLabel.Location = New System.Drawing.Point(53, 71)
        NAME_INDLabel.Name = "NAME_INDLabel"
        NAME_INDLabel.Size = New System.Drawing.Size(63, 13)
        NAME_INDLabel.TabIndex = 2
        NAME_INDLabel.Text = "NAME IND:"
        '
        'LAST_NAMELabel
        '
        LAST_NAMELabel.AutoSize = True
        LAST_NAMELabel.Location = New System.Drawing.Point(141, 126)
        LAST_NAMELabel.Name = "LAST_NAMELabel"
        LAST_NAMELabel.Size = New System.Drawing.Size(71, 13)
        LAST_NAMELabel.TabIndex = 4
        LAST_NAMELabel.Text = "LAST NAME:"
        '
        'FIRST_NAMELabel
        '
        FIRST_NAMELabel.AutoSize = True
        FIRST_NAMELabel.Location = New System.Drawing.Point(358, 126)
        FIRST_NAMELabel.Name = "FIRST_NAMELabel"
        FIRST_NAMELabel.Size = New System.Drawing.Size(75, 13)
        FIRST_NAMELabel.TabIndex = 6
        FIRST_NAMELabel.Text = "FIRST NAME:"
        '
        'MIDDLE_NAMELabel
        '
        MIDDLE_NAMELabel.AutoSize = True
        MIDDLE_NAMELabel.Location = New System.Drawing.Point(568, 126)
        MIDDLE_NAMELabel.Name = "MIDDLE_NAMELabel"
        MIDDLE_NAMELabel.Size = New System.Drawing.Size(85, 13)
        MIDDLE_NAMELabel.TabIndex = 8
        MIDDLE_NAMELabel.Text = "MIDDLE NAME:"
        '
        'PAY_GRLabel
        '
        PAY_GRLabel.AutoSize = True
        PAY_GRLabel.Location = New System.Drawing.Point(270, 162)
        PAY_GRLabel.Name = "PAY_GRLabel"
        PAY_GRLabel.Size = New System.Drawing.Size(50, 13)
        PAY_GRLabel.TabIndex = 12
        PAY_GRLabel.Text = "PAY GR:"
        '
        'H_ADDRLabel
        '
        H_ADDRLabel.AutoSize = True
        H_ADDRLabel.Location = New System.Drawing.Point(53, 200)
        H_ADDRLabel.Name = "H_ADDRLabel"
        H_ADDRLabel.Size = New System.Drawing.Size(52, 13)
        H_ADDRLabel.TabIndex = 14
        H_ADDRLabel.Text = "H ADDR:"
        '
        'H_CITYLabel
        '
        H_CITYLabel.AutoSize = True
        H_CITYLabel.Location = New System.Drawing.Point(141, 246)
        H_CITYLabel.Name = "H_CITYLabel"
        H_CITYLabel.Size = New System.Drawing.Size(45, 13)
        H_CITYLabel.TabIndex = 16
        H_CITYLabel.Text = "H CITY:"
        '
        'H_ZIPLabel
        '
        H_ZIPLabel.AutoSize = True
        H_ZIPLabel.Location = New System.Drawing.Point(358, 246)
        H_ZIPLabel.Name = "H_ZIPLabel"
        H_ZIPLabel.Size = New System.Drawing.Size(38, 13)
        H_ZIPLabel.TabIndex = 18
        H_ZIPLabel.Text = "H ZIP:"
        '
        'DOBLabel
        '
        DOBLabel.AutoSize = True
        DOBLabel.Location = New System.Drawing.Point(480, 227)
        DOBLabel.Name = "DOBLabel"
        DOBLabel.Size = New System.Drawing.Size(33, 13)
        DOBLabel.TabIndex = 20
        DOBLabel.Text = "DOB:"
        '
        'GENDERLabel
        '
        GENDERLabel.AutoSize = True
        GENDERLabel.Location = New System.Drawing.Point(480, 161)
        GENDERLabel.Name = "GENDERLabel"
        GENDERLabel.Size = New System.Drawing.Size(56, 13)
        GENDERLabel.TabIndex = 22
        GENDERLabel.Text = "GENDER:"
        '
        'IDNumberLabel
        '
        IDNumberLabel.AutoSize = True
        IDNumberLabel.Location = New System.Drawing.Point(51, 333)
        IDNumberLabel.Name = "IDNumberLabel"
        IDNumberLabel.Size = New System.Drawing.Size(58, 13)
        IDNumberLabel.TabIndex = 1
        IDNumberLabel.Text = "IDNumber:"
        '
        'LastNameLabel
        '
        LastNameLabel.AutoSize = True
        LastNameLabel.Location = New System.Drawing.Point(51, 35)
        LastNameLabel.Name = "LastNameLabel"
        LastNameLabel.Size = New System.Drawing.Size(38, 13)
        LastNameLabel.TabIndex = 3
        LastNameLabel.Text = "Name:"
        '
        'DOBLabel1
        '
        DOBLabel1.AutoSize = True
        DOBLabel1.Location = New System.Drawing.Point(432, 65)
        DOBLabel1.Name = "DOBLabel1"
        DOBLabel1.Size = New System.Drawing.Size(33, 13)
        DOBLabel1.TabIndex = 9
        DOBLabel1.Text = "DOB:"
        '
        'SSNLabel1
        '
        SSNLabel1.AutoSize = True
        SSNLabel1.Location = New System.Drawing.Point(51, 61)
        SSNLabel1.Name = "SSNLabel1"
        SSNLabel1.Size = New System.Drawing.Size(32, 13)
        SSNLabel1.TabIndex = 11
        SSNLabel1.Text = "SSN:"
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Location = New System.Drawing.Point(51, 99)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(48, 13)
        AddressLabel.TabIndex = 13
        AddressLabel.Text = "Address:"
        '
        'IssueDateLabel
        '
        IssueDateLabel.AutoSize = True
        IssueDateLabel.Location = New System.Drawing.Point(478, 103)
        IssueDateLabel.Name = "IssueDateLabel"
        IssueDateLabel.Size = New System.Drawing.Size(61, 13)
        IssueDateLabel.TabIndex = 15
        IssueDateLabel.Text = "Issue Date:"
        '
        'ExpirationDateLabel
        '
        ExpirationDateLabel.AutoSize = True
        ExpirationDateLabel.Location = New System.Drawing.Point(478, 129)
        ExpirationDateLabel.Name = "ExpirationDateLabel"
        ExpirationDateLabel.Size = New System.Drawing.Size(82, 13)
        ExpirationDateLabel.TabIndex = 17
        ExpirationDateLabel.Text = "Expiration Date:"
        '
        'PhotoLabel
        '
        PhotoLabel.AutoSize = True
        PhotoLabel.Location = New System.Drawing.Point(51, 171)
        PhotoLabel.Name = "PhotoLabel"
        PhotoLabel.Size = New System.Drawing.Size(38, 13)
        PhotoLabel.TabIndex = 19
        PhotoLabel.Text = "Photo:"
        '
        'HairLabel
        '
        HairLabel.AutoSize = True
        HairLabel.Location = New System.Drawing.Point(478, 181)
        HairLabel.Name = "HairLabel"
        HairLabel.Size = New System.Drawing.Size(29, 13)
        HairLabel.TabIndex = 21
        HairLabel.Text = "Hair:"
        '
        'EyesLabel
        '
        EyesLabel.AutoSize = True
        EyesLabel.Location = New System.Drawing.Point(478, 207)
        EyesLabel.Name = "EyesLabel"
        EyesLabel.Size = New System.Drawing.Size(33, 13)
        EyesLabel.TabIndex = 23
        EyesLabel.Text = "Eyes:"
        '
        'BloodTypeLabel
        '
        BloodTypeLabel.AutoSize = True
        BloodTypeLabel.Location = New System.Drawing.Point(478, 233)
        BloodTypeLabel.Name = "BloodTypeLabel"
        BloodTypeLabel.Size = New System.Drawing.Size(64, 13)
        BloodTypeLabel.TabIndex = 25
        BloodTypeLabel.Text = "Blood Type:"
        '
        'PayGradeLabel
        '
        PayGradeLabel.AutoSize = True
        PayGradeLabel.Location = New System.Drawing.Point(285, 207)
        PayGradeLabel.Name = "PayGradeLabel"
        PayGradeLabel.Size = New System.Drawing.Size(60, 13)
        PayGradeLabel.TabIndex = 29
        PayGradeLabel.Text = "Pay Grade:"
        '
        'HeightLabel
        '
        HeightLabel.AutoSize = True
        HeightLabel.Location = New System.Drawing.Point(643, 178)
        HeightLabel.Name = "HeightLabel"
        HeightLabel.Size = New System.Drawing.Size(41, 13)
        HeightLabel.TabIndex = 31
        HeightLabel.Text = "Height:"
        '
        'WeightLabel
        '
        WeightLabel.AutoSize = True
        WeightLabel.Location = New System.Drawing.Point(643, 204)
        WeightLabel.Name = "WeightLabel"
        WeightLabel.Size = New System.Drawing.Size(44, 13)
        WeightLabel.TabIndex = 33
        WeightLabel.Text = "Weight:"
        '
        'SexLabel
        '
        SexLabel.AutoSize = True
        SexLabel.Location = New System.Drawing.Point(285, 233)
        SexLabel.Name = "SexLabel"
        SexLabel.Size = New System.Drawing.Size(45, 13)
        SexLabel.TabIndex = 37
        SexLabel.Text = "Gender:"
        '
        'SerialNumberLabel
        '
        SerialNumberLabel.AutoSize = True
        SerialNumberLabel.Location = New System.Drawing.Point(293, 333)
        SerialNumberLabel.Name = "SerialNumberLabel"
        SerialNumberLabel.Size = New System.Drawing.Size(76, 13)
        SerialNumberLabel.TabIndex = 39
        SerialNumberLabel.Text = "Serial Number:"
        '
        'DLDataLabel
        '
        DLDataLabel.AutoSize = True
        DLDataLabel.Location = New System.Drawing.Point(285, 291)
        DLDataLabel.Name = "DLDataLabel"
        DLDataLabel.Size = New System.Drawing.Size(47, 13)
        DLDataLabel.TabIndex = 45
        DLDataLabel.Text = "DLData:"
        '
        'RankLabel1
        '
        RankLabel1.AutoSize = True
        RankLabel1.Location = New System.Drawing.Point(285, 178)
        RankLabel1.Name = "RankLabel1"
        RankLabel1.Size = New System.Drawing.Size(36, 13)
        RankLabel1.TabIndex = 46
        RankLabel1.Text = "Rank:"
        '
        'RANKLabel
        '
        RANKLabel.AutoSize = True
        RANKLabel.Location = New System.Drawing.Point(53, 161)
        RANKLabel.Name = "RANKLabel"
        RANKLabel.Size = New System.Drawing.Size(40, 13)
        RANKLabel.TabIndex = 28
        RANKLabel.Text = "RANK:"
        '
        'AddressLabel1
        '
        AddressLabel1.AutoSize = True
        AddressLabel1.Location = New System.Drawing.Point(12, 105)
        AddressLabel1.Name = "AddressLabel1"
        AddressLabel1.Size = New System.Drawing.Size(48, 13)
        AddressLabel1.TabIndex = 0
        AddressLabel1.Text = "Address:"
        '
        'BloodTypeLabel1
        '
        BloodTypeLabel1.AutoSize = True
        BloodTypeLabel1.Location = New System.Drawing.Point(385, 146)
        BloodTypeLabel1.Name = "BloodTypeLabel1"
        BloodTypeLabel1.Size = New System.Drawing.Size(64, 13)
        BloodTypeLabel1.TabIndex = 2
        BloodTypeLabel1.Text = "Blood Type:"
        '
        'DLDataLabel1
        '
        DLDataLabel1.AutoSize = True
        DLDataLabel1.Location = New System.Drawing.Point(12, 171)
        DLDataLabel1.Name = "DLDataLabel1"
        DLDataLabel1.Size = New System.Drawing.Size(47, 13)
        DLDataLabel1.TabIndex = 4
        DLDataLabel1.Text = "DLData:"
        '
        'DOBLabel2
        '
        DOBLabel2.AutoSize = True
        DOBLabel2.Location = New System.Drawing.Point(385, 233)
        DOBLabel2.Name = "DOBLabel2"
        DOBLabel2.Size = New System.Drawing.Size(33, 13)
        DOBLabel2.TabIndex = 6
        DOBLabel2.Text = "DOB:"
        '
        'ExpirationDateLabel1
        '
        ExpirationDateLabel1.AutoSize = True
        ExpirationDateLabel1.Location = New System.Drawing.Point(12, 309)
        ExpirationDateLabel1.Name = "ExpirationDateLabel1"
        ExpirationDateLabel1.Size = New System.Drawing.Size(82, 13)
        ExpirationDateLabel1.TabIndex = 8
        ExpirationDateLabel1.Text = "Expiration Date:"
        '
        'EyesLabel1
        '
        EyesLabel1.AutoSize = True
        EyesLabel1.Location = New System.Drawing.Point(385, 172)
        EyesLabel1.Name = "EyesLabel1"
        EyesLabel1.Size = New System.Drawing.Size(33, 13)
        EyesLabel1.TabIndex = 10
        EyesLabel1.Text = "Eyes:"
        '
        'FirstNameLabel
        '
        FirstNameLabel.AutoSize = True
        FirstNameLabel.Location = New System.Drawing.Point(12, 79)
        FirstNameLabel.Name = "FirstNameLabel"
        FirstNameLabel.Size = New System.Drawing.Size(38, 13)
        FirstNameLabel.TabIndex = 12
        FirstNameLabel.Text = "Name:"
        '
        'HairLabel1
        '
        HairLabel1.AutoSize = True
        HairLabel1.Location = New System.Drawing.Point(385, 198)
        HairLabel1.Name = "HairLabel1"
        HairLabel1.Size = New System.Drawing.Size(29, 13)
        HairLabel1.TabIndex = 14
        HairLabel1.Text = "Hair:"
        '
        'HeightLabel1
        '
        HeightLabel1.AutoSize = True
        HeightLabel1.Location = New System.Drawing.Point(582, 146)
        HeightLabel1.Name = "HeightLabel1"
        HeightLabel1.Size = New System.Drawing.Size(41, 13)
        HeightLabel1.TabIndex = 16
        HeightLabel1.Text = "Height:"
        '
        'IdNumberLabel1
        '
        IdNumberLabel1.AutoSize = True
        IdNumberLabel1.Location = New System.Drawing.Point(12, 223)
        IdNumberLabel1.Name = "IdNumberLabel1"
        IdNumberLabel1.Size = New System.Drawing.Size(59, 13)
        IdNumberLabel1.TabIndex = 18
        IdNumberLabel1.Text = "Id Number:"
        '
        'IssueDateLabel1
        '
        IssueDateLabel1.AutoSize = True
        IssueDateLabel1.Location = New System.Drawing.Point(12, 283)
        IssueDateLabel1.Name = "IssueDateLabel1"
        IssueDateLabel1.Size = New System.Drawing.Size(61, 13)
        IssueDateLabel1.TabIndex = 20
        IssueDateLabel1.Text = "Issue Date:"
        '
        'PayGradeLabel1
        '
        PayGradeLabel1.AutoSize = True
        PayGradeLabel1.Location = New System.Drawing.Point(582, 171)
        PayGradeLabel1.Name = "PayGradeLabel1"
        PayGradeLabel1.Size = New System.Drawing.Size(60, 13)
        PayGradeLabel1.TabIndex = 26
        PayGradeLabel1.Text = "Pay Grade:"
        '
        'RankLabel2
        '
        RankLabel2.AutoSize = True
        RankLabel2.Location = New System.Drawing.Point(582, 197)
        RankLabel2.Name = "RankLabel2"
        RankLabel2.Size = New System.Drawing.Size(36, 13)
        RankLabel2.TabIndex = 28
        RankLabel2.Text = "Rank:"
        '
        'SerialNumberLabel1
        '
        SerialNumberLabel1.AutoSize = True
        SerialNumberLabel1.Location = New System.Drawing.Point(12, 249)
        SerialNumberLabel1.Name = "SerialNumberLabel1"
        SerialNumberLabel1.Size = New System.Drawing.Size(76, 13)
        SerialNumberLabel1.TabIndex = 30
        SerialNumberLabel1.Text = "Serial Number:"
        '
        'SexLabel1
        '
        SexLabel1.AutoSize = True
        SexLabel1.Location = New System.Drawing.Point(385, 119)
        SexLabel1.Name = "SexLabel1"
        SexLabel1.Size = New System.Drawing.Size(28, 13)
        SexLabel1.TabIndex = 32
        SexLabel1.Text = "Sex:"
        '
        'SSNLabel2
        '
        SSNLabel2.AutoSize = True
        SSNLabel2.Location = New System.Drawing.Point(12, 197)
        SSNLabel2.Name = "SSNLabel2"
        SSNLabel2.Size = New System.Drawing.Size(32, 13)
        SSNLabel2.TabIndex = 34
        SSNLabel2.Text = "SSN:"
        '
        'WeightLabel1
        '
        WeightLabel1.AutoSize = True
        WeightLabel1.Location = New System.Drawing.Point(582, 119)
        WeightLabel1.Name = "WeightLabel1"
        WeightLabel1.Size = New System.Drawing.Size(44, 13)
        WeightLabel1.TabIndex = 36
        WeightLabel1.Text = "Weight:"
        '
        'TabControl_ID
        '
        Me.TabControl_ID.Controls.Add(Me.TabPage_CSMR_ID)
        Me.TabControl_ID.Controls.Add(Me.TabPage_ID_CARDS)
        Me.TabControl_ID.Controls.Add(Me.TabPage_Encoder)
        Me.TabControl_ID.Controls.Add(Me.TabPage_Scanner)
        Me.TabControl_ID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl_ID.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_ID.Name = "TabControl_ID"
        Me.TabControl_ID.SelectedIndex = 0
        Me.TabControl_ID.Size = New System.Drawing.Size(822, 393)
        Me.TabControl_ID.TabIndex = 0
        '
        'TabPage_CSMR_ID
        '
        Me.TabPage_CSMR_ID.AutoScroll = True
        Me.TabPage_CSMR_ID.Controls.Add(Me.ProgressBar1)
        Me.TabPage_CSMR_ID.Controls.Add(RANKLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.RANKComboBox)
        Me.TabPage_CSMR_ID.Controls.Add(Me.IssuingStation)
        Me.TabPage_CSMR_ID.Controls.Add(Me.Label1)
        Me.TabPage_CSMR_ID.Controls.Add(Me.Convert)
        Me.TabPage_CSMR_ID.Controls.Add(Me.CSMR_IDBindingNavigator)
        Me.TabPage_CSMR_ID.Controls.Add(GENDERLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.GENDERTextBox)
        Me.TabPage_CSMR_ID.Controls.Add(SSNLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.SSNTextBox)
        Me.TabPage_CSMR_ID.Controls.Add(NAME_INDLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.NAME_INDTextBox)
        Me.TabPage_CSMR_ID.Controls.Add(LAST_NAMELabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.LAST_NAMETextBox)
        Me.TabPage_CSMR_ID.Controls.Add(FIRST_NAMELabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.FIRST_NAMETextBox)
        Me.TabPage_CSMR_ID.Controls.Add(MIDDLE_NAMELabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.MIDDLE_NAMETextBox)
        Me.TabPage_CSMR_ID.Controls.Add(PAY_GRLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.PAY_GRTextBox)
        Me.TabPage_CSMR_ID.Controls.Add(H_ADDRLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.H_ADDRTextBox)
        Me.TabPage_CSMR_ID.Controls.Add(H_CITYLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.H_CITYTextBox)
        Me.TabPage_CSMR_ID.Controls.Add(H_ZIPLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.H_ZIPTextBox)
        Me.TabPage_CSMR_ID.Controls.Add(DOBLabel)
        Me.TabPage_CSMR_ID.Controls.Add(Me.DOBDateTimePicker)
        Me.TabPage_CSMR_ID.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_CSMR_ID.Name = "TabPage_CSMR_ID"
        Me.TabPage_CSMR_ID.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_CSMR_ID.Size = New System.Drawing.Size(814, 367)
        Me.TabPage_CSMR_ID.TabIndex = 0
        Me.TabPage_CSMR_ID.Text = "CSMR_ID"
        Me.TabPage_CSMR_ID.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(55, 293)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(751, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 30
        '
        'RANKComboBox
        '
        Me.RANKComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "RANK", True))
        Me.RANKComboBox.FormattingEnabled = True
        Me.RANKComboBox.Location = New System.Drawing.Point(144, 158)
        Me.RANKComboBox.Name = "RANKComboBox"
        Me.RANKComboBox.Size = New System.Drawing.Size(80, 21)
        Me.RANKComboBox.TabIndex = 29
        '
        'CSMR_IDBindingSource
        '
        Me.CSMR_IDBindingSource.DataMember = "CSMR_ID"
        Me.CSMR_IDBindingSource.DataSource = Me.CSMR_ID_DataSet
        '
        'CSMR_ID_DataSet
        '
        Me.CSMR_ID_DataSet.DataSetName = "CSMR_ID_DataSet"
        Me.CSMR_ID_DataSet.EnforceConstraints = False
        Me.CSMR_ID_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IssuingStation
        '
        Me.IssuingStation.Location = New System.Drawing.Point(188, 325)
        Me.IssuingStation.Name = "IssuingStation"
        Me.IssuingStation.Size = New System.Drawing.Size(100, 20)
        Me.IssuingStation.TabIndex = 28
        Me.IssuingStation.Text = "CAHQ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 328)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "ISSUING STATION:"
        '
        'Convert
        '
        Me.Convert.Location = New System.Drawing.Point(466, 338)
        Me.Convert.Name = "Convert"
        Me.Convert.Size = New System.Drawing.Size(340, 23)
        Me.Convert.TabIndex = 24
        Me.Convert.Text = "Convert to ID_CARD Database"
        Me.Convert.UseVisualStyleBackColor = True
        '
        'CSMR_IDBindingNavigator
        '
        Me.CSMR_IDBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.CSMR_IDBindingNavigator.BindingSource = Me.CSMR_IDBindingSource
        Me.CSMR_IDBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.CSMR_IDBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.CSMR_IDBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.CSMR_IDBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CSMR_IDBindingNavigatorSaveItem})
        Me.CSMR_IDBindingNavigator.Location = New System.Drawing.Point(3, 3)
        Me.CSMR_IDBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.CSMR_IDBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.CSMR_IDBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.CSMR_IDBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.CSMR_IDBindingNavigator.Name = "CSMR_IDBindingNavigator"
        Me.CSMR_IDBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.CSMR_IDBindingNavigator.Size = New System.Drawing.Size(808, 25)
        Me.CSMR_IDBindingNavigator.TabIndex = 1
        Me.CSMR_IDBindingNavigator.Text = "BindingNavigator_CSMR_ID"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CSMR_IDBindingNavigatorSaveItem
        '
        Me.CSMR_IDBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CSMR_IDBindingNavigatorSaveItem.Image = CType(resources.GetObject("CSMR_IDBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.CSMR_IDBindingNavigatorSaveItem.Name = "CSMR_IDBindingNavigatorSaveItem"
        Me.CSMR_IDBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.CSMR_IDBindingNavigatorSaveItem.Text = "Save Data"
        '
        'GENDERTextBox
        '
        Me.GENDERTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "GENDER", True))
        Me.GENDERTextBox.Location = New System.Drawing.Point(571, 158)
        Me.GENDERTextBox.Name = "GENDERTextBox"
        Me.GENDERTextBox.Size = New System.Drawing.Size(72, 20)
        Me.GENDERTextBox.TabIndex = 23
        '
        'SSNTextBox
        '
        Me.SSNTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "SSN", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "000-00-0000"))
        Me.SSNTextBox.Location = New System.Drawing.Point(144, 41)
        Me.SSNTextBox.Name = "SSNTextBox"
        Me.SSNTextBox.Size = New System.Drawing.Size(200, 20)
        Me.SSNTextBox.TabIndex = 1
        '
        'NAME_INDTextBox
        '
        Me.NAME_INDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "NAME_IND", True))
        Me.NAME_INDTextBox.Location = New System.Drawing.Point(144, 68)
        Me.NAME_INDTextBox.Name = "NAME_INDTextBox"
        Me.NAME_INDTextBox.Size = New System.Drawing.Size(565, 20)
        Me.NAME_INDTextBox.TabIndex = 3
        '
        'LAST_NAMETextBox
        '
        Me.LAST_NAMETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "LAST_NAME", True))
        Me.LAST_NAMETextBox.Location = New System.Drawing.Point(144, 103)
        Me.LAST_NAMETextBox.Name = "LAST_NAMETextBox"
        Me.LAST_NAMETextBox.Size = New System.Drawing.Size(200, 20)
        Me.LAST_NAMETextBox.TabIndex = 5
        '
        'FIRST_NAMETextBox
        '
        Me.FIRST_NAMETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "FIRST_NAME", True))
        Me.FIRST_NAMETextBox.Location = New System.Drawing.Point(361, 103)
        Me.FIRST_NAMETextBox.Name = "FIRST_NAMETextBox"
        Me.FIRST_NAMETextBox.Size = New System.Drawing.Size(164, 20)
        Me.FIRST_NAMETextBox.TabIndex = 7
        '
        'MIDDLE_NAMETextBox
        '
        Me.MIDDLE_NAMETextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "MIDDLE_NAME", True))
        Me.MIDDLE_NAMETextBox.Location = New System.Drawing.Point(571, 103)
        Me.MIDDLE_NAMETextBox.Name = "MIDDLE_NAMETextBox"
        Me.MIDDLE_NAMETextBox.Size = New System.Drawing.Size(138, 20)
        Me.MIDDLE_NAMETextBox.TabIndex = 9
        '
        'PAY_GRTextBox
        '
        Me.PAY_GRTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "PAY_GR", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PAY_GRTextBox.Location = New System.Drawing.Point(361, 159)
        Me.PAY_GRTextBox.Name = "PAY_GRTextBox"
        Me.PAY_GRTextBox.Size = New System.Drawing.Size(84, 20)
        Me.PAY_GRTextBox.TabIndex = 13
        '
        'H_ADDRTextBox
        '
        Me.H_ADDRTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "H_ADDR", True))
        Me.H_ADDRTextBox.Location = New System.Drawing.Point(144, 197)
        Me.H_ADDRTextBox.Name = "H_ADDRTextBox"
        Me.H_ADDRTextBox.Size = New System.Drawing.Size(298, 20)
        Me.H_ADDRTextBox.TabIndex = 15
        '
        'H_CITYTextBox
        '
        Me.H_CITYTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "H_CITY", True))
        Me.H_CITYTextBox.Location = New System.Drawing.Point(144, 223)
        Me.H_CITYTextBox.Name = "H_CITYTextBox"
        Me.H_CITYTextBox.Size = New System.Drawing.Size(200, 20)
        Me.H_CITYTextBox.TabIndex = 17
        '
        'H_ZIPTextBox
        '
        Me.H_ZIPTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "H_ZIP", True))
        Me.H_ZIPTextBox.Location = New System.Drawing.Point(361, 223)
        Me.H_ZIPTextBox.Name = "H_ZIPTextBox"
        Me.H_ZIPTextBox.Size = New System.Drawing.Size(81, 20)
        Me.H_ZIPTextBox.TabIndex = 19
        '
        'DOBDateTimePicker
        '
        Me.DOBDateTimePicker.CustomFormat = "   dd MMMM yyyy"
        Me.DOBDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CSMR_IDBindingSource, "DOB", True))
        Me.DOBDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOBDateTimePicker.Location = New System.Drawing.Point(571, 223)
        Me.DOBDateTimePicker.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DOBDateTimePicker.Name = "DOBDateTimePicker"
        Me.DOBDateTimePicker.Size = New System.Drawing.Size(138, 20)
        Me.DOBDateTimePicker.TabIndex = 21
        '
        'TabPage_ID_CARDS
        '
        Me.TabPage_ID_CARDS.AutoScroll = True
        Me.TabPage_ID_CARDS.Controls.Add(RankLabel1)
        Me.TabPage_ID_CARDS.Controls.Add(Me.RankComboBox_ID)
        Me.TabPage_ID_CARDS.Controls.Add(DLDataLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.DLDataTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(Me.BloodTypeComboBox)
        Me.TabPage_ID_CARDS.Controls.Add(Me.EyesComboBox)
        Me.TabPage_ID_CARDS.Controls.Add(Me.HairComboBox)
        Me.TabPage_ID_CARDS.Controls.Add(Me.ID_CARDSBindingNavigator)
        Me.TabPage_ID_CARDS.Controls.Add(IDNumberLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.IDNumberTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(LastNameLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.LastNameTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(Me.FirstNameTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(Me.MITextBox)
        Me.TabPage_ID_CARDS.Controls.Add(DOBLabel1)
        Me.TabPage_ID_CARDS.Controls.Add(Me.DOBDateTimePicker1)
        Me.TabPage_ID_CARDS.Controls.Add(SSNLabel1)
        Me.TabPage_ID_CARDS.Controls.Add(Me.SSNTextBox1)
        Me.TabPage_ID_CARDS.Controls.Add(AddressLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.AddressTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(IssueDateLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.IssueDateDateTimePicker)
        Me.TabPage_ID_CARDS.Controls.Add(ExpirationDateLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.ExpirationDateDateTimePicker)
        Me.TabPage_ID_CARDS.Controls.Add(PhotoLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.PhotoPictureBox)
        Me.TabPage_ID_CARDS.Controls.Add(HairLabel)
        Me.TabPage_ID_CARDS.Controls.Add(EyesLabel)
        Me.TabPage_ID_CARDS.Controls.Add(BloodTypeLabel)
        Me.TabPage_ID_CARDS.Controls.Add(PayGradeLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.PayGradeTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(HeightLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.HeightTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(WeightLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.WeightTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(SexLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.SexTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(SerialNumberLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.SerialNumberTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(Me.Button_CreateDB)
        Me.TabPage_ID_CARDS.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_ID_CARDS.Name = "TabPage_ID_CARDS"
        Me.TabPage_ID_CARDS.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_ID_CARDS.Size = New System.Drawing.Size(814, 367)
        Me.TabPage_ID_CARDS.TabIndex = 1
        Me.TabPage_ID_CARDS.Text = "ID_CARDS"
        Me.TabPage_ID_CARDS.UseVisualStyleBackColor = True
        '
        'RankComboBox_ID
        '
        Me.RankComboBox_ID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Rank", True))
        Me.RankComboBox_ID.FormattingEnabled = True
        Me.RankComboBox_ID.Location = New System.Drawing.Point(375, 175)
        Me.RankComboBox_ID.Name = "RankComboBox_ID"
        Me.RankComboBox_ID.Size = New System.Drawing.Size(51, 21)
        Me.RankComboBox_ID.TabIndex = 47
        '
        'ID_CARDSBindingSource
        '
        Me.ID_CARDSBindingSource.DataMember = "ID_CARDS"
        Me.ID_CARDSBindingSource.DataSource = Me.ID_CARDS_DataSet
        '
        'ID_CARDS_DataSet
        '
        Me.ID_CARDS_DataSet.DataSetName = "ID_CARDS_DataSet"
        Me.ID_CARDS_DataSet.EnforceConstraints = False
        Me.ID_CARDS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DLDataTextBox
        '
        Me.DLDataTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "DLData", True))
        Me.DLDataTextBox.Location = New System.Drawing.Point(375, 284)
        Me.DLDataTextBox.Name = "DLDataTextBox"
        Me.DLDataTextBox.Size = New System.Drawing.Size(96, 20)
        Me.DLDataTextBox.TabIndex = 46
        '
        'BloodTypeComboBox
        '
        Me.BloodTypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.ID_CARDSBindingSource, "BloodType", True))
        Me.BloodTypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ID_CARDSBindingSource, "BloodType", True))
        Me.BloodTypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "BloodType", True))
        Me.BloodTypeComboBox.DataSource = Me.ID_CARDSBindingSource
        Me.BloodTypeComboBox.DisplayMember = "BloodType"
        Me.BloodTypeComboBox.FormattingEnabled = True
        Me.BloodTypeComboBox.Location = New System.Drawing.Point(568, 233)
        Me.BloodTypeComboBox.Name = "BloodTypeComboBox"
        Me.BloodTypeComboBox.Size = New System.Drawing.Size(55, 21)
        Me.BloodTypeComboBox.TabIndex = 45
        Me.BloodTypeComboBox.ValueMember = "BloodType"
        '
        'EyesComboBox
        '
        Me.EyesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.ID_CARDSBindingSource, "Eyes", True))
        Me.EyesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Eyes", True))
        Me.EyesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ID_CARDSBindingSource, "Eyes", True))
        Me.EyesComboBox.DataSource = Me.ID_CARDSBindingSource
        Me.EyesComboBox.DisplayMember = "Eyes"
        Me.EyesComboBox.FormattingEnabled = True
        Me.EyesComboBox.Location = New System.Drawing.Point(568, 204)
        Me.EyesComboBox.Name = "EyesComboBox"
        Me.EyesComboBox.Size = New System.Drawing.Size(55, 21)
        Me.EyesComboBox.TabIndex = 43
        Me.EyesComboBox.ValueMember = "Eyes"
        '
        'HairComboBox
        '
        Me.HairComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.ID_CARDSBindingSource, "Hair", True))
        Me.HairComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Hair", True))
        Me.HairComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ID_CARDSBindingSource, "Hair", True))
        Me.HairComboBox.DataSource = Me.ID_CARDSBindingSource
        Me.HairComboBox.DisplayMember = "Hair"
        Me.HairComboBox.FormattingEnabled = True
        Me.HairComboBox.Location = New System.Drawing.Point(568, 177)
        Me.HairComboBox.Name = "HairComboBox"
        Me.HairComboBox.Size = New System.Drawing.Size(55, 21)
        Me.HairComboBox.TabIndex = 42
        Me.HairComboBox.ValueMember = "Hair"
        '
        'ID_CARDSBindingNavigator
        '
        Me.ID_CARDSBindingNavigator.AddNewItem = Me.AddItem
        Me.ID_CARDSBindingNavigator.BindingSource = Me.ID_CARDSBindingSource
        Me.ID_CARDSBindingNavigator.CountItem = Me.ToolStripLabel1
        Me.ID_CARDSBindingNavigator.DeleteItem = Me.DeleteItem
        Me.ID_CARDSBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ID_CARDSBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.AddItem, Me.DeleteItem, Me.SaveItem})
        Me.ID_CARDSBindingNavigator.Location = New System.Drawing.Point(3, 3)
        Me.ID_CARDSBindingNavigator.MoveFirstItem = Me.ToolStripButton3
        Me.ID_CARDSBindingNavigator.MoveLastItem = Me.ToolStripButton6
        Me.ID_CARDSBindingNavigator.MoveNextItem = Me.ToolStripButton5
        Me.ID_CARDSBindingNavigator.MovePreviousItem = Me.ToolStripButton4
        Me.ID_CARDSBindingNavigator.Name = "ID_CARDSBindingNavigator"
        Me.ID_CARDSBindingNavigator.PositionItem = Me.ToolStripTextBox1
        Me.ID_CARDSBindingNavigator.Size = New System.Drawing.Size(808, 25)
        Me.ID_CARDSBindingNavigator.Stretch = True
        Me.ID_CARDSBindingNavigator.TabIndex = 41
        Me.ID_CARDSBindingNavigator.Text = "ID_CARDSBindingNavigator"
        '
        'AddItem
        '
        Me.AddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddItem.Image = CType(resources.GetObject("AddItem.Image"), System.Drawing.Image)
        Me.AddItem.Name = "AddItem"
        Me.AddItem.RightToLeftAutoMirrorImage = True
        Me.AddItem.Size = New System.Drawing.Size(23, 22)
        Me.AddItem.Text = "Add new"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "of {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
        '
        'DeleteItem
        '
        Me.DeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteItem.Image = CType(resources.GetObject("DeleteItem.Image"), System.Drawing.Image)
        Me.DeleteItem.Name = "DeleteItem"
        Me.DeleteItem.RightToLeftAutoMirrorImage = True
        Me.DeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.DeleteItem.Text = "Delete"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Move first"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Move previous"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Position"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Current position"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Move next"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Move last"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'SaveItem
        '
        Me.SaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveItem.Image = CType(resources.GetObject("SaveItem.Image"), System.Drawing.Image)
        Me.SaveItem.Name = "SaveItem"
        Me.SaveItem.Size = New System.Drawing.Size(23, 22)
        Me.SaveItem.Text = "Save Data"
        '
        'IDNumberTextBox
        '
        Me.IDNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "IDNumber", True))
        Me.IDNumberTextBox.Location = New System.Drawing.Point(141, 330)
        Me.IDNumberTextBox.Name = "IDNumberTextBox"
        Me.IDNumberTextBox.ReadOnly = True
        Me.IDNumberTextBox.Size = New System.Drawing.Size(138, 20)
        Me.IDNumberTextBox.TabIndex = 2
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "LastName", True))
        Me.LastNameTextBox.Location = New System.Drawing.Point(141, 32)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.LastNameTextBox.TabIndex = 4
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "FirstName", True))
        Me.FirstNameTextBox.Location = New System.Drawing.Point(359, 32)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(106, 20)
        Me.FirstNameTextBox.TabIndex = 6
        '
        'MITextBox
        '
        Me.MITextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "MI", True))
        Me.MITextBox.Location = New System.Drawing.Point(480, 32)
        Me.MITextBox.Name = "MITextBox"
        Me.MITextBox.Size = New System.Drawing.Size(169, 20)
        Me.MITextBox.TabIndex = 8
        '
        'DOBDateTimePicker1
        '
        Me.DOBDateTimePicker1.CustomFormat = "   dd MMMM yyyy"
        Me.DOBDateTimePicker1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ID_CARDSBindingSource, "DOB", True))
        Me.DOBDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOBDateTimePicker1.Location = New System.Drawing.Point(480, 61)
        Me.DOBDateTimePicker1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DOBDateTimePicker1.Name = "DOBDateTimePicker1"
        Me.DOBDateTimePicker1.Size = New System.Drawing.Size(169, 20)
        Me.DOBDateTimePicker1.TabIndex = 10
        '
        'SSNTextBox1
        '
        Me.SSNTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "SSN", True))
        Me.SSNTextBox1.Location = New System.Drawing.Point(141, 58)
        Me.SSNTextBox1.Name = "SSNTextBox1"
        Me.SSNTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.SSNTextBox1.TabIndex = 12
        '
        'AddressTextBox
        '
        Me.AddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Address", True))
        Me.AddressTextBox.Location = New System.Drawing.Point(141, 96)
        Me.AddressTextBox.Multiline = True
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(324, 48)
        Me.AddressTextBox.TabIndex = 14
        '
        'IssueDateDateTimePicker
        '
        Me.IssueDateDateTimePicker.CustomFormat = "   dd MMMM yyyy"
        Me.IssueDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ID_CARDSBindingSource, "IssueDate", True))
        Me.IssueDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.IssueDateDateTimePicker.Location = New System.Drawing.Point(568, 99)
        Me.IssueDateDateTimePicker.Name = "IssueDateDateTimePicker"
        Me.IssueDateDateTimePicker.Size = New System.Drawing.Size(144, 20)
        Me.IssueDateDateTimePicker.TabIndex = 16
        '
        'ExpirationDateDateTimePicker
        '
        Me.ExpirationDateDateTimePicker.CustomFormat = "   dd MMMM yyyy"
        Me.ExpirationDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ID_CARDSBindingSource, "ExpirationDate", True))
        Me.ExpirationDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ExpirationDateDateTimePicker.Location = New System.Drawing.Point(568, 125)
        Me.ExpirationDateDateTimePicker.Name = "ExpirationDateDateTimePicker"
        Me.ExpirationDateDateTimePicker.Size = New System.Drawing.Size(144, 20)
        Me.ExpirationDateDateTimePicker.TabIndex = 18
        '
        'PhotoPictureBox
        '
        Me.PhotoPictureBox.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.ID_CARDSBindingSource, "Photo", True))
        Me.PhotoPictureBox.ErrorImage = Global.CSMR_DB_Convert.My.Resources.Resources.Empty
        Me.PhotoPictureBox.Image = CType(resources.GetObject("PhotoPictureBox.Image"), System.Drawing.Image)
        Me.PhotoPictureBox.Location = New System.Drawing.Point(141, 171)
        Me.PhotoPictureBox.Name = "PhotoPictureBox"
        Me.PhotoPictureBox.Size = New System.Drawing.Size(138, 153)
        Me.PhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PhotoPictureBox.TabIndex = 20
        Me.PhotoPictureBox.TabStop = False
        '
        'PayGradeTextBox
        '
        Me.PayGradeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "PayGrade", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PayGradeTextBox.Location = New System.Drawing.Point(375, 204)
        Me.PayGradeTextBox.Name = "PayGradeTextBox"
        Me.PayGradeTextBox.Size = New System.Drawing.Size(51, 20)
        Me.PayGradeTextBox.TabIndex = 30
        '
        'HeightTextBox
        '
        Me.HeightTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Height", True))
        Me.HeightTextBox.Location = New System.Drawing.Point(713, 175)
        Me.HeightTextBox.Name = "HeightTextBox"
        Me.HeightTextBox.Size = New System.Drawing.Size(55, 20)
        Me.HeightTextBox.TabIndex = 32
        '
        'WeightTextBox
        '
        Me.WeightTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Weight", True))
        Me.WeightTextBox.Location = New System.Drawing.Point(713, 200)
        Me.WeightTextBox.Name = "WeightTextBox"
        Me.WeightTextBox.Size = New System.Drawing.Size(55, 20)
        Me.WeightTextBox.TabIndex = 34
        '
        'SexTextBox
        '
        Me.SexTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Sex", True))
        Me.SexTextBox.Location = New System.Drawing.Point(375, 230)
        Me.SexTextBox.Name = "SexTextBox"
        Me.SexTextBox.Size = New System.Drawing.Size(51, 20)
        Me.SexTextBox.TabIndex = 38
        '
        'SerialNumberTextBox
        '
        Me.SerialNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "SerialNumber", True))
        Me.SerialNumberTextBox.Location = New System.Drawing.Point(375, 330)
        Me.SerialNumberTextBox.Name = "SerialNumberTextBox"
        Me.SerialNumberTextBox.ReadOnly = True
        Me.SerialNumberTextBox.Size = New System.Drawing.Size(96, 20)
        Me.SerialNumberTextBox.TabIndex = 40
        '
        'Button_CreateDB
        '
        Me.Button_CreateDB.Location = New System.Drawing.Point(633, 328)
        Me.Button_CreateDB.Name = "Button_CreateDB"
        Me.Button_CreateDB.Size = New System.Drawing.Size(135, 23)
        Me.Button_CreateDB.TabIndex = 0
        Me.Button_CreateDB.Text = "Create Database"
        Me.Button_CreateDB.UseVisualStyleBackColor = True
        '
        'TabPage_Encoder
        '
        Me.TabPage_Encoder.Controls.Add(Me.MI_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.AAMVAMAGTextBox_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.Label4)
        Me.TabPage_Encoder.Controls.Add(Me.Label2)
        Me.TabPage_Encoder.Controls.Add(Me.BindingNavigator_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.FirstName_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.LastName_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.Label3)
        Me.TabPage_Encoder.Controls.Add(Me.PayGrade_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.ExpirationDate_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.Rank_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.PhotoPicture_Enc)
        Me.TabPage_Encoder.Controls.Add(Me.MagEncoder_Status)
        Me.TabPage_Encoder.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Encoder.Name = "TabPage_Encoder"
        Me.TabPage_Encoder.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Encoder.Size = New System.Drawing.Size(814, 367)
        Me.TabPage_Encoder.TabIndex = 2
        Me.TabPage_Encoder.Text = "Encoder"
        Me.TabPage_Encoder.UseVisualStyleBackColor = True
        '
        'MI_Enc
        '
        Me.MI_Enc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "MI", True))
        Me.MI_Enc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MI_Enc.Location = New System.Drawing.Point(339, 272)
        Me.MI_Enc.Name = "MI_Enc"
        Me.MI_Enc.Size = New System.Drawing.Size(142, 23)
        Me.MI_Enc.TabIndex = 17
        Me.MI_Enc.Text = "MI"
        '
        'AAMVAMAGTextBox_Enc
        '
        Me.AAMVAMAGTextBox_Enc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "AAMVAMAG", True))
        Me.AAMVAMAGTextBox_Enc.Location = New System.Drawing.Point(281, 72)
        Me.AAMVAMAGTextBox_Enc.Multiline = True
        Me.AAMVAMAGTextBox_Enc.Name = "AAMVAMAGTextBox_Enc"
        Me.AAMVAMAGTextBox_Enc.ReadOnly = True
        Me.AAMVAMAGTextBox_Enc.Size = New System.Drawing.Size(512, 130)
        Me.AAMVAMAGTextBox_Enc.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(339, 309)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Rank"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(278, 309)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Grade"
        '
        'BindingNavigator_Enc
        '
        Me.BindingNavigator_Enc.AddNewItem = Nothing
        Me.BindingNavigator_Enc.BindingSource = Me.ID_CARDSBindingSource
        Me.BindingNavigator_Enc.CountItem = Me.BindingNavigatorCountItem1
        Me.BindingNavigator_Enc.DeleteItem = Nothing
        Me.BindingNavigator_Enc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator_Enc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5})
        Me.BindingNavigator_Enc.Location = New System.Drawing.Point(3, 3)
        Me.BindingNavigator_Enc.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.BindingNavigator_Enc.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.BindingNavigator_Enc.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.BindingNavigator_Enc.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.BindingNavigator_Enc.Name = "BindingNavigator_Enc"
        Me.BindingNavigator_Enc.PositionItem = Me.BindingNavigatorPositionItem1
        Me.BindingNavigator_Enc.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.BindingNavigator_Enc.Size = New System.Drawing.Size(808, 25)
        Me.BindingNavigator_Enc.Stretch = True
        Me.BindingNavigator_Enc.TabIndex = 13
        Me.BindingNavigator_Enc.Text = "BindingNavigator_Enc"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem1.Text = "of {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem1
        '
        Me.BindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem1.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem1.Name = "BindingNavigatorMoveFirstItem1"
        Me.BindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem1.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem1
        '
        Me.BindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem1.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem1.Name = "BindingNavigatorMovePreviousItem1"
        Me.BindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem1.Text = "Move previous"
        '
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = False
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem1"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem1
        '
        Me.BindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem1.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem1.Name = "BindingNavigatorMoveNextItem1"
        Me.BindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem1.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem1
        '
        Me.BindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem1.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem1.Name = "BindingNavigatorMoveLastItem1"
        Me.BindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem1.Text = "Move last"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'FirstName_Enc
        '
        Me.FirstName_Enc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "FirstName", True))
        Me.FirstName_Enc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstName_Enc.Location = New System.Drawing.Point(106, 272)
        Me.FirstName_Enc.Name = "FirstName_Enc"
        Me.FirstName_Enc.Size = New System.Drawing.Size(213, 20)
        Me.FirstName_Enc.TabIndex = 12
        Me.FirstName_Enc.Text = "FirstName"
        '
        'LastName_Enc
        '
        Me.LastName_Enc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "LastName", True))
        Me.LastName_Enc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastName_Enc.Location = New System.Drawing.Point(106, 252)
        Me.LastName_Enc.Name = "LastName_Enc"
        Me.LastName_Enc.Size = New System.Drawing.Size(272, 20)
        Me.LastName_Enc.TabIndex = 11
        Me.LastName_Enc.Text = "LastName"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(278, 218)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Expires"
        '
        'PayGrade_Enc
        '
        Me.PayGrade_Enc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "PayGrade", True))
        Me.PayGrade_Enc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayGrade_Enc.Location = New System.Drawing.Point(278, 322)
        Me.PayGrade_Enc.Name = "PayGrade_Enc"
        Me.PayGrade_Enc.Size = New System.Drawing.Size(55, 19)
        Me.PayGrade_Enc.TabIndex = 8
        Me.PayGrade_Enc.Text = "Grade"
        '
        'ExpirationDate_Enc
        '
        Me.ExpirationDate_Enc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "ExpirationDate", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "yyyyMMMdd"))
        Me.ExpirationDate_Enc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpirationDate_Enc.Location = New System.Drawing.Point(278, 231)
        Me.ExpirationDate_Enc.Name = "ExpirationDate_Enc"
        Me.ExpirationDate_Enc.Size = New System.Drawing.Size(100, 18)
        Me.ExpirationDate_Enc.TabIndex = 7
        Me.ExpirationDate_Enc.Text = "ExpDate"
        '
        'Rank_Enc
        '
        Me.Rank_Enc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Rank", True))
        Me.Rank_Enc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rank_Enc.Location = New System.Drawing.Point(339, 322)
        Me.Rank_Enc.Name = "Rank_Enc"
        Me.Rank_Enc.Size = New System.Drawing.Size(65, 19)
        Me.Rank_Enc.TabIndex = 6
        Me.Rank_Enc.Text = "Rank"
        '
        'PhotoPicture_Enc
        '
        Me.PhotoPicture_Enc.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.ID_CARDSBindingSource, "Photo", True))
        Me.PhotoPicture_Enc.Location = New System.Drawing.Point(109, 72)
        Me.PhotoPicture_Enc.Name = "PhotoPicture_Enc"
        Me.PhotoPicture_Enc.Size = New System.Drawing.Size(152, 177)
        Me.PhotoPicture_Enc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PhotoPicture_Enc.TabIndex = 2
        Me.PhotoPicture_Enc.TabStop = False
        '
        'MagEncoder_Status
        '
        Me.MagEncoder_Status.AutoSize = True
        Me.MagEncoder_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MagEncoder_Status.ForeColor = System.Drawing.SystemColors.Highlight
        Me.MagEncoder_Status.Location = New System.Drawing.Point(105, 38)
        Me.MagEncoder_Status.Name = "MagEncoder_Status"
        Me.MagEncoder_Status.Size = New System.Drawing.Size(24, 20)
        Me.MagEncoder_Status.TabIndex = 0
        Me.MagEncoder_Status.Text = "..."
        Me.MagEncoder_Status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabPage_Scanner
        '
        Me.TabPage_Scanner.AutoScroll = True
        Me.TabPage_Scanner.Controls.Add(Me.Barcode_Status)
        Me.TabPage_Scanner.Controls.Add(Me.MagReader_Status)
        Me.TabPage_Scanner.Controls.Add(Me.DataSourceLabel)
        Me.TabPage_Scanner.Controls.Add(AddressLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.AddressTextBox1)
        Me.TabPage_Scanner.Controls.Add(BloodTypeLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.BloodTypeTextBox)
        Me.TabPage_Scanner.Controls.Add(DLDataLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.DLDataTextBox1)
        Me.TabPage_Scanner.Controls.Add(DOBLabel2)
        Me.TabPage_Scanner.Controls.Add(Me.DOBDateTimePicker2)
        Me.TabPage_Scanner.Controls.Add(ExpirationDateLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.ExpirationDateDateTimePicker1)
        Me.TabPage_Scanner.Controls.Add(EyesLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.EyesTextBox)
        Me.TabPage_Scanner.Controls.Add(FirstNameLabel)
        Me.TabPage_Scanner.Controls.Add(Me.FirstNameTextBox1)
        Me.TabPage_Scanner.Controls.Add(HairLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.HairTextBox)
        Me.TabPage_Scanner.Controls.Add(HeightLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.HeightTextBox1)
        Me.TabPage_Scanner.Controls.Add(IdNumberLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.IdNumberTextBox1)
        Me.TabPage_Scanner.Controls.Add(IssueDateLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.IssueDateDateTimePicker1)
        Me.TabPage_Scanner.Controls.Add(Me.LastNameTextBox1)
        Me.TabPage_Scanner.Controls.Add(Me.MITextBox1)
        Me.TabPage_Scanner.Controls.Add(PayGradeLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.PayGradeTextBox1)
        Me.TabPage_Scanner.Controls.Add(RankLabel2)
        Me.TabPage_Scanner.Controls.Add(Me.RankTextBox)
        Me.TabPage_Scanner.Controls.Add(SerialNumberLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.SerialNumberTextBox1)
        Me.TabPage_Scanner.Controls.Add(SexLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.SexTextBox1)
        Me.TabPage_Scanner.Controls.Add(SSNLabel2)
        Me.TabPage_Scanner.Controls.Add(Me.SSNTextBox2)
        Me.TabPage_Scanner.Controls.Add(WeightLabel1)
        Me.TabPage_Scanner.Controls.Add(Me.WeightTextBox1)
        Me.TabPage_Scanner.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Scanner.Name = "TabPage_Scanner"
        Me.TabPage_Scanner.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Scanner.Size = New System.Drawing.Size(814, 367)
        Me.TabPage_Scanner.TabIndex = 3
        Me.TabPage_Scanner.Text = "Scanner"
        Me.TabPage_Scanner.UseVisualStyleBackColor = True
        '
        'Barcode_Status
        '
        Me.Barcode_Status.AllowDrop = True
        Me.Barcode_Status.AutoSize = True
        Me.Barcode_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Barcode_Status.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Barcode_Status.Location = New System.Drawing.Point(432, 14)
        Me.Barcode_Status.Name = "Barcode_Status"
        Me.Barcode_Status.Size = New System.Drawing.Size(24, 20)
        Me.Barcode_Status.TabIndex = 39
        Me.Barcode_Status.Text = "..."
        Me.Barcode_Status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MagReader_Status
        '
        Me.MagReader_Status.AutoSize = True
        Me.MagReader_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MagReader_Status.ForeColor = System.Drawing.SystemColors.Highlight
        Me.MagReader_Status.Location = New System.Drawing.Point(11, 14)
        Me.MagReader_Status.Name = "MagReader_Status"
        Me.MagReader_Status.Size = New System.Drawing.Size(24, 20)
        Me.MagReader_Status.TabIndex = 39
        Me.MagReader_Status.Text = "..."
        Me.MagReader_Status.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DataSourceLabel
        '
        Me.DataSourceLabel.AutoSize = True
        Me.DataSourceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DataSourceLabel.Location = New System.Drawing.Point(218, 45)
        Me.DataSourceLabel.Name = "DataSourceLabel"
        Me.DataSourceLabel.Size = New System.Drawing.Size(176, 18)
        Me.DataSourceLabel.TabIndex = 38
        Me.DataSourceLabel.Text = "Data scanned from ...."
        '
        'AddressTextBox1
        '
        Me.AddressTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "Address", True))
        Me.AddressTextBox1.Location = New System.Drawing.Point(100, 102)
        Me.AddressTextBox1.Multiline = True
        Me.AddressTextBox1.Name = "AddressTextBox1"
        Me.AddressTextBox1.ReadOnly = True
        Me.AddressTextBox1.Size = New System.Drawing.Size(200, 60)
        Me.AddressTextBox1.TabIndex = 1
        '
        'IDCardDataBindingSource
        '
        Me.IDCardDataBindingSource.AllowNew = False
        Me.IDCardDataBindingSource.DataSource = GetType(IDCardData)
        '
        'BloodTypeTextBox
        '
        Me.BloodTypeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "BloodType", True))
        Me.BloodTypeTextBox.Location = New System.Drawing.Point(473, 143)
        Me.BloodTypeTextBox.Name = "BloodTypeTextBox"
        Me.BloodTypeTextBox.ReadOnly = True
        Me.BloodTypeTextBox.Size = New System.Drawing.Size(61, 20)
        Me.BloodTypeTextBox.TabIndex = 3
        '
        'DLDataTextBox1
        '
        Me.DLDataTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "DLData", True))
        Me.DLDataTextBox1.Location = New System.Drawing.Point(100, 168)
        Me.DLDataTextBox1.Name = "DLDataTextBox1"
        Me.DLDataTextBox1.ReadOnly = True
        Me.DLDataTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.DLDataTextBox1.TabIndex = 5
        '
        'DOBDateTimePicker2
        '
        Me.DOBDateTimePicker2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.IDCardDataBindingSource, "DOB", True))
        Me.DOBDateTimePicker2.Enabled = False
        Me.DOBDateTimePicker2.Location = New System.Drawing.Point(473, 229)
        Me.DOBDateTimePicker2.Name = "DOBDateTimePicker2"
        Me.DOBDateTimePicker2.Size = New System.Drawing.Size(243, 20)
        Me.DOBDateTimePicker2.TabIndex = 7
        '
        'ExpirationDateDateTimePicker1
        '
        Me.ExpirationDateDateTimePicker1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.IDCardDataBindingSource, "ExpirationDate", True))
        Me.ExpirationDateDateTimePicker1.Enabled = False
        Me.ExpirationDateDateTimePicker1.Location = New System.Drawing.Point(100, 305)
        Me.ExpirationDateDateTimePicker1.Name = "ExpirationDateDateTimePicker1"
        Me.ExpirationDateDateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.ExpirationDateDateTimePicker1.TabIndex = 9
        '
        'EyesTextBox
        '
        Me.EyesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "Eyes", True))
        Me.EyesTextBox.Location = New System.Drawing.Point(473, 169)
        Me.EyesTextBox.Name = "EyesTextBox"
        Me.EyesTextBox.ReadOnly = True
        Me.EyesTextBox.Size = New System.Drawing.Size(61, 20)
        Me.EyesTextBox.TabIndex = 11
        '
        'FirstNameTextBox1
        '
        Me.FirstNameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "FirstName", True))
        Me.FirstNameTextBox1.Location = New System.Drawing.Point(100, 76)
        Me.FirstNameTextBox1.Name = "FirstNameTextBox1"
        Me.FirstNameTextBox1.ReadOnly = True
        Me.FirstNameTextBox1.Size = New System.Drawing.Size(124, 20)
        Me.FirstNameTextBox1.TabIndex = 13
        '
        'HairTextBox
        '
        Me.HairTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "Hair", True))
        Me.HairTextBox.Location = New System.Drawing.Point(473, 195)
        Me.HairTextBox.Name = "HairTextBox"
        Me.HairTextBox.ReadOnly = True
        Me.HairTextBox.Size = New System.Drawing.Size(61, 20)
        Me.HairTextBox.TabIndex = 15
        '
        'HeightTextBox1
        '
        Me.HeightTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "Height", True))
        Me.HeightTextBox1.Location = New System.Drawing.Point(670, 143)
        Me.HeightTextBox1.Name = "HeightTextBox1"
        Me.HeightTextBox1.ReadOnly = True
        Me.HeightTextBox1.Size = New System.Drawing.Size(46, 20)
        Me.HeightTextBox1.TabIndex = 17
        '
        'IdNumberTextBox1
        '
        Me.IdNumberTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "IdNumber", True))
        Me.IdNumberTextBox1.Location = New System.Drawing.Point(100, 220)
        Me.IdNumberTextBox1.Name = "IdNumberTextBox1"
        Me.IdNumberTextBox1.ReadOnly = True
        Me.IdNumberTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.IdNumberTextBox1.TabIndex = 19
        '
        'IssueDateDateTimePicker1
        '
        Me.IssueDateDateTimePicker1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.IDCardDataBindingSource, "IssueDate", True))
        Me.IssueDateDateTimePicker1.Enabled = False
        Me.IssueDateDateTimePicker1.Location = New System.Drawing.Point(100, 279)
        Me.IssueDateDateTimePicker1.Name = "IssueDateDateTimePicker1"
        Me.IssueDateDateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.IssueDateDateTimePicker1.TabIndex = 21
        '
        'LastNameTextBox1
        '
        Me.LastNameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "LastName", True))
        Me.LastNameTextBox1.Location = New System.Drawing.Point(345, 76)
        Me.LastNameTextBox1.Name = "LastNameTextBox1"
        Me.LastNameTextBox1.ReadOnly = True
        Me.LastNameTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.LastNameTextBox1.TabIndex = 23
        '
        'MITextBox1
        '
        Me.MITextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "MI", True))
        Me.MITextBox1.Location = New System.Drawing.Point(254, 76)
        Me.MITextBox1.Name = "MITextBox1"
        Me.MITextBox1.ReadOnly = True
        Me.MITextBox1.Size = New System.Drawing.Size(46, 20)
        Me.MITextBox1.TabIndex = 25
        '
        'PayGradeTextBox1
        '
        Me.PayGradeTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "PayGrade", True))
        Me.PayGradeTextBox1.Location = New System.Drawing.Point(670, 168)
        Me.PayGradeTextBox1.Name = "PayGradeTextBox1"
        Me.PayGradeTextBox1.ReadOnly = True
        Me.PayGradeTextBox1.Size = New System.Drawing.Size(46, 20)
        Me.PayGradeTextBox1.TabIndex = 27
        '
        'RankTextBox
        '
        Me.RankTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "Rank", True))
        Me.RankTextBox.Location = New System.Drawing.Point(670, 194)
        Me.RankTextBox.Name = "RankTextBox"
        Me.RankTextBox.ReadOnly = True
        Me.RankTextBox.Size = New System.Drawing.Size(46, 20)
        Me.RankTextBox.TabIndex = 29
        '
        'SerialNumberTextBox1
        '
        Me.SerialNumberTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "SerialNumber", True))
        Me.SerialNumberTextBox1.Location = New System.Drawing.Point(100, 246)
        Me.SerialNumberTextBox1.Name = "SerialNumberTextBox1"
        Me.SerialNumberTextBox1.ReadOnly = True
        Me.SerialNumberTextBox1.Size = New System.Drawing.Size(200, 20)
        Me.SerialNumberTextBox1.TabIndex = 31
        '
        'SexTextBox1
        '
        Me.SexTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "Sex", True))
        Me.SexTextBox1.Location = New System.Drawing.Point(473, 116)
        Me.SexTextBox1.Name = "SexTextBox1"
        Me.SexTextBox1.ReadOnly = True
        Me.SexTextBox1.Size = New System.Drawing.Size(61, 20)
        Me.SexTextBox1.TabIndex = 33
        '
        'SSNTextBox2
        '
        Me.SSNTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "SSN", True))
        Me.SSNTextBox2.Location = New System.Drawing.Point(100, 194)
        Me.SSNTextBox2.Name = "SSNTextBox2"
        Me.SSNTextBox2.ReadOnly = True
        Me.SSNTextBox2.Size = New System.Drawing.Size(200, 20)
        Me.SSNTextBox2.TabIndex = 35
        '
        'WeightTextBox1
        '
        Me.WeightTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.IDCardDataBindingSource, "Weight", True))
        Me.WeightTextBox1.Location = New System.Drawing.Point(670, 116)
        Me.WeightTextBox1.Name = "WeightTextBox1"
        Me.WeightTextBox1.ReadOnly = True
        Me.WeightTextBox1.Size = New System.Drawing.Size(46, 20)
        Me.WeightTextBox1.TabIndex = 37
        '
        'CSMR_IDTableAdapter
        '
        Me.CSMR_IDTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = CSMR_DB_Convert.CSMR_ID_DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ID_CARDSTableAdapter
        '
        Me.ID_CARDSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.ID_CARDSTableAdapter = Me.ID_CARDSTableAdapter
        Me.TableAdapterManager1.UpdateOrder = CSMR_DB_Convert.ID_CARDS_DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CSMR_ID_OpenFileDialog
        '
        Me.CSMR_ID_OpenFileDialog.DefaultExt = "mdb"
        Me.CSMR_ID_OpenFileDialog.FileName = "CSMR_ID.mdb"
        Me.CSMR_ID_OpenFileDialog.Filter = "Access DB Files|*.mdb|All Files|*.*"
        Me.CSMR_ID_OpenFileDialog.InitialDirectory = "."
        '
        'Form_error
        '
        Me.Form_error.ContainerControl = Me
        '
        'ID_CARDS_SaveFileDialog
        '
        Me.ID_CARDS_SaveFileDialog.DefaultExt = "mdb"
        Me.ID_CARDS_SaveFileDialog.FileName = "ID_CARDS.mdb"
        Me.ID_CARDS_SaveFileDialog.Filter = "Access DB Files|*.mdb|All Files|*.*"
        Me.ID_CARDS_SaveFileDialog.InitialDirectory = "."
        '
        'BackgroundWorkerThread
        '
        Me.BackgroundWorkerThread.WorkerSupportsCancellation = True
        '
        'ConvertDialogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 393)
        Me.Controls.Add(Me.TabControl_ID)
        Me.Name = "ConvertDialogForm"
        Me.Text = "ConvertDialogForm"
        Me.TabControl_ID.ResumeLayout(False)
        Me.TabPage_CSMR_ID.ResumeLayout(False)
        Me.TabPage_CSMR_ID.PerformLayout()
        CType(Me.CSMR_IDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CSMR_ID_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CSMR_IDBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CSMR_IDBindingNavigator.ResumeLayout(False)
        Me.CSMR_IDBindingNavigator.PerformLayout()
        Me.TabPage_ID_CARDS.ResumeLayout(False)
        Me.TabPage_ID_CARDS.PerformLayout()
        CType(Me.ID_CARDSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ID_CARDS_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ID_CARDSBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_CARDSBindingNavigator.ResumeLayout(False)
        Me.ID_CARDSBindingNavigator.PerformLayout()
        CType(Me.PhotoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Encoder.ResumeLayout(False)
        Me.TabPage_Encoder.PerformLayout()
        CType(Me.BindingNavigator_Enc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_Enc.ResumeLayout(False)
        Me.BindingNavigator_Enc.PerformLayout()
        CType(Me.PhotoPicture_Enc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Scanner.ResumeLayout(False)
        Me.TabPage_Scanner.PerformLayout()
        CType(Me.IDCardDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Form_error, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl_ID As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_CSMR_ID As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_ID_CARDS As System.Windows.Forms.TabPage
    Friend WithEvents CSMR_ID_DataSet As CSMR_DB_Convert.CSMR_ID_DataSet
    Friend WithEvents CSMR_IDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CSMR_IDBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CSMR_IDBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents GENDERTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SSNTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NAME_INDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LAST_NAMETextBox As System.Windows.Forms.TextBox
    Friend WithEvents FIRST_NAMETextBox As System.Windows.Forms.TextBox
    Friend WithEvents MIDDLE_NAMETextBox As System.Windows.Forms.TextBox
    Friend WithEvents PAY_GRTextBox As System.Windows.Forms.TextBox
    Friend WithEvents H_ADDRTextBox As System.Windows.Forms.TextBox
    Friend WithEvents H_CITYTextBox As System.Windows.Forms.TextBox
    Friend WithEvents H_ZIPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DOBDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Convert As System.Windows.Forms.Button
    Friend WithEvents Button_CreateDB As System.Windows.Forms.Button
    Friend WithEvents ID_CARDS_DataSet As CSMR_DB_Convert.ID_CARDS_DataSet
    Friend WithEvents ID_CARDSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LastNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FirstNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MITextBox As System.Windows.Forms.TextBox
    Friend WithEvents DOBDateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents SSNTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents AddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IssueDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ExpirationDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents PhotoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PayGradeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SexTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SerialNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_CARDSBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents AddItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveItem As System.Windows.Forms.ToolStripButton
    Private WithEvents CSMR_IDTableAdapter As CSMR_DB_Convert.CSMR_ID_DataSetTableAdapters.CSMR_IDTableAdapter
    Private WithEvents TableAdapterManager As CSMR_DB_Convert.CSMR_ID_DataSetTableAdapters.TableAdapterManager
    Private WithEvents ID_CARDSTableAdapter As CSMR_DB_Convert.ID_CARDS_DataSetTableAdapters.ID_CARDSTableAdapter
    Private WithEvents TableAdapterManager1 As CSMR_DB_Convert.ID_CARDS_DataSetTableAdapters.TableAdapterManager
    Friend WithEvents CSMR_ID_OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Form_error As System.Windows.Forms.ErrorProvider
    Friend WithEvents HairComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EyesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BloodTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents IssuingStation As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ID_CARDS_SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RankComboBox_ID As System.Windows.Forms.ComboBox
    Friend WithEvents DLDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RANKComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents TabPage_Encoder As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Scanner As System.Windows.Forms.TabPage
    Friend WithEvents MagEncoder_Status As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorkerThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents PhotoPicture_Enc As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PayGrade_Enc As System.Windows.Forms.Label
    Friend WithEvents ExpirationDate_Enc As System.Windows.Forms.Label
    Friend WithEvents Rank_Enc As System.Windows.Forms.Label
    Friend WithEvents FirstName_Enc As System.Windows.Forms.Label
    Friend WithEvents LastName_Enc As System.Windows.Forms.Label
    Friend WithEvents BindingNavigator_Enc As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AAMVAMAGTextBox_Enc As System.Windows.Forms.TextBox
    Friend WithEvents MSR206_Enc As MSR206
    Friend WithEvents MI_Enc As System.Windows.Forms.Label
    Friend WithEvents HHP4600_Scan As HHPScanner
    Friend WithEvents AddressTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents IDCardDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BloodTypeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DLDataTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DOBDateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ExpirationDateDateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents EyesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FirstNameTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents HairTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HeightTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents IdNumberTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents IssueDateDateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LastNameTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MITextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PayGradeTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents RankTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SerialNumberTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SexTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SSNTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents WeightTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataSourceLabel As System.Windows.Forms.Label
    Friend WithEvents MagReader_Status As System.Windows.Forms.Label
    Friend WithEvents Barcode_Status As System.Windows.Forms.Label

End Class
