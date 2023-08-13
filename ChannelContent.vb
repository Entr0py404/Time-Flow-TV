
Public Class ChannelContent

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 And Me.Visible And Not MainForm.MediaPlayer.URL = "https://archive.org/download/" & ListBox1.SelectedItem.ToString Then
            MainForm.MediaPlayer.URL = "https://archive.org/download/" & ListBox1.SelectedItem.ToString
        End If
    End Sub
End Class