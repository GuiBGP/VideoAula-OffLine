<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuracao
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProcurarRaizButton = New System.Windows.Forms.Button()
        Me.RaizTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ContinuarCheckBox = New System.Windows.Forms.CheckBox()
        Me.TestarUrlButton = New System.Windows.Forms.Button()
        Me.ProxyTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LimiteTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.URLTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SalvarButton = New System.Windows.Forms.Button()
        Me.CancelarButton = New System.Windows.Forms.Button()
        Me.PadraoButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProcurarRaizButton)
        Me.GroupBox1.Controls.Add(Me.RaizTextBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Diretório"
        '
        'ProcurarRaizButton
        '
        Me.ProcurarRaizButton.Location = New System.Drawing.Point(590, 26)
        Me.ProcurarRaizButton.Name = "ProcurarRaizButton"
        Me.ProcurarRaizButton.Size = New System.Drawing.Size(75, 23)
        Me.ProcurarRaizButton.TabIndex = 2
        Me.ProcurarRaizButton.Text = "Procurar"
        Me.ProcurarRaizButton.UseVisualStyleBackColor = True
        '
        'RaizTextBox
        '
        Me.RaizTextBox.Location = New System.Drawing.Point(109, 28)
        Me.RaizTextBox.Name = "RaizTextBox"
        Me.RaizTextBox.Size = New System.Drawing.Size(475, 20)
        Me.RaizTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Diretório Raiz:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ContinuarCheckBox)
        Me.GroupBox2.Controls.Add(Me.TestarUrlButton)
        Me.GroupBox2.Controls.Add(Me.ProxyTextBox)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.LimiteTextBox)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.URLTextBox)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(671, 149)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Url"
        '
        'ContinuarCheckBox
        '
        Me.ContinuarCheckBox.AutoSize = True
        Me.ContinuarCheckBox.Location = New System.Drawing.Point(290, 102)
        Me.ContinuarCheckBox.Name = "ContinuarCheckBox"
        Me.ContinuarCheckBox.Size = New System.Drawing.Size(357, 17)
        Me.ContinuarCheckBox.TabIndex = 16
        Me.ContinuarCheckBox.Text = "Continuar com os downloads interrompidos  quando a aplicação iniciar"
        Me.ContinuarCheckBox.UseVisualStyleBackColor = True
        '
        'TestarUrlButton
        '
        Me.TestarUrlButton.Location = New System.Drawing.Point(590, 29)
        Me.TestarUrlButton.Name = "TestarUrlButton"
        Me.TestarUrlButton.Size = New System.Drawing.Size(75, 56)
        Me.TestarUrlButton.TabIndex = 13
        Me.TestarUrlButton.Text = "Testar"
        Me.TestarUrlButton.UseVisualStyleBackColor = True
        '
        'ProxyTextBox
        '
        Me.ProxyTextBox.Enabled = False
        Me.ProxyTextBox.Location = New System.Drawing.Point(109, 65)
        Me.ProxyTextBox.Name = "ProxyTextBox"
        Me.ProxyTextBox.Size = New System.Drawing.Size(475, 20)
        Me.ProxyTextBox.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(67, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Proxy:"
        '
        'LimiteTextBox
        '
        Me.LimiteTextBox.Location = New System.Drawing.Point(109, 102)
        Me.LimiteTextBox.Name = "LimiteTextBox"
        Me.LimiteTextBox.Size = New System.Drawing.Size(152, 20)
        Me.LimiteTextBox.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Limite de Download:"
        '
        'URLTextBox
        '
        Me.URLTextBox.Location = New System.Drawing.Point(109, 29)
        Me.URLTextBox.Name = "URLTextBox"
        Me.URLTextBox.Size = New System.Drawing.Size(475, 20)
        Me.URLTextBox.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Url Raiz:"
        '
        'SalvarButton
        '
        Me.SalvarButton.Location = New System.Drawing.Point(602, 271)
        Me.SalvarButton.Name = "SalvarButton"
        Me.SalvarButton.Size = New System.Drawing.Size(75, 23)
        Me.SalvarButton.TabIndex = 13
        Me.SalvarButton.Text = "Salvar"
        Me.SalvarButton.UseVisualStyleBackColor = True
        '
        'CancelarButton
        '
        Me.CancelarButton.Location = New System.Drawing.Point(521, 271)
        Me.CancelarButton.Name = "CancelarButton"
        Me.CancelarButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelarButton.TabIndex = 14
        Me.CancelarButton.Text = "Cancelar"
        Me.CancelarButton.UseVisualStyleBackColor = True
        '
        'PadraoButton
        '
        Me.PadraoButton.Location = New System.Drawing.Point(440, 271)
        Me.PadraoButton.Name = "PadraoButton"
        Me.PadraoButton.Size = New System.Drawing.Size(75, 23)
        Me.PadraoButton.TabIndex = 15
        Me.PadraoButton.Text = "Padrão"
        Me.PadraoButton.UseVisualStyleBackColor = True
        '
        'Configuracao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 309)
        Me.Controls.Add(Me.PadraoButton)
        Me.Controls.Add(Me.CancelarButton)
        Me.Controls.Add(Me.SalvarButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Configuracao"
        Me.Text = "Configuracao"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProcurarRaizButton As System.Windows.Forms.Button
    Friend WithEvents RaizTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LimiteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents URLTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContinuarCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TestarUrlButton As System.Windows.Forms.Button
    Friend WithEvents ProxyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SalvarButton As System.Windows.Forms.Button
    Friend WithEvents CancelarButton As System.Windows.Forms.Button
    Friend WithEvents PadraoButton As System.Windows.Forms.Button
End Class
