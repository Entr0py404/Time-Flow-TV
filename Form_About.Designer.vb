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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label_Version = New System.Windows.Forms.Label()
        Me.Label_WMPVersion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button_Close = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label_Version)
        Me.Panel1.Controls.Add(Me.Label_WMPVersion)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 158)
        Me.Panel1.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.TimeFlowTV.My.Resources.Resources.TV0
        Me.PictureBox1.Location = New System.Drawing.Point(0, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label_Version
        '
        Me.Label_Version.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Version.Location = New System.Drawing.Point(0, 106)
        Me.Label_Version.Name = "Label_Version"
        Me.Label_Version.Size = New System.Drawing.Size(300, 26)
        Me.Label_Version.TabIndex = 3
        Me.Label_Version.Text = "v0.0.0.0"
        Me.Label_Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 42)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Time Flow TV"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = Global.TimeFlowTV.My.Resources.Resources.KY72
        Me.PictureBox2.Location = New System.Drawing.Point(0, 34)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(300, 450)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button_Close)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(300, 34)
        Me.Panel2.TabIndex = 6
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
        'Timer1
        '
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(300, 484)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel2)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.Opacity = 0.8R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label_Version As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button_Close As Button
    Friend WithEvents Label_WMPVersion As Label
    Friend WithEvents Timer1 As Timer
End Class
