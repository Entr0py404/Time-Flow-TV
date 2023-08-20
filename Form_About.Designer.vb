<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_About
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_About))
        Me.Panel_Info = New System.Windows.Forms.Panel()
        Me.PictureBox_ProjectIcon = New System.Windows.Forms.PictureBox()
        Me.Label_ProjectVersion = New System.Windows.Forms.Label()
        Me.Label_WMPVersion = New System.Windows.Forms.Label()
        Me.Label_ProjectTitle = New System.Windows.Forms.Label()
        Me.PictureBox_GifBackground = New System.Windows.Forms.PictureBox()
        Me.Panel_WindowTitleBar = New System.Windows.Forms.Panel()
        Me.Button_Close = New System.Windows.Forms.Button()
        Me.Timer_FadeIn = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_Info.SuspendLayout()
        CType(Me.PictureBox_ProjectIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_GifBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_WindowTitleBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_Info
        '
        Me.Panel_Info.Controls.Add(Me.PictureBox_ProjectIcon)
        Me.Panel_Info.Controls.Add(Me.Label_ProjectVersion)
        Me.Panel_Info.Controls.Add(Me.Label_WMPVersion)
        Me.Panel_Info.Controls.Add(Me.Label_ProjectTitle)
        Me.Panel_Info.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Info.Location = New System.Drawing.Point(0, 34)
        Me.Panel_Info.Name = "Panel_Info"
        Me.Panel_Info.Size = New System.Drawing.Size(300, 158)
        Me.Panel_Info.TabIndex = 4
        '
        'PictureBox_ProjectIcon
        '
        Me.PictureBox_ProjectIcon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_ProjectIcon.Image = Global.TimeFlowTV.My.Resources.Resources.TV0
        Me.PictureBox_ProjectIcon.Location = New System.Drawing.Point(0, 42)
        Me.PictureBox_ProjectIcon.Name = "PictureBox_ProjectIcon"
        Me.PictureBox_ProjectIcon.Size = New System.Drawing.Size(300, 64)
        Me.PictureBox_ProjectIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox_ProjectIcon.TabIndex = 0
        Me.PictureBox_ProjectIcon.TabStop = False
        '
        'Label_ProjectVersion
        '
        Me.Label_ProjectVersion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label_ProjectVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ProjectVersion.Location = New System.Drawing.Point(0, 106)
        Me.Label_ProjectVersion.Name = "Label_ProjectVersion"
        Me.Label_ProjectVersion.Size = New System.Drawing.Size(300, 26)
        Me.Label_ProjectVersion.TabIndex = 3
        Me.Label_ProjectVersion.Text = "v0.0.0.0"
        Me.Label_ProjectVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_WMPVersion
        '
        Me.Label_WMPVersion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label_WMPVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_WMPVersion.Location = New System.Drawing.Point(0, 132)
        Me.Label_WMPVersion.Name = "Label_WMPVersion"
        Me.Label_WMPVersion.Size = New System.Drawing.Size(300, 26)
        Me.Label_WMPVersion.TabIndex = 4
        Me.Label_WMPVersion.Text = "v0.0.0.0"
        Me.Label_WMPVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_ProjectTitle
        '
        Me.Label_ProjectTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label_ProjectTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ProjectTitle.Location = New System.Drawing.Point(0, 0)
        Me.Label_ProjectTitle.Name = "Label_ProjectTitle"
        Me.Label_ProjectTitle.Size = New System.Drawing.Size(300, 42)
        Me.Label_ProjectTitle.TabIndex = 2
        Me.Label_ProjectTitle.Text = "Time Flow TV"
        Me.Label_ProjectTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox_GifBackground
        '
        Me.PictureBox_GifBackground.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_GifBackground.Image = Global.TimeFlowTV.My.Resources.Resources.KY72
        Me.PictureBox_GifBackground.Location = New System.Drawing.Point(0, 34)
        Me.PictureBox_GifBackground.Name = "PictureBox_GifBackground"
        Me.PictureBox_GifBackground.Size = New System.Drawing.Size(300, 450)
        Me.PictureBox_GifBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_GifBackground.TabIndex = 1
        Me.PictureBox_GifBackground.TabStop = False
        '
        'Panel_WindowTitleBar
        '
        Me.Panel_WindowTitleBar.Controls.Add(Me.Button_Close)
        Me.Panel_WindowTitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_WindowTitleBar.Location = New System.Drawing.Point(0, 0)
        Me.Panel_WindowTitleBar.Name = "Panel_WindowTitleBar"
        Me.Panel_WindowTitleBar.Size = New System.Drawing.Size(300, 34)
        Me.Panel_WindowTitleBar.TabIndex = 6
        '
        'Button_Close
        '
        Me.Button_Close.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Button_Close.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button_Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Button_Close.FlatAppearance.BorderSize = 0
        Me.Button_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Button_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Close.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button_Close.Location = New System.Drawing.Point(266, 0)
        Me.Button_Close.Name = "Button_Close"
        Me.Button_Close.Size = New System.Drawing.Size(34, 34)
        Me.Button_Close.TabIndex = 91
        Me.Button_Close.Text = "✗"
        Me.Button_Close.UseVisualStyleBackColor = False
        '
        'Timer_FadeIn
        '
        '
        'Form_About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(300, 484)
        Me.Controls.Add(Me.Panel_Info)
        Me.Controls.Add(Me.PictureBox_GifBackground)
        Me.Controls.Add(Me.Panel_WindowTitleBar)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_About"
        Me.Opacity = 0.8R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.TopMost = True
        Me.Panel_Info.ResumeLayout(False)
        CType(Me.PictureBox_ProjectIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_GifBackground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_WindowTitleBar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox_ProjectIcon As PictureBox
    Friend WithEvents PictureBox_GifBackground As PictureBox
    Friend WithEvents Panel_Info As Panel
    Friend WithEvents Label_ProjectVersion As Label
    Friend WithEvents Label_ProjectTitle As Label
    Friend WithEvents Panel_WindowTitleBar As Panel
    Friend WithEvents Button_Close As Button
    Friend WithEvents Label_WMPVersion As Label
    Friend WithEvents Timer_FadeIn As Timer
End Class
