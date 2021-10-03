Public Class OptionsUI

  Public Overrides Sub LoadData(ByVal config As String)
    If config IsNot Nothing Then
      Dim cfg = MyConfig.Load(config)
      txtZone.Text = cfg.CloneZone.ToString
      'txt3LD.Text = cfg.TLD3String
      txtFile.Text = cfg.PSLFile
    End If
  End Sub

  Public Overrides Function ValidateData() As Boolean
    txtZone.Text = txtZone.Text.Trim.ToLowerInvariant

    Dim d As JHSoftware.SimpleDNS.DomName
    If Not JHSoftware.SimpleDNS.DomName.TryParse(txtZone.Text, d) OrElse d.SegmentCount < 1 Then
      MessageBox.Show("Invalid clone from zone name", "Clone Zone", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If

    If Not RemoteGUI Then
      If Not My.Computer.FileSystem.FileExists(txtFile.Text.Trim) Then
        MessageBox.Show("Public suffix list file does not exist!", "Public suffix list file", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
      End If
    End If
  
    'Dim x = txt3LD.Text
    'For i = 0 To x.Length - 1
    '  If "0123456789abcdefghijklmnopqrstuvwxyz-,".IndexOf(x(i)) < 0 Then
    '    MessageBox.Show("Invalid character (" & x(i) & ") in TLDs", "Clone Zone", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Return False
    '  End If
    'Next

    Return True
  End Function

  Public Overrides Function SaveData() As String
    Dim cfg As New MyConfig
    cfg.CloneZone = JHSoftware.SimpleDNS.DomName.Parse(txtZone.Text.Trim)
    'cfg.TLD3String = txt3LD.Text
    cfg.PSLFile = txtFile.Text.Trim
    Return cfg.Save
  End Function

  'Private Sub Clean3LD()
  '  Dim x = txt3LD.Text.Replace(" "c, "").ToLowerInvariant
  '  While x.IndexOf(",,") >= 0
  '    x = x.Replace(",,", ",")
  '  End While
  '  If x.StartsWith(",") Then x = x.Substring(1)
  '  If x.EndsWith(",") Then x = x.Substring(0, x.Length - 1)
  '  txt3LD.Text = x
  'End Sub

  Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
    If RemoteGUI Then MessageBox.Show("This function is not available during remote management", _
                                  "Browse for file/folder", MessageBoxButtons.OK, _
                                  MessageBoxIcon.Warning) : Exit Sub

    OpenFileDialog1.FileName = txtFile.Text.Trim
    Try
      If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
    Catch ex As System.InvalidOperationException
      REM reported by Kento for file name "C:\"
      OpenFileDialog1.FileName = ""
      If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
    End Try
    txtFile.Text = OpenFileDialog1.FileName

  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    Dim url = LinkLabel1.Text.Substring(LinkLabel1.LinkArea.Start, LinkLabel1.LinkArea.Length)
    Try
      System.Diagnostics.Process.Start(url)
    Catch
    End Try
  End Sub
End Class
