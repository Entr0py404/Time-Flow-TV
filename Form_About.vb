Public Class Form_About
    Private targetOpacity As Double = 0.8
    Private currentOpacity As Double = 0.0
    ' About - Load
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label_Version.Text = "v" & My.Application.Info.Version.ToString
        Label_WMPVersion.Text = "WMP v" & Form_Main.MediaPlayer.versionInfo

        Me.Opacity = 0.2
        currentOpacity = Me.Opacity
        Timer1.Start()
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

    ' Label1 - MouseDown
    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        Label1.Capture = False
        MoveWindow()
    End Sub

    ' Panel2 - MouseDown
    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        Panel2.Capture = False
        MoveWindow()
    End Sub

    ' PictureBox1  - MouseDown
    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        PictureBox1.Capture = False
        MoveWindow()
    End Sub

    ' PictureBox2 - MouseDown
    Private Sub PictureBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseDown
        PictureBox2.Capture = False
        MoveWindow()
    End Sub

    ' Label_Version - MouseDown
    Private Sub Label_Version_MouseDown(sender As Object, e As MouseEventArgs) Handles Label_Version.MouseDown
        Label_Version.Capture = False
        MoveWindow()
    End Sub

    ' Label_WMPVersion - MouseDown
    Private Sub Label_WMPVersion_MouseDown(sender As Object, e As MouseEventArgs) Handles Label_WMPVersion.MouseDown
        Label_WMPVersion.Capture = False
        MoveWindow()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If currentOpacity < targetOpacity Then
            currentOpacity += 0.1 ' Adjust this value for smoother/faster fade
            If currentOpacity > targetOpacity Then
                currentOpacity = targetOpacity
                Timer1.Stop()
            End If
            Me.Opacity = currentOpacity
        Else
            Timer1.Stop() ' Stop the Timer if opacity reaches the target
        End If
    End Sub
End Class