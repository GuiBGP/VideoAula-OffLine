Imports QuartzTypeLib
Public Class FormSincronia

#Region "Atributos"

    Private VideoAula As GerenciadorArquivos.VideoAula
    Private _listaDeSlides As List(Of String)

    Private _ultimaPosicaoMenu As Double
    Private _slideSelecionado As Integer

#End Region

#Region "Construtores"

    Sub New()
        Me.New(New GerenciadorArquivos.VideoAula("ead05001\Aula_001"))
    End Sub

    Sub New(ByVal aula As GerenciadorArquivos.VideoAula, Optional ByVal MdiParent As Form = Nothing)
        InitializeComponent()
        If MdiParent IsNot Nothing Then
            Me.MdiParent = MdiParent
        End If

        VideoAula = aula

        _listaDeSlides = VideoAula.Slides.Sincronia.Values.ToList
        SlideLabel.Text = String.Format("/{0:D3}", _listaDeSlides.Count)

        DisciplinaLabel.Text = VideoAula.Materia
        AulaLabel.Text = VideoAula.Nome & ":"
        TituloLabel.Text = VideoAula.Titulo
        ProfessorLabel.Text = VideoAula.Professor

        Apoio.CarregaMenu(VideoAula, AulaTreeView)
        AulaTreeView.HideSelection = True


        'ExecutarVideoAula()
        'AtualizarSlide()

    End Sub

#End Region

#Region "Eventos"

    Private Sub FormSincronia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub FormSincronia_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If filtroGrafico Is Nothing Then
            ExecutarVideoAula()
            AtualizarSlide()
        End If
    End Sub

    Private Sub AulaTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AulaTimer.Tick
        SetStatus()
    End Sub

#Region "Estado de Vídeo, Play|Pause|Stop"

    Private Sub PlayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayButton.Click
        PlayVideo()
    End Sub

    Private Sub PauseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseButton.Click
        PauseVideo()
    End Sub

    Private Sub StopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopButton.Click
        StopVideo()
    End Sub

#End Region

#Region "Posicionamento de Vídeo"

    Private Sub AulaTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AulaTrackBar.Scroll
        Dim posicaoAtual As Double = posicaoDeMedia.CurrentPosition

        Dim porcentagemPercorrida As Double
        porcentagemPercorrida = (posicaoAtual * 100) / posicaoDeMedia.Duration

        Dim posicaoFutura As Double
        posicaoFutura = (AulaTrackBar.Value * posicaoDeMedia.Duration) / 100

        AlterarPosicaoVideo(posicaoFutura)
    End Sub

    Private Sub BackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackButton.Click
        AlterarPosicaoVideo(posicaoDeMedia.CurrentPosition - 10)
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        AlterarPosicaoVideo(posicaoDeMedia.CurrentPosition + 10)
    End Sub

    Private Sub AulaTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles AulaTreeView.AfterSelect
        AlterarPosicaoVideo(Double.Parse(e.Node.Name))
    End Sub

#End Region

#Region "Posicionamento de Slide"

    Private Sub BackSlideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackSlideButton.Click
        AtualizarSlide(_slideSelecionado - 1)
    End Sub

    Private Sub NextSlideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextSlideButton.Click
        AtualizarSlide(_slideSelecionado + 1)
    End Sub

    Private Sub SincronizarCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SincronizarCheckBox.CheckedChanged
        If SincronizarCheckBox.Checked Then
            BackSlideButton.Enabled = False
            NextSlideButton.Enabled = False
            SlideTextBox.Enabled = False
        Else
            BackSlideButton.Enabled = True
            NextSlideButton.Enabled = True
            SlideTextBox.Enabled = True
        End If
    End Sub

    Private Sub SlideTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SlideTextBox.KeyPress
        If Asc(e.KeyChar) = 13 Then
            AtualizarSlide(CInt(SlideTextBox.Text) - 1)
        ElseIf Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#End Region

#Region "Volume"

    Private Sub VolumeTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VolumeTrackBar.Scroll
        AtualizarAudio()
    End Sub

    Private Sub MudoCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MudoCheckBox.CheckedChanged
        If MudoCheckBox.Checked Then
            audioBasico.Volume = -10000
            VolumeTrackBar.Enabled = False
            PorcentagemVolumeLabel.Enabled = False
        Else
            VolumeTrackBar.Enabled = True
            PorcentagemVolumeLabel.Enabled = True
            AtualizarAudio()
        End If
    End Sub

#End Region

#End Region

#Region "Vídeo Aula"

#Region "Constantes"
    Private Const WM_APP As Integer = 32768
    Private Const WM_GRAPHNOTIFY As Integer = WM_APP + 1
    Private Const EC_COMPLETE As Integer = 1
    Private Const WS_CHILD As Integer = 1073741824
    Private Const WS_CLIPCHILDREN As Integer = 33554432
#End Region

