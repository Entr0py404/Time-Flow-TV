Public Class Form_Statistics

    ' Form_Statistics - Load
    Private Sub Form_Statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label_FrameRate.Text = ""
        Label_EncodedFrameRate.Text = ""
        Label_FramesSkipped.Text = ""
        Label_BitRate.Text = ""
        Label_MaxBitRate.Text = ""
        Label_BandWidth.Text = ""
        Label_MaxBandwidth.Text = ""
        Label_ReceivedPackets.Text = ""
        Label_RecoveredPackets.Text = ""
        Label_LostPackets.Text = ""
        Label_BufferingProgress.Text = ""
        Label_BufferingTime.Text = ""
        Label_BufferingCount.Text = ""
        Label_DownloadProgress.Text = ""
        Label_ReceptionQuality.Text = ""
        Label_SourceProtocol.Text = ""
        Label_PlayerStatus.Text = ""
        Label_PlayState.Text = ""
        Label_OpenState.Text = ""
    End Sub

    'Timer_Statistics - Tick
    Private Sub Timer_Statistics_Tick(sender As Object, e As EventArgs) Handles Timer_Statistics.Tick
        If Not Form_Main.MediaPlayer.network.frameRate = 0 Then
            Label_FrameRate.Text = "Frame Rate: " & Form_Main.MediaPlayer.network.frameRate \ 100
        Else
            Label_FrameRate.Text = "Frame Rate: 0"
        End If
        Label_EncodedFrameRate.Text = "Encoded Frame Rate: " & Form_Main.MediaPlayer.network.encodedFrameRate
        Label_FramesSkipped.Text = "Frames Skipped: " & Form_Main.MediaPlayer.network.framesSkipped

        Label_BitRate.Text = "Bit Rate: " & FormatDataSize(Form_Main.MediaPlayer.network.bitRate)
        Label_MaxBitRate.Text = "Max BitRate: " & FormatDataSize(Form_Main.MediaPlayer.network.maxBitRate)
        Label_BandWidth.Text = "Band Width: " & FormatDataSize(Form_Main.MediaPlayer.network.bandWidth)
        Label_MaxBandwidth.Text = "Max Bandwidth: " & FormatDataSize(Form_Main.MediaPlayer.network.maxBandwidth)

        Label_ReceivedPackets.Text = "Received Packets: " & Form_Main.MediaPlayer.network.receivedPackets
        Label_RecoveredPackets.Text = "Recovered Packets: " & Form_Main.MediaPlayer.network.recoveredPackets
        Label_LostPackets.Text = "Lost Packets: " & Form_Main.MediaPlayer.network.lostPackets

        Label_BufferingProgress.Text = "Buffering Progress: " & Form_Main.MediaPlayer.network.bufferingProgress & "%"
        Label_BufferingTime.Text = "Buffering Time: " & FormatBufferingTime(Form_Main.MediaPlayer.network.bufferingTime)
        Label_BufferingCount.Text = "Buffering Count: " & Form_Main.MediaPlayer.network.bufferingCount

        Label_DownloadProgress.Text = "Download Progress: " & Form_Main.MediaPlayer.network.downloadProgress
        Label_ReceptionQuality.Text = "Reception Quality: " & Form_Main.MediaPlayer.network.receptionQuality & "%"

        Label_SourceProtocol.Text = "Source Protocol: " & Form_Main.MediaPlayer.network.sourceProtocol

        If Form_Main.MediaPlayer.playState = WMPPlayState.wmppsPlaying Then
            Label_PlayerStatus.Text = "Player Status: " & Form_Main.MediaPlayer.status.Replace("'" & Form_Main.MediaPlayer.currentMedia.name.ToString & "':", "@")
        Else
            Label_PlayerStatus.Text = "Player Status: " & Form_Main.MediaPlayer.status
        End If

        Label_PlayState.Text = "Play State: " & Form_Main.MediaPlayer.playState.ToString
        Label_OpenState.Text = "Open State: " & Form_Main.MediaPlayer.openState.ToString
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