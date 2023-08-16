<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ChannelContent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ChannelContent))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ContentListModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentListModeSortedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentListModeShuffledToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(0, 78)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(785, 410)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label1.Location = New System.Drawing.Point(0, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(785, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(0, 488)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(785, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(0, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(785, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "https://archive.org/download/"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentListModeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(785, 29)
        Me.MenuStrip1.TabIndex = 4
        '
        'ContentListModeToolStripMenuItem
        '
        Me.ContentListModeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ContentListModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentListModeSortedToolStripMenuItem, Me.ContentListModeShuffledToolStripMenuItem})
        Me.ContentListModeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ContentListModeToolStripMenuItem.Name = "ContentListModeToolStripMenuItem"
        Me.ContentListModeToolStripMenuItem.Size = New System.Drawing.Size(145, 25)
        Me.ContentListModeToolStripMenuItem.Text = "Content list mode"
        '
        'ContentListModeSortedToolStripMenuItem
        '
        Me.ContentListModeSortedToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ContentListModeSortedToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ContentListModeSortedToolStripMenuItem.Name = "ContentListModeSortedToolStripMenuItem"
        Me.ContentListModeSortedToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.ContentListModeSortedToolStripMenuItem.Text = "Sorted"
        '
        'ContentListModeShuffledToolStripMenuItem
        '
        Me.ContentListModeShuffledToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ContentListModeShuffledToolStripMenuItem.Checked = True
        Me.ContentListModeShuffledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ContentListModeShuffledToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ContentListModeShuffledToolStripMenuItem.Name = "ContentListModeShuffledToolStripMenuItem"
        Me.ContentListModeShuffledToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.ContentListModeShuffledToolStripMenuItem.Text = "Shuffled"
        '
        'Form_ChannelContent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(785, 512)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_ChannelContent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "URLs List"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ContentListModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContentListModeSortedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContentListModeShuffledToolStripMenuItem As ToolStripMenuItem
End Class
