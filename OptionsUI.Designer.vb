<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsUI
    Inherits JHSoftware.SimpleDNS.Plugin.OptionsUI

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsUI))
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtZone = New System.Windows.Forms.TextBox
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.btnBrowse = New System.Windows.Forms.Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtFile = New System.Windows.Forms.TextBox
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
    Me.SuspendLayout()
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(-3, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(158, 13)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "Clone from zone (domain name):"
    '
    'txtZone
    '
    Me.txtZone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtZone.Location = New System.Drawing.Point(0, 16)
    Me.txtZone.Name = "txtZone"
    Me.txtZone.Size = New System.Drawing.Size(384, 20)
    Me.txtZone.TabIndex = 1
    '
    'btnBrowse
    '
    Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnBrowse.Location = New System.Drawing.Point(361, 74)
    Me.btnBrowse.Name = "btnBrowse"
    Me.btnBrowse.Size = New System.Drawing.Size(23, 23)
    Me.btnBrowse.TabIndex = 7
    Me.btnBrowse.Text = ".."
    Me.ToolTip1.SetToolTip(Me.btnBrowse, "Browse")
    Me.btnBrowse.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(-3, 60)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(97, 13)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "Public suffix list file:"
    '
    'txtFile
    '
    Me.txtFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtFile.Location = New System.Drawing.Point(0, 76)
    Me.txtFile.Name = "txtFile"
    Me.txtFile.Size = New System.Drawing.Size(355, 20)
    Me.txtFile.TabIndex = 6
    '
    'LinkLabel1
    '
    Me.LinkLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LinkLabel1.LinkArea = New System.Windows.Forms.LinkArea(203, 23)
    Me.LinkLabel1.Location = New System.Drawing.Point(0, 104)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(384, 97)
    Me.LinkLabel1.TabIndex = 8
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = resources.GetString("LinkLabel1.Text")
    Me.LinkLabel1.UseCompatibleTextRendering = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.AddExtension = False
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    Me.OpenFileDialog1.Filter = "All files (*.*)|*.*"
    Me.OpenFileDialog1.Title = "Select public suffix list file"
    '
    'OptionsUI
    '
    Me.Controls.Add(Me.LinkLabel1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.btnBrowse)
    Me.Controls.Add(Me.txtFile)
    Me.Controls.Add(Me.txtZone)
    Me.Controls.Add(Me.Label2)
    Me.Name = "OptionsUI"
    Me.Size = New System.Drawing.Size(384, 201)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtZone As System.Windows.Forms.TextBox
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents btnBrowse As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtFile As System.Windows.Forms.TextBox
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
