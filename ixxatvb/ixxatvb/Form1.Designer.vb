<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ButtonInit = New System.Windows.Forms.Button()
        Me.LabelLastRxMsgCaption = New System.Windows.Forms.Label()
        Me.labelLastRxMsg = New System.Windows.Forms.Label()
        Me.ButtonTransmitData = New System.Windows.Forms.Button()
        Me.PictureBoxInitMode = New System.Windows.Forms.PictureBox()
        Me.PictureBoxTxPending = New System.Windows.Forms.PictureBox()
        Me.PictureBoxOverrun = New System.Windows.Forms.PictureBox()
        Me.PictureBoxWarningLevel = New System.Windows.Forms.PictureBox()
        Me.PictureBoxBusOff = New System.Windows.Forms.PictureBox()
        Me.LabelInitMode = New System.Windows.Forms.Label()
        Me.LabelTxPending = New System.Windows.Forms.Label()
        Me.LabelOverrun = New System.Windows.Forms.Label()
        Me.LabelWarningLevel = New System.Windows.Forms.Label()
        Me.LabelBusOff = New System.Windows.Forms.Label()
        Me.TimerGetStatus = New System.Windows.Forms.Timer(Me.components)
        Me.LabelCaptionListBox = New System.Windows.Forms.Label()
        Me.ListViewAvailInterfaces = New System.Windows.Forms.ListView()
        Me.TimerSendData = New System.Windows.Forms.Timer(Me.components)
        Me.LabelHardwareID = New System.Windows.Forms.Label()
        Me.LblHWID = New System.Windows.Forms.Label()
        Me.btnAcceptanceAll = New System.Windows.Forms.Button()
        Me.btnAcceptanceID1 = New System.Windows.Forms.Button()
        Me.ListBoxBaudrate = New System.Windows.Forms.ListBox()
        Me.LabelBaudListBox = New System.Windows.Forms.Label()
        Me.LabelFilterDescription = New System.Windows.Forms.Label()
        Me.Button_Read_Sdo = New System.Windows.Forms.Button()
        Me.Button_Write_Sdo = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NodeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mian_Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        CType(Me.PictureBoxInitMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxTxPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxOverrun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxWarningLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxBusOff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(991, 261)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 21)
        Me.ButtonClose.TabIndex = 0
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonInit
        '
        Me.ButtonInit.Enabled = False
        Me.ButtonInit.Location = New System.Drawing.Point(204, 14)
        Me.ButtonInit.Name = "ButtonInit"
        Me.ButtonInit.Size = New System.Drawing.Size(75, 21)
        Me.ButtonInit.TabIndex = 1
        Me.ButtonInit.Text = "Initialize"
        Me.ButtonInit.UseVisualStyleBackColor = True
        '
        'LabelLastRxMsgCaption
        '
        Me.LabelLastRxMsgCaption.AutoSize = True
        Me.LabelLastRxMsgCaption.Location = New System.Drawing.Point(20, 167)
        Me.LabelLastRxMsgCaption.Name = "LabelLastRxMsgCaption"
        Me.LabelLastRxMsgCaption.Size = New System.Drawing.Size(137, 12)
        Me.LabelLastRxMsgCaption.TabIndex = 2
        Me.LabelLastRxMsgCaption.Text = "Last Received Message:"
        '
        'labelLastRxMsg
        '
        Me.labelLastRxMsg.BackColor = System.Drawing.SystemColors.Window
        Me.labelLastRxMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelLastRxMsg.Location = New System.Drawing.Point(18, 188)
        Me.labelLastRxMsg.Name = "labelLastRxMsg"
        Me.labelLastRxMsg.Size = New System.Drawing.Size(401, 21)
        Me.labelLastRxMsg.TabIndex = 3
        '
        'ButtonTransmitData
        '
        Me.ButtonTransmitData.Enabled = False
        Me.ButtonTransmitData.Location = New System.Drawing.Point(487, 247)
        Me.ButtonTransmitData.Name = "ButtonTransmitData"
        Me.ButtonTransmitData.Size = New System.Drawing.Size(135, 21)
        Me.ButtonTransmitData.TabIndex = 4
        Me.ButtonTransmitData.Text = "Transmit Message"
        Me.ButtonTransmitData.UseVisualStyleBackColor = True
        '
        'PictureBoxInitMode
        '
        Me.PictureBoxInitMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxInitMode.Location = New System.Drawing.Point(290, 14)
        Me.PictureBoxInitMode.Name = "PictureBoxInitMode"
        Me.PictureBoxInitMode.Size = New System.Drawing.Size(12, 11)
        Me.PictureBoxInitMode.TabIndex = 5
        Me.PictureBoxInitMode.TabStop = False
        '
        'PictureBoxTxPending
        '
        Me.PictureBoxTxPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxTxPending.Location = New System.Drawing.Point(290, 30)
        Me.PictureBoxTxPending.Name = "PictureBoxTxPending"
        Me.PictureBoxTxPending.Size = New System.Drawing.Size(12, 11)
        Me.PictureBoxTxPending.TabIndex = 6
        Me.PictureBoxTxPending.TabStop = False
        '
        'PictureBoxOverrun
        '
        Me.PictureBoxOverrun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxOverrun.Location = New System.Drawing.Point(290, 47)
        Me.PictureBoxOverrun.Name = "PictureBoxOverrun"
        Me.PictureBoxOverrun.Size = New System.Drawing.Size(12, 11)
        Me.PictureBoxOverrun.TabIndex = 7
        Me.PictureBoxOverrun.TabStop = False
        '
        'PictureBoxWarningLevel
        '
        Me.PictureBoxWarningLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxWarningLevel.Location = New System.Drawing.Point(290, 65)
        Me.PictureBoxWarningLevel.Name = "PictureBoxWarningLevel"
        Me.PictureBoxWarningLevel.Size = New System.Drawing.Size(12, 11)
        Me.PictureBoxWarningLevel.TabIndex = 8
        Me.PictureBoxWarningLevel.TabStop = False
        '
        'PictureBoxBusOff
        '
        Me.PictureBoxBusOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxBusOff.Location = New System.Drawing.Point(290, 81)
        Me.PictureBoxBusOff.Name = "PictureBoxBusOff"
        Me.PictureBoxBusOff.Size = New System.Drawing.Size(12, 11)
        Me.PictureBoxBusOff.TabIndex = 9
        Me.PictureBoxBusOff.TabStop = False
        '
        'LabelInitMode
        '
        Me.LabelInitMode.AutoSize = True
        Me.LabelInitMode.Location = New System.Drawing.Point(308, 14)
        Me.LabelInitMode.Name = "LabelInitMode"
        Me.LabelInitMode.Size = New System.Drawing.Size(59, 12)
        Me.LabelInitMode.TabIndex = 10
        Me.LabelInitMode.Text = "Init mode"
        '
        'LabelTxPending
        '
        Me.LabelTxPending.AutoSize = True
        Me.LabelTxPending.Location = New System.Drawing.Point(308, 30)
        Me.LabelTxPending.Name = "LabelTxPending"
        Me.LabelTxPending.Size = New System.Drawing.Size(65, 12)
        Me.LabelTxPending.TabIndex = 11
        Me.LabelTxPending.Text = "Tx pending"
        '
        'LabelOverrun
        '
        Me.LabelOverrun.AutoSize = True
        Me.LabelOverrun.Location = New System.Drawing.Point(308, 47)
        Me.LabelOverrun.Name = "LabelOverrun"
        Me.LabelOverrun.Size = New System.Drawing.Size(77, 12)
        Me.LabelOverrun.TabIndex = 12
        Me.LabelOverrun.Text = "Data Overrun"
        '
        'LabelWarningLevel
        '
        Me.LabelWarningLevel.AutoSize = True
        Me.LabelWarningLevel.Location = New System.Drawing.Point(308, 65)
        Me.LabelWarningLevel.Name = "LabelWarningLevel"
        Me.LabelWarningLevel.Size = New System.Drawing.Size(119, 12)
        Me.LabelWarningLevel.TabIndex = 13
        Me.LabelWarningLevel.Text = "Error warning level"
        '
        'LabelBusOff
        '
        Me.LabelBusOff.AutoSize = True
        Me.LabelBusOff.Location = New System.Drawing.Point(308, 81)
        Me.LabelBusOff.Name = "LabelBusOff"
        Me.LabelBusOff.Size = New System.Drawing.Size(47, 12)
        Me.LabelBusOff.TabIndex = 14
        Me.LabelBusOff.Text = "Bus off"
        '
        'TimerGetStatus
        '
        '
        'LabelCaptionListBox
        '
        Me.LabelCaptionListBox.AutoSize = True
        Me.LabelCaptionListBox.Location = New System.Drawing.Point(20, 18)
        Me.LabelCaptionListBox.Name = "LabelCaptionListBox"
        Me.LabelCaptionListBox.Size = New System.Drawing.Size(161, 12)
        Me.LabelCaptionListBox.TabIndex = 16
        Me.LabelCaptionListBox.Text = "Available IXXAT Interfaces"
        '
        'ListViewAvailInterfaces
        '
        Me.ListViewAvailInterfaces.GridLines = True
        Me.ListViewAvailInterfaces.HideSelection = False
        Me.ListViewAvailInterfaces.Location = New System.Drawing.Point(18, 41)
        Me.ListViewAvailInterfaces.Name = "ListViewAvailInterfaces"
        Me.ListViewAvailInterfaces.Size = New System.Drawing.Size(180, 85)
        Me.ListViewAvailInterfaces.TabIndex = 17
        Me.ListViewAvailInterfaces.UseCompatibleStateImageBehavior = False
        Me.ListViewAvailInterfaces.View = System.Windows.Forms.View.List
        '
        'TimerSendData
        '
        Me.TimerSendData.Interval = 1
        '
        'LabelHardwareID
        '
        Me.LabelHardwareID.AutoSize = True
        Me.LabelHardwareID.Location = New System.Drawing.Point(20, 128)
        Me.LabelHardwareID.Name = "LabelHardwareID"
        Me.LabelHardwareID.Size = New System.Drawing.Size(173, 12)
        Me.LabelHardwareID.TabIndex = 18
        Me.LabelHardwareID.Text = "Hardware ID / Serial Number:"
        '
        'LblHWID
        '
        Me.LblHWID.AutoSize = True
        Me.LblHWID.BackColor = System.Drawing.SystemColors.Window
        Me.LblHWID.Location = New System.Drawing.Point(173, 128)
        Me.LblHWID.Name = "LblHWID"
        Me.LblHWID.Size = New System.Drawing.Size(11, 12)
        Me.LblHWID.TabIndex = 19
        Me.LblHWID.Text = "-"
        '
        'btnAcceptanceAll
        '
        Me.btnAcceptanceAll.Location = New System.Drawing.Point(325, 248)
        Me.btnAcceptanceAll.Name = "btnAcceptanceAll"
        Me.btnAcceptanceAll.Size = New System.Drawing.Size(75, 21)
        Me.btnAcceptanceAll.TabIndex = 20
        Me.btnAcceptanceAll.Text = "Filter off"
        Me.btnAcceptanceAll.UseVisualStyleBackColor = True
        '
        'btnAcceptanceID1
        '
        Me.btnAcceptanceID1.Location = New System.Drawing.Point(406, 247)
        Me.btnAcceptanceID1.Name = "btnAcceptanceID1"
        Me.btnAcceptanceID1.Size = New System.Drawing.Size(75, 21)
        Me.btnAcceptanceID1.TabIndex = 21
        Me.btnAcceptanceID1.Text = "Filter on"
        Me.btnAcceptanceID1.UseVisualStyleBackColor = True
        '
        'ListBoxBaudrate
        '
        Me.ListBoxBaudrate.FormattingEnabled = True
        Me.ListBoxBaudrate.ItemHeight = 12
        Me.ListBoxBaudrate.Items.AddRange(New Object() {"125", "250", "500", "800", "1000"})
        Me.ListBoxBaudrate.Location = New System.Drawing.Point(204, 62)
        Me.ListBoxBaudrate.Name = "ListBoxBaudrate"
        Me.ListBoxBaudrate.Size = New System.Drawing.Size(66, 64)
        Me.ListBoxBaudrate.TabIndex = 22
        '
        'LabelBaudListBox
        '
        Me.LabelBaudListBox.AutoSize = True
        Me.LabelBaudListBox.Location = New System.Drawing.Point(204, 41)
        Me.LabelBaudListBox.Name = "LabelBaudListBox"
        Me.LabelBaudListBox.Size = New System.Drawing.Size(41, 12)
        Me.LabelBaudListBox.TabIndex = 23
        Me.LabelBaudListBox.Text = "kBit/s"
        '
        'LabelFilterDescription
        '
        Me.LabelFilterDescription.AutoSize = True
        Me.LabelFilterDescription.Location = New System.Drawing.Point(301, 224)
        Me.LabelFilterDescription.Name = "LabelFilterDescription"
        Me.LabelFilterDescription.Size = New System.Drawing.Size(335, 12)
        Me.LabelFilterDescription.TabIndex = 24
        Me.LabelFilterDescription.Text = "Set/Reset a filter for all identifier with Bit 0 is set"
        '
        'Button_Read_Sdo
        '
        Me.Button_Read_Sdo.Location = New System.Drawing.Point(227, 69)
        Me.Button_Read_Sdo.Name = "Button_Read_Sdo"
        Me.Button_Read_Sdo.Size = New System.Drawing.Size(77, 27)
        Me.Button_Read_Sdo.TabIndex = 25
        Me.Button_Read_Sdo.Text = "Read_Sdo"
        Me.Button_Read_Sdo.UseVisualStyleBackColor = True
        '
        'Button_Write_Sdo
        '
        Me.Button_Write_Sdo.Location = New System.Drawing.Point(115, 69)
        Me.Button_Write_Sdo.Name = "Button_Write_Sdo"
        Me.Button_Write_Sdo.Size = New System.Drawing.Size(77, 26)
        Me.Button_Write_Sdo.TabIndex = 26
        Me.Button_Write_Sdo.Text = "Write_Sdo"
        Me.Button_Write_Sdo.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(115, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(45, 21)
        Me.TextBox1.TabIndex = 27
        Me.TextBox1.Text = "60F6"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(184, 33)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(45, 21)
        Me.TextBox2.TabIndex = 28
        Me.TextBox2.Text = "1"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(259, 33)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(45, 21)
        Me.TextBox3.TabIndex = 29
        Me.TextBox3.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(96, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Main Index"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Sub Index"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Data"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(98, 248)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(61, 21)
        Me.TextBox6.TabIndex = 35
        Me.TextBox6.Text = "60F6"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(40, 248)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(45, 21)
        Me.TextBox5.TabIndex = 34
        Me.TextBox5.Text = "601"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(172, 248)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(57, 21)
        Me.TextBox7.TabIndex = 41
        Me.TextBox7.Text = "01"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(241, 248)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(45, 21)
        Me.TextBox8.TabIndex = 40
        Me.TextBox8.Text = "01"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(592, 277)
        Me.TextBox9.Multiline = True
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox9.Size = New System.Drawing.Size(381, 100)
        Me.TextBox9.TabIndex = 39
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(833, 144)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(45, 21)
        Me.TextBox12.TabIndex = 38
        Me.TextBox12.Text = "01"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(833, 105)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(45, 21)
        Me.TextBox11.TabIndex = 37
        Me.TextBox11.Text = "60F0"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(833, 30)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(45, 21)
        Me.TextBox10.TabIndex = 36
        Me.TextBox10.Text = "601"
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(833, 186)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(45, 21)
        Me.TextBox13.TabIndex = 47
        Me.TextBox13.Text = "01"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TextBox15)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Button_Read_Sdo)
        Me.Panel1.Controls.Add(Me.Button_Write_Sdo)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Location = New System.Drawing.Point(433, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(309, 102)
        Me.Panel1.TabIndex = 49
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(789, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Node"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(68, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Node"
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(61, 33)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(45, 21)
        Me.TextBox15.TabIndex = 52
        Me.TextBox15.Text = "601"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(267, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Data"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(189, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Sub Index"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(113, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Main Index"
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(833, 65)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(45, 21)
        Me.TextBox14.TabIndex = 48
        Me.TextBox14.Text = "22"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NodeId, Me.Mian_Index, Me.SubIndex, Me.Data})
        Me.DataGridView1.Location = New System.Drawing.Point(25, 277)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(440, 100)
        Me.DataGridView1.TabIndex = 50
        '
        'NodeId
        '
        Me.NodeId.HeaderText = "NodeId"
        Me.NodeId.Name = "NodeId"
        '
        'Mian_Index
        '
        Me.Mian_Index.DataPropertyName = "1"
        Me.Mian_Index.HeaderText = "Mian Index"
        Me.Mian_Index.Name = "Mian_Index"
        Me.Mian_Index.ToolTipText = "1"
        '
        'SubIndex
        '
        Me.SubIndex.HeaderText = "Sub Index"
        Me.SubIndex.Name = "SubIndex"
        '
        'Data
        '
        Me.Data.HeaderText = "Data"
        Me.Data.Name = "Data"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(478, 310)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 38)
        Me.Button1.TabIndex = 51
        Me.Button1.Text = "Send from grid"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(886, 27)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(164, 197)
        Me.RichTextBox1.TabIndex = 52
        Me.RichTextBox1.Text = "601 22 60F6 01 01" & Global.Microsoft.VisualBasic.ChrW(10) & "601 22 60F6 01 02" & Global.Microsoft.VisualBasic.ChrW(10) & "601 22 60F6 01 03" & Global.Microsoft.VisualBasic.ChrW(10) & "601 22 60F6 01 04"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(800, 232)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(78, 25)
        Me.Button3.TabIndex = 54
        Me.Button3.Text = "Send"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(884, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Send From Text"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(919, 236)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(45, 21)
        Me.TextBox4.TabIndex = 48
        Me.TextBox4.Text = "500"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(884, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Time"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(47, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Node"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(753, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Main Index"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(759, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 57
        Me.Label13.Text = "Sub Index"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(789, 189)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Data"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 387)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox14)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox11)
        Me.Controls.Add(Me.LabelFilterDescription)
        Me.Controls.Add(Me.LabelBaudListBox)
        Me.Controls.Add(Me.ListBoxBaudrate)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.btnAcceptanceID1)
        Me.Controls.Add(Me.btnAcceptanceAll)
        Me.Controls.Add(Me.LblHWID)
        Me.Controls.Add(Me.LabelHardwareID)
        Me.Controls.Add(Me.ListViewAvailInterfaces)
        Me.Controls.Add(Me.LabelCaptionListBox)
        Me.Controls.Add(Me.LabelBusOff)
        Me.Controls.Add(Me.LabelWarningLevel)
        Me.Controls.Add(Me.LabelOverrun)
        Me.Controls.Add(Me.LabelTxPending)
        Me.Controls.Add(Me.LabelInitMode)
        Me.Controls.Add(Me.PictureBoxBusOff)
        Me.Controls.Add(Me.PictureBoxWarningLevel)
        Me.Controls.Add(Me.PictureBoxOverrun)
        Me.Controls.Add(Me.PictureBoxTxPending)
        Me.Controls.Add(Me.PictureBoxInitMode)
        Me.Controls.Add(Me.ButtonTransmitData)
        Me.Controls.Add(Me.labelLastRxMsg)
        Me.Controls.Add(Me.LabelLastRxMsgCaption)
        Me.Controls.Add(Me.ButtonInit)
        Me.Controls.Add(Me.ButtonClose)
        Me.Name = "Form1"
        Me.Text = "VCI4 VB .NET Example"
        CType(Me.PictureBoxInitMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxTxPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxOverrun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxWarningLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxBusOff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents ButtonInit As System.Windows.Forms.Button
    Friend WithEvents LabelLastRxMsgCaption As System.Windows.Forms.Label
    Friend WithEvents labelLastRxMsg As System.Windows.Forms.Label
    Friend WithEvents ButtonTransmitData As System.Windows.Forms.Button
    Friend WithEvents PictureBoxInitMode As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxTxPending As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxOverrun As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxWarningLevel As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxBusOff As System.Windows.Forms.PictureBox
    Friend WithEvents LabelInitMode As System.Windows.Forms.Label
    Friend WithEvents LabelTxPending As System.Windows.Forms.Label
    Friend WithEvents LabelOverrun As System.Windows.Forms.Label
    Friend WithEvents LabelWarningLevel As System.Windows.Forms.Label
    Friend WithEvents LabelBusOff As System.Windows.Forms.Label
    Friend WithEvents TimerGetStatus As System.Windows.Forms.Timer
    Friend WithEvents LabelCaptionListBox As System.Windows.Forms.Label
    Friend WithEvents ListViewAvailInterfaces As System.Windows.Forms.ListView
    Friend WithEvents TimerSendData As System.Windows.Forms.Timer
    Friend WithEvents LabelHardwareID As System.Windows.Forms.Label
    Friend WithEvents LblHWID As System.Windows.Forms.Label
    Friend WithEvents btnAcceptanceAll As System.Windows.Forms.Button
    Friend WithEvents btnAcceptanceID1 As System.Windows.Forms.Button
    Friend WithEvents ListBoxBaudrate As System.Windows.Forms.ListBox
    Friend WithEvents LabelBaudListBox As System.Windows.Forms.Label
    Friend WithEvents LabelFilterDescription As System.Windows.Forms.Label
    Friend WithEvents Button_Read_Sdo As Button
    Friend WithEvents Button_Write_Sdo As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents NodeId As DataGridViewTextBoxColumn
    Friend WithEvents Mian_Index As DataGridViewTextBoxColumn
    Friend WithEvents SubIndex As DataGridViewTextBoxColumn
    Friend WithEvents Data As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
End Class
