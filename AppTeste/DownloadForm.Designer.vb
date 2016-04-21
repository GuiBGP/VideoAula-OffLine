<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadForm
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
        Me.DetalheTabControl = New System.Windows.Forms.TabControl()
        Me.AulaTabPage = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ExecutarButton = New System.Windows.Forms.Button()
        Me.IniciarAulaButton = New System.Windows.Forms.Button()
        Me.AbrirAulaButton = New System.Windows.Forms.Button()
        Me.SlidesGroupBox = New System.Windows.Forms.GroupBox()
        Me.DownloadConcluidoLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PorcentagemSlideSimplesLabel = New System.Windows.Forms.Label()
        Me.PorcentagemSlideSimplesProgressBar = New System.Windows.Forms.ProgressBar()
        Me.DownloadSlideLabel = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.SlideLabel = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PorcentagemSlideLabel = New System.Windows.Forms.Label()
        Me.PorcentagemSlideProgressBar = New System.Windows.Forms.ProgressBar()
        Me.IniciarSlideButton = New System.Windows.Forms.Button()
        Me.VideoAulaGroupBox = New System.Windows.Forms.GroupBox()
        Me.DownloadVideoLabel = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.DuracaoLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.VideoAulaLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PorcentagemVideoLabel = New System.Windows.Forms.Label()
        Me.PorcentagemVideoProgressBar = New System.Windows.Forms.ProgressBar()
        Me.IniciarVideoAulaButton = New System.Windows.Forms.Button()
        Me.PorcentagemAulaLabel = New System.Windows.Forms.Label()
        Me.PrimarioGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DownloadPrimarioLabel = New System.Windows.Forms.Label()
        Me.PorcentagemPrimarioProgressBar = New System.Windows.Forms.ProgressBar()
        Me.IniciarPrimarioButton = New System.Windows.Forms.Button()
        Me.SyncCheckBox = New System.Windows.Forms.CheckBox()
        Me.IndexCheckBox = New System.Windows.Forms.CheckBox()
        Me.XmlCheckBox = New System.Windows.Forms.CheckBox()
        Me.AlertaPrimarioLabel = New System.Windows.Forms.Label()
        Me.PorcentagemAulaProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PeriodoAulaTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NomeAulaTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CodigoAulaTextBox = New System.Windows.Forms.TextBox()
        Me.ConcluidaAulaTextBox = New System.Windows.Forms.TextBox()
        Me.ArquivosAulaTextBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DisciplinaAulaTextBox = New System.Windows.Forms.TextBox()
        Me.DownloadTabPage = New System.Windows.Forms.TabPage()
        Me.DownloadDataGridView = New System.Windows.Forms.DataGridView()
        Me.DetalheTabControl.SuspendLayout()
        Me.AulaTabPage.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SlidesGroupBox.SuspendLayout()
        Me.VideoAulaGroupBox.SuspendLayout()
        Me.PrimarioGroupBox.SuspendLayout()
        Me.DownloadTabPage.SuspendLayout()
        CType(Me.DownloadDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ItensTreeView
        '
        Me.ItensTreeView.HideSelection = False
        Me.ItensTreeView.Location = New System.Drawing.Point(12, 27)
        Me.ItensTreeView.Name = "ItensTreeView"
        Me.ItensTreeView.Size = New System.Drawing.Size(253, 538)
        Me.ItensTreeView.TabIndex = 0
        '
        'DetalheTabControl
        '
        Me.DetalheTabControl.Controls.Add(Me.AulaTabPage)
        Me.DetalheTabControl.Controls.Add(Me.DownloadTabPage)
        Me.DetalheTabControl.Location = New System.Drawing.Point(271, 27)
        Me.DetalheTabControl.Name = "DetalheTabControl"
        Me.DetalheTabControl.SelectedIndex = 0
        Me.DetalheTabControl.Size = New System.Drawing.Size(774, 538)
        Me.DetalheTabControl.TabIndex = 0
        '
        'AulaTabPage
        '
        Me.AulaTabPage.Controls.Add(Me.GroupBox2)
        Me.AulaTabPage.Location = New System.Drawing.Point(4, 22)
        Me.AulaTabPage.Name = "AulaTabPage"
        Me.AulaTabPage.Size = New System.Drawing.Size(766, 512)
        Me.AulaTabPage.TabIndex = 2
        Me.AulaTabPage.Text = "Aula"
        Me.AulaTabPage.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ExecutarButton)
        Me.GroupBox2.Controls.Add(Me.IniciarAulaButton)
        Me.GroupBox2.Controls.Add(Me.AbrirAulaButton)
        Me.GroupBox2.Controls.Add(Me.SlidesGroupBox)
        Me.GroupBox2.Controls.Add(Me.VideoAulaGroupBox)
        Me.GroupBox2.Controls.Add(Me.PorcentagemAulaLabel)
        Me.GroupBox2.Controls.Add(Me.PrimarioGroupBox)
        Me.GroupBox2.Controls.Add(Me.AlertaPrimarioLabel)
        Me.GroupBox2.Controls.Add(Me.PorcentagemAulaProgressBar)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.PeriodoAulaTextBox)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.NomeAulaTextBox)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.CodigoAulaTextBox)
        Me.GroupBox2.Controls.Add(Me.ConcluidaAulaTextBox)
        Me.GroupBox2.Controls.Add(Me.ArquivosAulaTextBox)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.DisciplinaAulaTextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(734, 462)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'ExecutarButton
        '
        Me.ExecutarButton.Enabled = False
        Me.ExecutarButton.Location = New System.Drawing.Point(532, 134)
        Me.ExecutarButton.Name = "ExecutarButton"
        Me.ExecutarButton.Size = New System.Drawing.Size(160, 23)
        Me.ExecutarButton.TabIndex = 28
        Me.ExecutarButton.Text = "Executar VideoAula"
        Me.ExecutarButton.UseVisualStyleBackColor = True
        '
        'IniciarAulaButton
        '
        Me.IniciarAulaButton.Location = New System.Drawing.Point(617, 78)
        Me.IniciarAulaButton.Name = "IniciarAulaButton"
        Me.IniciarAulaButton.Size = New System.Drawing.Size(75, 23)
        Me.IniciarAulaButton.TabIndex = 27
        Me.IniciarAulaButton.Text = "Iniciar"
        Me.IniciarAulaButton.UseVisualStyleBackColor = True
        '
        'AbrirAulaButton
        '
        Me.AbrirAulaButton.Location = New System.Drawing.Point(451, 134)
        Me.AbrirAulaButton.Name = "AbrirAulaButton"
        Me.AbrirAulaButton.Size = New System.Drawing.Size(75, 23)
        Me.AbrirAulaButton.TabIndex = 26
        Me.AbrirAulaButton.Text = "Abrir"
        Me.AbrirAulaButton.UseVisualStyleBackColor = True
        '
        'SlidesGroupBox
        '
        Me.SlidesGroupBox.Controls.Add(Me.DownloadConcluidoLabel)
        Me.SlidesGroupBox.Controls.Add(Me.Label4)
        Me.SlidesGroupBox.Controls.Add(Me.PorcentagemSlideSimplesLabel)
        Me.SlidesGroupBox.Controls.Add(Me.PorcentagemSlideSimplesProgressBar)
        Me.SlidesGroupBox.Controls.Add(Me.DownloadSlideLabel)
        Me.SlidesGroupBox.Controls.Add(Me.Label25)
        Me.SlidesGroupBox.Controls.Add(Me.SlideLabel)
        Me.SlidesGroupBox.Controls.Add(Me.Label23)
        Me.SlidesGroupBox.Controls.Add(Me.PorcentagemSlideLabel)
        Me.SlidesGroupBox.Controls.Add(Me.PorcentagemSlideProgressBar)
        Me.SlidesGroupBox.Controls.Add(Me.IniciarSlideButton)
        Me.SlidesGroupBox.Location = New System.Drawing.Point(24, 343)
        Me.SlidesGroupBox.Name = "SlidesGroupBox"
        Me.SlidesGroupBox.Size = New System.Drawing.Size(674, 113)
        Me.SlidesGroupBox.TabIndex = 23
        Me.SlidesGroupBox.TabStop = False
        Me.SlidesGroupBox.Text = "Slides"
        '
        'DownloadConcluidoLabel
        '
        Me.DownloadConcluidoLabel.AutoSize = True
        Me.DownloadConcluidoLabel.Location = New System.Drawing.Point(455, 26)
        Me.DownloadConcluidoLabel.Name = "DownloadConcluidoLabel"
        Me.DownloadConcluidoLabel.Size = New System.Drawing.Size(30, 13)
        Me.DownloadConcluidoLabel.TabIndex = 25
        Me.DownloadConcluidoLabel.Text = "0/00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(343, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Slides Concluídos:"
        '
        'PorcentagemSlideSimplesLabel
        '
        Me.PorcentagemSlideSimplesLabel.AutoSize = True
        Me.PorcentagemSlideSimplesLabel.Location = New System.Drawing.Point(8, 60)
        Me.PorcentagemSlideSimplesLabel.Name = "PorcentagemSlideSimplesLabel"
        Me.PorcentagemSlideSimplesLabel.Size = New System.Drawing.Size(33, 13)
        Me.PorcentagemSlideSimplesLabel.TabIndex = 23
        Me.PorcentagemSlideSimplesLabel.Text = "100%"
        '
        'PorcentagemSlideSimplesProgressBar
        '
        Me.PorcentagemSlideSimplesProgressBar.Location = New System.Drawing.Point(60, 55)
        Me.PorcentagemSlideSimplesProgressBar.Name = "PorcentagemSlideSimplesProgressBar"
        Me.PorcentagemSlideSimplesProgressBar.Size = New System.Drawing.Size(286, 23)
        Me.PorcentagemSlideSimplesProgressBar.TabIndex = 22
        '
        'DownloadSlideLabel
        '
        Me.DownloadSlideLabel.AutoSize = True
        Me.DownloadSlideLabel.Location = New System.Drawing.Point(238, 26)
        Me.DownloadSlideLabel.Name = "DownloadSlideLabel"
        Me.DownloadSlideLabel.Size = New System.Drawing.Size(72, 13)
        Me.DownloadSlideLabel.TabIndex = 21
        Me.DownloadSlideLabel.Text = "0000/000000"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(181, 26)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 13)
        Me.Label25.TabIndex = 20
        Me.Label25.Text = "Download:"
        '
        'SlideLabel
        '
        Me.SlideLabel.AutoSize = True
        Me.SlideLabel.Location = New System.Drawing.Point(57, 26)
        Me.SlideLabel.Name = "SlideLabel"
        Me.SlideLabel.Size = New System.Drawing.Size(93, 13)
        Me.SlideLabel.TabIndex = 19
        Me.SlideLabel.Text = "Xxxx_000-000.swf"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 13)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "Slide:"
        '
        'PorcentagemSlideLabel
        '
        Me.PorcentagemSlideLabel.AutoSize = True
        Me.PorcentagemSlideLabel.Location = New System.Drawing.Point(8, 89)
        Me.PorcentagemSlideLabel.Name = "PorcentagemSlideLabel"
        Me.PorcentagemSlideLabel.Size = New System.Drawing.Size(33, 13)
        Me.PorcentagemSlideLabel.TabIndex = 17
        Me.PorcentagemSlideLabel.Text = "100%"
        '
        'PorcentagemSlideProgressBar
        '
        Me.PorcentagemSlideProgressBar.Location = New System.Drawing.Point(60, 84)
        Me.PorcentagemSlideProgressBar.Name = "PorcentagemSlideProgressBar"
        Me.PorcentagemSlideProgressBar.Size = New System.Drawing.Size(425, 23)
        Me.PorcentagemSlideProgressBar.TabIndex = 16
        '
        'IniciarSlideButton
        '
        Me.IniciarSlideButton.Location = New System.Drawing.Point(593, 84)
        Me.IniciarSlideButton.Name = "IniciarSlideButton"
        Me.IniciarSlideButton.Size = New System.Drawing.Size(75, 23)
        Me.IniciarSlideButton.TabIndex = 14
        Me.IniciarSlideButton.Text = "Iniciar"
        Me.IniciarSlideButton.UseVisualStyleBackColor = True
        '
        'VideoAulaGroupBox
        '
        Me.VideoAulaGroupBox.Controls.Add(Me.DownloadVideoLabel)
        Me.VideoAulaGroupBox.Controls.Add(Me.Label21)
        Me.VideoAulaGroupBox.Controls.Add(Me.DuracaoLabel)
        Me.VideoAulaGroupBox.Controls.Add(Me.Label5)
        Me.VideoAulaGroupBox.Controls.Add(Me.VideoAulaLabel)
        Me.VideoAulaGroupBox.Controls.Add(Me.Label3)
        Me.VideoAulaGroupBox.Controls.Add(Me.PorcentagemVideoLabel)
        Me.VideoAulaGroupBox.Controls.Add(Me.PorcentagemVideoProgressBar)
        Me.VideoAulaGroupBox.Controls.Add(Me.IniciarVideoAulaButton)
        Me.VideoAulaGroupBox.Location = New System.Drawing.Point(24, 253)
        Me.VideoAulaGroupBox.Name = "VideoAulaGroupBox"
        Me.VideoAulaGroupBox.Size = New System.Drawing.Size(674, 84)
        Me.VideoAulaGroupBox.TabIndex = 22
        Me.VideoAulaGroupBox.TabStop = False
        Me.VideoAulaGroupBox.Text = "Video Aula"
        '
        'DownloadVideoLabel
        '
        Me.DownloadVideoLabel.AutoSize = True
        Me.DownloadVideoLabel.Location = New System.Drawing.Point(413, 25)
        Me.DownloadVideoLabel.Name = "DownloadVideoLabel"
        Me.DownloadVideoLabel.Size = New System.Drawing.Size(72, 13)
        Me.DownloadVideoLabel.TabIndex = 19
        Me.DownloadVideoLabel.Text = "0000/000000"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(343, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 13)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Download:"
        '
        'DuracaoLabel
        '
        Me.DuracaoLabel.AutoSize = True
        Me.DuracaoLabel.Location = New System.Drawing.Point(238, 25)
        Me.DuracaoLabel.Name = "DuracaoLabel"
        Me.DuracaoLabel.Size = New System.Drawing.Size(49, 13)
        Me.DuracaoLabel.TabIndex = 17
        Me.DuracaoLabel.Text = "00:00:00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(181, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Duração:"
        '
        'VideoAulaLabel
        '
        Me.VideoAulaLabel.AutoSize = True
        Me.VideoAulaLabel.Location = New System.Drawing.Point(77, 25)
        Me.VideoAulaLabel.Name = "VideoAulaLabel"
        Me.VideoAulaLabel.Size = New System.Drawing.Size(67, 13)
        Me.VideoAulaLabel.TabIndex = 15
        Me.VideoAulaLabel.Text = "Xxxx_000.flv"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Vídeo Aula:"
        '
        'PorcentagemVideoLabel
        '
        Me.PorcentagemVideoLabel.AutoSize = True
        Me.PorcentagemVideoLabel.Location = New System.Drawing.Point(8, 56)
        Me.PorcentagemVideoLabel.Name = "PorcentagemVideoLabel"
        Me.PorcentagemVideoLabel.Size = New System.Drawing.Size(33, 13)
        Me.PorcentagemVideoLabel.TabIndex = 13
        Me.PorcentagemVideoLabel.Text = "100%"
        '
        'PorcentagemVideoProgressBar
        '
        Me.PorcentagemVideoProgressBar.Location = New System.Drawing.Point(60, 51)
        Me.PorcentagemVideoProgressBar.Name = "PorcentagemVideoProgressBar"
        Me.PorcentagemVideoProgressBar.Size = New System.Drawing.Size(425, 23)
        Me.PorcentagemVideoProgressBar.TabIndex = 12
        '
        'IniciarVideoAulaButton
        '
        Me.IniciarVideoAulaButton.Location = New System.Drawing.Point(593, 51)
        Me.IniciarVideoAulaButton.Name = "IniciarVideoAulaButton"
        Me.IniciarVideoAulaButton.Size = New System.Drawing.Size(75, 23)
        Me.IniciarVideoAulaButton.TabIndex = 10
        Me.IniciarVideoAulaButton.Text = "Iniciar"
        Me.IniciarVideoAulaButton.UseVisualStyleBackColor = True
        '
        'PorcentagemAulaLabel
        '
        Me.PorcentagemAulaLabel.AutoSize = True
        Me.PorcentagemAulaLabel.Location = New System.Drawing.Point(21, 139)
        Me.PorcentagemAulaLabel.Name = "PorcentagemAulaLabel"
        Me.PorcentagemAulaLabel.Size = New System.Drawing.Size(33, 13)
        Me.PorcentagemAulaLabel.TabIndex = 25
        Me.PorcentagemAulaLabel.Text = "100%"
        '
        'PrimarioGroupBox
        '
        Me.PrimarioGroupBox.Controls.Add(Me.Label1)
        Me.PrimarioGroupBox.Controls.Add(Me.DownloadPrimarioLabel)
        Me.PrimarioGroupBox.Controls.Add(Me.PorcentagemPrimarioProgressBar)
        Me.PrimarioGroupBox.Controls.Add(Me.IniciarPrimarioButton)
        Me.PrimarioGroupBox.Controls.Add(Me.SyncCheckBox)
        Me.PrimarioGroupBox.Controls.Add(Me.IndexCheckBox)
        Me.PrimarioGroupBox.Controls.Add(Me.XmlCheckBox)
        Me.PrimarioGroupBox.Location = New System.Drawing.Point(24, 203)
        Me.PrimarioGroupBox.Name = "PrimarioGroupBox"
        Me.PrimarioGroupBox.Size = New System.Drawing.Size(674, 44)
        Me.PrimarioGroupBox.TabIndex = 21
        Me.PrimarioGroupBox.TabStop = False
        Me.PrimarioGroupBox.Text = "Arquivos Primários"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(240, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Download:"
        '
        'DownloadPrimarioLabel
        '
        Me.DownloadPrimarioLabel.AutoSize = True
        Me.DownloadPrimarioLabel.Location = New System.Drawing.Point(304, 20)
        Me.DownloadPrimarioLabel.Name = "DownloadPrimarioLabel"
        Me.DownloadPrimarioLabel.Size = New System.Drawing.Size(24, 13)
        Me.DownloadPrimarioLabel.TabIndex = 25
        Me.DownloadPrimarioLabel.Text = "0/3"
        '
        'PorcentagemPrimarioProgressBar
        '
        Me.PorcentagemPrimarioProgressBar.Location = New System.Drawing.Point(346, 13)
        Me.PorcentagemPrimarioProgressBar.Name = "PorcentagemPrimarioProgressBar"
        Me.PorcentagemPrimarioProgressBar.Size = New System.Drawing.Size(219, 23)
        Me.PorcentagemPrimarioProgressBar.TabIndex = 24
        '
        'IniciarPrimarioButton
        '
        Me.IniciarPrimarioButton.Location = New System.Drawing.Point(593, 13)
        Me.IniciarPrimarioButton.Name = "IniciarPrimarioButton"
        Me.IniciarPrimarioButton.Size = New System.Drawing.Size(75, 23)
        Me.IniciarPrimarioButton.TabIndex = 23
        Me.IniciarPrimarioButton.Text = "Iniciar"
        Me.IniciarPrimarioButton.UseVisualStyleBackColor = True
        '
        'SyncCheckBox
        '
        Me.SyncCheckBox.AutoSize = True
        Me.SyncCheckBox.Location = New System.Drawing.Point(169, 19)
        Me.SyncCheckBox.Name = "SyncCheckBox"
        Me.SyncCheckBox.Size = New System.Drawing.Size(50, 17)
        Me.SyncCheckBox.TabIndex = 22
        Me.SyncCheckBox.Text = "Sync"
        Me.SyncCheckBox.UseVisualStyleBackColor = True
        '
        'IndexCheckBox
        '
        Me.IndexCheckBox.AutoSize = True
        Me.IndexCheckBox.Location = New System.Drawing.Point(92, 19)
        Me.IndexCheckBox.Name = "IndexCheckBox"
        Me.IndexCheckBox.Size = New System.Drawing.Size(52, 17)
        Me.IndexCheckBox.TabIndex = 21
        Me.IndexCheckBox.Text = "Index"
        Me.IndexCheckBox.UseVisualStyleBackColor = True
        '
        'XmlCheckBox
        '
        Me.XmlCheckBox.AutoSize = True
        Me.XmlCheckBox.Location = New System.Drawing.Point(11, 19)
        Me.XmlCheckBox.Name = "XmlCheckBox"
        Me.XmlCheckBox.Size = New System.Drawing.Size(43, 17)
        Me.XmlCheckBox.TabIndex = 20
        Me.XmlCheckBox.Text = "Xml"
        Me.XmlCheckBox.UseVisualStyleBackColor = True
        '
        'AlertaPrimarioLabel
        '
        Me.AlertaPrimarioLabel.AutoSize = True
        Me.AlertaPrimarioLabel.ForeColor = System.Drawing.Color.Red
        Me.AlertaPrimarioLabel.Location = New System.Drawing.Point(21, 170)
        Me.AlertaPrimarioLabel.Name = "AlertaPrimarioLabel"
        Me.AlertaPrimarioLabel.Size = New System.Drawing.Size(490, 13)
        Me.AlertaPrimarioLabel.TabIndex = 20
        Me.AlertaPrimarioLabel.Text = "****   A Vídeo Aula e os Slides só podem ter inicio quando os arquivos Primários " & _
            "forem finalizados.   ****"
        Me.AlertaPrimarioLabel.Visible = False
        '
        'PorcentagemAulaProgressBar
        '
        Me.PorcentagemAulaProgressBar.Location = New System.Drawing.Point(70, 134)
        Me.PorcentagemAulaProgressBar.Name = "PorcentagemAulaProgressBar"
        Me.PorcentagemAulaProgressBar.Size = New System.Drawing.Size(365, 23)
        Me.PorcentagemAulaProgressBar.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(448, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Periodo:"
        '
        'PeriodoAulaTextBox
        '
        Me.PeriodoAulaTextBox.Location = New System.Drawing.Point(500, 19)
        Me.PeriodoAulaTextBox.Name = "PeriodoAulaTextBox"
        Me.PeriodoAulaTextBox.Size = New System.Drawing.Size(198, 20)
        Me.PeriodoAulaTextBox.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Nome:"
        '
        'NomeAulaTextBox
        '
        Me.NomeAulaTextBox.Location = New System.Drawing.Point(70, 54)
        Me.NomeAulaTextBox.Name = "NomeAulaTextBox"
        Me.NomeAulaTextBox.Size = New System.Drawing.Size(365, 20)
        Me.NomeAulaTextBox.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Código:"
        '
        'CodigoAulaTextBox
        '
        Me.CodigoAulaTextBox.Location = New System.Drawing.Point(70, 21)
        Me.CodigoAulaTextBox.Name = "CodigoAulaTextBox"
        Me.CodigoAulaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodigoAulaTextBox.TabIndex = 11
        '
        'ConcluidaAulaTextBox
        '
        Me.ConcluidaAulaTextBox.Location = New System.Drawing.Point(318, 85)
        Me.ConcluidaAulaTextBox.Name = "ConcluidaAulaTextBox"
        Me.ConcluidaAulaTextBox.Size = New System.Drawing.Size(117, 20)
        Me.ConcluidaAulaTextBox.TabIndex = 6
        '
        'ArquivosAulaTextBox
        '
        Me.ArquivosAulaTextBox.Location = New System.Drawing.Point(70, 88)
        Me.ArquivosAulaTextBox.Name = "ArquivosAulaTextBox"
        Me.ArquivosAulaTextBox.Size = New System.Drawing.Size(116, 20)
        Me.ArquivosAulaTextBox.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(248, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Concluídas:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Arquivos:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(176, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Disciplina:"
        '
        'DisciplinaAulaTextBox
        '
        Me.DisciplinaAulaTextBox.Location = New System.Drawing.Point(237, 21)
        Me.DisciplinaAulaTextBox.Name = "DisciplinaAulaTextBox"
        Me.DisciplinaAulaTextBox.Size = New System.Drawing.Size(198, 20)
        Me.DisciplinaAulaTextBox.TabIndex = 0
        '
        'DownloadTabPage
        '
        Me.DownloadTabPage.Controls.Add(Me.DownloadDataGridView)
        Me.DownloadTabPage.Location = New System.Drawing.Point(4, 22)
        Me.DownloadTabPage.Name = "DownloadTabPage"
        Me.DownloadTabPage.Size = New System.Drawing.Size(766, 512)
        Me.DownloadTabPage.TabIndex = 3
        Me.DownloadTabPage.Text = "Downloads"
        Me.DownloadTabPage.UseVisualStyleBackColor = True
        '
        'DownloadDataGridView
        '
        Me.DownloadDataGridView.AllowUserToAddRows = False
        Me.DownloadDataGridView.AllowUserToDeleteRows = False
        Me.DownloadDataGridView.AllowUserToResizeRows = False
        Me.DownloadDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DownloadDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DownloadDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.DownloadDataGridView.MultiSelect = False
        Me.DownloadDataGridView.Name = "DownloadDataGridView"
        Me.DownloadDataGridView.ReadOnly = True
        Me.DownloadDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DownloadDataGridView.Size = New System.Drawing.Size(760, 506)
        Me.DownloadDataGridView.TabIndex = 0
        '
        'DownloadForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 590)
        Me.Controls.Add(Me.DetalheTabControl)
        Me.Controls.Add(Me.ItensTreeView)
        Me.Name = "DownloadForm"
        Me.Text = "DownloadForm"
        Me.DetalheTabControl.ResumeLayout(False)
        Me.AulaTabPage.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.SlidesGroupBox.ResumeLayout(False)
        Me.SlidesGroupBox.PerformLayout()
        Me.VideoAulaGroupBox.ResumeLayout(False)
        Me.VideoAulaGroupBox.PerformLayout()
        Me.PrimarioGroupBox.ResumeLayout(False)
        Me.PrimarioGroupBox.PerformLayout()
        Me.DownloadTabPage.ResumeLayout(False)
        CType(Me.DownloadDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ItensTreeView As System.Windows.Forms.TreeView
    Friend WithEvents DetalheTabControl As System.Windows.Forms.TabControl
    Friend WithEvents AulaTabPage As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AlertaPrimarioLabel As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PeriodoAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NomeAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CodigoAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ConcluidaAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ArquivosAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DisciplinaAulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PrimarioGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SyncCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents IndexCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents XmlCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SlidesGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents VideoAulaGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents PorcentagemVideoLabel As System.Windows.Forms.Label
    Friend WithEvents PorcentagemVideoProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents IniciarVideoAulaButton As System.Windows.Forms.Button
    Friend WithEvents IniciarPrimarioButton As System.Windows.Forms.Button
    Friend WithEvents PorcentagemSlideSimplesLabel As System.Windows.Forms.Label
    Friend WithEvents PorcentagemSlideSimplesProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents DownloadSlideLabel As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents SlideLabel As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents PorcentagemSlideLabel As System.Windows.Forms.Label
    Friend WithEvents PorcentagemSlideProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents IniciarSlideButton As System.Windows.Forms.Button
    Friend WithEvents DownloadVideoLabel As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents DuracaoLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents VideoAulaLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AbrirAulaButton As System.Windows.Forms.Button
    Friend WithEvents PorcentagemAulaLabel As System.Windows.Forms.Label
    Friend WithEvents PorcentagemAulaProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ExecutarButton As System.Windows.Forms.Button
    Friend WithEvents IniciarAulaButton As System.Windows.Forms.Button
    Friend WithEvents DownloadPrimarioLabel As System.Windows.Forms.Label
    Friend WithEvents PorcentagemPrimarioProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DownloadConcluidoLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DownloadTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DownloadDataGridView As System.Windows.Forms.DataGridView
End Class