#Region "Atributos"
    Private _estadoAtual As MediaStatus = MediaStatus.None
    Private _lockObject As New Object()

    Private filtroGrafico As FilgraphManager = Nothing
    Private audioBasico As IBasicAudio = Nothing
    Private janelaDeVideo As IVideoWindow = Nothing
    Private eventoDeMedia As IMediaEvent = Nothing
    Private eventoDeMediaEx As IMediaEventEx = Nothing
    Private posicaoDeMedia As IMediaPosition = Nothing
    Private controleDeMedia As IMediaControl = Nothing
#End Region

#Region "Enumeradores"
    Enum MediaStatus
        None
        Stopped
        Paused
        Running
    End Enum
#End Region

#Region "Delegates"
    Private Delegate Sub SetStatusStripCallback()
#End Region

#Region "Métodos"

    Private Sub PlayVideo()
        controleDeMedia.Run()
        AulaTimer.Start()
        _estadoAtual = MediaStatus.Running
    End Sub

    Private Sub PauseVideo()
        controleDeMedia.Pause()
        AulaTimer.Stop()
        _estadoAtual = MediaStatus.Paused
    End Sub

    Private Sub StopVideo()
        controleDeMedia.Stop()
        AulaTimer.Stop()
        _estadoAtual = MediaStatus.Stopped
        AlterarPosicaoVideo(0)
    End Sub

    Private Sub SetStatus()
        If AulaStatusStrip.InvokeRequired Then
            Dim p As New SetStatusStripCallback(AddressOf SetStatus)
            Me.Invoke(p)
        Else
            SyncLock _lockObject
                Dim posicao As Double = posicaoDeMedia.CurrentPosition
                Dim porcentagem As Integer = (posicao * 100 / posicaoDeMedia.Duration)

                AtualizarSlide()
                AlterarPosicaoMenu(posicao)
                UpdateStatusBar()
                PorcentagemLabel.Text = String.Format("{0:P}", porcentagem / 100)
                AulaTrackBar.Value = porcentagem
            End SyncLock
        End If
    End Sub

    Private Sub AlterarPosicaoVideo(ByVal posicao As Double)
        If posicao > posicaoDeMedia.Duration Then posicao = posicaoDeMedia.Duration
        If posicao < Decimal.Zero Then posicao = Decimal.Zero

        posicaoDeMedia.CurrentPosition = posicao
        AtualizarSlide()
        AlterarPosicaoMenu(posicao)
    End Sub

    Private Sub AlterarPosicaoMenu(ByVal posicao As Double)
        posicao = VideoAula.BuscaMelhorTempoMenu(posicao)
        If posicao <> _ultimaPosicaoMenu Then

            Dim noh As TreeNode

            noh = AulaTreeView.Nodes.Find(_ultimaPosicaoMenu.ToString, True).First
            noh.BackColor = Color.White
            noh.ForeColor = Color.Black
            noh = AulaTreeView.Nodes.Find(posicao.ToString, True).First
            noh.BackColor = Color.FromArgb(51, 153, 255)
            noh.ForeColor = Color.White

            _ultimaPosicaoMenu = posicao
        End If
    End Sub

    Private Sub AtualizarAudio()
        Dim percent As Decimal = -1 + (VolumeTrackBar.Value / VolumeTrackBar.Maximum)
        audioBasico.Volume = 5000 * percent
        PorcentagemVolumeLabel.Text = String.Format("{0:P}", 1 + percent)
    End Sub

    Public Sub AtualizarSlide()
        If SincronizarCheckBox.Checked Then
            ExecutarSlide(VideoAula.Slides.BuscaMelhorSlide(posicaoDeMedia.CurrentPosition))
            SlideTextBox.Text = _slideSelecionado + 1
        End If
    End Sub

    Private Sub AtualizarSlide(ByVal index As Integer)
        If index >= 0 And _listaDeSlides.Count >= index Then
            ExecutarSlide(_listaDeSlides(index))
        End If
        SlideTextBox.Text = _slideSelecionado + 1
    End Sub

    Public Sub ExecutarVideoAula()
        'CleanUp()

        filtroGrafico = New FilgraphManager()
        filtroGrafico.RenderFile(VideoAula.VideoPath)

        audioBasico = filtroGrafico

        Try
            janelaDeVideo = filtroGrafico

            janelaDeVideo.Owner = AulaPanel.Handle
            janelaDeVideo.WindowStyle = WS_CHILD Or WS_CLIPCHILDREN
            janelaDeVideo.SetWindowPosition( _
                AulaPanel.ClientRectangle.Left, _
                AulaPanel.ClientRectangle.Top, _
                AulaPanel.ClientRectangle.Width, _
                AulaPanel.ClientRectangle.Height)

        Catch ex As Exception
            janelaDeVideo = Nothing
        End Try

        eventoDeMedia = filtroGrafico
        eventoDeMediaEx = filtroGrafico

        eventoDeMediaEx.SetNotifyWindow(Me.Handle, WM_GRAPHNOTIFY, 0)

        posicaoDeMedia = filtroGrafico
        controleDeMedia = filtroGrafico

        audioBasico = filtroGrafico

        controleDeMedia.Run()

        _estadoAtual = MediaStatus.Running

        AulaTreeView.SelectedNode = AulaTreeView.Nodes(0)
        AulaTreeView.SelectedNode.BackColor = Color.FromArgb(51, 153, 255)
        AulaTreeView.SelectedNode.ForeColor = Color.White

        PorcentagemVolumeLabel.Text = "100,00%"
        VolumeTrackBar.Value = 100
        SincronizarCheckBox.Checked = True

        AulaTimer.Start()
    End Sub

    Private Sub ExecutarSlide(ByVal slide As String)
        Dim path As String = VideoAula.Slides.SlidePath(slide)
        If Not path.Equals(AulaAxShockwaveFlash.Movie) Then
            _slideSelecionado = _listaDeSlides.IndexOf(slide)
            AulaAxShockwaveFlash.LoadMovie(0, path)
            AulaAxShockwaveFlash.Menu = False
        End If
    End Sub

    Private Sub UpdateStatusBar()
        Select Case _estadoAtual
            Case MediaStatus.None
                EstadoToolStripStatusLabel.Text = "--------   "
            Case MediaStatus.Paused
                EstadoToolStripStatusLabel.Text = "Pausado    "
            Case MediaStatus.Running
                EstadoToolStripStatusLabel.Text = "Executando "
            Case MediaStatus.Stopped
                EstadoToolStripStatusLabel.Text = "Parado     "
        End Select

        If posicaoDeMedia IsNot Nothing Then
            If TotalToolStripStatusLabel.Text = "00:00:00" Then
                TotalToolStripStatusLabel.Text = posicaoParaTempo(posicaoDeMedia.Duration)
            End If
            AtualToolStripStatusLabel.Text = posicaoParaTempo(posicaoDeMedia.CurrentPosition)
        Else
            TotalToolStripStatusLabel.Text = "00:00:00"
            AtualToolStripStatusLabel.Text = "00:00:00"
        End If
    End Sub

    Private Function posicaoParaTempo(ByVal posicao As Double) As String
        Dim seg, hrs, min As Integer
        seg = posicao
        hrs = seg \ 3600
        min = (seg - (hrs * 3600)) \ 60
        seg = seg - (hrs * 3600 + min * 60)

        Return String.Format("{0:D2}:{1:D2}:{2:D2}", hrs, min, seg)
    End Function

