'Imports System.Reflection.Emit
'Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading

Public Class MainForm
    Private CurrentChannel_videoFiles As String()
    Private CurrentChannel_videoDurations As Integer()
    Private currentIndex As Integer = 0
    Private currentChannel As Integer = 0
    Private currentChannelName As String = ""
    Private PopoutDesktopMode As Boolean = False
    Private elapsedTime As Integer = 0

    Private ContentListModeShuffled As Boolean = True

    Private DefaultChannelIconNumber As Integer = 1

    Private targetOpacity As Double = 1.0
    Private currentOpacity As Double = 0.0
    'Private Const MAX_VOLUME As Integer = &HFFFF
    'Private Const WAVE_MAPPER As Integer = -1

    '<DllImport("winmm.dll")>
    'Private Shared Function waveOutGetVolume(ByVal hwo As IntPtr, ByRef dwVolume As Integer) As Integer
    'End Function

    '<DllImport("winmm.dll")>
    'Private Shared Function waveOutSetVolume(ByVal hwo As IntPtr, ByVal dwVolume As Integer) As Integer
    'End Function

    ' MainForm - Load
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContextMenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        MenuStrip2.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

        If Not Directory.Exists(Application.StartupPath & "\Channels") Then
            Directory.CreateDirectory(Application.StartupPath & "\Channels")
        End If

        If Not Directory.Exists(Application.StartupPath & "\Channels\Sorted") Then
            Directory.CreateDirectory(Application.StartupPath & "\Channels\Sorted")
        End If

        PictureBox1.Image = My.Resources.Intro

        MediaPlayer.uiMode = "none"
        MediaPlayer.windowlessVideo = True
        MediaPlayer.stretchToFit = True
        MediaPlayer.enableContextMenu = False
        MediaPlayer.Ctlenabled = True
        MediaPlayer.settings.autoStart = True
        MediaPlayer.settings.volume = 100

        If MediaPlayer.stretchToFit Then
            StretchToFitToolStripMenuItem1.Checked = True
            StretchToFitToolStripMenuItem.Checked = True
        Else
            StretchToFitToolStripMenuItem1.Checked = False
            StretchToFitToolStripMenuItem.Checked = False
        End If

        ToolStripStatusLabel_PlayerStatus.Text = MediaPlayer.status

        Me.Opacity = 0.0
        currentOpacity = Me.Opacity
        Timer1.Start()

        'UpdateURLsList()
    End Sub

    ' MainForm - FormClosing
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Clean up the resources.
        MediaPlayer.close()

        ' Save settings.

    End Sub

    ' PlayVideoAtCurrentTime
    Private Sub PlayVideoAtCurrentTime()

        ' Get the current UTC time and convert it to Central Time.
        ' Dim currentTimeUTC As DateTime = DateTime.UtcNow
        ' Dim centralTime As DateTime = DateTime.UtcNow ' TimeZoneInfo.ConvertTimeFromUtc(currentTimeUTC, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"))

        ' Get the current UTC time and convert it to Central Time.
        Dim currentTimeUTC As DateTime = DateTime.UtcNow
        Dim centralTime As DateTime = TimeZoneInfo.ConvertTimeFromUtc(currentTimeUTC, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"))

        ' Calculate the start time of the current week (Sunday midnight).
        Dim startTimeOfWeek As DateTime = centralTime.Date.AddDays(-(CInt(centralTime.DayOfWeek)))
        ' Calculate the elapsed time (in seconds) since the start of the week's content.
        Dim elapsedTime As Integer = CInt((centralTime - startTimeOfWeek).TotalSeconds)

        ' Calculate the total duration of one week's worth of content (sum of videoDurations array).
        Dim totalDuration As Integer = CurrentChannel_videoDurations.Sum()

        ' Check if the elapsed time is within the total duration of one week's worth of content.
        If elapsedTime >= totalDuration Then
            ' Start a new cycle and calculate the remaining elapsed time.
            Dim remainingElapsedTime As Integer = elapsedTime Mod totalDuration
            Dim numCyclesCompleted As Integer = elapsedTime \ totalDuration
            currentIndex = (currentIndex + numCyclesCompleted) Mod CurrentChannel_videoFiles.Length
            elapsedTime = remainingElapsedTime
        End If

        ' Find the current video and its playback position.
        Dim currentVideo As String = ""
        Dim playbackPosition As Integer = 0

        For i As Integer = 0 To CurrentChannel_videoDurations.Length - 1
            If elapsedTime < CurrentChannel_videoDurations(i) Then
                currentIndex = (currentIndex * CurrentChannel_videoDurations.Length + i) Mod CurrentChannel_videoFiles.Length
                currentVideo = CurrentChannel_videoFiles(currentIndex)
                playbackPosition = elapsedTime
                Exit For
            End If
            elapsedTime -= CurrentChannel_videoDurations(i)
        Next

        ' Play the current video at the correct playback position.
        PlayVideo(currentVideo, playbackPosition)
    End Sub

    ' MediaPlayer - PlayStateChange
    Private Sub MediaPlayer_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles MediaPlayer.PlayStateChange
        ' Check if the media player has reached the end of the current video (wmppsMediaEnded state).
        If e.newState = WMPPlayState.wmppsMediaEnded Then
            ' Move to the next video.
            currentIndex = (currentIndex + 1) Mod CurrentChannel_videoFiles.Length
            ' Reset the elapsed time for the new video.
            elapsedTime = 0

            Console.WriteLine("currentIndex: " & currentIndex)
            Console.WriteLine(CurrentChannel_videoFiles(currentIndex))

            ' Play the next video.
            PlayVideo(CurrentChannel_videoFiles(currentIndex), 0)
        End If
        'ElseIf e.newState = WMPPlayState. Then
        'MediaPlayer.Ctlcontrols.play()
        'Console.WriteLine("WMPPlayState.wmppsReady")
        'End If
        'ElseIf MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
        'ToolStripStatusLabel_PlayerStatus.Text = MediaPlayer.status.Replace("'" & MediaPlayer.currentMedia.name.ToString & "':", "@")
        'URLsList.Label2.Text = MediaPlayer.currentMedia.name.ToString()
        'Else
        'ToolStripStatusLabel_PlayerStatus.Text = MediaPlayer.status
        'End If

        If MediaPlayer.playState = WMPPlayState.wmppsReady Then
            MediaPlayer.Ctlcontrols.play()
            Console.WriteLine("WMPPlayState.wmppsReady")
        End If

        If MediaPlayer.playState = WMPPlayState.wmppsBuffering Then
            PictureBox1.Image = My.Resources.Buffering
            PictureBox1.Visible = True
        End If

        If MediaPlayer.playState = WMPPlayState.wmppsReady Or MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
            PictureBox1.Image = Nothing
            PictureBox1.Visible = False
        End If

    End Sub

    ' MediaPlayer - MediaError
    Private Sub MediaPlayer_MediaError(sender As Object, e As _WMPOCXEvents_MediaErrorEvent) Handles MediaPlayer.MediaError
        PictureBox1.Image = My.Resources.No_Content
        PictureBox1.Visible = True
    End Sub

    ' PlayVideo
    Private Sub PlayVideo(videoFile As String, playbackPosition As Integer)
        ' Stop the current video (if any) and load and play the new video.
        MediaPlayer.Ctlcontrols.stop()

        ' Load the new video.
        MediaPlayer.URL = videoFile
        Console.WriteLine(MediaPlayer.URL)

        ' Seek to the specified playback position.
        If playbackPosition > 0 Then
            ' If the playback position is not 0, seek to the paused position.
            MediaPlayer.Ctlcontrols.currentPosition = playbackPosition
        End If

        ' Play the video.
        'MediaPlayer.Ctlcontrols.play()
        'Console.WriteLine("MediaPlayer.Ctlcontrols.play()")
        'URLsList.Label2.Text = MediaPlayer.currentMedia.name.ToString()

        ' Update the currentIndex to ensure it stays within the valid range.
        currentIndex = currentIndex Mod CurrentChannel_videoFiles.Length
        Console.WriteLine("currentIndex: " & currentIndex)
    End Sub

    ' ChannelLabel - MouseEnter
    Private Sub ChannelLabel_MouseEnter(sender As Object, e As EventArgs)
        If Not DirectCast(sender, Label).BackColor = Color.MediumSeaGreen Then ' DirectCast(sender, Label)
            DirectCast(sender, Label).BackColor = Color.DodgerBlue ' DirectCast(sender, Label)
        End If
    End Sub

    ' ChannelLabel - MouseLeave
    Private Sub ChannelLabel_MouseLeave(sender As Object, e As EventArgs)
        If Not DirectCast(sender, Label).BackColor = Color.MediumSeaGreen Then ' DirectCast(sender, Label)
            DirectCast(sender, Label).BackColor = Color.FromArgb(28, 30, 34) ' DirectCast(sender, Label)
        End If
    End Sub

    ' ChannelLabel - Click
    Private Sub ChannelLabel_Click(sender As Object, e As EventArgs)
        currentChannel = FlowLayoutPanel_Channels.Controls.GetChildIndex(DirectCast(sender, Label).Parent) ' DirectCast(sender, Label)
        ColorizeCurrentChannel()
        UpdateURLsList()

        If AutoCloseChannelsListToolStripMenuItem.Checked Then
            Panel_ChannelsList.Hide()
        End If
    End Sub

    ' ChannelImage - MouseEnter
    Private Sub ChannelImage_MouseEnter(sender As Object, e As EventArgs)
        If Not DirectCast(sender, PictureBox).BackColor = Color.MediumSeaGreen Then ' DirectCast(sender, Label)
            DirectCast(sender, PictureBox).BackColor = Color.DodgerBlue ' DirectCast(sender, Label)
        End If
    End Sub

    ' ChannelImage - MouseLeave
    Private Sub ChannelImage_MouseLeave(sender As Object, e As EventArgs)
        If Not DirectCast(sender, PictureBox).BackColor = Color.MediumSeaGreen Then ' DirectCast(sender, Label)
            DirectCast(sender, PictureBox).BackColor = Color.FromArgb(28, 30, 34) ' DirectCast(sender, Label)
        End If
    End Sub

    ' ChannelImage - Click
    Private Sub ChannelImage_Click(sender As Object, e As EventArgs)
        currentChannel = FlowLayoutPanel_Channels.Controls.GetChildIndex(DirectCast(sender, PictureBox).Parent) ' DirectCast(sender, Label)
        ColorizeCurrentChannel()
        UpdateURLsList()

        If AutoCloseChannelsListToolStripMenuItem.Checked Then
            Panel_ChannelsList.Hide()
        End If
    End Sub

    ' ColorizeCurrentChannel
    Private Sub ColorizeCurrentChannel()
        UncolorizeChannels()
        FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(0).BackColor = Color.MediumSeaGreen

        currentChannelName = FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(0).Text
        ToolStripStatusLabel_CurrentChannel.Text = currentChannelName

        If ContentListModeShuffled = True Then
            If File.Exists(FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text) Then
                ReadChannelFile(FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text)
            End If
        Else
            Dim FileStr As String = FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text
            Dim DirStr As String = Path.GetDirectoryName(FileStr)
            Dim FileNameStr As String = Path.GetFileName(FileStr)
            Dim TmpStr As String = DirStr & "\Sorted\" & FileNameStr

            'Console.WriteLine(TmpStr)
            If File.Exists(TmpStr) Then
                ReadChannelFile(TmpStr)
            End If
        End If
    End Sub

    ' UncolorizeChannels
    Private Sub UncolorizeChannels()
        For I = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
            FlowLayoutPanel_Channels.Controls.Item(I).Controls.Item(0).BackColor = Color.FromArgb(28, 30, 34)
        Next
    End Sub

    ' MediaPlayer - KeyDownEvent
    Private Sub MediaPlayer_KeyDownEvent(sender As Object, e As _WMPOCXEvents_KeyDownEvent) Handles MediaPlayer.KeyDownEvent
        If e.nKeyCode = Keys.Down Then ' Channel Down
            If currentChannel < FlowLayoutPanel_Channels.Controls.Count - 1 Then
                currentChannel += 1
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            Else
                currentChannel = 0
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            End If
        ElseIf e.nKeyCode = Keys.Up Then ' Channel Up
            If currentChannel > 0 Then
                currentChannel -= 1
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            Else
                currentChannel = 7
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            End If
        ElseIf e.nKeyCode = Keys.C Then ' ChannelsList 
            ChannelsListToolStripMenuItem1.PerformClick()
        ElseIf e.nKeyCode = Keys.F11 Then
            If MediaPlayer.fullScreen Then
                MediaPlayer.fullScreen = False
            Else
                If MediaPlayer.playState = 3 Then
                    MediaPlayer.fullScreen = True
                End If
            End If
        ElseIf e.nKeyCode = Keys.Escape And PopoutDesktopMode = True Then ' Exit Popout Mode
            SetPopoutDesktopMode_False()
        ElseIf e.nKeyCode = Keys.P Then ' Popout Mode
            If PopoutDesktopMode Then
                SetPopoutDesktopMode_False()
            Else
                SetPopoutDesktopMode_True()
            End If
        ElseIf e.nKeyCode = Keys.R Then ' Resize Mode
            If PopoutDesktopMode Then
                Me.FormBorderStyle = FormBorderStyle.Sizable
            End If
        ElseIf e.nKeyCode = Keys.F2 Then 'Channel Duration Information
            ChannelContentDurationTotalToolStripMenuItem.PerformClick()
        ElseIf e.nKeyCode = Keys.PageUp Then
            'SetVolume(100) ' Testing
            'MediaPlayer.settings.volume += 1
        ElseIf e.nKeyCode = Keys.PageDown Then
            'SetVolume(0) ' Testing
            'MediaPlayer.settings.volume -= 1
        ElseIf e.nKeyCode = Keys.I Then ' Information
            CurrentMediaNameToolStripMenuItem.PerformClick()
        ElseIf e.nKeyCode = Keys.L Then ' URLsList
            ChannelContent.Show()
            UpdateURLsList()
        ElseIf e.nKeyCode = Keys.S Then
            ResizeToMedia()
        ElseIf e.nKeyCode = Keys.F1 Then
            HotkeysToolStripMenuItem.PerformClick()
        End If
    End Sub

    ' UpdateURLsList
    Private Sub UpdateURLsList()
        ChannelContent.Label1.Text = currentChannelName
        ChannelContent.ListBox1.BeginUpdate()
        ChannelContent.ListBox1.Items.Clear()
        For Each videoFileURl In CurrentChannel_videoFiles
            Dim urlname As String = videoFileURl.Replace("https://archive.org/download/", "")
            ChannelContent.ListBox1.Items.Add(urlname)
        Next
        ' URLsList.ListBox1.Items.AddRange(CurrentChannel_videoFiles)

        ChannelContent.ListBox1.EndUpdate()

        ChannelContent.Label2.Text = MediaPlayer.currentMedia.name.ToString()

        If Not currentIndex > ChannelContent.ListBox1.Items.Count - 1 Then
            ChannelContent.ListBox1.SelectedIndex = currentIndex
        End If
    End Sub

    ' MediaPlayer_StatusChange
    Private Sub MediaPlayer_StatusChange(sender As Object, e As EventArgs) Handles MediaPlayer.StatusChange
        If MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
            ToolStripStatusLabel_PlayerStatus.Text = MediaPlayer.status.Replace("'" & MediaPlayer.currentMedia.name.ToString & "':", "@")
            ChannelContent.Label2.Text = MediaPlayer.currentMedia.name.ToString()
        Else
            ToolStripStatusLabel_PlayerStatus.Text = MediaPlayer.status
        End If

        If MediaPlayer.status.ToString = "Connecting..." Then
            PictureBox1.Image = My.Resources.Connecting
            PictureBox1.Visible = True
        End If

        'Console.WriteLine(MediaPlayer.status.ToString())

        'If MediaPlayer.playState = WMPPlayState. Then
        'MediaPlayer.Ctlcontrols.play()
        'Console.WriteLine("WMPPlayState.wmppsReady")
        'End If
    End Sub

    ' MediaPlayer - MouseDownEvent
    Private Sub MediaPlayer_MouseDownEvent(sender As Object, e As _WMPOCXEvents_MouseDownEvent) Handles MediaPlayer.MouseDownEvent
        If e.nButton = 1 Then
            MediaPlayer.Capture = False
            Const WM_NCLBUTTONDOWN As Integer = &HA1S
            Const HTCAPTION As Integer = 2
            Dim msg As Message = Message.Create(Me.Handle, WM_NCLBUTTONDOWN, New IntPtr(HTCAPTION), IntPtr.Zero)
            Me.DefWndProc(msg)
        ElseIf e.nButton = 2 Then
            If PopoutDesktopMode Then
                MediaPlayer.ContextMenuStrip.Show(MousePosition.X, MousePosition.Y)
            End If
        End If
    End Sub

    ' MainForm - ResizeEnd
    Private Sub MainForm_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        If PopoutDesktopMode Then
            Me.FormBorderStyle = FormBorderStyle.None
            If MediaAspectAutoInPopoutModeToolStripMenuItem1.Checked Then
                CalculateVideoAspectRatio_ResizeToAspectResolution()
            End If
        Else
            If MediaAspectAutoInNormalModeToolStripMenuItem.Checked Then
                CalculateVideoAspectRatio_ResizeToAspectResolution()
            End If
        End If
    End Sub

    ' ResizeToMedia
    Private Sub ResizeToMedia()
        If MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
            If MenuStrip1.Visible Then
                Dim CR As Rectangle = RectangleToScreen(Me.ClientRectangle)
                Dim TitlebarHeight As Integer = CR.Top - Me.Top - 4
                Me.Height = MediaPlayer.currentMedia.imageSourceHeight + MenuStrip1.Height + StatusStrip1.Height + TitlebarHeight
                Me.Width = MediaPlayer.currentMedia.imageSourceWidth
            Else
                Me.Height = MediaPlayer.currentMedia.imageSourceHeight
                Me.Width = MediaPlayer.currentMedia.imageSourceWidth
            End If
        End If
    End Sub

    ' ReadChannelFile
    Private Sub ReadChannelFile(ChannelFilePath As String)
        Dim videoFilesList As New List(Of String)()
        Dim videoDurationsList As New List(Of Integer)()

        ' Check if the file exists before proceeding.
        If File.Exists(ChannelFilePath) Then
            Try
                ' Read all lines from the file into an array.
                Dim lines As String() = File.ReadAllLines(ChannelFilePath)

                ' Process each line.
                For Each line As String In lines
                    ' Split the line using the "|" character as the delimiter.
                    Dim splitParts As String() = line.Split("|"c)

                    ' Check if the line contains the "|" character before adding to the lists.
                    If splitParts.Length = 2 Then
                        ' Add both sides of the split to the respective lists.
                        videoFilesList.Add(splitParts(0))
                        videoDurationsList.Add(CInt(Single.Parse(splitParts(1))))
                    Else
                        ' Handle the case where the line does not contain the "|" character.
                        Console.WriteLine("Invalid line format: " & line)
                    End If
                Next

                ' Convert the lists to arrays and store them in CurrentChannel_videoFiles and CurrentChannel_videoDurations.
                CurrentChannel_videoFiles = videoFilesList.ToArray()
                CurrentChannel_videoDurations = videoDurationsList.ToArray()

                PlayVideoAtCurrentTime()

            Catch ex As Exception
                'Handle any exceptions that may occur during file reading Or processing.
                Console.WriteLine("Error reading the file: " & ex.Message)
            End Try
        Else
            ' Handle the case where the file does not exist.
            Console.WriteLine("File not found: " & ChannelFilePath)
        End If
    End Sub

    ' BuildChannelsList
    Private Sub BuildChannelsList()
        Dim ImagePathStr As String = ""
        Dim FilePathStr As String = ""
        Dim ChannelNameStr As String = ""
        Dim MatchedChannels As New ArrayList

        Dim ChannelCFGs() As String = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Channels", FileIO.SearchOption.SearchTopLevelOnly, "*.cfg").ToArray

        Dim directoryPath As String = Path.Combine(Application.StartupPath, "Channels")
        Dim channelOrderFile As String = Path.Combine(Application.StartupPath, "Channel Order.cfg")

        'Console.WriteLine(directoryPath)
        'Console.WriteLine(channelOrderFile)

        FlowLayoutPanel_Channels.Controls.Clear()

        If File.Exists(channelOrderFile) Then

            Dim channelNames As New List(Of String)(File.ReadAllLines(channelOrderFile))
            Dim cfgFiles As String() = Directory.GetFiles(directoryPath, "*.cfg")

            Dim combinedCFGFiles As New List(Of String)()

            For Each channelName As String In channelNames
                Dim matchingCFGFile As String = cfgFiles.FirstOrDefault(Function(cfgFile) Path.GetFileNameWithoutExtension(cfgFile).Equals(channelName))
                If matchingCFGFile IsNot Nothing Then
                    combinedCFGFiles.Add(matchingCFGFile)
                    cfgFiles = cfgFiles.Where(Function(cfgFile) Not cfgFile.Equals(matchingCFGFile)).ToArray()
                End If
            Next

            ' Add the remaining CFG files that didn't match any channel name
            combinedCFGFiles.AddRange(cfgFiles)

            ' Now you have the combined CFG files list in "combinedCFGFiles"
            For Each CFGFile As String In combinedCFGFiles
                FilePathStr = CFGFile
                ChannelNameStr = Path.GetFileNameWithoutExtension(CFGFile)
                ImagePathStr = Path.ChangeExtension(FilePathStr, "png") ' File might not exist
                'Console.WriteLine(ImagePathStr)

                CreateChannel(ChannelNameStr, FilePathStr, ImagePathStr)
            Next

        Else ' Handle the case when "channel order.cfg" file doesn't exist in the directory

            For Each CFGFile As String In ChannelCFGs
                FilePathStr = CFGFile
                ChannelNameStr = Path.GetFileNameWithoutExtension(CFGFile)
                ImagePathStr = Path.ChangeExtension(FilePathStr, "png") ' File might not exist
                'Console.WriteLine(ImagePathStr)

                CreateChannel(ChannelNameStr, FilePathStr, ImagePathStr)
            Next

        End If
    End Sub

    ' Create Channel
    Private Sub CreateChannel(ChannelName As String, ChannelFilePath As String, ChannelImagePath As String)
        Console.WriteLine("Creating channel: " & ChannelName) ' Debug output

        ' Panel
        Dim ChannelPanel = New Panel
        ChannelPanel.Size = New Size(253, 48)
        ChannelPanel.BackColor = Color.FromArgb(28, 30, 34)
        ChannelPanel.Name = "Panel_Channel"
        ChannelPanel.Margin = New Padding(12, 6, 3, 6)

        ' PictureBox
        Dim ChannelPictureBox = New PictureBox
        ChannelPictureBox.Dock = DockStyle.Left
        ChannelPictureBox.Size = New Size(48, 48)
        ChannelPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ChannelPictureBox.Name = "PictureBox_ChannelLogo"
        ChannelPictureBox.Text = ChannelFilePath


        If File.Exists(ChannelImagePath) Then
            ChannelPictureBox.Image = SafeImageFromFile(ChannelImagePath)
        Else

            If DefaultChannelIconNumber >= 9 Then
                DefaultChannelIconNumber = 1
            End If

            Select Case DefaultChannelIconNumber
                Case 1
                    ChannelPictureBox.Image = My.Resources.TV1
                Case 2
                    ChannelPictureBox.Image = My.Resources.TV2
                Case 3
                    ChannelPictureBox.Image = My.Resources.TV3
                Case 4
                    ChannelPictureBox.Image = My.Resources.TV4
                Case 5
                    ChannelPictureBox.Image = My.Resources.TV5
                Case 6
                    ChannelPictureBox.Image = My.Resources.TV6
                Case 7
                    ChannelPictureBox.Image = My.Resources.TV7
                Case 8
                    ChannelPictureBox.Image = My.Resources.TV8
                Case Else
                    ChannelPictureBox.Image = My.Resources.TV1
            End Select

            DefaultChannelIconNumber += 1

        End If

        ' Label
        Dim ChannelLabel = New Label
        ChannelLabel.AutoEllipsis = True
        ChannelLabel.TextAlign = ContentAlignment.MiddleLeft
        ChannelLabel.Dock = DockStyle.Fill
        ChannelLabel.Text = ChannelName
        ChannelLabel.ForeColor = Color.WhiteSmoke
        ChannelLabel.Font = New Font("Microsoft Sans Serif", 11.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        ChannelLabel.Cursor = Cursors.Hand

        ' Add Child Object to Channel Panel
        ChannelPanel.Controls.Add(ChannelLabel)
        ChannelPanel.Controls.Add(ChannelPictureBox)

        ' Add ChannelPanel to FlowLayoutPanel1
        FlowLayoutPanel_Channels.Controls.Add(ChannelPanel)

        AddHandler ChannelLabel.MouseEnter, AddressOf ChannelLabel_MouseEnter
        AddHandler ChannelLabel.MouseLeave, AddressOf ChannelLabel_MouseLeave
        AddHandler ChannelLabel.Click, AddressOf ChannelLabel_Click
    End Sub

    ' SafeImageFromFile()
    Public Shared Function SafeImageFromFile(path As String) As Image
        ' Load an image from a file into a safe memory stream
        Dim bytes = File.ReadAllBytes(path)
        Using ms As New MemoryStream(bytes)
            Dim img = Image.FromStream(ms)
            Return img
        End Using
    End Function

    ' CalculateVideoAspectRatio_ResizeToAspectResolution
    Private Sub CalculateVideoAspectRatio_ResizeToAspectResolution()
        If MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
            ' Calculate aspect ratio from width and height
            Dim width As Integer = 1920 ' Example width
            Dim height As Integer = 1080 ' Example height
            Dim aspectRatio As Double = CDbl(MediaPlayer.currentMedia.imageSourceWidth) / MediaPlayer.currentMedia.imageSourceHeight

            ' Call the ResizeToAspectResolution method with the calculated aspect ratio
            ResizeToAspectResolution(aspectRatio)
        End If
    End Sub

    ' ResizeToAspectResolution
    Private Sub ResizeToAspectResolution(aspectRatio As Double)
        Dim newWidth As Integer = Me.Width
        Dim newHeight As Integer = CInt(newWidth / aspectRatio)

        If newHeight > Me.Height Then
            newHeight = Me.Height
            newWidth = CInt(newHeight * aspectRatio)
        End If

        Dim CR As Rectangle = RectangleToScreen(Me.ClientRectangle)
        Dim TitlebarHeight As Integer = CR.Top - Me.Top - 4
        If MenuStrip1.Visible Then
            Me.Size = New Size(newWidth, newHeight + MenuStrip1.Height + StatusStrip1.Height + TitlebarHeight)
        Else
            Me.Size = New Size(newWidth, newHeight)
        End If
    End Sub

    ' Testing
    Private Sub Testing(ChannelImageSize As Integer)
        If CompactToolStripMenuItem.Checked Then
            FlowLayoutPanel_Channels.SuspendLayout()

            If ChannelImageSize = 80 Then
                Panel_ChannelsList.Width = 292 + 128
            ElseIf ChannelImageSize = 64 Then
                Panel_ChannelsList.Width = 292 + 64
            Else
                Panel_ChannelsList.Width = 292
            End If

            For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(0).Hide()
                FlowLayoutPanel_Channels.Controls.Item(i).Size = New Size(ChannelImageSize, ChannelImageSize)
                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Size = New Size(ChannelImageSize, ChannelImageSize)
                ToolTip1.SetToolTip(FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1), FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(0).Text())


                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Cursor = Cursors.Hand
            Next
            FlowLayoutPanel_Channels.ResumeLayout()
        Else
            FlowLayoutPanel_Channels.SuspendLayout()

            If ChannelImageSize = 80 Then
                Panel_ChannelsList.Width = 292 + 64
            Else
                Panel_ChannelsList.Width = 292
            End If

            For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(0).Show()

                If ChannelImageSize = 80 Then
                    FlowLayoutPanel_Channels.Controls.Item(i).Size = New Size(253 + 64, ChannelImageSize)
                Else
                    FlowLayoutPanel_Channels.Controls.Item(i).Size = New Size(253, ChannelImageSize)
                End If

                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Size = New Size(ChannelImageSize, ChannelImageSize)
                ToolTip1.SetToolTip(FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1), "")


                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Cursor = Cursors.Default
            Next

            FlowLayoutPanel_Channels.ResumeLayout()
        End If
    End Sub

    ' SetPopoutDesktopMode_True
    Private Sub SetPopoutDesktopMode_True()
        Me.ControlBox = False
        MenuStrip1.Hide()
        StatusStrip1.Hide()

        MediaPlayer.uiMode = "none"
        Me.FormBorderStyle = FormBorderStyle.None
        Me.TopMost = True
        AlwaysOnTopToolStripMenuItem1.Checked = True
        AlwaysOnTopToolStripMenuItem.Checked = True

        PlayerControlsToolStripMenuItem.Checked = False

        Panel_ChannelsList.Hide()

        If MediaAspectAutoInPopoutModeToolStripMenuItem1.Checked Then
            CalculateVideoAspectRatio_ResizeToAspectResolution()
        End If

        PopoutDesktopMode = True
    End Sub

    ' SetPopoutDesktopMode_False
    Private Sub SetPopoutDesktopMode_False()
        Me.ControlBox = True
        MenuStrip1.Show()
        StatusStrip1.Show()

        If PlayerControlsToolStripMenuItem1.Checked = True Then
            MediaPlayer.uiMode = "full"
        End If

        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.TopMost = False
        AlwaysOnTopToolStripMenuItem1.Checked = False
        AlwaysOnTopToolStripMenuItem.Checked = False

        If MediaAspectAutoInNormalModeToolStripMenuItem.Checked Then
            CalculateVideoAspectRatio_ResizeToAspectResolution()
        End If

        Me.Opacity = 1.0

        PopoutDesktopMode = False
    End Sub

    ' ChannelsList - ToolStripMenuItem1 - Click
    Private Sub ChannelsListToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChannelsListToolStripMenuItem1.Click
        If Panel_ChannelsList.Visible Then
            Panel_ChannelsList.Hide()
        Else
            Panel_ChannelsList.Show()
        End If
    End Sub

    ' PopoutMode - ToolStripMenuItem1 - Click
    Private Sub PopoutModeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PopoutModeToolStripMenuItem1.Click
        SetPopoutDesktopMode_True()
    End Sub

    ' ChannelsList - ToolStripMenuItem - Click
    Private Sub ChannelsListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelsListToolStripMenuItem.Click
        If Panel_ChannelsList.Visible Then
            Panel_ChannelsList.Hide()
        Else
            Panel_ChannelsList.Show()
        End If
    End Sub

    ' NormalMode - ToolStripMenuItem - Click
    Private Sub NormalModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalModeToolStripMenuItem.Click
        SetPopoutDesktopMode_False()
    End Sub

    ' Resize - ToolStripMenuItem - Click
    Private Sub ResizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResizeToolStripMenuItem.Click
        If PopoutDesktopMode Then
            Me.FormBorderStyle = FormBorderStyle.Sizable
        End If
    End Sub

    ' AlwaysOnTop - ToolStripMenuItem - Click
    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
        If Me.TopMost Then
            Me.TopMost = False
            AlwaysOnTopToolStripMenuItem1.Checked = False
            AlwaysOnTopToolStripMenuItem.Checked = False
        Else
            Me.TopMost = True
            AlwaysOnTopToolStripMenuItem1.Checked = True
            AlwaysOnTopToolStripMenuItem.Checked = True
        End If
    End Sub

    ' AlwaysOnTop - ToolStripMenuItem1 - Click
    Private Sub AlwaysOnTopToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem1.Click
        If Me.TopMost Then
            Me.TopMost = False
            AlwaysOnTopToolStripMenuItem1.Checked = False
            AlwaysOnTopToolStripMenuItem.Checked = False
        Else
            Me.TopMost = True
            AlwaysOnTopToolStripMenuItem1.Checked = True
            AlwaysOnTopToolStripMenuItem.Checked = True
        End If
    End Sub

    ' StretchToFit - ToolStripMenuItem - Click
    Private Sub StretchToFitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StretchToFitToolStripMenuItem.Click
        If MediaPlayer.stretchToFit Then
            MediaPlayer.stretchToFit = False
            StretchToFitToolStripMenuItem1.Checked = False
            StretchToFitToolStripMenuItem.Checked = False
        Else
            MediaPlayer.stretchToFit = True
            StretchToFitToolStripMenuItem1.Checked = True
            StretchToFitToolStripMenuItem.Checked = True
        End If
    End Sub

    ' StretchToFit - ToolStripMenuItem1 - Click
    Private Sub StretchToFitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StretchToFitToolStripMenuItem1.Click
        If MediaPlayer.stretchToFit Then
            MediaPlayer.stretchToFit = False
            StretchToFitToolStripMenuItem1.Checked = False
            StretchToFitToolStripMenuItem.Checked = False
        Else
            MediaPlayer.stretchToFit = True
            StretchToFitToolStripMenuItem1.Checked = True
            StretchToFitToolStripMenuItem.Checked = True
        End If
    End Sub

    ' PlayerControls - ToolStripMenuItem1 - Click
    Private Sub PlayerControlsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PlayerControlsToolStripMenuItem1.Click
        If MediaPlayer.uiMode = "none" Then
            MediaPlayer.uiMode = "full"
            PlayerControlsToolStripMenuItem.Checked = True
            PlayerControlsToolStripMenuItem1.Checked = True
        Else
            MediaPlayer.uiMode = "none"
            PlayerControlsToolStripMenuItem.Checked = False
            PlayerControlsToolStripMenuItem1.Checked = False
        End If
    End Sub

    ' PlayerControls - ToolStripMenuItem - Click
    Private Sub PlayerControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayerControlsToolStripMenuItem.Click
        If MediaPlayer.uiMode = "none" Then
            MediaPlayer.uiMode = "full"
            PlayerControlsToolStripMenuItem.Checked = True
            PlayerControlsToolStripMenuItem1.Checked = True
        Else
            MediaPlayer.uiMode = "none"
            PlayerControlsToolStripMenuItem.Checked = False
            PlayerControlsToolStripMenuItem1.Checked = False
        End If
    End Sub

    ' ResizeToMediaSource - ToolStripMenuItem - Click
    Private Sub ResizeToMediaSourceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResizeToMediaSourceToolStripMenuItem.Click
        ResizeToMedia()
    End Sub

    ' ResizeToMediaSource - ToolStripMenuItem1 - Click
    Private Sub ResizeToMediaSourceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ResizeToMediaSourceToolStripMenuItem1.Click
        ResizeToMedia()
    End Sub

    ' ContentListModeSorted - ToolStripMenuItem - Click
    Private Sub ContentListModeSortedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentListModeSortedToolStripMenuItem.Click
        ContentListModeShuffled = False
        ContentListModeSortedToolStripMenuItem.Checked = True
        ContentListModeShuffledToolStripMenuItem.Checked = False
        ColorizeCurrentChannel()
        UpdateURLsList()
    End Sub

    ' ContentListModeShuffled - ToolStripMenuItem - Click
    Private Sub ContentListModeShuffledToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentListModeShuffledToolStripMenuItem.Click
        ContentListModeShuffled = True
        ContentListModeSortedToolStripMenuItem.Checked = False
        ContentListModeShuffledToolStripMenuItem.Checked = True
        ColorizeCurrentChannel()
        UpdateURLsList()
    End Sub

    ' ResizeToMediaAspect - ToolStripMenuItem1 - Click
    Private Sub ResizeToMediaAspectToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ResizeToMediaAspectToolStripMenuItem1.Click
        CalculateVideoAspectRatio_ResizeToAspectResolution()
    End Sub

    ' ResizeToMediaAspect - ToolStripMenuItem - Click
    Private Sub ResizeToMediaAspectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResizeToMediaAspectToolStripMenuItem.Click
        CalculateVideoAspectRatio_ResizeToAspectResolution()
    End Sub

    ' MediaAspectAutoInPopoutMode - ToolStripMenuItem - Click
    Private Sub MediaAspectAutoInPopoutModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MediaAspectAutoInPopoutModeToolStripMenuItem.Click
        If MediaAspectAutoInPopoutModeToolStripMenuItem.Checked Then
            MediaAspectAutoInPopoutModeToolStripMenuItem1.Checked = True
            CalculateVideoAspectRatio_ResizeToAspectResolution()
        Else
            MediaAspectAutoInPopoutModeToolStripMenuItem1.Checked = False
        End If
    End Sub

    'MediaAspectAutoInPopoutMode - ToolStripMenuItem1 - Click
    Private Sub MediaAspectAutoInPopoutModeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MediaAspectAutoInPopoutModeToolStripMenuItem1.Click
        If MediaAspectAutoInPopoutModeToolStripMenuItem1.Checked Then
            MediaAspectAutoInPopoutModeToolStripMenuItem.Checked = True
            CalculateVideoAspectRatio_ResizeToAspectResolution()
        Else
            MediaAspectAutoInPopoutModeToolStripMenuItem.Checked = False
        End If
    End Sub

    ' MediaAspectAutoInNormalMode - ToolStripMenuItem - Click
    Private Sub MediaAspectAutoInNormalModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MediaAspectAutoInNormalModeToolStripMenuItem.Click
        If MediaAspectAutoInNormalModeToolStripMenuItem.Checked Then
            CalculateVideoAspectRatio_ResizeToAspectResolution()
        End If
    End Sub

    ' ChannelsWindow - ToolStripMenuItem - Click
    Private Sub ChannelsWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelsWindowToolStripMenuItem.Click
        If Not Channels.Visible Then
            Channels.Show()
            Channels.BringToFront()
        Else
            Channels.BringToFront()
        End If
    End Sub

    ' ChannelContent - ToolStripMenuItem - Click
    Private Sub ChannelContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelContentToolStripMenuItem.Click
        If Not ChannelContent.Visible Then
            ChannelContent.Show()
            ChannelContent.BringToFront()
            UpdateURLsList()
        Else
            ChannelContent.BringToFront()
        End If
    End Sub

    ' 32x - ToolStripMenuItem - Click
    Private Sub X32ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X32ToolStripMenuItem.Click
        If X32ToolStripMenuItem.Checked = False Then
            X48ToolStripMenuItem.Checked = False
            X64ToolStripMenuItem.Checked = False
            X80ToolStripMenuItem.Checked = False

            X32ToolStripMenuItem.Checked = True
            Testing(32)
        End If
    End Sub

    ' X48 - ToolStripMenuItem - Click
    Private Sub X48ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X48ToolStripMenuItem.Click
        If X48ToolStripMenuItem.Checked = False Then
            X32ToolStripMenuItem.Checked = False
            X64ToolStripMenuItem.Checked = False
            X80ToolStripMenuItem.Checked = False

            X48ToolStripMenuItem.Checked = True
            Testing(48)
        End If
    End Sub

    ' 64x - ToolStripMenuItem - Click
    Private Sub X64ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X64ToolStripMenuItem.Click
        If X64ToolStripMenuItem.Checked = False Then
            X32ToolStripMenuItem.Checked = False
            X48ToolStripMenuItem.Checked = False
            X80ToolStripMenuItem.Checked = False

            X64ToolStripMenuItem.Checked = True
            Testing(64)
        End If
    End Sub

    ' 80x - ToolStripMenuItem - Click
    Private Sub X80ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X80ToolStripMenuItem.Click
        If X80ToolStripMenuItem.Checked = False Then
            X32ToolStripMenuItem.Checked = False
            X48ToolStripMenuItem.Checked = False
            X64ToolStripMenuItem.Checked = False

            X80ToolStripMenuItem.Checked = True
            Testing(80)
        End If
    End Sub

    ' Compact - ToolStripMenuItem - Click
    Private Sub CompactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompactToolStripMenuItem.Click

        If CompactToolStripMenuItem.Checked Then
            For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
                AddHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseEnter, AddressOf ChannelImage_MouseEnter
                AddHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseLeave, AddressOf ChannelImage_MouseLeave
                AddHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Click, AddressOf ChannelImage_Click
            Next
        Else
            For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
                RemoveHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseEnter, AddressOf ChannelImage_MouseEnter
                RemoveHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseLeave, AddressOf ChannelImage_MouseLeave
                RemoveHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Click, AddressOf ChannelImage_Click
            Next
        End If

        If X32ToolStripMenuItem.Checked Then
            Testing(32)
        End If

        If X48ToolStripMenuItem.Checked Then
            Testing(48)
        End If

        If X64ToolStripMenuItem.Checked Then
            Testing(64)
        End If

        If X80ToolStripMenuItem.Checked Then
            Testing(80)
        End If
    End Sub

    ' About - ToolStripMenuItem - Click
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        If Not About.Visible Then
            About.Show()
            About.BringToFront()
        Else
            About.BringToFront()
        End If
    End Sub

    ' X - ToolStripMenuItem - Click
    Private Sub XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XToolStripMenuItem.Click
        Panel_ChannelsList.Hide()
    End Sub

    ' ChannelContentDurationTotal - ToolStripMenuItem - Click
    Private Sub ChannelContentDurationTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelContentDurationTotalToolStripMenuItem.Click
        Dim ts As TimeSpan = TimeSpan.FromSeconds(CurrentChannel_videoDurations.Sum)
        Dim mydate As DateTime = New DateTime(ts.Ticks)
        MsgBox("Current channel ( " & currentChannelName & " ) content duration: " & mydate.ToString("HH:mm:ss") & vbNewLine & vbNewLine & "Target content duration for all channels is one week: 168 Hours.", MsgBoxStyle.Information)
    End Sub

    ' CurrentMediaName - ToolStripMenuItem - Click
    Private Sub CurrentMediaNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrentMediaNameToolStripMenuItem.Click
        MsgBox("Current Media Name: " & MediaPlayer.currentMedia.name.ToString, MsgBoxStyle.Information)
    End Sub

    ' Hotkeys - ToolStripMenuItem - Click
    Private Sub HotkeysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HotkeysToolStripMenuItem.Click
        MsgBox("Hotkeys:" & vbNewLine & vbNewLine _
           & "Controls." & vbNewLine _
           & "C - Channels" & vbNewLine _
           & "P - Popout mode" & vbNewLine _
           & "R - Resize" & vbNewLine _
           & "L - Channel content" & vbNewLine _
           & "S - Resize to media" & vbNewLine _
           & "Up - Channel up" & vbNewLine _
           & "Down - Channel down" & vbNewLine _
           & "F11 - Fullscreen" & vbNewLine _
           & vbNewLine _
           & "Info." & vbNewLine _
           & "F1 - Hotkeys list" & vbNewLine _
           & "F2 - Channel content duration total" & vbNewLine _
           & "I - Current media name" & vbNewLine _
           , MsgBoxStyle.Information)
    End Sub

    'SubOpacity - ToolStripMenuItem - Click
    Private Sub SubOpacityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubOpacityToolStripMenuItem.Click
        If Not Me.Opacity <= 0.3 Then

            'If Not ContextMenuStrip1.Visible Then
            ContextMenuStrip1.Show()
            ' End If

            OpacityToolStripMenuItem.ShowDropDown()
            Me.Opacity -= 0.1
        End If
    End Sub

    'PlusOpacity - ToolStripMenuItem - Click
    Private Sub PlusOpacityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlusOpacityToolStripMenuItem.Click
        If Not Me.Opacity >= 1.0 Then

            ' If Not ContextMenuStrip1.Visible Then
            ContextMenuStrip1.Show()
            ' End If

            OpacityToolStripMenuItem.ShowDropDown()
            Me.Opacity += 0.1
        End If
    End Sub

    ' Opacity100 - ToolStripMenuItem - Click
    Private Sub Opacity100ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Opacity100ToolStripMenuItem.Click
        Me.Opacity = 1.0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If currentOpacity < targetOpacity Then
            currentOpacity += 0.1 ' Adjust this value for smoother/faster fade
            If currentOpacity > targetOpacity Then
                currentOpacity = targetOpacity
                Timer1.Stop()
                Console.WriteLine("Timer1.Stop()")

                BuildChannelsList()

                ColorizeCurrentChannel()
            End If
            Me.Opacity = currentOpacity
        Else
            Console.WriteLine("Timer1.Stop()")
            Timer1.Stop() ' Stop the Timer if opacity reaches the target

            BuildChannelsList()

            ColorizeCurrentChannel()
        End If
    End Sub

    ' MainForm - Closing
    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ' Close other windows
        About.Close()
        ChannelContent.Close()
        Channels.Close()

        ' Fade out opcaity and volume
        Dim Count As Integer
        For Counter = 75 To 0 Step -5
            Count = Counter
            Me.Opacity = Count / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
            MediaPlayer.settings.volume -= 5
        Next Counter
    End Sub
End Class