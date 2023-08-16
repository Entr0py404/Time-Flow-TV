Public Class Form_Statistics

    ' Form_Statistics - Load
    Private Sub Form_Statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""

        Label2.Text = ""
        Label3.Text = ""

        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = ""

        Label8.Text = ""
        Label9.Text = ""
        Label10.Text = ""

        Label11.Text = ""
        Label12.Text = ""
        Label13.Text = ""

        Label14.Text = ""
        Label15.Text = ""
        Label16.Text = ""

        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
    End Sub

    'Timer1 - Tick
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim roundedFrameRate As Integer = CInt(Math.Round(MainForm.MediaPlayer.network.frameRate, 1))

        Label1.Text = "Frame Rate: " & Form_Main.MediaPlayer.network.frameRate \ 100

        Label2.Text = "Encoded Frame Rate: " & Form_Main.MediaPlayer.network.encodedFrameRate
        Label3.Text = "Frames Skipped: " & Form_Main.MediaPlayer.network.framesSkipped

        Label4.Text = "Bit Rate: " & FormatDataSize(Form_Main.MediaPlayer.network.bitRate)
        Label5.Text = "Max BitRate: " & FormatDataSize(Form_Main.MediaPlayer.network.maxBitRate)
        Label6.Text = "Band Width: " & FormatDataSize(Form_Main.MediaPlayer.network.bandWidth)
        Label7.Text = "Max Bandwidth: " & FormatDataSize(Form_Main.MediaPlayer.network.maxBandwidth)

        Label8.Text = "Received Packets: " & Form_Main.MediaPlayer.network.receivedPackets
        Label9.Text = "Recovered Packets: " & Form_Main.MediaPlayer.network.recoveredPackets
        Label10.Text = "Lost Packets: " & Form_Main.MediaPlayer.network.lostPackets

        Label11.Text = "Buffering Progress: " & Form_Main.MediaPlayer.network.bufferingProgress & "%"
        Label12.Text = "Buffering Time: " & FormatBufferingTime(Form_Main.MediaPlayer.network.bufferingTime)
        Label13.Text = "Buffering Count: " & Form_Main.MediaPlayer.network.bufferingCount

        Label14.Text = "Download Progress: " & Form_Main.MediaPlayer.network.downloadProgress
        Label15.Text = "Reception Quality: " & Form_Main.MediaPlayer.network.receptionQuality & "%"

        Label16.Text = "Source Protocol: " & Form_Main.MediaPlayer.network.sourceProtocol

        If Form_Main.MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
            Label17.Text = "Player Status: " & Form_Main.MediaPlayer.status.Replace("'" & Form_Main.MediaPlayer.currentMedia.name.ToString & "':", "@")
        Else
            Label17.Text = "Player Status: " & Form_Main.MediaPlayer.status
        End If

        Label18.Text = "Play State: " & Form_Main.MediaPlayer.playState.ToString
        Label19.Text = "Open State: " & Form_Main.MediaPlayer.openState.ToString
    End Sub

    'FormatDataSize
    Private Function FormatDataSize(value As Double) As String
        If value < 1000 Then
            Return $"{value:F2} bps"
        Else 'If value < 1000000 Then
            Return $"{value / 1000:F2} kbps"
            'Else
            'Return $"{value / 1000000:F2} Mbps"
        End If
    End Function

    ' FormatBufferingTime
    Private Function FormatBufferingTime(milliseconds As Long) As String
        Dim totalMilliseconds As Long = milliseconds
        Dim millisecondsPart As Long = totalMilliseconds Mod 1000
        totalMilliseconds \= 1000
        Dim secondsPart As Long = totalMilliseconds Mod 60
        Dim minutesPart As Long = totalMilliseconds \ 60

        Dim formattedTime As String = ""

        If minutesPart > 0 Then
            formattedTime = $"{minutesPart} min"
        End If

        If secondsPart > 0 Then
            If formattedTime <> "" Then
                formattedTime &= ", "
            End If
            formattedTime &= $"{secondsPart} sec"
        End If

        If millisecondsPart > 0 Then
            If formattedTime <> "" Then
                formattedTime &= ", "
            End If
            formattedTime &= $"{millisecondsPart} ms"
        End If

        Return formattedTime
    End Function
End Class