#End Region

#End Region

    Private Sub FormSincronia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'TODO: verificar pq não funciona!!!!
        Select Case e.KeyCode
            Case Keys.Space
                If _estadoAtual = MediaStatus.Running Then
                    PauseVideo()
                ElseIf _estadoAtual = MediaStatus.Paused Or _estadoAtual = MediaStatus.Stopped Then
                    PlayVideo()
                End If
            Case Keys.P 'Play/Pause
            Case Keys.S 'Stop
                'TODO: Verificar a Utilização do Shift, para alterar funcionalidade, Back/Next Slide!
            Case Keys.B 'Back
            Case Keys.Next 'Next
                'TODO: Verificar se o Up,Down num fodem com o TreeView
            Case Keys.Up, Keys.VolumeUp 'VolumeUp
            Case Keys.Down, Keys.VolumeDown 'VolumeDown
            Case Keys.M, Keys.VolumeMute 'VolumeMute
        End Select
    End Sub

    Private Sub FormSincronia_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'AulaTimer.Stop()

        'filtroGrafico = Nothing
        'controleDeMedia = Nothing
        'AulaPanel.Dispose()
        'audioBasico = Nothing
        'janelaDeVideo = Nothing
        'eventoDeMedia = Nothing
        'eventoDeMediaEx = Nothing
        'posicaoDeMedia = Nothing
        ''controleDeMedia.Stop()
        'AulaAxShockwaveFlash.Dispose()
        'Me.Dispose()
    End Sub

    Private Sub CloseForm()
        If AulaStatusStrip.InvokeRequired Then
            Dim p As New SetStatusStripCallback(AddressOf SetStatus)
            Me.Invoke(p)
        Else
            SyncLock _lockObject
                'filtroGrafico.Stop()
                GC.SuppressFinalize(filtroGrafico)
                filtroGrafico = Nothing
                controleDeMedia = Nothing
                AulaPanel.Dispose()
                audioBasico = Nothing
                janelaDeVideo = Nothing
                eventoDeMedia = Nothing
                eventoDeMediaEx = Nothing
                posicaoDeMedia = Nothing
                'controleDeMedia.Stop()
                AulaAxShockwaveFlash.Dispose()
                Me.Dispose()
            End SyncLock
        End If
    End Sub

    Private Sub SobreButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SobreButton.Click
        AulaTimer.Stop()
        GC.SuppressFinalize(filtroGrafico)
        filtroGrafico = Nothing
        controleDeMedia = Nothing
        AulaPanel.Dispose()
        audioBasico = Nothing
        janelaDeVideo = Nothing
        eventoDeMedia = Nothing
        eventoDeMediaEx = Nothing
        posicaoDeMedia = Nothing
        'controleDeMedia.Stop()
        AulaAxShockwaveFlash.Dispose()
        'Me.Dispose()
    End Sub

End Class