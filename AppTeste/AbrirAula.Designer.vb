<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AbrirAula
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ItensTreeView = New System.Windows.Forms.TreeView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProcurarRaizButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NomeAulaTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CodigoAulaTextBox = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DisciplinaAulaTextBox = New System.Windows.Forms.TextBox()
        Me.PorcentagemAulaLabel = New System.Windows.Forms.Label()
        Me.PorcentagemAulaProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ReproduzirButton = New System.Windows.Forms.Button()
        Me.DownloadButton = New System.Windows.Forms.Button()
        Me.NovaAulaTextBox = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ItensTreeView
        '
        Me.ItensTreeView.HideSelection = False
        Me.ItensTreeView.Location = New System.Drawing.Point(12, 14)
        Me.ItensTreeView.Name = "ItensTreeView"
        Me.ItensTreeView.Size = New System.Drawing.Size(253, 538)
        Me.ItensTreeView.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NovaAulaTextBox)
        Me.GroupBox1.Controls.Add(Me.ProcurarRaizButton)
        Me.GroupBox1.Location = New System.Drawing.Point(271, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(395, 62)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Abrir Vídeo-Aula"
        '
        'ProcurarRaizButton
        '
        Me.ProcurarRaizButton.Location = New System.Drawing.Point(314, 24)
        Me.ProcurarRaizButton.Name = "ProcurarRaizButton"
        Me.ProcurarRaizButton.Size = New System.Drawing.Size(75, 23)
        Me.ProcurarRaizButton.TabIndex = 4
        Me.ProcurarRaizButton.Text = "Abrir"
        Me.ProcurarRaizButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DownloadButton)
        Me.GroupBox2.Controls.Add(Me.ReproduzirButton)
        Me.GroupBox2.Controls.Add(Me.PorcentagemAulaLabel)
        Me.GroupBox2.Controls.Add(Me.PorcentagemAulaProgressBar)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.NomeAulaTextBox)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.CodigoAulaTextBox)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.DisciplinaAulaTextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(271, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(395, 253)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Descrição de Vídeo-Aula"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Nome:"
        '
        'NomeAulaTextBox
        '
        Me.NomeAulaTextBox.Location = New System.Drawing.Point(52, 71)
        Me.NomeAulaTextBox.Name = "NomeAulaTextBox"
        Me.NomeAulaTextBox.Size = New System.Drawing.Size(337, 20)
        Me.NomeAulaTextBox.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Código:"
        '
        'CodigoAulaTextBox
        '
        Me.CodigoAulaTextBox.Location = New System.Drawing.Point(52, 31)
        Me.CodigoAulaTextBox.Name = "CodigoAulaTextBox"
        Me.CodigoAulaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodigoAulaTextBox.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(158, 34)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Disciplina:"
        '
        'DisciplinaAulaTextBox
        '
        Me.DisciplinaAulaTextBox.Location = New System.Drawing.Point(219, 31)
        Me.DisciplinaAulaTextBox.Name = "DisciplinaAulaTextBox"
        Me.DisciplinaAulaTextBox.Size = New System.Drawing.Size(170, 20)
        Me.DisciplinaAulaTextBox.TabIndex = 15
        '
        'PorcentagemAulaLabel
        '
        Me.PorcentagemAulaLabel.AutoSize = True
        Me.PorcentagemAulaLabel.Location = New System.Drawing.Point(13, 116)
        Me.PorcentagemAulaLabel.Name = "PorcentagemAulaLabel"
        Me.PorcentagemAulaLabel.Size = New System.Drawing.Size(33, 13)
        Me.PorcentagemAulaLabel.TabIndex = 27
        Me.PorcentagemAulaLabel.Text = "000%"
        '
        'PorcentagemAulaProgressBar
        '
        Me.PorcentagemAulaProgressBar.Location = New System.Drawing.Point(52, 106)
        Me.PorcentagemAulaProgressBar.Name = "PorcentagemAulaProgressBar"
        Me.PorcentagemAulaProgressBar.Size = New System.Drawing.Size(337, 23)
        Me.PorcentagemAulaProgressBar.TabIndex = 26
        '
        'ReproduzirButton
        '
        Me.ReproduzirButton.Enabled = False
        Me.ReproduzirButton.Location = New System.Drawing.Point(286, 212)
        Me.ReproduzirButton.Name = "ReproduzirButton"
        Me.ReproduzirButton.Size = New System.Drawing.Size(103, 23)
        Me.ReproduzirButton.TabIndex = 5
        Me.ReproduzirButton.Text = "Reproduzir"
        Me.ReproduzirButton.UseVisualStyleBackColor = True
        '
        'DownloadButton
        '
        Me.DownloadButton.Enabled = False
        Me.DownloadButton.Location = New System.Drawing.Point(191, 212)
        Me.DownloadButton.Name = "DownloadButton"
        Me.DownloadButton.Size = New System.Drawing.Size(89, 23)
        Me.DownloadButton.TabIndex = 28
        Me.DownloadButton.Text = "Download"
        Me.DownloadButton.UseVisualStyleBackColor = True
        '
        'NovaAulaTextBox
        '
        Me.NovaAulaTextBox.Location = New System.Drawing.Point(6, 27)
        Me.NovaAulaTextBox.Name = "NovaAulaTextBox"
        Me.NovaAulaTextBox.Size = New System.Drawing.Size(302, 20)
        Me.NovaAulaTextBox.TabIndex = 5
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "Vídeo Aula (*.xml)|*.xml"
        Me.OpenFileDialog.RestoreDirectory = True
        '
        'AbrirAula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 564)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ItensTreeView)
        Me.Name = "AbrirAula"
        Me.Text = "AbrirAula"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItensTreeView As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProcurarRaizButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NomeAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CodigoAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DisciplinaAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DownloadButton As System.Windows.Forms.Button
    Friend WithEvents ReproduzirButton As System.Windows.Forms.Button
    Friend WithEvents PorcentagemAulaLabel As System.Windows.Forms.Label
    Friend WithEvents PorcentagemAulaProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents NovaAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class
