Public Class Form_ChannelContent

    ' Form_ChannelContent - Load
    Private Sub Form_ChannelContent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        Label1.Text = ""
        Label2.Text = ""
    End Sub

    ' ListBox1 - SelectedIndexChanged
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_ChannelContent.SelectedIndexChanged
        If ListBox_ChannelContent.SelectedIndex > -1 AndAlso Me.Visible Then
            Dim selectedItem As Object = ListBox_ChannelContent.SelectedItem
            If selectedItem IsNot Nothing Then
                Dim url As String = "https://archive.org/download/" & selectedItem.ToString()

                ' Find the last slash in the URL
                Dim lastSlashIndex As Integer = url.LastIndexOf("/"c)

                ' Ensure there's a valid filename to encode
                If lastSlashIndex > -1 AndAlso lastSlashIndex < url.Length - 1 Then
                    ' Separate the base URL and the filename
                    Dim baseUrl As String = url.Substring(0, lastSlashIndex + 1)
                    Dim filename As String = url.Substring(lastSlashIndex + 1)

                    ' URL encode using Uri.EscapeDataString()
                    Dim encodedFilename As String = Uri.EscapeDataString(filename)

                    ' Reconstruct the full URL
                    Dim encodedUrl As String = baseUrl & encodedFilename

                    ' Output the result
                    Console.WriteLine(encodedUrl)

                    ' Update MediaPlayer if the URL has changed
                    If Form_Main.MediaPlayer.URL <> encodedUrl Then
                        Form_Main.MediaPlayer.URL = encodedUrl
                        'Console.WriteLine(Form_Main.MediaPlayer.URL)
                    End If
                Else
                    Console.WriteLine("Invalid URL structure.")
                End If
            Else
                Console.WriteLine("No item selected.")
            End If
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