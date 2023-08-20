<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Statistics
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Statistics))
        Me.Label_FrameRate = New System.Windows.Forms.Label()
        Me.Timer_Statistics = New System.Windows.Forms.Timer(Me.components)
        Me.Label_EncodedFrameRate = New System.Windows.Forms.Label()
        Me.Label_FramesSkipped = New System.Windows.Forms.Label()
        Me.Label_BitRate = New System.Windows.Forms.Label()
        Me.Label_MaxBitRate = New System.Windows.Forms.Label()
        Me.Label_BandWidth = New System.Windows.Forms.Label()
        Me.Label_MaxBandwidth = New System.Windows.Forms.Label()
        Me.Label_ReceivedPackets = New System.Windows.Forms.Label()
        Me.Label_RecoveredPackets = New System.Windows.Forms.Label()
        Me.Label_LostPackets = New System.Windows.Forms.Label()
        Me.Label_BufferingProgress = New System.Windows.Forms.Label()
        Me.Label_BufferingTime = New System.Windows.Forms.Label()
        Me.Label_BufferingCount = New System.Windows.Forms.Label()
        Me.Label_DownloadProgress = New System.Windows.Forms.Label()
        Me.Label_ReceptionQuality = New System.Windows.Forms.Label()
        Me.Label_SourceProtocol = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel_Top1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel_Top2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel_Top5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel_Top3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel_Top4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label_OpenState = New System.Windows.Forms.Label()
        Me.Panel_Top6 = New System.Windows.Forms.Panel()
        Me.Label_PlayerStatus = New System.Windows.Forms.Label()
        Me.Label_PlayState = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_FrameRate
        '
        Me.Label_FrameRate.AutoSize = True
        Me.Label_FrameRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_FrameRate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_FrameRate.Location = New System.Drawing.Point(3, 11)
        Me.Label_FrameRate.Name = "Label_FrameRate"
        Me.Label_FrameRate.Size = New System.Drawing.Size(94, 18)
        Me.Label_FrameRate.TabIndex = 0
        Me.Label_FrameRate.Text = "Frame Rate: "
        '
        'Timer_Statistics
        '
        Me.Timer_Statistics.Enabled = True
        Me.Timer_Statistics.Interval = 500
        '
        'Label_EncodedFrameRate
        '
        Me.Label_EncodedFrameRate.AutoSize = True
        Me.Label_EncodedFrameRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_EncodedFrameRate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_EncodedFrameRate.Location = New System.Drawing.Point(3, 29)
        Me.Label_EncodedFrameRate.Name = "Label_EncodedFrameRate"
        Me.Label_EncodedFrameRate.Size = New System.Drawing.Size(157, 18)
        Me.Label_EncodedFrameRate.TabIndex = 1
        Me.Label_EncodedFrameRate.Text = "Encoded Frame Rate: "
        '
        'Label_FramesSkipped
        '
        Me.Label_FramesSkipped.AutoSize = True
        Me.Label_FramesSkipped.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_FramesSkipped.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_FramesSkipped.Location = New System.Drawing.Point(3, 47)
        Me.Label_FramesSkipped.Name = "Label_FramesSkipped"
        Me.Label_FramesSkipped.Size = New System.Drawing.Size(124, 18)
        Me.Label_FramesSkipped.TabIndex = 3
        Me.Label_FramesSkipped.Text = "Frames Skipped: "
        '
        'Label_BitRate
        '
        Me.Label_BitRate.AutoSize = True
        Me.Label_BitRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_BitRate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_BitRate.Location = New System.Drawing.Point(3, 11)
        Me.Label_BitRate.Name = "Label_BitRate"
        Me.Label_BitRate.Size = New System.Drawing.Size(64, 18)
        Me.Label_BitRate.TabIndex = 2
        Me.Label_BitRate.Text = "Bit Rate:"
        '
        'Label_MaxBitRate
        '
        Me.Label_MaxBitRate.AutoSize = True
        Me.Label_MaxBitRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaxBitRate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_MaxBitRate.Location = New System.Drawing.Point(3, 29)
        Me.Label_MaxBitRate.Name = "Label_MaxBitRate"
        Me.Label_MaxBitRate.Size = New System.Drawing.Size(100, 18)
        Me.Label_MaxBitRate.TabIndex = 7
        Me.Label_MaxBitRate.Text = "Max Bit Rate: "
        '
        'Label_BandWidth
        '
        Me.Label_BandWidth.AutoSize = True
        Me.Label_BandWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_BandWidth.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_BandWidth.Location = New System.Drawing.Point(3, 47)
        Me.Label_BandWidth.Name = "Label_BandWidth"
        Me.Label_BandWidth.Size = New System.Drawing.Size(88, 18)
        Me.Label_BandWidth.TabIndex = 6
        Me.Label_BandWidth.Tag = ""
        Me.Label_BandWidth.Text = "Band Width:"
        '
        'Label_MaxBandwidth
        '
        Me.Label_MaxBandwidth.AutoSize = True
        Me.Label_MaxBandwidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaxBandwidth.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_MaxBandwidth.Location = New System.Drawing.Point(3, 65)
        Me.Label_MaxBandwidth.Name = "Label_MaxBandwidth"
        Me.Label_MaxBandwidth.Size = New System.Drawing.Size(116, 18)
        Me.Label_MaxBandwidth.TabIndex = 5
        Me.Label_MaxBandwidth.Text = "Max Bandwidth: "
        '
        'Label_ReceivedPackets
        '
        Me.Label_ReceivedPackets.AutoSize = True
        Me.Label_ReceivedPackets.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ReceivedPackets.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_ReceivedPackets.Location = New System.Drawing.Point(3, 11)
        Me.Label_ReceivedPackets.Name = "Label_ReceivedPackets"
        Me.Label_ReceivedPackets.Size = New System.Drawing.Size(135, 18)
        Me.Label_ReceivedPackets.TabIndex = 4
        Me.Label_ReceivedPackets.Text = "Received Packets: "
        '
        'Label_RecoveredPackets
        '
        Me.Label_RecoveredPackets.AutoSize = True
        Me.Label_RecoveredPackets.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_RecoveredPackets.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_RecoveredPackets.Location = New System.Drawing.Point(3, 29)
        Me.Label_RecoveredPackets.Name = "Label_RecoveredPackets"
        Me.Label_RecoveredPackets.Size = New System.Drawing.Size(146, 18)
        Me.Label_RecoveredPackets.TabIndex = 8
        Me.Label_RecoveredPackets.Text = "Recovered Packets: "
        '
        'Label_LostPackets
        '
        Me.Label_LostPackets.AutoSize = True
        Me.Label_LostPackets.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LostPackets.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_LostPackets.Location = New System.Drawing.Point(3, 47)
        Me.Label_LostPackets.Name = "Label_LostPackets"
        Me.Label_LostPackets.Size = New System.Drawing.Size(103, 18)
        Me.Label_LostPackets.TabIndex = 9
        Me.Label_LostPackets.Text = "Lost Packets: "
        '
        'Label_BufferingProgress
        '
        Me.Label_BufferingProgress.AutoSize = True
        Me.Label_BufferingProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_BufferingProgress.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_BufferingProgress.Location = New System.Drawing.Point(3, 11)
        Me.Label_BufferingProgress.Name = "Label_BufferingProgress"
        Me.Label_BufferingProgress.Size = New System.Drawing.Size(139, 18)
        Me.Label_BufferingProgress.TabIndex = 10
        Me.Label_BufferingProgress.Text = "Buffering Progress: "
        '
        'Label_BufferingTime
        '
        Me.Label_BufferingTime.AutoSize = True
        Me.Label_BufferingTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_BufferingTime.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_BufferingTime.Location = New System.Drawing.Point(3, 29)
        Me.Label_BufferingTime.Name = "Label_BufferingTime"
        Me.Label_BufferingTime.Size = New System.Drawing.Size(111, 18)
        Me.Label_BufferingTime.TabIndex = 11
        Me.Label_BufferingTime.Text = "Buffering Time: "
        '
        'Label_BufferingCount
        '
        Me.Label_BufferingCount.AutoSize = True
        Me.Label_BufferingCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_BufferingCount.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_BufferingCount.Location = New System.Drawing.Point(3, 47)
        Me.Label_BufferingCount.Name = "Label_BufferingCount"
        Me.Label_BufferingCount.Size = New System.Drawing.Size(118, 18)
        Me.Label_BufferingCount.TabIndex = 12
        Me.Label_BufferingCount.Text = "Buffering Count: "
        '
        'Label_DownloadProgress
        '
        Me.Label_DownloadProgress.AutoSize = True
        Me.Label_DownloadProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_DownloadProgress.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_DownloadProgress.Location = New System.Drawing.Point(3, 11)
        Me.Label_DownloadProgress.Name = "Label_DownloadProgress"
        Me.Label_DownloadProgress.Size = New System.Drawing.Size(148, 18)
        Me.Label_DownloadProgress.TabIndex = 13
        Me.Label_DownloadProgress.Text = "Download Progress: "
        '
        'Label_ReceptionQuality
        '
        Me.Label_ReceptionQuality.AutoSize = True
        Me.Label_ReceptionQuality.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ReceptionQuality.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_ReceptionQuality.Location = New System.Drawing.Point(3, 29)
        Me.Label_ReceptionQuality.Name = "Label_ReceptionQuality"
        Me.Label_ReceptionQuality.Size = New System.Drawing.Size(132, 18)
        Me.Label_ReceptionQuality.TabIndex = 14
        Me.Label_ReceptionQuality.Text = "Reception Quality: "
        '
        'Label_SourceProtocol
        '
        Me.Label_SourceProtocol.AutoSize = True
        Me.Label_SourceProtocol.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SourceProtocol.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_SourceProtocol.Location = New System.Drawing.Point(3, 47)
        Me.Label_SourceProtocol.Name = "Label_SourceProtocol"
        Me.Label_SourceProtocol.Size = New System.Drawing.Size(125, 18)
        Me.Label_SourceProtocol.TabIndex = 15
        Me.Label_SourceProtocol.Text = "Source Protocol: "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label_FrameRate)
        Me.Panel1.Controls.Add(Me.Label_EncodedFrameRate)
        Me.Panel1.Controls.Add(Me.Label_FramesSkipped)
        Me.Panel1.Controls.Add(Me.Panel_Top1)
        Me.Panel1.Location = New System.Drawing.Point(15, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(6, 6, 3, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(256, 68)
        Me.Panel1.TabIndex = 16
        '
        'Panel_Top1
        '
        Me.Panel_Top1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel_Top1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top1.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top1.Name = "Panel_Top1"
        Me.Panel_Top1.Size = New System.Drawing.Size(256, 8)
        Me.Panel_Top1.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel_Top2)
        Me.Panel2.Controls.Add(Me.Label_BitRate)
        Me.Panel2.Controls.Add(Me.Label_MaxBandwidth)
        Me.Panel2.Controls.Add(Me.Label_BandWidth)
        Me.Panel2.Controls.Add(Me.Label_MaxBitRate)
        Me.Panel2.Location = New System.Drawing.Point(15, 95)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(6, 6, 3, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(256, 86)
        Me.Panel2.TabIndex = 17
        '
        'Panel_Top2
        '
        Me.Panel_Top2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel_Top2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top2.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top2.Name = "Panel_Top2"
        Me.Panel_Top2.Size = New System.Drawing.Size(256, 8)
        Me.Panel_Top2.TabIndex = 22
        '
        'Panel5
        '
        Me.Panel5.AutoSize = True
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Panel_Top5)
        Me.Panel5.Controls.Add(Me.Label_ReceivedPackets)
        Me.Panel5.Controls.Add(Me.Label_RecoveredPackets)
        Me.Panel5.Controls.Add(Me.Label_LostPackets)
        Me.Panel5.Location = New System.Drawing.Point(286, 95)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(6, 6, 3, 6)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(333, 86)
        Me.Panel5.TabIndex = 18
        '
        'Panel_Top5
        '
        Me.Panel_Top5.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel_Top5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top5.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top5.Name = "Panel_Top5"
        Me.Panel_Top5.Size = New System.Drawing.Size(333, 8)
        Me.Panel_Top5.TabIndex = 22
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Panel_Top3)
        Me.Panel3.Controls.Add(Me.Label_DownloadProgress)
        Me.Panel3.Controls.Add(Me.Label_ReceptionQuality)
        Me.Panel3.Controls.Add(Me.Label_SourceProtocol)
        Me.Panel3.Location = New System.Drawing.Point(15, 193)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(12, 6, 3, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(256, 68)
        Me.Panel3.TabIndex = 19
        '
        'Panel_Top3
        '
        Me.Panel_Top3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel_Top3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top3.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top3.Name = "Panel_Top3"
        Me.Panel_Top3.Size = New System.Drawing.Size(256, 8)
        Me.Panel_Top3.TabIndex = 22
        '
        'Panel4
        '
        Me.Panel4.AutoSize = True
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Panel_Top4)
        Me.Panel4.Controls.Add(Me.Label_BufferingProgress)
        Me.Panel4.Controls.Add(Me.Label_BufferingTime)
        Me.Panel4.Controls.Add(Me.Label_BufferingCount)
        Me.Panel4.Location = New System.Drawing.Point(286, 15)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(12, 6, 3, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(333, 68)
        Me.Panel4.TabIndex = 20
        '
        'Panel_Top4
        '
        Me.Panel_Top4.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel_Top4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top4.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top4.Name = "Panel_Top4"
        Me.Panel_Top4.Size = New System.Drawing.Size(333, 8)
        Me.Panel_Top4.TabIndex = 22
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Panel6.Controls.Add(Me.Label_OpenState)
        Me.Panel6.Controls.Add(Me.Panel_Top6)
        Me.Panel6.Controls.Add(Me.Label_PlayerStatus)
        Me.Panel6.Controls.Add(Me.Label_PlayState)
        Me.Panel6.Location = New System.Drawing.Point(286, 193)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(12, 6, 3, 6)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(333, 68)
        Me.Panel6.TabIndex = 25
        '
        'Label_OpenState
        '
        Me.Label_OpenState.AutoSize = True
        Me.Label_OpenState.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_OpenState.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_OpenState.Location = New System.Drawing.Point(3, 47)
        Me.Label_OpenState.Name = "Label_OpenState"
        Me.Label_OpenState.Size = New System.Drawing.Size(90, 18)
        Me.Label_OpenState.TabIndex = 23
        Me.Label_OpenState.Text = "Open State: "
        '
        'Panel_Top6
        '
        Me.Panel_Top6.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel_Top6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top6.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top6.Name = "Panel_Top6"
        Me.Panel_Top6.Size = New System.Drawing.Size(333, 8)
        Me.Panel_Top6.TabIndex = 22
        '
        'Label_PlayerStatus
        '
        Me.Label_PlayerStatus.AutoSize = True
        Me.Label_PlayerStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PlayerStatus.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_PlayerStatus.Location = New System.Drawing.Point(3, 11)
        Me.Label_PlayerStatus.Name = "Label_PlayerStatus"
        Me.Label_PlayerStatus.Size = New System.Drawing.Size(103, 18)
        Me.Label_PlayerStatus.TabIndex = 13
        Me.Label_PlayerStatus.Text = "Player Status: "
        '
        'Label_PlayState
        '
        Me.Label_PlayState.AutoSize = True
        Me.Label_PlayState.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PlayState.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_PlayState.Location = New System.Drawing.Point(3, 29)
        Me.Label_PlayState.Name = "Label_PlayState"
        Me.Label_PlayState.Size = New System.Drawing.Size(82, 18)
        Me.Label_PlayState.TabIndex = 14
        Me.Label_PlayState.Text = "Play State: "
        '
        'Form_Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(634, 275)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_Statistics"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Statistics"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_FrameRate As Label
    Friend WithEvents Timer_Statistics As Timer
    Friend WithEvents Label_EncodedFrameRate As Label
    Friend WithEvents Label_FramesSkipped As Label
    Friend WithEvents Label_BitRate As Label
    Friend WithEvents Label_MaxBitRate As Label
    Friend WithEvents Label_BandWidth As Label
    Friend WithEvents Label_MaxBandwidth As Label
    Friend WithEvents Label_ReceivedPackets As Label
    Friend WithEvents Label_RecoveredPackets As Label
    Friend WithEvents Label_LostPackets As Label
    Friend WithEvents Label_BufferingProgress As Label
    Friend WithEvents Label_BufferingTime As Label
    Friend WithEvents Label_BufferingCount As Label
    Friend WithEvents Label_DownloadProgress As Label
    Friend WithEvents Label_ReceptionQuality As Label
    Friend WithEvents Label_SourceProtocol As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel_Top1 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label_PlayerStatus As Label
    Friend WithEvents Label_PlayState As Label
    Friend WithEvents Panel_Top2 As Panel
    Friend WithEvents Panel_Top5 As Panel
    Friend WithEvents Panel_Top3 As Panel
    Friend WithEvents Panel_Top4 As Panel
    Friend WithEvents Panel_Top6 As Panel
    Friend WithEvents Label_OpenState As Label
End Class
