<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSincronia
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSincronia))
        Me.AulaPanel = New System.Windows.Forms.Panel()
        Me.AulaTrackBar = New System.Windows.Forms.TrackBar()
        Me.PorcentagemLabel = New System.Windows.Forms.Label()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.PauseButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.BackButton = New System.Windows.Forms.Button()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.SobreButton = New System.Windows.Forms.Button()
        Me.AulaTreeView = New System.Windows.Forms.TreeView()
        Me.AulaAxShockwaveFlash = New AxShockwaveFlashObjects.AxShockwaveFlash()
        Me.AulaStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.EstadoToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.AtualToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.AulaTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DiscLabel = New System.Windows.Forms.Label()
        Me.DisciplinaLabel = New System.Windows.Forms.Label()
        Me.AulaLabel = New System.Windows.Forms.Label()
        Me.TituloLabel = New System.Windows.Forms.Label()
        Me.ProfLabel = New System.Windows.Forms.Label()
        Me.ProfessorLabel = New System.Windows.Forms.Label()
        Me.BackSlideButton = New System.Windows.Forms.Button()
        Me.NextSlideButton = New System.Windows.Forms.Button()
        Me.SlideTextBox = New System.Windows.Forms.TextBox()
        Me.SlideLabel = New System.Windows.Forms.Label()
        Me.SincronizarCheckBox = New System.Windows.Forms.CheckBox()
        Me.VolumeTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PorcentagemVolumeLabel = New System.Windows.Forms.Label()
        Me.MudoCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.AulaTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AulaAxShockwaveFlash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AulaStatusStrip.SuspendLayout()
        CType(Me.VolumeTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AulaPanel
        '
        Me.AulaPanel.BackColor = System.Drawing.Color.Black
        Me.AulaPanel.Location = New System.Drawing.Point(12, 38)
        Me.AulaPanel.Name = "AulaPanel"
        Me.AulaPanel.Size = New System.Drawing.Size(320, 240)
        Me.AulaPanel.TabIndex = 0
        '
        'AulaTrackBar
        '
        Me.AulaTrackBar.LargeChange = 1
        Me.AulaTrackBar.Location = New System.Drawing.Point(65, 284)
        Me.AulaTrackBar.Maximum = 100
        Me.AulaTrackBar.Name = "AulaTrackBar"
        Me.AulaTrackBar.Size = New System.Drawing.Size(267, 45)
        Me.AulaTrackBar.TabIndex = 1
        '
        'PorcentagemLabel
        '
        Me.PorcentagemLabel.AutoSize = True
        Me.PorcentagemLabel.Location = New System.Drawing.Point(20, 289)
        Me.PorcentagemLabel.Name = "PorcentagemLabel"
        Me.PorcentagemLabel.Size = New System.Drawing.Size(33, 13)
        Me.PorcentagemLabel.TabIndex = 3
        Me.PorcentagemLabel.Text = "000%"
        '
        'PlayButton
        '
        Me.PlayButton.Location = New System.Drawing.Point(12, 318)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(50, 34)
        Me.PlayButton.TabIndex = 4
        Me.PlayButton.Text = "Play"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'PauseButton
        '
        Me.PauseButton.Location = New System.Drawing.Point(66, 318)
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(50, 34)
        Me.PauseButton.TabIndex = 5
        Me.PauseButton.Text = "Pause"
        Me.PauseButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(120, 318)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(50, 34)
        Me.StopButton.TabIndex = 6
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'BackButton
        '
        Me.BackButton.Location = New System.Drawing.Point(174, 318)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(50, 34)
        Me.BackButton.TabIndex = 7
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = True
        '
        'NextButton
        '
        Me.NextButton.Location = New System.Drawing.Point(228, 318)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(50, 34)
        Me.NextButton.TabIndex = 8
        Me.NextButton.Text = "Next"
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'SobreButton
        '
        Me.SobreButton.Location = New System.Drawing.Point(282, 318)
        Me.SobreButton.Name = "SobreButton"
        Me.SobreButton.Size = New System.Drawing.Size(50, 34)
        Me.SobreButton.TabIndex = 9
        Me.SobreButton.Text = "????"
        Me.SobreButton.UseVisualStyleBackColor = True
        '
        'AulaTreeView
        '
        Me.AulaTreeView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AulaTreeView.HideSelection = False
        Me.AulaTreeView.Location = New System.Drawing.Point(12, 368)
        Me.AulaTreeView.Name = "AulaTreeView"
        Me.AulaTreeView.Size = New System.Drawing.Size(320, 337)
        Me.AulaTreeView.TabIndex = 10
        '
        'AulaAxShockwaveFlash
        '
        Me.AulaAxShockwaveFlash.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AulaAxShockwaveFlash.Enabled = True
        Me.AulaAxShockwaveFlash.Location = New System.Drawing.Point(353, 38)
        Me.AulaAxShockwaveFlash.MaximumSize = New System.Drawing.Size(1226, 0)
        Me.AulaAxShockwaveFlash.MinimumSize = New System.Drawing.Size(840, 630)
        Me.AulaAxShockwaveFlash.Name = "AulaAxShockwaveFlash"
        Me.AulaAxShockwaveFlash.OcxState = CType(resources.GetObject("AulaAxShockwaveFlash.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AulaAxShockwaveFlash.Size = New System.Drawing.Size(840, 630)
        Me.AulaAxShockwaveFlash.TabIndex = 11
        '
        'AulaStatusStrip
        '
        Me.AulaStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstadoToolStripStatusLabel, Me.AtualToolStripStatusLabel, Me.TotalToolStripStatusLabel})
        Me.AulaStatusStrip.Location = New System.Drawing.Point(0, 717)
        Me.AulaStatusStrip.Name = "AulaStatusStrip"
        Me.AulaStatusStrip.Size = New System.Drawing.Size(1206, 22)
        Me.AulaStatusStrip.TabIndex = 12
        Me.AulaStatusStrip.Text = "StatusStrip1"
        '
        'EstadoToolStripStatusLabel
        '
        Me.EstadoToolStripStatusLabel.Name = "EstadoToolStripStatusLabel"
        Me.EstadoToolStripStatusLabel.Size = New System.Drawing.Size(51, 17)
        Me.EstadoToolStripStatusLabel.Text = "Stopped"
        '
        'AtualToolStripStatusLabel
        '
        Me.AtualToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.AtualToolStripStatusLabel.Name = "AtualToolStripStatusLabel"
        Me.AtualToolStripStatusLabel.Size = New System.Drawing.Size(49, 17)
        Me.AtualToolStripStatusLabel.Text = "00:00:00"
        '
        'TotalToolStripStatusLabel
        '
        Me.TotalToolStripStatusLabel.Name = "TotalToolStripStatusLabel"
        Me.TotalToolStripStatusLabel.Size = New System.Drawing.Size(49, 17)
        Me.TotalToolStripStatusLabel.Text = "00:00:00"
        '
        'AulaTimer
        '
        '
        'DiscLabel
        '
        Me.DiscLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DiscLabel.AutoSize = True
        Me.DiscLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiscLabel.Location = New System.Drawing.Point(223, 9)
        Me.DiscLabel.Name = "DiscLabel"
        Me.DiscLabel.Size = New System.Drawing.Size(66, 13)
        Me.DiscLabel.TabIndex = 13
        Me.DiscLabel.Text = "Disciplina:"
        '
        'DisciplinaLabel
        '
        Me.DisciplinaLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DisciplinaLabel.AutoSize = True
        Me.DisciplinaLabel.Location = New System.Drawing.Point(284, 9)
        Me.DisciplinaLabel.Name = "DisciplinaLabel"
        Me.DisciplinaLabel.Size = New System.Drawing.Size(226, 13)
        Me.DisciplinaLabel.TabIndex = 14
        Me.DisciplinaLabel.Text = "Fundamentos de Algorítmos para Computação"
        '
        'AulaLabel
        '
        Me.AulaLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AulaLabel.AutoSize = True
        Me.AulaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AulaLabel.Location = New System.Drawing.Point(516, 9)
        Me.AulaLabel.Name = "AulaLabel"
        Me.AulaLabel.Size = New System.Drawing.Size(64, 13)
        Me.AulaLabel.TabIndex = 15
        Me.AulaLabel.Text = "Aula_000:"
        '
        'TituloLabel
        '
        Me.TituloLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TituloLabel.AutoSize = True
        Me.TituloLabel.Location = New System.Drawing.Point(577, 9)
        Me.TituloLabel.Name = "TituloLabel"
        Me.TituloLabel.Size = New System.Drawing.Size(226, 13)
        Me.TituloLabel.TabIndex = 16
        Me.TituloLabel.Text = "Fundamentos de Algorítmos para Computação"
        '
        'ProfLabel
        '
        Me.ProfLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProfLabel.AutoSize = True
        Me.ProfLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProfLabel.Location = New System.Drawing.Point(818, 9)
        Me.ProfLabel.Name = "ProfLabel"
        Me.ProfLabel.Size = New System.Drawing.Size(64, 13)
        Me.ProfLabel.TabIndex = 17
        Me.ProfLabel.Text = "Professor:"
        '
        'ProfessorLabel
        '
        Me.ProfessorLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProfessorLabel.AutoSize = True
        Me.ProfessorLabel.Location = New System.Drawing.Point(879, 9)
        Me.ProfessorLabel.Name = "ProfessorLabel"
        Me.ProfessorLabel.Size = New System.Drawing.Size(149, 13)
        Me.ProfessorLabel.TabIndex = 18
        Me.ProfessorLabel.Text = "Anselmo Antunes Montenegro"
        '
        'BackSlideButton
        '
        Me.BackSlideButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BackSlideButton.Location = New System.Drawing.Point(353, 682)
        Me.BackSlideButton.Name = "BackSlideButton"
        Me.BackSlideButton.Size = New System.Drawing.Size(75, 23)
        Me.BackSlideButton.TabIndex = 19
        Me.BackSlideButton.Text = "Back"
        Me.BackSlideButton.UseVisualStyleBackColor = True
        '
        'NextSlideButton
        '
        Me.NextSlideButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NextSlideButton.Location = New System.Drawing.Point(505, 683)
        Me.NextSlideButton.Name = "NextSlideButton"
        Me.NextSlideButton.Size = New System.Drawing.Size(75, 23)
        Me.NextSlideButton.TabIndex = 20
        Me.NextSlideButton.Text = "Next"
        Me.NextSlideButton.UseVisualStyleBackColor = True
        '
        'SlideTextBox
        '
        Me.SlideTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SlideTextBox.Location = New System.Drawing.Point(434, 685)
        Me.SlideTextBox.Name = "SlideTextBox"
        Me.SlideTextBox.Size = New System.Drawing.Size(34, 20)
        Me.SlideTextBox.TabIndex = 21
        '
        'SlideLabel
        '
        Me.SlideLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SlideLabel.AutoSize = True
        Me.SlideLabel.Location = New System.Drawing.Point(471, 692)
        Me.SlideLabel.Name = "SlideLabel"
        Me.SlideLabel.Size = New System.Drawing.Size(30, 13)
        Me.SlideLabel.TabIndex = 22
        Me.SlideLabel.Text = "/000"
        '
        'SincronizarCheckBox
        '
        Me.SincronizarCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SincronizarCheckBox.AutoSize = True
        Me.SincronizarCheckBox.Location = New System.Drawing.Point(604, 688)
        Me.SincronizarCheckBox.Name = "SincronizarCheckBox"
        Me.SincronizarCheckBox.Size = New System.Drawing.Size(78, 17)
        Me.SincronizarCheckBox.TabIndex = 23
        Me.SincronizarCheckBox.Text = "Sincronizar"
        Me.SincronizarCheckBox.UseVisualStyleBackColor = True
        '
        'VolumeTrackBar
        '
        Me.VolumeTrackBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VolumeTrackBar.LargeChange = 1
        Me.VolumeTrackBar.Location = New System.Drawing.Point(1043, 669)
        Me.VolumeTrackBar.Maximum = 100
        Me.VolumeTrackBar.Name = "VolumeTrackBar"
        Me.VolumeTrackBar.Size = New System.Drawing.Size(150, 45)
        Me.VolumeTrackBar.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(983, 682)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Volume:"
        '
        'PorcentagemVolumeLabel
        '
        Me.PorcentagemVolumeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PorcentagemVolumeLabel.AutoSize = True
        Me.PorcentagemVolumeLabel.Location = New System.Drawing.Point(1140, 701)
        Me.PorcentagemVolumeLabel.Name = "PorcentagemVolumeLabel"
        Me.PorcentagemVolumeLabel.Size = New System.Drawing.Size(33, 13)
        Me.PorcentagemVolumeLabel.TabIndex = 26
        Me.PorcentagemVolumeLabel.Text = "000%"
        '
        'MudoCheckBox
        '
        Me.MudoCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MudoCheckBox.AutoSize = True
        Me.MudoCheckBox.Location = New System.Drawing.Point(1054, 700)
        Me.MudoCheckBox.Name = "MudoCheckBox"
        Me.MudoCheckBox.Size = New System.Drawing.Size(53, 17)
        Me.MudoCheckBox.TabIndex = 27
        Me.MudoCheckBox.Text = "Mudo"
        Me.MudoCheckBox.UseVisualStyleBackColor = True
        '
        'FormSincronia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1206, 739)
        Me.Controls.Add(Me.MudoCheckBox)
        Me.Controls.Add(Me.PorcentagemVolumeLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.VolumeTrackBar)
        Me.Controls.Add(Me.SincronizarCheckBox)
        Me.Controls.Add(Me.SlideLabel)
        Me.Controls.Add(Me.SlideTextBox)
        Me.Controls.Add(Me.NextSlideButton)
        Me.Controls.Add(Me.BackSlideButton)
        Me.Controls.Add(Me.ProfessorLabel)
        Me.Controls.Add(Me.ProfLabel)
        Me.Controls.Add(Me.TituloLabel)
        Me.Controls.Add(Me.AulaLabel)
        Me.Controls.Add(Me.DisciplinaLabel)
        Me.Controls.Add(Me.DiscLabel)
        Me.Controls.Add(Me.AulaStatusStrip)
        Me.Controls.Add(Me.AulaAxShockwaveFlash)
        Me.Controls.Add(Me.AulaTreeView)
        Me.Controls.Add(Me.SobreButton)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.BackButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.PauseButton)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.PorcentagemLabel)
        Me.Controls.Add(Me.AulaTrackBar)
        Me.Controls.Add(Me.AulaPanel)
        Me.Name = "FormSincronia"
        Me.Text = "FormSincronia"
        CType(Me.AulaTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AulaAxShockwaveFlash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AulaStatusStrip.ResumeLayout(False)
        Me.AulaStatusStrip.PerformLayout()
        CType(Me.VolumeTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AulaPanel As System.Windows.Forms.Panel
    Friend WithEvents AulaTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents PorcentagemLabel As System.Windows.Forms.Label
    Friend WithEvents PlayButton As System.Windows.Forms.Button
    Friend WithEvents PauseButton As System.Windows.Forms.Button
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents BackButton As System.Windows.Forms.Button
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents SobreButton As System.Windows.Forms.Button
    Friend WithEvents AulaTreeView As System.Windows.Forms.TreeView
    Friend WithEvents AulaAxShockwaveFlash As AxShockwaveFlashObjects.AxShockwaveFlash
    Friend WithEvents AulaStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents EstadoToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AtualToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TotalToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AulaTimer As System.Windows.Forms.Timer
    Friend WithEvents DiscLabel As System.Windows.Forms.Label
    Friend WithEvents DisciplinaLabel As System.Windows.Forms.Label
    Friend WithEvents AulaLabel As System.Windows.Forms.Label
    Friend WithEvents TituloLabel As System.Windows.Forms.Label
    Friend WithEvents ProfLabel As System.Windows.Forms.Label
    Friend WithEvents ProfessorLabel As System.Windows.Forms.Label
    Friend WithEvents BackSlideButton As System.Windows.Forms.Button
    Friend WithEvents NextSlideButton As System.Windows.Forms.Button
    Friend WithEvents SlideTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SlideLabel As System.Windows.Forms.Label
    Friend WithEvents SincronizarCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents VolumeTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PorcentagemVolumeLabel As System.Windows.Forms.Label
    Friend WithEvents MudoCheckBox As System.Windows.Forms.CheckBox
End Class
