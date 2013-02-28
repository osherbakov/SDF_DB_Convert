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
        Dim RANKLabel As System.Windows.Forms.Label
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
        Dim RankLabel1 As System.Windows.Forms.Label
        Dim PayGradeLabel As System.Windows.Forms.Label
        Dim HeightLabel As System.Windows.Forms.Label
        Dim WeightLabel As System.Windows.Forms.Label
        Dim DLDataLabel As System.Windows.Forms.Label
        Dim SexLabel As System.Windows.Forms.Label
        Dim SerialNumberLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConvertDialogForm))
        Me.TabControl_ID = New System.Windows.Forms.TabControl
        Me.TabPage_CSMR_ID = New System.Windows.Forms.TabPage
        Me.RANKComboBox = New System.Windows.Forms.ComboBox
        Me.CSMR_IDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CSMR_ID_DataSet = New CSMR_DB_Convert.CSMR_ID_DataSet
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
        Me.BloodTypeTextBox = New System.Windows.Forms.TextBox
        Me.PayGradeTextBox = New System.Windows.Forms.TextBox
        Me.HeightTextBox = New System.Windows.Forms.TextBox
        Me.WeightTextBox = New System.Windows.Forms.TextBox
        Me.DLDataTextBox = New System.Windows.Forms.TextBox
        Me.SexTextBox = New System.Windows.Forms.TextBox
        Me.SerialNumberTextBox = New System.Windows.Forms.TextBox
        Me.Button_CreateDB = New System.Windows.Forms.Button
        Me.CSMR_IDTableAdapter = New CSMR_DB_Convert.CSMR_ID_DataSetTableAdapters.CSMR_IDTableAdapter
        Me.TableAdapterManager = New CSMR_DB_Convert.CSMR_ID_DataSetTableAdapters.TableAdapterManager
        Me.ID_CARDSTableAdapter = New CSMR_DB_Convert.ID_CARDS_DataSetTableAdapters.ID_CARDSTableAdapter
        Me.TableAdapterManager1 = New CSMR_DB_Convert.ID_CARDS_DataSetTableAdapters.TableAdapterManager
        Me.CSMR_ID_OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Form_error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ConvertDialogFormBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        SSNLabel = New System.Windows.Forms.Label
        NAME_INDLabel = New System.Windows.Forms.Label
        LAST_NAMELabel = New System.Windows.Forms.Label
        FIRST_NAMELabel = New System.Windows.Forms.Label
        MIDDLE_NAMELabel = New System.Windows.Forms.Label
        RANKLabel = New System.Windows.Forms.Label
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
        RankLabel1 = New System.Windows.Forms.Label
        PayGradeLabel = New System.Windows.Forms.Label
        HeightLabel = New System.Windows.Forms.Label
        WeightLabel = New System.Windows.Forms.Label
        DLDataLabel = New System.Windows.Forms.Label
        SexLabel = New System.Windows.Forms.Label
        SerialNumberLabel = New System.Windows.Forms.Label
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
        CType(Me.Form_error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConvertDialogFormBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'RANKLabel
        '
        RANKLabel.AutoSize = True
        RANKLabel.Location = New System.Drawing.Point(53, 162)
        RANKLabel.Name = "RANKLabel"
        RANKLabel.Size = New System.Drawing.Size(40, 13)
        RANKLabel.TabIndex = 10
        RANKLabel.Text = "RANK:"
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
        GENDERLabel.Location = New System.Drawing.Point(49, 282)
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
        'RankLabel1
        '
        RankLabel1.AutoSize = True
        RankLabel1.Location = New System.Drawing.Point(285, 181)
        RankLabel1.Name = "RankLabel1"
        RankLabel1.Size = New System.Drawing.Size(36, 13)
        RankLabel1.TabIndex = 27
        RankLabel1.Text = "Rank:"
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
        'DLDataLabel
        '
        DLDataLabel.AutoSize = True
        DLDataLabel.Location = New System.Drawing.Point(285, 271)
        DLDataLabel.Name = "DLDataLabel"
        DLDataLabel.Size = New System.Drawing.Size(47, 13)
        DLDataLabel.TabIndex = 35
        DLDataLabel.Text = "DLData:"
        '
        'SexLabel
        '
        SexLabel.AutoSize = True
        SexLabel.Location = New System.Drawing.Point(285, 233)
        SexLabel.Name = "SexLabel"
        SexLabel.Size = New System.Drawing.Size(28, 13)
        SexLabel.TabIndex = 37
        SexLabel.Text = "Sex:"
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
        'TabControl_ID
        '
        Me.TabControl_ID.Controls.Add(Me.TabPage_CSMR_ID)
        Me.TabControl_ID.Controls.Add(Me.TabPage_ID_CARDS)
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
        Me.TabPage_CSMR_ID.Controls.Add(Me.RANKComboBox)
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
        Me.TabPage_CSMR_ID.Controls.Add(RANKLabel)
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
        'RANKComboBox
        '
        Me.RANKComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.CSMR_IDBindingSource, "RANK", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RANKComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CSMR_IDBindingSource, "RANK", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RANKComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CSMR_IDBindingSource, "RANK", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RANKComboBox.DataSource = Me.CSMR_IDBindingSource
        Me.RANKComboBox.DisplayMember = "RANK"
        Me.RANKComboBox.FormattingEnabled = True
        Me.RANKComboBox.Location = New System.Drawing.Point(144, 162)
        Me.RANKComboBox.Name = "RANKComboBox"
        Me.RANKComboBox.Size = New System.Drawing.Size(68, 21)
        Me.RANKComboBox.TabIndex = 26
        Me.RANKComboBox.ValueMember = "RANK"
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
        Me.GENDERTextBox.Location = New System.Drawing.Point(144, 279)
        Me.GENDERTextBox.Name = "GENDERTextBox"
        Me.GENDERTextBox.Size = New System.Drawing.Size(68, 20)
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
        Me.TabPage_ID_CARDS.Controls.Add(Me.RankComboBox_ID)
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
        Me.TabPage_ID_CARDS.Controls.Add(Me.BloodTypeTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(RankLabel1)
        Me.TabPage_ID_CARDS.Controls.Add(PayGradeLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.PayGradeTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(HeightLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.HeightTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(WeightLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.WeightTextBox)
        Me.TabPage_ID_CARDS.Controls.Add(DLDataLabel)
        Me.TabPage_ID_CARDS.Controls.Add(Me.DLDataTextBox)
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
        Me.RankComboBox_ID.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.ID_CARDSBindingSource, "Rank", True))
        Me.RankComboBox_ID.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ID_CARDSBindingSource, "Rank", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RankComboBox_ID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Rank", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RankComboBox_ID.FormattingEnabled = True
        Me.RankComboBox_ID.Location = New System.Drawing.Point(375, 174)
        Me.RankComboBox_ID.Name = "RankComboBox_ID"
        Me.RankComboBox_ID.Size = New System.Drawing.Size(51, 21)
        Me.RankComboBox_ID.TabIndex = 44
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
        'EyesComboBox
        '
        Me.EyesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.ID_CARDSBindingSource, "Eyes", True))
        Me.EyesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ID_CARDSBindingSource, "Eyes", True))
        Me.EyesComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Eyes", True))
        Me.EyesComboBox.FormattingEnabled = True
        Me.EyesComboBox.Location = New System.Drawing.Point(568, 204)
        Me.EyesComboBox.Name = "EyesComboBox"
        Me.EyesComboBox.Size = New System.Drawing.Size(55, 21)
        Me.EyesComboBox.TabIndex = 43
        '
        'HairComboBox
        '
        Me.HairComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.ID_CARDSBindingSource, "Hair", True))
        Me.HairComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ID_CARDSBindingSource, "Hair", True))
        Me.HairComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "Hair", True))
        Me.HairComboBox.FormattingEnabled = True
        Me.HairComboBox.Location = New System.Drawing.Point(568, 177)
        Me.HairComboBox.Name = "HairComboBox"
        Me.HairComboBox.Size = New System.Drawing.Size(55, 21)
        Me.HairComboBox.TabIndex = 42
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
        Me.PhotoPictureBox.Location = New System.Drawing.Point(141, 171)
        Me.PhotoPictureBox.Name = "PhotoPictureBox"
        Me.PhotoPictureBox.Size = New System.Drawing.Size(138, 153)
        Me.PhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PhotoPictureBox.TabIndex = 20
        Me.PhotoPictureBox.TabStop = False
        '
        'BloodTypeTextBox
        '
        Me.BloodTypeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "BloodType", True))
        Me.BloodTypeTextBox.Location = New System.Drawing.Point(568, 230)
        Me.BloodTypeTextBox.Name = "BloodTypeTextBox"
        Me.BloodTypeTextBox.Size = New System.Drawing.Size(55, 20)
        Me.BloodTypeTextBox.TabIndex = 26
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
        'DLDataTextBox
        '
        Me.DLDataTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ID_CARDSBindingSource, "DLData", True))
        Me.DLDataTextBox.Location = New System.Drawing.Point(375, 268)
        Me.DLDataTextBox.Name = "DLDataTextBox"
        Me.DLDataTextBox.Size = New System.Drawing.Size(90, 20)
        Me.DLDataTextBox.TabIndex = 36
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
        'ConvertDialogFormBindingSource
        '
        Me.ConvertDialogFormBindingSource.DataSource = GetType(CSMR_DB_Convert.ConvertDialogForm)
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
        CType(Me.Form_error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConvertDialogFormBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BloodTypeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PayGradeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DLDataTextBox As System.Windows.Forms.TextBox
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
    Friend WithEvents ConvertDialogFormBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RANKComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents HairComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EyesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RankComboBox_ID As System.Windows.Forms.ComboBox

End Class
