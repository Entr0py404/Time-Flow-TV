Public Class Form_About
    Private targetOpacity As Double = 0.8
    Private currentOpacity As Double = 0.0
    ' About - Load
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label_ProjectVersion.Text = "v" & My.Application.Info.Version.ToString
        Label_WMPVersion.Text = "WMP v" & Form_Main.MediaPlayer.versionInfo

        Me.Opacity = 0.2
        currentOpacity = Me.Opacity
        Timer_FadeIn.Start()
    End Sub

    ' Button_Close - Click
    Private Sub Button_Close_Click(sender As Object, e As EventArgs) Handles Button_Close.Click
        Me.Close()
    End Sub

    ' MoveWindow
    Private Sub MoveWindow()
        Const WM_NCLBUTTONDOWN As Integer = &HA1S
        Const HTCAPTION As Integer = 2
        Dim msg As Message = Message.Create(Me.Handle, WM_NCLBUTTONDOWN, New IntPtr(HTCAPTION), IntPtr.Zero)
        Me.DefWndProc(msg)
    End Sub

    ' Label_ProjectTitle - MouseDown
    Private Sub Label_ProjectTitle_MouseDown(sender As Object, e As MouseEventArgs) Handles Label_ProjectTitle.MouseDown
        Label_ProjectTitle.Capture = False
        MoveWindow()
    End Sub

    ' Panel_WindowTitleBar - MouseDown
    Private Sub Panel_WindowTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel_WindowTitleBar.MouseDown
        Panel_WindowTitleBar.Capture = False
        MoveWindow()
    End Sub

    ' PictureBox_ProjectIcon  - MouseDown
    Private Sub PictureBox_ProjectIcon_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_ProjectIcon.MouseDown
        PictureBox_ProjectIcon.Capture = False
        MoveWindow()
    End Sub

    ' PictureBox_GifBackground - MouseDown
    Private Sub PictureBox_GifBackground_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox_GifBackground.MouseDown
        PictureBox_GifBackground.Capture = False
        MoveWindow()
    End Sub

    ' Label_Version - MouseDown
    Private Sub Label_Version_MouseDown(sender As Object, e As MouseEventArgs) Handles Label_ProjectVersion.MouseDown
        Label_ProjectVersion.Capture = False
        MoveWindow()
    End Sub

    ' Label_WMPVersion - MouseDown
    Private Sub Label_WMPVersion_MouseDown(sender As Object, e As MouseEventArgs) Handles Label_WMPVersion.MouseDown
        Label_WMPVersion.Capture = False
        MoveWindow()
    End Sub

    ' Timer_FadeIn - Tick
    Private Sub Timer_FadeIn_Tick(sender As Object, e As EventArgs) Handles Timer_FadeIn.Tick
        If currentOpacity < targetOpacity Then
            currentOpacity += 0.1 ' Adjust this value for smoother/faster fade
            If currentOpacity > targetOpacity Then
                currentOpacity = targetOpacity
                Timer_FadeIn.Stop()
            End If
            Me.Opacity = currentOpacity
        Else
            Timer_FadeIn.Stop() ' Stop the Timer if opacity reaches the target
        End If
    End Sub
End Class