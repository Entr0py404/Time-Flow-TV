<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.NormalModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChannelsListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlwaysOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StretchToFitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayerControlsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResizeToMediaAspectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResizeToMediaSourceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpacityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubOpacityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlusOpacityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Opacity100ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowLayoutPanel_Channels = New System.Windows.Forms.FlowLayoutPanel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoCloseChannelsListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlwaysOnTopToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StretchToFitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayerControlsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentListModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentListModeSortedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentListModeShuffledToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResizeToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResizeToMediaSourceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResizeToMediaAspectToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediaAspectAutoInNormalModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChannelsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChannelContentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChannelsWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChannelsListToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PopoutModeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChannelContentDurationTotalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurrentMediaNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HotkeysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_CurrentChannel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_PlayerStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel_ChannelsList = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompactToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X32ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X48ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X64ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.X80ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.XToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MediaPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel_ChannelsList.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.MediaPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.NormalModeToolStripMenuItem, Me.ChannelsListToolStripMenuItem, Me.ToolStripSeparator5, Me.AlwaysOnTopToolStripMenuItem, Me.StretchToFitToolStripMenuItem, Me.PlayerControlsToolStripMenuItem, Me.ToolStripSeparator4, Me.MediaAspectAutoInPopoutModeToolStripMenuItem, Me.ResizeToMediaAspectToolStripMenuItem, Me.ResizeToMediaSourceToolStripMenuItem, Me.ResizeToolStripMenuItem, Me.ToolStripSeparator1, Me.OpacityToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowCheckMargin = True
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(289, 274)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(285, 12)
        '
        'NormalModeToolStripMenuItem
        '
        Me.NormalModeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.NormalModeToolStripMenuItem.Name = "NormalModeToolStripMenuItem"
        Me.NormalModeToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.NormalModeToolStripMenuItem.Text = "Normal mode"
        '
        'ChannelsListToolStripMenuItem
        '
        Me.ChannelsListToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ChannelsListToolStripMenuItem.Name = "ChannelsListToolStripMenuItem"
        Me.ChannelsListToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.ChannelsListToolStripMenuItem.Text = "Channels list"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(285, 6)
        '
        'AlwaysOnTopToolStripMenuItem
        '
        Me.AlwaysOnTopToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem"
        Me.AlwaysOnTopToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.AlwaysOnTopToolStripMenuItem.Text = "Always on top"
        '
        'StretchToFitToolStripMenuItem
        '
        Me.StretchToFitToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.StretchToFitToolStripMenuItem.Name = "StretchToFitToolStripMenuItem"
        Me.StretchToFitToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.StretchToFitToolStripMenuItem.Text = "Stretch to fit"
        '
        'PlayerControlsToolStripMenuItem
        '
        Me.PlayerControlsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.PlayerControlsToolStripMenuItem.Name = "PlayerControlsToolStripMenuItem"
        Me.PlayerControlsToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.PlayerControlsToolStripMenuItem.Text = "Player controls"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(285, 6)
        '
        'MediaAspectAutoInPopoutModeToolStripMenuItem
        '
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem.Checked = True
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem.CheckOnClick = True
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem.Name = "MediaAspectAutoInPopoutModeToolStripMenuItem"
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem.Text = "Media aspect auto ( in popout )"
        '
        'ResizeToMediaAspectToolStripMenuItem
        '
        Me.ResizeToMediaAspectToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ResizeToMediaAspectToolStripMenuItem.Name = "ResizeToMediaAspectToolStripMenuItem"
        Me.ResizeToMediaAspectToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.ResizeToMediaAspectToolStripMenuItem.Text = "Resize to media aspect"
        '
        'ResizeToMediaSourceToolStripMenuItem
        '
        Me.ResizeToMediaSourceToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ResizeToMediaSourceToolStripMenuItem.Name = "ResizeToMediaSourceToolStripMenuItem"
        Me.ResizeToMediaSourceToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.ResizeToMediaSourceToolStripMenuItem.Text = "Resize to media source"
        '
        'ResizeToolStripMenuItem
        '
        Me.ResizeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ResizeToolStripMenuItem.Name = "ResizeToolStripMenuItem"
        Me.ResizeToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.ResizeToolStripMenuItem.Text = "Resize"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(285, 6)
        '
        'OpacityToolStripMenuItem
        '
        Me.OpacityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SubOpacityToolStripMenuItem, Me.PlusOpacityToolStripMenuItem, Me.ToolStripMenuItem5, Me.Opacity100ToolStripMenuItem})
        Me.OpacityToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.OpacityToolStripMenuItem.Name = "OpacityToolStripMenuItem"
        Me.OpacityToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.OpacityToolStripMenuItem.Text = "Opacity"
        '
        'SubOpacityToolStripMenuItem
        '
        Me.SubOpacityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.SubOpacityToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SubOpacityToolStripMenuItem.Name = "SubOpacityToolStripMenuItem"
        Me.SubOpacityToolStripMenuItem.Size = New System.Drawing.Size(114, 24)
        Me.SubOpacityToolStripMenuItem.Text = " -"
        '
        'PlusOpacityToolStripMenuItem
        '
        Me.PlusOpacityToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.PlusOpacityToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.PlusOpacityToolStripMenuItem.Name = "PlusOpacityToolStripMenuItem"
        Me.PlusOpacityToolStripMenuItem.Size = New System.Drawing.Size(114, 24)
        Me.PlusOpacityToolStripMenuItem.Text = " +"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(111, 6)
        '
        'Opacity100ToolStripMenuItem
        '
        Me.Opacity100ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Opacity100ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Opacity100ToolStripMenuItem.Name = "Opacity100ToolStripMenuItem"
        Me.Opacity100ToolStripMenuItem.Size = New System.Drawing.Size(114, 24)
        Me.Opacity100ToolStripMenuItem.Text = "100%"
        '
        'FlowLayoutPanel_Channels
        '
        Me.FlowLayoutPanel_Channels.AutoScroll = True
        Me.FlowLayoutPanel_Channels.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.FlowLayoutPanel_Channels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel_Channels.Location = New System.Drawing.Point(0, 33)
        Me.FlowLayoutPanel_Channels.Name = "FlowLayoutPanel_Channels"
        Me.FlowLayoutPanel_Channels.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FlowLayoutPanel_Channels.Size = New System.Drawing.Size(292, 408)
        Me.FlowLayoutPanel_Channels.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ChannelsToolStripMenuItem1, Me.PopoutModeToolStripMenuItem1, Me.InfoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(816, 28)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoCloseChannelsListToolStripMenuItem, Me.AlwaysOnTopToolStripMenuItem1, Me.StretchToFitToolStripMenuItem1, Me.PlayerControlsToolStripMenuItem1, Me.ContentListModeToolStripMenuItem, Me.ResizeToToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'AutoCloseChannelsListToolStripMenuItem
        '
        Me.AutoCloseChannelsListToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.AutoCloseChannelsListToolStripMenuItem.Checked = True
        Me.AutoCloseChannelsListToolStripMenuItem.CheckOnClick = True
        Me.AutoCloseChannelsListToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoCloseChannelsListToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AutoCloseChannelsListToolStripMenuItem.Name = "AutoCloseChannelsListToolStripMenuItem"
        Me.AutoCloseChannelsListToolStripMenuItem.Size = New System.Drawing.Size(232, 24)
        Me.AutoCloseChannelsListToolStripMenuItem.Text = "Auto close channels list"
        '
        'AlwaysOnTopToolStripMenuItem1
        '
        Me.AlwaysOnTopToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.AlwaysOnTopToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AlwaysOnTopToolStripMenuItem1.Name = "AlwaysOnTopToolStripMenuItem1"
        Me.AlwaysOnTopToolStripMenuItem1.Size = New System.Drawing.Size(232, 24)
        Me.AlwaysOnTopToolStripMenuItem1.Text = "Always on top"
        '
        'StretchToFitToolStripMenuItem1
        '
        Me.StretchToFitToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.StretchToFitToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.StretchToFitToolStripMenuItem1.Name = "StretchToFitToolStripMenuItem1"
        Me.StretchToFitToolStripMenuItem1.Size = New System.Drawing.Size(232, 24)
        Me.StretchToFitToolStripMenuItem1.Text = "Stretch to fit"
        '
        'PlayerControlsToolStripMenuItem1
        '
        Me.PlayerControlsToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.PlayerControlsToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.PlayerControlsToolStripMenuItem1.Name = "PlayerControlsToolStripMenuItem1"
        Me.PlayerControlsToolStripMenuItem1.Size = New System.Drawing.Size(232, 24)
        Me.PlayerControlsToolStripMenuItem1.Text = "Player controls"
        '
        'ContentListModeToolStripMenuItem
        '
        Me.ContentListModeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ContentListModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentListModeSortedToolStripMenuItem, Me.ContentListModeShuffledToolStripMenuItem})
        Me.ContentListModeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ContentListModeToolStripMenuItem.Name = "ContentListModeToolStripMenuItem"
        Me.ContentListModeToolStripMenuItem.Size = New System.Drawing.Size(232, 24)
        Me.ContentListModeToolStripMenuItem.Text = "Content list mode"
        '
        'ContentListModeSortedToolStripMenuItem
        '
        Me.ContentListModeSortedToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ContentListModeSortedToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ContentListModeSortedToolStripMenuItem.Name = "ContentListModeSortedToolStripMenuItem"
        Me.ContentListModeSortedToolStripMenuItem.Size = New System.Drawing.Size(133, 24)
        Me.ContentListModeSortedToolStripMenuItem.Text = "Sorted"
        '
        'ContentListModeShuffledToolStripMenuItem
        '
        Me.ContentListModeShuffledToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ContentListModeShuffledToolStripMenuItem.Checked = True
        Me.ContentListModeShuffledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ContentListModeShuffledToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ContentListModeShuffledToolStripMenuItem.Name = "ContentListModeShuffledToolStripMenuItem"
        Me.ContentListModeShuffledToolStripMenuItem.Size = New System.Drawing.Size(133, 24)
        Me.ContentListModeShuffledToolStripMenuItem.Text = "Shuffled"
        '
        'ResizeToToolStripMenuItem
        '
        Me.ResizeToToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ResizeToToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResizeToMediaSourceToolStripMenuItem1, Me.ResizeToMediaAspectToolStripMenuItem1, Me.MediaAspectAutoInPopoutModeToolStripMenuItem1, Me.MediaAspectAutoInNormalModeToolStripMenuItem})
        Me.ResizeToToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ResizeToToolStripMenuItem.Name = "ResizeToToolStripMenuItem"
        Me.ResizeToToolStripMenuItem.Size = New System.Drawing.Size(232, 24)
        Me.ResizeToToolStripMenuItem.Text = "Resize to"
        '
        'ResizeToMediaSourceToolStripMenuItem1
        '
        Me.ResizeToMediaSourceToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ResizeToMediaSourceToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ResizeToMediaSourceToolStripMenuItem1.Name = "ResizeToMediaSourceToolStripMenuItem1"
        Me.ResizeToMediaSourceToolStripMenuItem1.Size = New System.Drawing.Size(288, 24)
        Me.ResizeToMediaSourceToolStripMenuItem1.Text = "Media source"
        '
        'ResizeToMediaAspectToolStripMenuItem1
        '
        Me.ResizeToMediaAspectToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ResizeToMediaAspectToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ResizeToMediaAspectToolStripMenuItem1.Name = "ResizeToMediaAspectToolStripMenuItem1"
        Me.ResizeToMediaAspectToolStripMenuItem1.Size = New System.Drawing.Size(288, 24)
        Me.ResizeToMediaAspectToolStripMenuItem1.Text = "Media aspect"
        '
        'MediaAspectAutoInPopoutModeToolStripMenuItem1
        '
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1.Checked = True
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1.CheckOnClick = True
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1.Name = "MediaAspectAutoInPopoutModeToolStripMenuItem1"
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1.Size = New System.Drawing.Size(288, 24)
        Me.MediaAspectAutoInPopoutModeToolStripMenuItem1.Text = "Media aspect auto ( in popout )"
        '
        'MediaAspectAutoInNormalModeToolStripMenuItem
        '
        Me.MediaAspectAutoInNormalModeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.MediaAspectAutoInNormalModeToolStripMenuItem.CheckOnClick = True
        Me.MediaAspectAutoInNormalModeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.MediaAspectAutoInNormalModeToolStripMenuItem.Name = "MediaAspectAutoInNormalModeToolStripMenuItem"
        Me.MediaAspectAutoInNormalModeToolStripMenuItem.Size = New System.Drawing.Size(288, 24)
        Me.MediaAspectAutoInNormalModeToolStripMenuItem.Text = "Media aspect auto ( in normal )"
        '
        'ChannelsToolStripMenuItem1
        '
        Me.ChannelsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChannelContentToolStripMenuItem, Me.ChannelsWindowToolStripMenuItem, Me.ChannelsListToolStripMenuItem1})
        Me.ChannelsToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ChannelsToolStripMenuItem1.Name = "ChannelsToolStripMenuItem1"
        Me.ChannelsToolStripMenuItem1.Size = New System.Drawing.Size(80, 24)
        Me.ChannelsToolStripMenuItem1.Text = "Channels"
        '
        'ChannelContentToolStripMenuItem
        '
        Me.ChannelContentToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ChannelContentToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ChannelContentToolStripMenuItem.Name = "ChannelContentToolStripMenuItem"
        Me.ChannelContentToolStripMenuItem.Size = New System.Drawing.Size(133, 24)
        Me.ChannelContentToolStripMenuItem.Text = "Content"
        '
        'ChannelsWindowToolStripMenuItem
        '
        Me.ChannelsWindowToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ChannelsWindowToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ChannelsWindowToolStripMenuItem.Name = "ChannelsWindowToolStripMenuItem"
        Me.ChannelsWindowToolStripMenuItem.Size = New System.Drawing.Size(133, 24)
        Me.ChannelsWindowToolStripMenuItem.Text = "Window"
        '
        'ChannelsListToolStripMenuItem1
        '
        Me.ChannelsListToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ChannelsListToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ChannelsListToolStripMenuItem1.Name = "ChannelsListToolStripMenuItem1"
        Me.ChannelsListToolStripMenuItem1.Size = New System.Drawing.Size(133, 24)
        Me.ChannelsListToolStripMenuItem1.Text = "List"
        '
        'PopoutModeToolStripMenuItem1
        '
        Me.PopoutModeToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.PopoutModeToolStripMenuItem1.Name = "PopoutModeToolStripMenuItem1"
        Me.PopoutModeToolStripMenuItem1.Size = New System.Drawing.Size(111, 24)
        Me.PopoutModeToolStripMenuItem1.Text = "Popout mode"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChannelContentDurationTotalToolStripMenuItem, Me.CurrentMediaNameToolStripMenuItem, Me.HotkeysToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.InfoToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(47, 24)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'ChannelContentDurationTotalToolStripMenuItem
        '
        Me.ChannelContentDurationTotalToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ChannelContentDurationTotalToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ChannelContentDurationTotalToolStripMenuItem.Name = "ChannelContentDurationTotalToolStripMenuItem"
        Me.ChannelContentDurationTotalToolStripMenuItem.Size = New System.Drawing.Size(280, 24)
        Me.ChannelContentDurationTotalToolStripMenuItem.Text = "Channel content duration total"
        '
        'CurrentMediaNameToolStripMenuItem
        '
        Me.CurrentMediaNameToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.CurrentMediaNameToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CurrentMediaNameToolStripMenuItem.Name = "CurrentMediaNameToolStripMenuItem"
        Me.CurrentMediaNameToolStripMenuItem.Size = New System.Drawing.Size(280, 24)
        Me.CurrentMediaNameToolStripMenuItem.Text = "Current media name"
        '
        'HotkeysToolStripMenuItem
        '
        Me.HotkeysToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.HotkeysToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.HotkeysToolStripMenuItem.Name = "HotkeysToolStripMenuItem"
        Me.HotkeysToolStripMenuItem.Size = New System.Drawing.Size(280, 24)
        Me.HotkeysToolStripMenuItem.Text = "Hotkeys"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.AboutToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(280, 24)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_CurrentChannel, Me.ToolStripStatusLabel_PlayerStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 469)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(816, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel_CurrentChannel
        '
        Me.ToolStripStatusLabel_CurrentChannel.Name = "ToolStripStatusLabel_CurrentChannel"
        Me.ToolStripStatusLabel_CurrentChannel.Size = New System.Drawing.Size(51, 17)
        Me.ToolStripStatusLabel_CurrentChannel.Text = "Channel"
        '
        'ToolStripStatusLabel_PlayerStatus
        '
        Me.ToolStripStatusLabel_PlayerStatus.Name = "ToolStripStatusLabel_PlayerStatus"
        Me.ToolStripStatusLabel_PlayerStatus.Size = New System.Drawing.Size(71, 17)
        Me.ToolStripStatusLabel_PlayerStatus.Text = "PlayerStatus"
        '
        'Panel_ChannelsList
        '
        Me.Panel_ChannelsList.Controls.Add(Me.FlowLayoutPanel_Channels)
        Me.Panel_ChannelsList.Controls.Add(Me.MenuStrip2)
        Me.Panel_ChannelsList.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel_ChannelsList.Location = New System.Drawing.Point(524, 28)
        Me.Panel_ChannelsList.Name = "Panel_ChannelsList"
        Me.Panel_ChannelsList.Size = New System.Drawing.Size(292, 441)
        Me.Panel_ChannelsList.TabIndex = 41
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.XToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(292, 33)
        Me.MenuStrip2.TabIndex = 0
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompactToolStripMenuItem, Me.X32ToolStripMenuItem, Me.X48ToolStripMenuItem, Me.X64ToolStripMenuItem, Me.X80ToolStripMenuItem, Me.ToolStripSeparator3})
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(41, 29)
        Me.ToolStripMenuItem1.Text = "☰"
        '
        'CompactToolStripMenuItem
        '
        Me.CompactToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.CompactToolStripMenuItem.CheckOnClick = True
        Me.CompactToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CompactToolStripMenuItem.Name = "CompactToolStripMenuItem"
        Me.CompactToolStripMenuItem.Size = New System.Drawing.Size(159, 30)
        Me.CompactToolStripMenuItem.Text = "Compact"
        '
        'X32ToolStripMenuItem
        '
        Me.X32ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.X32ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.X32ToolStripMenuItem.Name = "X32ToolStripMenuItem"
        Me.X32ToolStripMenuItem.Size = New System.Drawing.Size(159, 30)
        Me.X32ToolStripMenuItem.Text = "32x"
        '
        'X48ToolStripMenuItem
        '
        Me.X48ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.X48ToolStripMenuItem.Checked = True
        Me.X48ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.X48ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.X48ToolStripMenuItem.Name = "X48ToolStripMenuItem"
        Me.X48ToolStripMenuItem.Size = New System.Drawing.Size(159, 30)
        Me.X48ToolStripMenuItem.Text = "48x"
        '
        'X64ToolStripMenuItem
        '
        Me.X64ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.X64ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.X64ToolStripMenuItem.Name = "X64ToolStripMenuItem"
        Me.X64ToolStripMenuItem.Size = New System.Drawing.Size(159, 30)
        Me.X64ToolStripMenuItem.Text = "64x"
        '
        'X80ToolStripMenuItem
        '
        Me.X80ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.X80ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.X80ToolStripMenuItem.Name = "X80ToolStripMenuItem"
        Me.X80ToolStripMenuItem.Size = New System.Drawing.Size(159, 30)
        Me.X80ToolStripMenuItem.Text = "80x"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(156, 6)
        '
        'XToolStripMenuItem
        '
        Me.XToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.XToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.XToolStripMenuItem.Name = "XToolStripMenuItem"
        Me.XToolStripMenuItem.Size = New System.Drawing.Size(40, 29)
        Me.XToolStripMenuItem.Text = "✕"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.ToolTip1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Channel: "
        '
        'Timer1
        '
        '
        'MediaPlayer
        '
        Me.MediaPlayer.ContextMenuStrip = Me.ContextMenuStrip1
        Me.MediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MediaPlayer.Enabled = True
        Me.MediaPlayer.Location = New System.Drawing.Point(0, 28)
        Me.MediaPlayer.Name = "MediaPlayer"
        Me.MediaPlayer.OcxState = CType(resources.GetObject("MediaPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MediaPlayer.Size = New System.Drawing.Size(524, 441)
        Me.MediaPlayer.TabIndex = 40
        Me.MediaPlayer.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(524, 441)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 42
        Me.PictureBox1.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(816, 491)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MediaPlayer)
        Me.Controls.Add(Me.Panel_ChannelsList)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time Flow TV"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel_ChannelsList.ResumeLayout(False)
        Me.Panel_ChannelsList.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.MediaPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel_Channels As FlowLayoutPanel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel_CurrentChannel As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_PlayerStatus As ToolStripStatusLabel
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlwaysOnTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormalModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChannelsListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PopoutModeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AlwaysOnTopToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents StretchToFitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StretchToFitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MediaPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents PlayerControlsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PlayerControlsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AutoCloseChannelsListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResizeToMediaSourceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContentListModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContentListModeSortedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContentListModeShuffledToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResizeToMediaAspectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResizeToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResizeToMediaSourceToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ResizeToMediaAspectToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MediaAspectAutoInPopoutModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MediaAspectAutoInPopoutModeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MediaAspectAutoInNormalModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChannelsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ChannelsListToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ChannelsWindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChannelContentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel_ChannelsList As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents X32ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents X64ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents X80ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents CompactToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents X48ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HotkeysToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ChannelContentDurationTotalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CurrentMediaNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents OpacityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Opacity100ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents PlusOpacityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubOpacityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
End Class
