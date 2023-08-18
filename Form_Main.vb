'Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.Hosting
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports Microsoft.VisualBasic.Devices

Public Class Form_Main
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

    Private AutoComplete_Channels As New AutoCompleteStringCollection()
    Private AutoComplete_FavoriteChannels As New AutoCompleteStringCollection()
    Private OnlyFavoritesShown As Boolean = False

    Private FavoritesChannelsList As String()

    Dim FavoriteChannelsFilePath As String = Application.StartupPath & "\Favorite Channels.cfg"

    Private currentChannelCFG As String = ""

    'Dim i_test As Integer = 48

    Dim OriginalPanelSize As New Size

    Dim DefaultChannelSize As Integer = 119

    ' MainForm - Load
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContextMenuStrip_MediaPlayer.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        ContextMenuStrip_Channel.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        MenuStrip_Channels.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

        If Not Directory.Exists(Application.StartupPath & "\Channels") Then
            Directory.CreateDirectory(Application.StartupPath & "\Channels")
        End If

        If Not Directory.Exists(Application.StartupPath & "\Channels\Image") Then
            Directory.CreateDirectory(Application.StartupPath & "\Channels\Image")
        End If

        If Not Directory.Exists(Application.StartupPath & "\Channels\Sorted") Then
            Directory.CreateDirectory(Application.StartupPath & "\Channels\Sorted")
        End If

        If Not Directory.Exists(Application.StartupPath & "\Channels\Shuffled") Then
            Directory.CreateDirectory(Application.StartupPath & "\Channels\Shuffled")
        End If

        If Not File.Exists(FavoriteChannelsFilePath) Then
            File.Create(FavoriteChannelsFilePath)
        End If

        PictureBox_Media.Image = My.Resources.Intro

        MediaPlayer.uiMode = "none"
        MediaPlayer.windowlessVideo = False
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

        ToolStripStatusLabel_CurrentChannelNumber.Text = ""
        ToolStripStatusLabel_CurrentChannelName.Text = ""
        ToolStripStatusLabel_PlayerStatus.Text = MediaPlayer.status

        Me.Opacity = 0.0
        currentOpacity = Me.Opacity
        Timer_OpeningFade.Start()

        BuildChannelsList()
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

            'Console.WriteLine("currentIndex: " & currentIndex)
            'Console.WriteLine(CurrentChannel_videoFiles(currentIndex))

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
            'Console.WriteLine("WMPPlayState.wmppsReady")
        End If

        If MediaPlayer.playState = WMPPlayState.wmppsBuffering Then
            PictureBox_Media.Image = My.Resources.Buffering
            PictureBox_Media.Visible = True
        End If

        If MediaPlayer.playState = WMPPlayState.wmppsReady Or MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
            PictureBox_Media.Image = Nothing
            PictureBox_Media.Visible = False
        End If

    End Sub

    ' MediaPlayer - MediaError
    Private Sub MediaPlayer_MediaError(sender As Object, e As _WMPOCXEvents_MediaErrorEvent) Handles MediaPlayer.MediaError
        PictureBox_Media.Image = My.Resources.No_Content
        PictureBox_Media.Visible = True
    End Sub

    ' PlayVideo
    Private Sub PlayVideo(videoFile As String, playbackPosition As Integer)
        ' Stop the current video (if any) and load and play the new video.
        MediaPlayer.Ctlcontrols.stop()

        ' Load the new video.
        MediaPlayer.URL = videoFile
        'Console.WriteLine(MediaPlayer.URL)

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
        'Console.WriteLine("currentIndex: " & currentIndex)
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
    Private Sub ChannelLabel_Click(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            currentChannel = FlowLayoutPanel_Channels.Controls.GetChildIndex(DirectCast(sender, Label).Parent) ' DirectCast(sender, Label)
            'currentChannel = DirectCast(sender, Label).Parent.Parent.Controls.GetChildIndex(DirectCast(sender, Label).Parent) ' DirectCast(sender, Label)

            ColorizeCurrentChannel()
            UpdateURLsList()

            If AutoCloseChannelsListToolStripMenuItem.Checked Then
                PanelChannelsListVisiblityWorkAround(False)
            End If
        End If
    End Sub

    ' ChannelImage - MouseEnter
    Private Sub ChannelImage_MouseEnter(sender As Object, e As EventArgs)
        If CompactToolStripMenuItem.Checked Then
            If Not DirectCast(sender, PictureBox).BackColor = Color.MediumSeaGreen Then ' DirectCast(sender, PictureBox)
                DirectCast(sender, PictureBox).BackColor = Color.DodgerBlue ' DirectCast(sender, PictureBox)
            End If
        Else
            If Not DirectCast(sender, PictureBox).Parent.Controls.Item(0).BackColor = Color.MediumSeaGreen Then ' DirectCast(sender, PictureBox)
                DirectCast(sender, PictureBox).Parent.Controls.Item(0).BackColor = Color.DodgerBlue ' DirectCast(sender, PictureBox)
            End If
        End If
    End Sub

    ' ChannelImage - MouseLeave
    Private Sub ChannelImage_MouseLeave(sender As Object, e As EventArgs)
        If CompactToolStripMenuItem.Checked Then
            If Not DirectCast(sender, PictureBox).BackColor = Color.MediumSeaGreen Then ' DirectCast(sender, PictureBox)
                DirectCast(sender, PictureBox).BackColor = Color.FromArgb(28, 30, 34) ' DirectCast(sender, PictureBox)
            End If
        Else
            If Not DirectCast(sender, PictureBox).Parent.Controls.Item(0).BackColor = Color.MediumSeaGreen Then ' DirectCast(sender, PictureBox)
                DirectCast(sender, PictureBox).Parent.Controls.Item(0).BackColor = Color.FromArgb(28, 30, 34) ' DirectCast(sender, PictureBox)
            End If
        End If
    End Sub

    ' ChannelImage - Click
    Private Sub ChannelImage_Click(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            currentChannel = FlowLayoutPanel_Channels.Controls.GetChildIndex(DirectCast(sender, PictureBox).Parent) ' DirectCast(sender, PictureBox)
            ColorizeCurrentChannel()
            UpdateURLsList()

            If AutoCloseChannelsListToolStripMenuItem.Checked Then
                PanelChannelsListVisiblityWorkAround(False)
            End If
        End If
    End Sub

    ' ColorizeCurrentChannel
    Private Sub ColorizeCurrentChannel()
        UncolorizeChannels()
        FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(0).BackColor = Color.MediumSeaGreen

        currentChannelName = FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(0).Text
        ToolStripStatusLabel_CurrentChannelName.Text = currentChannelName
        ToolStripStatusLabel_CurrentChannelNumber.Text = "ch. " & currentChannel

        Dim FileStr As String = FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text

        If ContentListModeShuffled = True Then
            If File.Exists(FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text) Then

                If Not currentChannelCFG = FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text Then
                    ReadChannelFile(FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text)
                End If

            Else

                FileStr = Application.StartupPath & "\Channels\Sorted\" & Path.GetFileName(FileStr)

                If File.Exists(FileStr) Then
                    If Not currentChannelCFG = FileStr Then
                        ReadChannelFile(FileStr)
                    End If

                    ContentListModeShuffled = False
                    ContentListModeSortedToolStripMenuItem.Checked = True
                    Form_ChannelContent.ContentListModeSortedToolStripMenuItem.Checked = True
                    ContentListModeShuffledToolStripMenuItem.Checked = False
                    Form_ChannelContent.ContentListModeShuffledToolStripMenuItem.Checked = False
                End If

            End If

        Else

            FileStr = Application.StartupPath & "\Channels\Sorted\" & Path.GetFileName(FileStr)

            If File.Exists(FileStr) Then

                If Not currentChannelCFG = FileStr Then
                    ReadChannelFile(FileStr)
                End If

            Else

                If File.Exists(FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text) Then
                    If Not currentChannelCFG = FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text Then
                        ReadChannelFile(FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text)
                    End If

                    ContentListModeShuffled = True
                    ContentListModeSortedToolStripMenuItem.Checked = False
                    Form_ChannelContent.ContentListModeSortedToolStripMenuItem.Checked = False
                    ContentListModeShuffledToolStripMenuItem.Checked = True
                    Form_ChannelContent.ContentListModeShuffledToolStripMenuItem.Checked = True
                End If

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
        HotKeys(CType(e.nKeyCode, Keys))
        'Console.WriteLine("MediaPlayer_KeyDownEvent")
    End Sub

    ' MainForm - KeyDown
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        HotKeys(e.KeyCode)
    End Sub

    ' PictureBox_Intro - KeyDown
    Private Sub PictureBox_Intro_KeyDown(sender As Object, e As KeyEventArgs) Handles PictureBox_Media.KeyDown
        '  HotKeys(e.KeyCode)
    End Sub

    ' HotKeys
    Private Sub HotKeys(PressedKey As Keys)
        If PressedKey = Keys.Down Then ' Channel Down
            If currentChannel < FlowLayoutPanel_Channels.Controls.Count - 1 Then
                currentChannel += 1
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            Else
                currentChannel = 0
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            End If
        ElseIf PressedKey = Keys.Up Then ' Channel Up
            If currentChannel > 0 Then
                currentChannel -= 1
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            Else
                currentChannel = 7
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            End If
        ElseIf PressedKey = Keys.C Then ' ChannelsList 
            ChannelsListToolStripMenuItem1.PerformClick()
        ElseIf PressedKey = Keys.F11 Then
            If MediaPlayer.fullScreen Then
                MediaPlayer.fullScreen = False
            Else
                If MediaPlayer.playState = 3 Then
                    MediaPlayer.fullScreen = True
                End If
            End If
        ElseIf PressedKey = Keys.Escape And PopoutDesktopMode = True Then ' Exit Popout Mode
            SetPopoutDesktopMode_False()
        ElseIf PressedKey = Keys.P Then ' Popout Mode
            If PopoutDesktopMode Then
                SetPopoutDesktopMode_False()
            Else
                SetPopoutDesktopMode_True()
            End If
        ElseIf PressedKey = Keys.R Then ' Resize Mode
            If PopoutDesktopMode Then
                Me.FormBorderStyle = FormBorderStyle.Sizable
            End If
        ElseIf PressedKey = Keys.F2 Then 'Channel Duration Information
            ChannelContentDurationTotalToolStripMenuItem.PerformClick()
        ElseIf PressedKey = Keys.PageUp Then
            'SetVolume(100) ' Testing
            'MediaPlayer.settings.volume += 1
        ElseIf PressedKey = Keys.PageDown Then
            'SetVolume(0) ' Testing
            'MediaPlayer.settings.volume -= 1
        ElseIf PressedKey = Keys.I Then ' Information
            CurrentMediaNameToolStripMenuItem.PerformClick()
        ElseIf PressedKey = Keys.L Then ' URLsList
            Form_ChannelContent.Show()
            UpdateURLsList()
        ElseIf PressedKey = Keys.S Then
            ResizeToMedia()
        ElseIf PressedKey = Keys.F1 Then
            HotkeysToolStripMenuItem.PerformClick()
        End If
    End Sub

    ' UpdateURLsList
    Private Sub UpdateURLsList()
        If CurrentChannel_videoFiles IsNot Nothing Then
            Form_ChannelContent.Label1.Text = currentChannelName
            Form_ChannelContent.ListBox1.BeginUpdate()
            Form_ChannelContent.ListBox1.Items.Clear()
            For Each videoFileURl In CurrentChannel_videoFiles
                Dim urlname As String = videoFileURl.Replace("https://archive.org/download/", "")
                Form_ChannelContent.ListBox1.Items.Add(urlname)
            Next
            ' URLsList.ListBox1.Items.AddRange(CurrentChannel_videoFiles)

            Form_ChannelContent.ListBox1.EndUpdate()

            Form_ChannelContent.Label2.Text = MediaPlayer.currentMedia.name.ToString()

            If Not currentIndex > Form_ChannelContent.ListBox1.Items.Count - 1 Then
                Form_ChannelContent.ListBox1.SelectedIndex = currentIndex
            End If
        End If
    End Sub

    ' MediaPlayer_StatusChange
    Private Sub MediaPlayer_StatusChange(sender As Object, e As EventArgs) Handles MediaPlayer.StatusChange
        If MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
            ToolStripStatusLabel_PlayerStatus.Text = MediaPlayer.status.Replace("'" & MediaPlayer.currentMedia.name.ToString & "':", "@")
            Form_ChannelContent.Label2.Text = MediaPlayer.currentMedia.name.ToString()
        Else
            ToolStripStatusLabel_PlayerStatus.Text = MediaPlayer.status
        End If

        If MediaPlayer.status.ToString = "Connecting..." Then
            PictureBox_Media.Image = My.Resources.Connecting
            PictureBox_Media.Visible = True
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
            MoveWindow()
        ElseIf e.nButton = 2 Then
            'If PopoutDesktopMode Then
            MediaPlayer.ContextMenuStrip.Show(MousePosition.X, MousePosition.Y)
            'End If
        End If
    End Sub

    ' PictureBox_Intro - MouseDown
    Private Sub PictureBox_Intro_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_Media.MouseDown
        If e.Button = MouseButtons.Left Then
            PictureBox_Media.Capture = False
            MoveWindow()
            'ElseIf e.Button = MouseButtons.Right Then
            'If PopoutDesktopMode Then
            'PictureBox_Intro.ContextMenuStrip.Show(MousePosition.X, MousePosition.Y)
            'End If
        End If
    End Sub

    ' MoveWindow
    Private Sub MoveWindow()
        Const WM_NCLBUTTONDOWN As Integer = &HA1S
        Const HTCAPTION As Integer = 2
        Dim msg As Message = Message.Create(Me.Handle, WM_NCLBUTTONDOWN, New IntPtr(HTCAPTION), IntPtr.Zero)
        Me.DefWndProc(msg)
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
                Me.Height = MediaPlayer.currentMedia.imageSourceHeight + MenuStrip1.Height + StatusStrip_PlayerStatus.Height + TitlebarHeight
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
        currentChannelCFG = ChannelFilePath
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
        Dim ChannelNameStr As String = ""
        Dim MatchedChannels As New ArrayList

        Dim ChannelCFGs() As String = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Channels\Shuffled\", FileIO.SearchOption.SearchTopLevelOnly, "*.cfg").ToArray

        'Dim directoryPath As String = Path.Combine(Application.StartupPath, "Channels")
        'Dim channelOrderFile As String = Path.Combine(Application.StartupPath, "Channel Order.cfg")

        'Console.WriteLine(directoryPath)
        'Console.WriteLine(channelOrderFile)

        If File.Exists(FavoriteChannelsFilePath) Then
            FavoritesChannelsList = File.ReadAllLines(FavoriteChannelsFilePath)
            AutoComplete_FavoriteChannels.Clear()
            AutoComplete_FavoriteChannels.AddRange(FavoritesChannelsList)
        End If

        AutoComplete_Channels.Clear()
        FlowLayoutPanel_Channels.Controls.Clear()
        FlowLayoutPanel_Channels.SuspendLayout()
        FlowLayoutPanel_Channels.Visible = False

        If File.Exists(Application.StartupPath & "\Channel Order.cfg") Then

            Dim channelNames As New List(Of String)(File.ReadAllLines(Application.StartupPath & "\Channel Order.cfg"))
            'Dim cfgFiles As String() = Directory.GetFiles(directoryPath, "*.cfg")

            Dim combinedCFGFiles As New List(Of String)()

            For Each channelName As String In channelNames
                Dim matchingCFGFile As String = ChannelCFGs.FirstOrDefault(Function(cfgFile) Path.GetFileNameWithoutExtension(cfgFile).Equals(channelName))
                If matchingCFGFile IsNot Nothing Then
                    combinedCFGFiles.Add(matchingCFGFile)
                    ChannelCFGs = ChannelCFGs.Where(Function(cfgFile) Not cfgFile.Equals(matchingCFGFile)).ToArray()
                End If
            Next

            ' Add the remaining CFG files that didn't match any channel name
            combinedCFGFiles.AddRange(ChannelCFGs)

            ' Now you have the combined CFG files list in "combinedCFGFiles"
            For Each CFGFile As String In combinedCFGFiles
                ChannelNameStr = Path.GetFileNameWithoutExtension(CFGFile)
                ImagePathStr = Application.StartupPath & "\Channels\Image\" & Path.GetFileName(CFGFile)
                ImagePathStr = Path.ChangeExtension(ImagePathStr, "png") ' File might not exist

                If Not File.Exists(ImagePathStr) Then
                    ImagePathStr = Path.ChangeExtension(ImagePathStr, "jpg") ' File might not exist
                End If

                'Console.WriteLine(ImagePathStr)

                CreateChannel(ChannelNameStr, CFGFile, ImagePathStr)
            Next

        Else ' Handle the case when "channel order.cfg" file doesn't exist in the directory

            For Each CFGFile As String In ChannelCFGs
                ChannelNameStr = Path.GetFileNameWithoutExtension(CFGFile)
                ImagePathStr = Application.StartupPath & "\Channel\Image\" & Path.GetFileName(CFGFile)
                ImagePathStr = Path.ChangeExtension(ImagePathStr, "png") ' File might not exist

                If Not File.Exists(ImagePathStr) Then
                    ImagePathStr = Path.ChangeExtension(ImagePathStr, "jpg") ' File might not exist
                End If

                'Console.WriteLine(ImagePathStr)

                CreateChannel(ChannelNameStr, CFGFile, ImagePathStr)
            Next

        End If

        TextBox_SearchByChannelName.AutoCompleteCustomSource = AutoComplete_Channels
        FlowLayoutPanel_Channels.ResumeLayout()
        FlowLayoutPanel_Channels.Visible = True

        NumericUpDown_SearchByChannelNumber.Maximum = FlowLayoutPanel_Channels.Controls.Count - 1
    End Sub

    ' Create Channel
    Private Sub CreateChannel(ChannelName As String, ChannelFilePath As String, ChannelImagePath As String)
        'Console.WriteLine("Creating channel: " & ChannelName) ' Debug output

        AutoComplete_Channels.Add(ChannelName)

        ' Panel
        Dim ChannelPanel = New Panel
        ChannelPanel.Size = New Size(348, DefaultChannelSize)
        ChannelPanel.BackColor = Color.FromArgb(28, 30, 34)
        ChannelPanel.Name = "Panel_Channel"
        ChannelPanel.Margin = New Padding(12, 6, 3, 6)


        ' Label
        Dim ChannelNumberLabel = New Label
        ChannelNumberLabel.AutoEllipsis = False
        ChannelNumberLabel.TextAlign = ContentAlignment.MiddleCenter
        ChannelNumberLabel.Dock = DockStyle.Left
        ChannelNumberLabel.AutoSize = False
        ChannelNumberLabel.Size = New Size(48, 48)
        ChannelNumberLabel.Text = FlowLayoutPanel_Channels.Controls.Count.ToString
        ChannelNumberLabel.Name = "Label_ChannelNumber"
        ChannelNumberLabel.ForeColor = Color.WhiteSmoke

        If FavoritesChannelsList IsNot Nothing Then
            If FavoritesChannelsList.Contains(ChannelName) Then
                ChannelNumberLabel.ForeColor = Color.Goldenrod
            Else
                ChannelNumberLabel.ForeColor = Color.WhiteSmoke
            End If
        Else
            ChannelNumberLabel.ForeColor = Color.WhiteSmoke
        End If
        ChannelNumberLabel.Font = New Font("Microsoft Sans Serif", 11.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))


        ' PictureBox
        Dim ChannelPictureBox = New PictureBox
        ChannelPictureBox.Dock = DockStyle.Left
        ChannelPictureBox.Size = New Size(DefaultChannelSize, DefaultChannelSize)
        ChannelPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        ChannelPictureBox.Name = "PictureBox_ChannelLogo"
        ChannelPictureBox.Text = ChannelFilePath
        ChannelPictureBox.ContextMenuStrip = ContextMenuStrip_Channel
        ChannelPictureBox.Cursor = Cursors.Hand

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

        AddHandler ChannelPictureBox.MouseEnter, AddressOf ChannelImage_MouseEnter
        AddHandler ChannelPictureBox.MouseLeave, AddressOf ChannelImage_MouseLeave
        AddHandler ChannelPictureBox.MouseClick, AddressOf ChannelImage_Click

        ' Label
        Dim ChannelLabel = New Label
        ChannelLabel.AutoEllipsis = True
        ChannelLabel.TextAlign = ContentAlignment.MiddleLeft
        ChannelLabel.Dock = DockStyle.Fill
        ChannelLabel.Text = ChannelName
        ChannelLabel.ForeColor = Color.WhiteSmoke
        ChannelLabel.Font = New Font("Microsoft Sans Serif", 11.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        ChannelLabel.Name = "Label_ChannelLabel"
        ChannelLabel.Cursor = Cursors.Hand
        ChannelLabel.ContextMenuStrip = ContextMenuStrip_Channel

        ' Add Child Object to Channel Panel
        ChannelPanel.Controls.Add(ChannelLabel)
        ChannelPanel.Controls.Add(ChannelPictureBox)
        ChannelPanel.Controls.Add(ChannelNumberLabel)

        ' Add ChannelPanel to FlowLayoutPanel1
        FlowLayoutPanel_Channels.Controls.Add(ChannelPanel)

        AddHandler ChannelLabel.MouseEnter, AddressOf ChannelLabel_MouseEnter
        AddHandler ChannelLabel.MouseLeave, AddressOf ChannelLabel_MouseLeave
        AddHandler ChannelLabel.MouseClick, AddressOf ChannelLabel_Click

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
            'Dim width As Integer = 1920 ' Example width
            'Dim height As Integer = 1080 ' Example height
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
            Me.Size = New Size(newWidth, newHeight + MenuStrip1.Height + StatusStrip_PlayerStatus.Height + TitlebarHeight)
        Else
            Me.Size = New Size(newWidth, newHeight)
        End If
    End Sub

    ' ResizeChannels
    Private Sub ResizeChannels(ChannelImageSize As Integer)
        If CompactToolStripMenuItem.Checked Then
            FlowLayoutPanel_Channels.SuspendLayout()

            'If ChannelImageSize = 80 Then
            ' Panel_ChannelsList.Width = 388 + 22
            'ElseIf ChannelImageSize = 64 Then
            '  Panel_ChannelsList.Width = 388 - 42
            'ElseIf ChannelImageSize = 48 Then
            ' Panel_ChannelsList.Width = 388 - 42
            'ElseIf ChannelImageSize = 32 Then
            '  Panel_ChannelsList.Width = 388 - 24
            'End If

            For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(0).Hide()
                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(2).Hide()

                FlowLayoutPanel_Channels.Controls.Item(i).Size = New Size(ChannelImageSize, ChannelImageSize)
                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Size = New Size(ChannelImageSize, ChannelImageSize)
                ToolTip1.SetToolTip(FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1), FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(0).Text())


                'FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Cursor = Cursors.Hand
            Next
            FlowLayoutPanel_Channels.ResumeLayout()
        Else
            FlowLayoutPanel_Channels.SuspendLayout()

            'If ChannelImageSize = 80 Then
            'Panel_ChannelsList.Width = 388 + 64
            'Else
            'Panel_ChannelsList.Width = 388
            'End If

            For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(0).Show()
                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(2).Show()

                'If ChannelImageSize = 80 Then
                'FlowLayoutPanel_Channels.Controls.Item(i).Size = New Size(348 + 64, ChannelImageSize)
                'Else
                FlowLayoutPanel_Channels.Controls.Item(i).Size = New Size(348, ChannelImageSize)
                'End If

                FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Size = New Size(ChannelImageSize, ChannelImageSize)
                ToolTip1.SetToolTip(FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1), "")


                'FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).Cursor = Cursors.Default
            Next

            FlowLayoutPanel_Channels.ResumeLayout()
        End If
    End Sub

    ' SetPopoutDesktopMode_True
    Private Sub SetPopoutDesktopMode_True()
        Me.ControlBox = False
        MenuStrip1.Hide()
        StatusStrip_PlayerStatus.Hide()

        MediaPlayer.uiMode = "none"
        Me.FormBorderStyle = FormBorderStyle.None
        Me.TopMost = True
        AlwaysOnTopToolStripMenuItem1.Checked = True
        AlwaysOnTopToolStripMenuItem.Checked = True

        ShowPlayerControlsToolStripMenuItem.Checked = False

        'SplitContainer1.Panel2Collapsed = True
        PanelChannelsListVisiblityWorkAround(False)

        If MediaAspectAutoInPopoutModeToolStripMenuItem1.Checked Then
            CalculateVideoAspectRatio_ResizeToAspectResolution()
        End If

        PopoutDesktopMode = True
    End Sub

    ' SetPopoutDesktopMode_False
    Private Sub SetPopoutDesktopMode_False()
        Me.ControlBox = True
        MenuStrip1.Show()
        StatusStrip_PlayerStatus.Show()

        If ShowPlayerControlsToolStripMenuItem1.Checked = True Then
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

    'Timer_OpeningFade - Tick
    Private Sub Timer_OpeningFade_Tick(sender As Object, e As EventArgs) Handles Timer_OpeningFade.Tick
        If currentOpacity < targetOpacity Then
            currentOpacity += 0.1 ' Adjust this value for smoother/faster fade
            If currentOpacity > targetOpacity Then
                currentOpacity = targetOpacity
                Timer_OpeningFade.Stop()
                'Console.WriteLine("Timer_OpeningFade.Stop()")
            End If
            Me.Opacity = currentOpacity
        Else
            'Console.WriteLine("Timer_OpeningFade.Stop()")
            Timer_OpeningFade.Stop() ' Stop the Timer if opacity reaches the target
        End If
    End Sub

    ' MainForm - Closing
    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ' Close other windows
        Form_About.Close()
        Form_ChannelContent.Close()
        Form_Statistics.Close()

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

    ' ChannelsList - ToolStripMenuItem1 - Click
    Private Sub ChannelsListToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChannelsListToolStripMenuItem1.Click
        If Splitter1.Visible = True Then

            PanelChannelsListVisiblityWorkAround(False)
        Else
            PanelChannelsListVisiblityWorkAround(True)
        End If
    End Sub

    ' PopoutMode - ToolStripMenuItem1 - Click
    Private Sub PopoutModeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PopoutModeToolStripMenuItem1.Click
        SetPopoutDesktopMode_True()
    End Sub

    ' ChannelsList - ToolStripMenuItem - Click
    Private Sub ChannelsListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelsListToolStripMenuItem.Click
        ChannelsListToolStripMenuItem1.PerformClick()
    End Sub

    ' NormalPopoutToggleMode - ToolStripMenuItem - Click
    Private Sub NormalPopoutToggleModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalPopoutToggleModeToolStripMenuItem.Click
        If PopoutDesktopMode Then
            SetPopoutDesktopMode_False()
        Else
            SetPopoutDesktopMode_True()
        End If
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
    Private Sub PlayerControlsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShowPlayerControlsToolStripMenuItem1.Click
        If MediaPlayer.uiMode = "none" Then
            MediaPlayer.uiMode = "full"
            ShowPlayerControlsToolStripMenuItem.Checked = True
            ShowPlayerControlsToolStripMenuItem1.Checked = True
        Else
            MediaPlayer.uiMode = "none"
            ShowPlayerControlsToolStripMenuItem.Checked = False
            ShowPlayerControlsToolStripMenuItem1.Checked = False
        End If
    End Sub

    ' PlayerControls - ToolStripMenuItem - Click
    Private Sub PlayerControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowPlayerControlsToolStripMenuItem.Click
        If MediaPlayer.uiMode = "none" Then
            MediaPlayer.uiMode = "full"
            ShowPlayerControlsToolStripMenuItem.Checked = True
            ShowPlayerControlsToolStripMenuItem1.Checked = True
        Else
            MediaPlayer.uiMode = "none"
            ShowPlayerControlsToolStripMenuItem.Checked = False
            ShowPlayerControlsToolStripMenuItem1.Checked = False
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
        'Dim FileStr As String = FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text
        'FileStr = Application.StartupPath & "\Channels\Sorted\" & Path.GetFileName(FileStr)
        'If File.Exists(FileStr) Then
        ContentListModeShuffled = False
        ContentListModeSortedToolStripMenuItem.Checked = True
        Form_ChannelContent.ContentListModeSortedToolStripMenuItem.Checked = True
        ContentListModeShuffledToolStripMenuItem.Checked = False
        Form_ChannelContent.ContentListModeShuffledToolStripMenuItem.Checked = False
        ColorizeCurrentChannel()
        UpdateURLsList()
        'End If
    End Sub

    ' ContentListModeShuffled - ToolStripMenuItem - Click
    Private Sub ContentListModeShuffledToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentListModeShuffledToolStripMenuItem.Click
        'If File.Exists(FlowLayoutPanel_Channels.Controls.Item(currentChannel).Controls.Item(1).Text) Then
        ContentListModeShuffled = True
        ContentListModeSortedToolStripMenuItem.Checked = False
        Form_ChannelContent.ContentListModeSortedToolStripMenuItem.Checked = False
        ContentListModeShuffledToolStripMenuItem.Checked = True
        Form_ChannelContent.ContentListModeShuffledToolStripMenuItem.Checked = True
        ColorizeCurrentChannel()
        UpdateURLsList()
        'End If
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

    ' ChannelContent - ToolStripMenuItem - Click
    Private Sub ChannelContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelContentToolStripMenuItem.Click
        If Not Form_ChannelContent.Visible Then
            Form_ChannelContent.Show()
            Form_ChannelContent.BringToFront()
            UpdateURLsList()
        Else
            Form_ChannelContent.BringToFront()
        End If
    End Sub

    ' Scale1 - ToolStripMenuItem - Click
    Private Sub Scale1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale1ToolStripMenuItem.Click
        If Scale1ToolStripMenuItem.Checked = False Then
            UncheckAllSizes()
            Scale1ToolStripMenuItem.Checked = True
            ResizeChannels(45)
        End If
    End Sub

    ' Scale2 - ToolStripMenuItem Click
    Private Sub Scale2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale2ToolStripMenuItem.Click
        If Scale2ToolStripMenuItem.Checked = False Then
            UncheckAllSizes()
            Scale2ToolStripMenuItem.Checked = True
            ResizeChannels(71)
        End If
    End Sub

    ' Scale3 - ToolStripMenuItem - Click
    Private Sub Scale3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale3ToolStripMenuItem.Click
        If Scale3ToolStripMenuItem.Checked = False Then
            UncheckAllSizes()
            Scale3ToolStripMenuItem.Checked = True
            ResizeChannels(103)
        End If
    End Sub

    ' Scale4 - ToolStripMenuItem - Click
    Private Sub Scale4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale4ToolStripMenuItem.Click
        If Scale4ToolStripMenuItem.Checked = False Then
            UncheckAllSizes()
            Scale4ToolStripMenuItem.Checked = True
            ResizeChannels(119)
        End If
    End Sub

    ' Scale5 - ToolStripMenuItem - Click
    Private Sub Scale5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale5ToolStripMenuItem.Click
        If Scale5ToolStripMenuItem.Checked = False Then
            UncheckAllSizes()
            Scale5ToolStripMenuItem.Checked = True
            ResizeChannels(135)
        End If
    End Sub

    ' Scale6 - ToolStripMenuItem - Click
    Private Sub Scale6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale6ToolStripMenuItem.Click
        If Scale6ToolStripMenuItem.Checked = False Then
            UncheckAllSizes()
            Scale6ToolStripMenuItem.Checked = True
            ResizeChannels(167)
        End If
    End Sub

    ' Scale7 - ToolStripMenuItem - Click
    Private Sub Scale7ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale7ToolStripMenuItem.Click
        If Scale7ToolStripMenuItem.Checked = False Then
            UncheckAllSizes()
            Scale7ToolStripMenuItem.Checked = True
            ResizeChannels(215)
        End If
    End Sub

    ' Scale8 - ToolStripMenuItem - Click
    Private Sub Scale8ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Scale8ToolStripMenuItem.Click
        If Scale8ToolStripMenuItem.Checked = False Then
            UncheckAllSizes()
            Scale8ToolStripMenuItem.Checked = True
            ResizeChannels(295)
        End If
    End Sub

    ' UncheckAllSizes
    Private Sub UncheckAllSizes()
        Scale1ToolStripMenuItem.Checked = False
        Scale2ToolStripMenuItem.Checked = False
        Scale3ToolStripMenuItem.Checked = False
        Scale4ToolStripMenuItem.Checked = False
        Scale5ToolStripMenuItem.Checked = False
        Scale6ToolStripMenuItem.Checked = False
        Scale7ToolStripMenuItem.Checked = False
        Scale8ToolStripMenuItem.Checked = False
    End Sub


    ' Compact - ToolStripMenuItem - Click
    Private Sub CompactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompactToolStripMenuItem.Click

        'If CompactToolStripMenuItem.Checked Then
        'For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
        'AddHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseEnter, AddressOf ChannelImage_MouseEnter
        'AddHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseLeave, AddressOf ChannelImage_MouseLeave
        'AddHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseClick, AddressOf ChannelImage_Click
        'Next
        'Else
        'For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
        'RemoveHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseEnter, AddressOf ChannelImage_MouseEnter
        'RemoveHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseLeave, AddressOf ChannelImage_MouseLeave
        'RemoveHandler FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(1).MouseClick, AddressOf ChannelImage_Click
        'Next
        'End If

        If Scale1ToolStripMenuItem.Checked = True Then
            ResizeChannels(45)
        End If

        If Scale2ToolStripMenuItem.Checked = True Then
            ResizeChannels(71)
        End If

        If Scale3ToolStripMenuItem.Checked = True Then
            ResizeChannels(103)
        End If

        If Scale4ToolStripMenuItem.Checked = True Then
            ResizeChannels(119)
        End If

        If Scale5ToolStripMenuItem.Checked = True Then
            ResizeChannels(135)
        End If

        If Scale6ToolStripMenuItem.Checked = True Then
            ResizeChannels(167)
        End If

        If Scale7ToolStripMenuItem.Checked = True Then
            ResizeChannels(215)
        End If

        If Scale8ToolStripMenuItem.Checked = True Then
            ResizeChannels(295)
        End If
    End Sub

    ' About - ToolStripMenuItem - Click
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        If Not Form_About.Visible Then
            Form_About.Show()
            Form_About.BringToFront()
        Else
            Form_About.BringToFront()
        End If
    End Sub

    ' X - ToolStripMenuItem - Click
    Private Sub XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseChannelsListToolStripMenuItem.Click
        PanelChannelsListVisiblityWorkAround(False)
    End Sub

    ' ChannelContentDurationTotal - ToolStripMenuItem - Click
    Private Sub ChannelContentDurationTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelContentDurationTotalToolStripMenuItem.Click
        If CurrentChannel_videoDurations IsNot Nothing Then
            Dim ts As TimeSpan = TimeSpan.FromSeconds(CurrentChannel_videoDurations.Sum)
            Dim mydate As DateTime = New DateTime(ts.Ticks)
            MsgBox("Current channel ( " & currentChannelName & " ) content duration: " & mydate.ToString("HH:mm:ss") & vbNewLine & vbNewLine & "Target content duration for all channels is one week: 168 Hours.", MsgBoxStyle.Information)
        End If
    End Sub

    ' CurrentMediaName - ToolStripMenuItem - Click
    Private Sub CurrentMediaNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrentMediaNameToolStripMenuItem.Click
        If MediaPlayer.currentMedia IsNot Nothing Then
            MsgBox("Current Media Name: " & MediaPlayer.currentMedia.name.ToString, MsgBoxStyle.Information)
        End If
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
            ContextMenuStrip_MediaPlayer.Show()
            ' End If
            OpacityToolStripMenuItem.ShowDropDown()
            Me.Opacity -= 0.1
        End If
    End Sub

    'PlusOpacity - ToolStripMenuItem - Click
    Private Sub PlusOpacityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlusOpacityToolStripMenuItem.Click
        If Not Me.Opacity >= 1.0 Then
            ' If Not ContextMenuStrip1.Visible Then
            ContextMenuStrip_MediaPlayer.Show()
            ' End If
            OpacityToolStripMenuItem.ShowDropDown()
            Me.Opacity += 0.1
        End If
    End Sub

    ' Opacity100 - ToolStripMenuItem - Click
    Private Sub Opacity100ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Opacity100ToolStripMenuItem.Click
        Me.Opacity = 1.0
    End Sub

    ' Button_CloseSearch - Click
    Private Sub Button_CloseSearch_Click(sender As Object, e As EventArgs) Handles Button_CloseSearch.Click
        Panel_Search.Hide()
    End Sub

    ' Search - ToolStripMenuItem - Click
    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        If Panel_Search.Visible = True Then
            Panel_Search.Hide()
        Else
            Panel_Search.Show()
        End If
    End Sub

    ' TextBox1 - KeyDown
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_SearchByChannelName.KeyDown
        If e.KeyData = Keys.Enter Then
            If TextBox_SearchByChannelName.Text.Length > 0 Then
                e.Handled = True
                e.SuppressKeyPress = True

                For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
                    If TextBox_SearchByChannelName.Text.ToLower = FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(0).Text().ToLower And FlowLayoutPanel_Channels.Controls.Item(CInt(NumericUpDown_SearchByChannelNumber.Value)).Visible Then
                        TextBox_SearchByChannelName.Clear()

                        currentChannel = i
                        ColorizeCurrentChannel()
                        FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))

                        If AutoCloseChannelsListToolStripMenuItem.Checked Then
                            PanelChannelsListVisiblityWorkAround(False)
                            Panel_Search.Hide()
                        End If

                    End If
                Next

            End If
        End If
    End Sub

    ' NumericUpDown1 - ValueChanged
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_SearchByChannelNumber.ValueChanged
        If NumericUpDown_SearchByChannelNumber.Maximum > -1 Then
            If FlowLayoutPanel_Channels.Controls.Item(CInt(NumericUpDown_SearchByChannelNumber.Value)).Visible Then
                currentChannel = CInt(NumericUpDown_SearchByChannelNumber.Value)
                ColorizeCurrentChannel()
                FlowLayoutPanel_Channels.ScrollControlIntoView(FlowLayoutPanel_Channels.Controls.Item(currentChannel))
            End If
        End If
    End Sub

    ' NumericUpDown1 - KeyDown
    Private Sub NumericUpDown1_KeyDown(sender As Object, e As KeyEventArgs) Handles NumericUpDown_SearchByChannelNumber.KeyDown
        If e.KeyData = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Favorites ToolStripMenuItem - Click
    Private Sub FavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FavoritesToolStripMenuItem.Click

        If File.Exists(FavoriteChannelsFilePath) And FavoritesChannelsList IsNot Nothing Then
            If OnlyFavoritesShown = True Then

                OnlyFavoritesShown = False
                FavoritesToolStripMenuItem.Text = "Favorites"
                TextBox_SearchByChannelName.AutoCompleteCustomSource = AutoComplete_Channels

                FlowLayoutPanel_Channels.SuspendLayout()
                FlowLayoutPanel_Channels.Visible = False
                For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1
                    FlowLayoutPanel_Channels.Controls.Item(i).Show()
                Next
                FlowLayoutPanel_Channels.ResumeLayout()
                FlowLayoutPanel_Channels.Visible = True

            Else
                If FavoritesChannelsList.Count > 0 Then
                    OnlyFavoritesShown = True
                    FavoritesToolStripMenuItem.Text = "All Channels"
                    FavoritesChannelsList = File.ReadAllLines(FavoriteChannelsFilePath)
                    AutoComplete_FavoriteChannels.Clear()
                    AutoComplete_FavoriteChannels.AddRange(FavoritesChannelsList)
                    TextBox_SearchByChannelName.AutoCompleteCustomSource = AutoComplete_FavoriteChannels

                    FlowLayoutPanel_Channels.SuspendLayout()
                    FlowLayoutPanel_Channels.Visible = False
                    For i = 0 To FlowLayoutPanel_Channels.Controls.Count - 1

                        If FavoritesChannelsList IsNot Nothing Then
                            If FavoritesChannelsList.Count > 0 Then
                                If Not FavoritesChannelsList.Contains(FlowLayoutPanel_Channels.Controls.Item(i).Controls.Item(0).Text()) Then
                                    FlowLayoutPanel_Channels.Controls.Item(i).Hide()
                                End If
                            End If
                        End If
                    Next
                    FlowLayoutPanel_Channels.ResumeLayout()
                    FlowLayoutPanel_Channels.Visible = True
                End If
            End If
        End If
    End Sub

    'AddRemoveFavorites - ToolStripMenuItem - Click
    Private Sub AddRemoveFavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddRemoveFavoritesToolStripMenuItem.Click
        If ContextMenuStrip_Channel.SourceControl.Parent.Controls.Item(2).ForeColor = Color.Goldenrod Then
            'Console.WriteLine(ContextMenuStrip2.SourceControl.Parent.Controls.Item(0).Text)
            ContextMenuStrip_Channel.SourceControl.Parent.Controls.Item(2).ForeColor = Color.WhiteSmoke


            Dim lineToRemove As String = ContextMenuStrip_Channel.SourceControl.Parent.Controls.Item(0).Text

            Try
                Dim lines As List(Of String) = File.ReadAllLines(FavoriteChannelsFilePath).ToList()

                If lines.Contains(lineToRemove) Then
                    lines.Remove(lineToRemove)
                    File.WriteAllLines(FavoriteChannelsFilePath, lines)
                    FavoritesChannelsList = File.ReadAllLines(FavoriteChannelsFilePath)
                    AutoComplete_FavoriteChannels.Remove(lineToRemove)

                    If FavoritesToolStripMenuItem.Text = "All Channels" Then
                        ContextMenuStrip_Channel.SourceControl.Parent.Hide()
                    End If

                    Console.WriteLine("Line removed successfully.")
                Else
                    Console.WriteLine("Line not found in the file.")
                End If
            Catch ex As Exception
                Console.WriteLine("An error occurred: " & ex.Message)
            End Try
        Else
            'Console.WriteLine(ContextMenuStrip2.SourceControl.Parent.Controls.Item(0).Text)
            ContextMenuStrip_Channel.SourceControl.Parent.Controls.Item(2).ForeColor = Color.Goldenrod
            File.AppendAllText(FavoriteChannelsFilePath, ContextMenuStrip_Channel.SourceControl.Parent.Controls.Item(0).Text & Environment.NewLine)
            FavoritesChannelsList = File.ReadAllLines(FavoriteChannelsFilePath)
            AutoComplete_FavoriteChannels.Add(ContextMenuStrip_Channel.SourceControl.Parent.Controls.Item(0).Text)
        End If
    End Sub

    ' ContextMenuStrip2 - Opening
    Private Sub ContextMenuStrip2_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip_Channel.Opening
        If ContextMenuStrip_Channel.SourceControl.Parent.Controls.Item(2).ForeColor = Color.Goldenrod Then
            AddRemoveFavoritesToolStripMenuItem.Text = "Remove from favorites"
        Else
            AddRemoveFavoritesToolStripMenuItem.Text = "Add to favorites"
        End If
    End Sub

    ' ContextMenuStrip1 - Opening
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip_MediaPlayer.Opening
        If PopoutDesktopMode = True Then
            NormalPopoutToggleModeToolStripMenuItem.Text = "Normal mode"
        Else
            NormalPopoutToggleModeToolStripMenuItem.Text = "Popout mode"
        End If
    End Sub

    ' Statistics - ToolStripMenuItem - Click
    Private Sub StatisticsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatisticsToolStripMenuItem.Click
        If Not Form_Statistics.Visible Then
            Form_Statistics.Show()
            Form_Statistics.BringToFront()
            UpdateURLsList()
        Else
            Form_Statistics.BringToFront()
        End If
    End Sub

    'Exit - ToolStripMenuItem - Click
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    ' FixedVertical - ToolStripMenuItem - Click
    Private Sub FixedVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixedVerticalToolStripMenuItem.Click
        If FixedVerticalToolStripMenuItem.Checked = False Then
            VerticalToolStripMenuItem.Checked = False
            HorizontalToolStripMenuItem.Checked = False
            FixedVerticalToolStripMenuItem.Checked = True
            Splitter1.Enabled = False
            Splitter1.BackColor = Color.FromArgb(28, 30, 34)

            If Panel_ChannelsList.Dock = DockStyle.Right Then
                Splitter1.MinSize = 398
                Panel_ChannelsList.Width = 398
            Else
                Splitter1.MinSize = 84
                Panel_ChannelsList.Height = 314
            End If

            ForceLayoutUpate(FlowDirection.LeftToRight)
            End If
    End Sub

    ' Vertical - ToolStripMenuItem - Click
    Private Sub VerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerticalToolStripMenuItem.Click
        If VerticalToolStripMenuItem.Checked = False Then
            FixedVerticalToolStripMenuItem.Checked = False
            HorizontalToolStripMenuItem.Checked = False
            VerticalToolStripMenuItem.Checked = True
            Splitter1.Enabled = True
            Splitter1.BackColor = Color.DodgerBlue
            ForceLayoutUpate(FlowDirection.LeftToRight)
        End If
    End Sub

    ' Horizontal - ToolStripMenuItem - Click
    Private Sub HorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HorizontalToolStripMenuItem.Click
        If HorizontalToolStripMenuItem.Checked = False Then
            VerticalToolStripMenuItem.Checked = False
            FixedVerticalToolStripMenuItem.Checked = False
            HorizontalToolStripMenuItem.Checked = True
            Splitter1.Enabled = True
            Splitter1.BackColor = Color.DodgerBlue
            ForceLayoutUpate(FlowDirection.TopDown)
        End If
    End Sub

    ' ForceLayoutUpate
    Private Sub ForceLayoutUpate(newFlowDirection As FlowDirection)
        ' Temporarily remove and re-add controls to force layout update
        Dim controls As Control() = New Control(FlowLayoutPanel_Channels.Controls.Count - 1) {}
        FlowLayoutPanel_Channels.Controls.CopyTo(controls, 0)
        FlowLayoutPanel_Channels.Controls.Clear()
        FlowLayoutPanel_Channels.FlowDirection = newFlowDirection
        FlowLayoutPanel_Channels.Controls.AddRange(controls)
    End Sub

    'Right - ToolStripMenuItem - Click
    Private Sub RightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RightToolStripMenuItem.Click
        If RightToolStripMenuItem.Checked = False Then
            Dim OriginalPanelHeight As Integer = Panel_ChannelsList.Height

            BottomToolStripMenuItem.Checked = False
            RightToolStripMenuItem.Checked = True
            Panel_ChannelsList.Dock = DockStyle.Right
            Splitter1.Dock = DockStyle.Right
            Panel_ChannelsList.SendToBack()
            Splitter1.BringToFront()

            Splitter1.MinSize = 398

            If FixedVerticalToolStripMenuItem.Checked Then
                Panel_ChannelsList.Width = 398
            Else

                If OriginalPanelHeight > 398 Then
                    Panel_ChannelsList.Width = OriginalPanelHeight
                Else
                    Panel_ChannelsList.Width = 398
                End If
            End If

        End If
    End Sub

    ' Bottom - ToolStripMenuItem - Click
    Private Sub BottomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BottomToolStripMenuItem.Click
        If BottomToolStripMenuItem.Checked = False Then
            Dim OriginalPanelWidth As Integer = Panel_ChannelsList.Width

            RightToolStripMenuItem.Checked = False
            BottomToolStripMenuItem.Checked = True
            Panel_ChannelsList.Dock = DockStyle.Bottom
            Splitter1.Dock = DockStyle.Bottom
            Panel_ChannelsList.BringToFront()
            Splitter1.BringToFront()

            MediaPlayer.BringToFront()
            PictureBox_Media.BringToFront()

            Splitter1.MinSize = 84

            If FixedVerticalToolStripMenuItem.Checked Then
                Panel_ChannelsList.Height = 314
            Else
                Panel_ChannelsList.Height = CInt(OriginalPanelWidth / 2)
            End If

        End If
    End Sub

    '
    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Console.WriteLine(SplitContainer1.SplitterDistance)
        'Console.WriteLine(MediaPlayer.network.frameRate.ToString)
        Console.WriteLine(Panel_ChannelsList.Size)
    End Sub

    ' PanelChannelsListVisiblityWorkAround
    Private Sub PanelChannelsListVisiblityWorkAround(Visiblity As Boolean)
        If Visiblity = True Then
            Splitter1.Visible = True
            Panel_ChannelsList.Size = OriginalPanelSize
        Else
            OriginalPanelSize = Panel_ChannelsList.Size
            Splitter1.Visible = False


            Dim targetControl As Control = FlowLayoutPanel_Channels.Controls.Item(currentChannel)

            If Not targetControl.Visible Then
                ' If the control is not visible, scroll it into view
                FlowLayoutPanel_Channels.ScrollControlIntoView(targetControl)
            Else
                ' If the control is visible, check if it's within the visible area
                Dim visibleRectangle As Rectangle = New Rectangle(FlowLayoutPanel_Channels.HorizontalScroll.Value, FlowLayoutPanel_Channels.VerticalScroll.Value, FlowLayoutPanel_Channels.ClientSize.Width, FlowLayoutPanel_Channels.ClientSize.Height)

                If Not visibleRectangle.Contains(targetControl.Bounds) Then
                    FlowLayoutPanel_Channels.ScrollControlIntoView(targetControl)
                End If
            End If

            If Panel_ChannelsList.Dock = DockStyle.Right Then
                Panel_ChannelsList.Width = 0
            Else
                Panel_ChannelsList.Height = 0
            End If
        End If
    End Sub
End Class