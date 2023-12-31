﻿
Public Class Form_ChannelContent

    ' Form_ChannelContent - Load
    Private Sub Form_ChannelContent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        Label1.Text = ""
        Label2.Text = ""
    End Sub

    ' ListBox1 - SelectedIndexChanged
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_ChannelContent.SelectedIndexChanged
        If ListBox_ChannelContent.SelectedIndex > -1 And Me.Visible And Not Form_Main.MediaPlayer.URL = "https://archive.org/download/" & ListBox_ChannelContent.SelectedItem.ToString Then
            Form_Main.MediaPlayer.URL = "https://archive.org/download/" & ListBox_ChannelContent.SelectedItem.ToString
        End If
    End Sub

    ' ContentListModeSorted - ToolStripMenuItem - Click
    Private Sub ContentListModeSortedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentListModeSortedToolStripMenuItem.Click
        Form_Main.ContentListModeSortedToolStripMenuItem.PerformClick()
    End Sub

    ' ContentListModeShuffled - ToolStripMenuItem - Click
    Private Sub ContentListModeShuffledToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentListModeShuffledToolStripMenuItem.Click
        Form_Main.ContentListModeShuffledToolStripMenuItem.PerformClick()
    End Sub

    ' Download - ToolStripMenuItem_Download - Click
    Private Sub DownloadToolStripMenuItem_Download_Click(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem_Download.Click
        If ListBox_ChannelContent.SelectedIndex > -1 Then
            Process.Start("https://archive.org/download/" & ListBox_ChannelContent.SelectedItem.ToString)
        End If
    End Sub
End Class