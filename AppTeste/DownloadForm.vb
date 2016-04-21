Imports System.Threading
Imports GerenciadorArquivos
Imports System.IO

Public Class DownloadForm

#Region "Atributos"

    Private _idJanela As String
    Private _ultimaPosicaoMenu As TreeNode
    Private _downloads As New Dictionary(Of String, Download)
    Private _downloadAula As Download
    Private _lockObject As New Object()

#End Region

#Region "Delegates"

    Private Delegate Sub _atualizarDownloadCallback(ByVal download As GerenciadorArquivos.Download)
    Private Delegate Sub _atualizarDownloadCompletoCallback(ByVal download As GerenciadorArquivos.Download, ByVal sucesso As Boolean)

#End Region

    Private Sub DownloadForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Apoio.ImportaXmlParaTreeView(ItensTreeView, "Materias.xml")
        ItensTreeView.HideSelection = True
        ItensTreeView.CollapseAll()
        ItensTreeView.Nodes(0).Expand()
    End Sub

    Private Sub ItensTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles ItensTreeView.AfterSelect
        Select Case e.Node.Level
            Case 0 'Todos
                'MsgBox("Todos")
            Case 1 'Período
                'MsgBox("Período")
                'MontarPeriodo(e.Node)
            Case 2 'Disciplina
                'MsgBox("Disciplina")
                'MontarDisciplina(e.Node)
            Case 3 'Aula
                'MsgBox("Aula")
                MontarAula(e.Node.Parent.Name.ToLowerInvariant & "\" & e.Node.Text)
        End Select

    End Sub

    'Private Sub DetalheListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim no As TreeNode = DirectCast(DetalheListBox.SelectedItem, System.Windows.Forms.TreeNode)
    '    LimparDetalhe()

    '    If PeriodoDisciplinaTabPage.Text = "Período" Then
    '        CodigoDetalheTextBox.Text = no.Name
    '        NomeDetalheTextBox.Text = no.Text

    '        Dim completosCount As Integer = 0
    '        For Each noh As TreeNode In no.Nodes
    '            If GerenciadorArquivos.Gerenciador.Existe(noh.Parent.Name, noh.Text & ".xml") Then
    '                completosCount += If(New GerenciadorArquivos.VideoAula(noh.Parent.Name & "\" & noh.Text).Completo, 1, 0)
    '            End If
    '        Next
    '        ConcluidaDetalheTextBox.Text = completosCount
    '        PorcentagemDetalheLabel.Text = String.Format("{0:P}", completosCount / If(no.Nodes.Count > 0, no.Nodes.Count, 1))
    '        PorcentagemDetalheProgressBar.Maximum = no.Nodes.Count
    '        PorcentagemDetalheProgressBar.Value = completosCount

    '        TotalDetalheLabel.Text = "Aulas:"
    '        TotalDetalheTextBox.Text = no.Nodes.Count

    '    ElseIf PeriodoDisciplinaTabPage.Text = "Disciplina" Then
    '        CodigoDetalheTextBox.Text = no.Name
    '        NomeDetalheTextBox.Text = no.Text

    '        XmlFinalizadoCheckBox.Checked = GerenciadorArquivos.Gerenciador.Existe(no.Parent.Name, no.Text & ".xml")

    '        If XmlFinalizadoCheckBox.Checked Then
    '            Dim videoAula As New GerenciadorArquivos.VideoAula(no.Parent.Name & "\" & no.Text)
    '            Dim completosCount As Integer = 1 'XML
    '            completosCount += If((videoAula.MenuCompleto And videoAula.SincronizadorCompleto), 2, 0) 'Index + Sync
    '            completosCount += If(videoAula.Estado = GerenciadorArquivos.EstadoArquivos.Completo, 1, 0)
    '            completosCount += If(videoAula.Slides IsNot Nothing AndAlso videoAula.Slides.Baixados.Count > 0, videoAula.Slides.Baixados.Count, 0)

    '            '1 para Xml, 1 para Index, 1 para Sync, 1 para Flv, X para Slides
    '            '4 + X
    '            TotalDetalheTextBox.Text = 4 + If(videoAula.Slides IsNot Nothing, videoAula.Slides.Total, 0)
    '            ConcluidaDetalheTextBox.Text = completosCount
    '            PorcentagemDetalheLabel.Text = String.Format("{0:P}", (completosCount / (4 + If(videoAula.Slides IsNot Nothing, videoAula.Slides.Total, 0))))
    '            PorcentagemDetalheProgressBar.Maximum = 4 + If(videoAula.Slides IsNot Nothing, videoAula.Slides.Total, 0)
    '            PorcentagemDetalheProgressBar.Value = completosCount
    '        Else
    '            AlertaDetalheLabel.Visible = True
    '        End If

    '        TotalDetalheLabel.Text = "Arquivos:"
    '    End If
    'End Sub

    Private Sub GerarDownloadAula()
        If _downloads.ContainsKey(_idJanela) Then
            _downloadAula = _downloads(_idJanela)
        Else
            _downloadAula = New Download(New GerenciadorArquivos.VideoAula(_idJanela))

            With _downloadAula
                AddHandler .PrimarioIniciado, AddressOf DownloadPrimarioIniciado
                AddHandler .PrimarioAndamento, AddressOf DownloadPrimarioAndamento
                AddHandler .PrimarioParado, AddressOf DownloadPrimarioParado
                AddHandler .PrimarioCompleto, AddressOf DownloadPrimarioCompleto

                AddHandler .VideoIniciado, AddressOf DownloadVideoIniciado
                AddHandler .VideoAndamento, AddressOf DownloadVideoAndamento
                AddHandler .VideoParado, AddressOf DownloadVideoParado
                AddHandler .VideoCompleto, AddressOf DownloadVideoCompleto

                AddHandler .SlideIniciado, AddressOf DownloadSlideIniciado
                AddHandler .SlideAndamento, AddressOf DownloadSlideAndamento
                AddHandler .SlideParado, AddressOf DownloadSlideParado
                AddHandler .SlideCompleto, AddressOf DownloadSlideCompleto
            End With

            _downloads.Add(_idJanela, _downloadAula)
        End If
    End Sub

    Private Function IniciarDownload(ByVal button As Object) As Boolean
        Return (DirectCast(button, Button).Text = "Iniciar")
    End Function

    Private Function PausarDownload(ByVal button As Object) As Boolean
        Return (DirectCast(button, Button).Text = "Pausar")
    End Function

    Private Sub AlterarStatusIniciarAulaButton()

        If IniciarDownload(IniciarPrimarioButton) AndAlso IniciarDownload(IniciarVideoAulaButton) AndAlso IniciarDownload(IniciarSlideButton) Then
            IniciarAulaButton.Text = "Iniciar"
            IniciarAulaButton.Enabled = Not (Not PrimarioGroupBox.Enabled AndAlso Not VideoAulaGroupBox.Enabled AndAlso Not SlidesGroupBox.Enabled)
        End If

    End Sub


#Region "Limpa Form"

    'Private Sub LimparDetalhe()
    '    XmlFinalizadoCheckBox.Checked = False

    '    CodigoDetalheTextBox.Text = String.Empty
    '    NomeDetalheTextBox.Text = String.Empty

    '    TotalDetalheTextBox.Text = String.Empty
    '    ConcluidaDetalheTextBox.Text = String.Empty
    '    PorcentagemDetalheLabel.Text = "0%"
    '    PorcentagemDetalheProgressBar.Value = 0

    '    TotalDetalheLabel.Text = String.Empty
    '    AlertaDetalheLabel.Visible = False
    'End Sub

    'Private Sub LimparPeriodoDisciplina()
    '    PeriodoDisciplinaTabPage.Text = String.Empty

    '    PeriodoTextBox.Text = String.Empty
    '    CodigoTextBox.Text = String.Empty
    '    NomeTextBox.Text = String.Empty
    '    TotalLabel.Text = String.Empty
    '    TotalTextBox.Text = String.Empty
    '    ConcluidaTextBox.Text = String.Empty

    '    PorcentagemLabel.Text = "0%"
    '    PorcentagemProgressBar.Value = 0

    '    LimparDetalhe()
    'End Sub

    Private Sub LimparAula()

        IniciarAulaButton.Text = "Iniciar"
        IniciarPrimarioButton.Text = "Iniciar"
        IniciarVideoAulaButton.Text = "Iniciar"
        IniciarSlideButton.Text = "Iniciar"

        CodigoAulaTextBox.Text = String.Empty
        DisciplinaAulaTextBox.Text = String.Empty
        PeriodoAulaTextBox.Text = String.Empty
        NomeAulaTextBox.Text = String.Empty

        'ExecutarButton.Enabled = False
        IniciarAulaButton.Enabled = True

        XmlCheckBox.Checked = False
        XmlCheckBox.Enabled = True
        IndexCheckBox.Checked = False
        IndexCheckBox.Enabled = True
        SyncCheckBox.Checked = False
        SyncCheckBox.Enabled = True

        PorcentagemPrimarioProgressBar.Maximum = 3
        PorcentagemPrimarioProgressBar.Value = 0

        AlertaPrimarioLabel.Visible = False

        VideoAulaLabel.Text = String.Empty
        DuracaoLabel.Text = String.Empty

        DownloadVideoLabel.Text = String.Empty
        DownloadVideoLabel.ForeColor = Color.Black
        PorcentagemVideoLabel.Text = "0%"
        PorcentagemVideoLabel.ForeColor = Color.Black
        PorcentagemVideoProgressBar.Value = 0


        DownloadSlideLabel.Text = String.Empty
        DownloadConcluidoLabel.Text = String.Empty
        PorcentagemSlideLabel.Text = "0%"
        PorcentagemSlideProgressBar.Value = 0

        ArquivosAulaTextBox.Text = String.Empty
        ConcluidaAulaTextBox.Text = String.Empty
        PorcentagemAulaLabel.Text = "0%"
        PorcentagemAulaProgressBar.Value = 0

        SlideLabel.Text = String.Empty
        PorcentagemSlideSimplesLabel.Text = "0%"
        PorcentagemSlideSimplesProgressBar.Value = 0

        PrimarioGroupBox.Enabled = True
        VideoAulaGroupBox.Enabled = True
        SlidesGroupBox.Enabled = True
    End Sub

#End Region

#Region "Monta Form"

    'Private Sub MontarPeriodo(ByVal no As TreeNode)
    '    _idJanela = String.Format("{0}\{1}", no.Text, no.Name)

    '    LimparPeriodoDisciplina()
    '    DetalheTabControl.SelectTab(PeriodoDisciplinaTabPage)
    '    PeriodoDisciplinaTabPage.Text = "Período"

    '    PeriodoTextBox.Visible = False
    '    PeriodoLabel.Visible = False
    '    AbrirButton.Visible = False
    '    CodigoTextBox.Text = no.Text
    '    NomeTextBox.Text = no.Name
    '    TotalLabel.Text = "Disciplinas:"
    '    TotalTextBox.Text = no.Nodes.Count

    '    XmlFinalizadoCheckBox.Visible = False
    '    DetalheListBox.DataSource = no.Nodes
    '    DetalheListBox.DisplayMember = "Text"
    '    DetalheListBox.ValueMember = "Name"
    'End Sub

    'Private Sub MontarDisciplina(ByVal no As TreeNode)
    '    _idJanela = String.Format("{0}\{1}", no.Name, no.Text)

    '    LimparPeriodoDisciplina()
    '    DetalheTabControl.SelectTab(PeriodoDisciplinaTabPage)
    '    PeriodoDisciplinaTabPage.Text = "Disciplina"

    '    PeriodoLabel.Visible = True
    '    PeriodoTextBox.Visible = True
    '    AbrirButton.Visible = True
    '    PeriodoTextBox.Text = String.Format("{0} ({1})", no.Parent.Text, no.Parent.Name)
    '    CodigoTextBox.Text = no.Name
    '    NomeTextBox.Text = no.Text
    '    TotalLabel.Text = "        Aulas:"
    '    TotalTextBox.Text = no.Nodes.Count

    '    Dim completosCount As Integer = 0
    '    For Each noh As TreeNode In no.Nodes
    '        If GerenciadorArquivos.Gerenciador.Existe(noh.Parent.Name, noh.Text & ".xml") Then
    '            completosCount += If(New GerenciadorArquivos.VideoAula(noh.Parent.Name & "\" & noh.Text).Completo, 1, 0)
    '        End If
    '    Next
    '    ConcluidaTextBox.Text = completosCount
    '    PorcentagemLabel.Text = String.Format("{0:P}", completosCount / If(no.Nodes.Count > 0, no.Nodes.Count, 1))
    '    PorcentagemProgressBar.Maximum = no.Nodes.Count
    '    PorcentagemProgressBar.Value = completosCount

    '    XmlFinalizadoCheckBox.Visible = True

    '    DetalheListBox.DataSource = no.Nodes
    '    DetalheListBox.DisplayMember = "Text"
    '    DetalheListBox.ValueMember = "Name"
    'End Sub

    Public Sub MontarAula(ByVal idAula As String)
        MontarAula(New VideoAula(idAula))
    End Sub
    Public Sub MontarAula(ByVal aula As VideoAula)
        LimparAula()
        DetalheTabControl.SelectTab(AulaTabPage)

        If aula.ArquivoBaseCompleto Then
            Dim completosCount As Integer = 1 'XML
            Dim totalSlides As Integer = 0

            With aula
                _idJanela = String.Format("{0}\{1}", .Codigo, .Nome)

                CodigoAulaTextBox.Text = .Codigo
                DisciplinaAulaTextBox.Text = .Materia
                NomeAulaTextBox.Text = .Nome

                'ArquivosPrimariosGroupBox
                XmlCheckBox.Checked = True
                XmlCheckBox.Enabled = False
                PorcentagemPrimarioProgressBar.Value = 1

                IndexCheckBox.Checked = .MenuCompleto
                IndexCheckBox.Enabled = Not .MenuCompleto

                SyncCheckBox.Checked = .SincronizadorCompleto
                SyncCheckBox.Enabled = Not .SincronizadorCompleto


                If IndexCheckBox.Checked And SyncCheckBox.Checked Then
                    PrimarioGroupBox.Enabled = False
                    completosCount += 2 'Index + Sync
                    PorcentagemPrimarioProgressBar.Value += 2
                ElseIf IndexCheckBox.Checked Xor SyncCheckBox.Checked Then
                    PorcentagemPrimarioProgressBar.Value += 1
                End If

                If Not PrimarioGroupBox.Enabled Then

                    'VideoAulaGroupBox
                    VideoAulaLabel.Text = .Nome
                    DuracaoLabel.Text = .Duracao

                    DownloadVideoLabel.Text = String.Format("{0}/{1}", .TamanhoFisico, .Tamanho)
                    PorcentagemVideoLabel.Text = String.Format("{0:P}", (.TamanhoFisico / .Tamanho))
                    PorcentagemVideoProgressBar.Maximum = .Tamanho

                    If (.Estado = EstadoArquivos.Erro) Then
                        DownloadVideoLabel.Text &= " - ERRO"
                        PorcentagemVideoProgressBar.Value = .Tamanho

                        DownloadVideoLabel.ForeColor = Color.Red
                        PorcentagemVideoLabel.ForeColor = Color.Red
                    Else
                        PorcentagemVideoProgressBar.Value = .TamanhoFisico
                        DownloadVideoLabel.ForeColor = Color.Black
                        PorcentagemVideoLabel.ForeColor = Color.Black
                    End If

                    If .Estado = EstadoArquivos.Completo Then
                        VideoAulaGroupBox.Enabled = False
                        completosCount += 1 'VideoAula
                        ExecutarButton.Enabled = True
                        IniciarAulaButton.Enabled = False
                    End If

                    'SlidesGroupBox
                    totalSlides = .Slides.Total
                    DownloadConcluidoLabel.Text = String.Format("{0}/{1}", .Slides.Baixados.Count, totalSlides)
                    PorcentagemSlideLabel.Text = String.Format("{0:P}", (.Slides.Baixados.Count / totalSlides))
                    PorcentagemSlideProgressBar.Maximum = totalSlides
                    PorcentagemSlideProgressBar.Value = .Slides.Baixados.Count

                    If .Slides.Baixados.Count > 0 Then
                        SlidesGroupBox.Enabled = Not .Slides.Completo
                        completosCount += .Slides.Baixados.Count 'Slides
                    End If

                Else
                    VideoAulaGroupBox.Enabled = False
                    SlidesGroupBox.Enabled = False
                End If

                '1 para Xml, 1 para Index, 1 para Sync, 1 para Flv, X para Slides
                '4 + X
                ArquivosAulaTextBox.Text = 4 + totalSlides
                ConcluidaAulaTextBox.Text = completosCount
                PorcentagemAulaLabel.Text = String.Format("{0:P}", (completosCount / (4 + totalSlides)))
                PorcentagemAulaProgressBar.Maximum = 4 + totalSlides
                PorcentagemAulaProgressBar.Value = completosCount
            End With
        Else
            Dim codigo As String = aula.RelativePath.Substring(0, aula.RelativePath.IndexOf("\"))
            Dim nome As String = aula.RelativePath.Substring(aula.RelativePath.IndexOf("\") + 1)

            _idJanela = String.Format("{0}\{1}", codigo, nome)

            CodigoAulaTextBox.Text = codigo
            NomeAulaTextBox.Text = nome

            ArquivosAulaTextBox.Text = "3"
            PorcentagemAulaProgressBar.Maximum = 3
            ConcluidaAulaTextBox.Text = "0"
            AlertaPrimarioLabel.Visible = True
            VideoAulaGroupBox.Enabled = False
            SlidesGroupBox.Enabled = False
        End If

        DownloadPrimarioLabel.Text = PorcentagemPrimarioProgressBar.Value & "/" & PorcentagemPrimarioProgressBar.Maximum

    End Sub

    Private Sub IncrementarPorcentagemAula()
        PorcentagemAulaProgressBar.Value += 1
        ConcluidaAulaTextBox.Text = PorcentagemAulaProgressBar.Value
        PorcentagemAulaLabel.Text = String.Format("{0:P}", (PorcentagemAulaProgressBar.Value / PorcentagemAulaProgressBar.Maximum))
    End Sub

#End Region


    Private Sub AbrirAulaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirAulaButton.Click
        Process.Start("explorer.exe", GerenciadorArquivos.Gerenciador.PathPasta(CodigoAulaTextBox.Text, NomeAulaTextBox.Text))
    End Sub

    'Private Sub AbrirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Process.Start("explorer.exe", GerenciadorArquivos.Gerenciador.PathPasta(CodigoTextBox.Text))
    'End Sub

    'Private Sub DetalheButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim no As TreeNode = DirectCast(DetalheListBox.SelectedItem, System.Windows.Forms.TreeNode)
    '    If PeriodoDisciplinaTabPage.Text = "Período" Then
    '        MontarDisciplina(no)
    '    ElseIf PeriodoDisciplinaTabPage.Text = "Disciplina" Then
    '        MontarAula(New VideoAula(no.Parent.Name.ToLowerInvariant & "\" & no.Text))
    '    End If
    'End Sub

    Private Sub IniciarAulaButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IniciarAulaButton.Click
        If IniciarDownload(sender) Then
            GerarDownloadAula()
            _downloadAula.IniciarTodos()
            IniciarAulaButton.Text = "Pausar"
        ElseIf PausarDownload(sender) Then
            _downloadAula.PararTodos()
            IniciarAulaButton.Text = "Iniciar"
        End If
    End Sub

    Private Sub IniciarPausarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IniciarPrimarioButton.Click, IniciarVideoAulaButton.Click, IniciarSlideButton.Click
        Dim button As Button = DirectCast(sender, Button)
        If IniciarDownload(button) Then
            GerarDownloadAula()
            Select Case button.Name
                Case "IniciarPrimarioButton"
                    _downloadAula.IniciarPrimario()
                Case "IniciarVideoAulaButton"
                    _downloadAula.IniciarVideo()
                Case "IniciarSlideButton"
                    _downloadAula.IniciarSlide()
            End Select
        ElseIf PausarDownload(button) Then
            Select Case button.Name
                Case "IniciarPrimarioButton"
                    _downloadAula.PararPrimario()
                Case "IniciarVideoAulaButton"
                    _downloadAula.PararVideo()
                Case "IniciarSlideButton"
                    _downloadAula.PararSlide()
            End Select
        End If
    End Sub

    Private Sub ExecutarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecutarButton.Click
        Dim videoAula As VideoAula = If(_downloadAula IsNot Nothing, _downloadAula.VideoAula, New VideoAula(_idJanela))

        Dim ChildForm As FormSincronia = TryCast(Application.OpenForms("FormSincronia"), FormSincronia)
        If ChildForm Is Nothing Then
            ChildForm = New FormSincronia(videoAula, Me.MdiParent)
            'ChildForm.MdiParent = Me.MdiParent
            ChildForm.Text = "Vídeo Aula - " & videoAula.Materia & " - " & videoAula.Titulo
            ChildForm.Show()

        Else
            ChildForm.Focus()
        End If
        AddHandler ChildForm.FormClosed, AddressOf Morreu

    End Sub
    ' Private Delegate Sub Morreu(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
    Private Sub Morreu(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        TryCast(sender, FormSincronia).Dispose()
    End Sub

#Region "Eventos CallBacks Downloads"

#Region "Arquivo Primário"

    Public Sub DownloadPrimarioIniciado(ByVal download As GerenciadorArquivos.Download)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadPrimarioIniciado)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        IniciarPrimarioButton.Text = "Pausar"
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadPrimarioAndamento(ByVal download As GerenciadorArquivos.Download)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadPrimarioAndamento)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        With download.Primario
                            PorcentagemPrimarioProgressBar.Maximum = .TotalArquivo
                            PorcentagemPrimarioProgressBar.Value = .TotalBaixado
                        End With
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadPrimarioParado(ByVal download As GerenciadorArquivos.Download)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadPrimarioParado)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        IniciarPrimarioButton.Text = "Iniciar"
                        AlterarStatusIniciarAulaButton()
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadPrimarioCompleto(ByVal download As GerenciadorArquivos.Download, ByVal sucesso As Boolean)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCompletoCallback(AddressOf DownloadPrimarioCompleto)
            Me.Invoke(p, download, sucesso)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        If sucesso Then
                            Select Case download.Primario.ExtensaoArquivo
                                Case "xml"
                                    XmlCheckBox.Checked = True
                                    XmlCheckBox.Enabled = False
                                Case "index"
                                    IndexCheckBox.Checked = True
                                    IndexCheckBox.Enabled = False
                                Case "sync"
                                    SyncCheckBox.Checked = True
                                    SyncCheckBox.Enabled = False
                            End Select

                            Dim count As Integer = 0
                            If Not XmlCheckBox.Enabled Then count += 1
                            If Not IndexCheckBox.Enabled Then count += 1
                            If Not SyncCheckBox.Enabled Then count += 1

                            DownloadPrimarioLabel.Text = count & "/3"

                            IncrementarPorcentagemAula()

                            If count = 3 Then
                                IniciarPrimarioButton.Text = "Iniciar"
                                PrimarioGroupBox.Enabled = False
                                MontarAula(download.VideoAula)
                                'Downloads.Remove(download.VideoAula.RelativePath)
                            End If
                        Else
                            'ERROR
                        End If
                    End If
                End If
            End SyncLock
        End If
    End Sub

#End Region

#Region "Vídeo"

    Public Sub DownloadVideoIniciado(ByVal download As GerenciadorArquivos.Download)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadVideoIniciado)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        IniciarVideoAulaButton.Text = "Pausar"
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadVideoAndamento(ByVal download As GerenciadorArquivos.Download)
        If PorcentagemVideoProgressBar.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadVideoAndamento)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        If ((download.VideoAula.TamanhoFisico + download.Video.TotalArquivo) <> download.VideoAula.Tamanho) Then
                            If MessageBox.Show(String.Format("O tamanho  do Vídeo esta difente:{2}{0} no Arquivo de Configuração e {1} no Servidor.{2}Deseja atualizar a Configuração e Continuar?", download.VideoAula.Tamanho, download.Video.TotalArquivo, vbLf), "Vídeo com tamanho Diferente", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                                'MessageBox.Show("TODO: Atualizar Arquivo")
                                If download.VideoAula.AtualizarTamanhoVideo(download.Video.TotalArquivo) > 0 Then
                                    download.VideoAula.Atualizar()
                                    MessageBox.Show("Atualizado com Sucesso!")
                                Else
                                    MessageBox.Show("Ocorreu um erro ao tentar atualizar o Arquivo de Configuração.")
                                    _downloadAula.PararVideo()
                                End If
                                _downloadAula.IniciarVideo()
                            Else
                                File.Delete(download.VideoAula.ArquivoBasePath)
                                File.Delete(download.VideoAula.SincronizadorPath)
                                File.Delete(download.VideoAula.MenuPath)
                                _downloadAula.PararTodos()
                                MessageBox.Show("Por favor realizer novamente download do Arquivo Primário(.xml)")
                                _downloads.Remove(_idJanela)
                                MontarAula(download.VideoAula)
                            End If
                        End If
                        With download.VideoAula
                            PorcentagemVideoProgressBar.Maximum = .Tamanho
                            PorcentagemVideoProgressBar.Value = download.Video.TotalBaixado
                            DownloadVideoLabel.Text = PorcentagemVideoProgressBar.Value & "/" & PorcentagemVideoProgressBar.Maximum
                            PorcentagemVideoLabel.Text = String.Format("{0:P}", (PorcentagemVideoProgressBar.Value / PorcentagemVideoProgressBar.Maximum))
                        End With
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadVideoParado(ByVal download As GerenciadorArquivos.Download)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadVideoParado)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        IniciarVideoAulaButton.Text = "Iniciar"
                        AlterarStatusIniciarAulaButton()
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadVideoCompleto(ByVal download As GerenciadorArquivos.Download, ByVal sucesso As Boolean)
        If PorcentagemVideoProgressBar.InvokeRequired Then
            Dim p As New _atualizarDownloadCompletoCallback(AddressOf DownloadVideoCompleto)
            Me.Invoke(p, download, sucesso)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        If sucesso Then
                            IncrementarPorcentagemAula()
                            VideoAulaGroupBox.Enabled = False
                            IniciarVideoAulaButton.Text = "Iniciar"
                            ExecutarButton.Enabled = True
                            'Downloads.Remove(download.VideoAula.RelativePath)

                            'Os Download da video aula só é iniciado de os Arquivos primarios estiverem completos, então não é necessário verificar.
                            'Como esse é o "Completo" do Video, basta verificar os Slides.
                            If download.VideoAula.Slides.Completo Then
                                IniciarAulaButton.Enabled = False
                            End If
                        Else
                            'ERROR
                        End If
                    End If
                End If
            End SyncLock
        End If
    End Sub

#End Region

#Region "Slide"

    Public Sub DownloadSlideIniciado(ByVal download As GerenciadorArquivos.Download)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadSlideIniciado)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        SlideLabel.Text = download.Slide.NomeArquivo
                        IniciarSlideButton.Text = "Pausar"
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadSlideAndamento(ByVal download As GerenciadorArquivos.Download)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadSlideAndamento)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        With download.Slide
                            DownloadSlideLabel.Text = String.Format("{0}/{1}", .TotalBaixado, .TotalArquivo)
                            PorcentagemSlideSimplesProgressBar.Maximum = .TotalArquivo
                            PorcentagemSlideSimplesProgressBar.Value = .TotalBaixado
                            PorcentagemSlideSimplesLabel.Text = String.Format("{0:P}", (.TotalBaixado / .TotalArquivo))
                        End With
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadSlideParado(ByVal download As GerenciadorArquivos.Download)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCallback(AddressOf DownloadSlideParado)
            Me.Invoke(p, download)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        IniciarSlideButton.Text = "Iniciar"
                        AlterarStatusIniciarAulaButton()
                    End If
                End If
            End SyncLock
        End If
    End Sub

    Public Sub DownloadSlideCompleto(ByVal download As GerenciadorArquivos.Download, ByVal sucesso As Boolean)
        If DetalheTabControl.InvokeRequired Then
            Dim p As New _atualizarDownloadCompletoCallback(AddressOf DownloadSlideCompleto)
            Me.Invoke(p, download, sucesso)
        Else
            SyncLock _lockObject
                If DetalheTabControl.SelectedTab Is AulaTabPage Then
                    If _idJanela = download.VideoAula.RelativePath Then
                        If sucesso Then
                            PorcentagemSlideProgressBar.Maximum = download.VideoAula.Slides.Total
                            PorcentagemSlideProgressBar.Value = download.VideoAula.Slides.Baixados.Count

                            DownloadConcluidoLabel.Text = PorcentagemSlideProgressBar.Value & "/" & PorcentagemSlideProgressBar.Maximum
                            PorcentagemSlideLabel.Text = String.Format("{0:P}", (PorcentagemSlideProgressBar.Value / PorcentagemSlideProgressBar.Maximum))

                            IncrementarPorcentagemAula()


                            IniciarSlideButton.Text = "Iniciar"
                            SlidesGroupBox.Enabled = False
                            'Downloads.Remove(download.VideoAula.RelativePath)
                            'Os Download dos Slides só é iniciado de os Arquivos primarios estiverem completos, então não é necessário verificar.
                            'Como esse é o "Completo" do Slide, basta verificar a Video Aula.
                            If download.VideoAula.Estado = EstadoArquivos.Completo Then
                                IniciarAulaButton.Enabled = False
                            End If

                        Else
                            'ERROR
                        End If
                    End If
                End If
            End SyncLock
        End If

    End Sub

#End Region

#End Region

    Private Function ListaDownloads() As List(Of Object)
        Dim list As New List(Of Object)
        For Each down As Download In _downloads.Values
            list.Add(New With {.Codigo = String.Format("{0}\{1}", down.VideoAula.Codigo, down.VideoAula.Nome), .Nome = down.VideoAula.Titulo, .Periodo = "P", _
                               .Primario = -(down.VideoAula.ArquivoBaseCompleto) - (down.VideoAula.SincronizadorCompleto) - (down.VideoAula.MenuCompleto), _
                               .VideoAula = If(down.VideoAula.ArquivoBaseCompleto, String.Format("{0}/{1}", down.VideoAula.TamanhoFisico, down.VideoAula.Tamanho), ""), _
                               .Slides = If(down.VideoAula.SincronizadorCompleto, String.Format("{0}/{1}", down.VideoAula.Slides.Baixados.Count, down.VideoAula.Slides.Total), "")})
        Next
        Return list
    End Function

    Private Sub DetalheTabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalheTabControl.SelectedIndexChanged
        If DetalheTabControl.SelectedTab Is DownloadTabPage Then
            DownloadDataGridView.AutoGenerateColumns = True
            DownloadDataGridView.DataSource = ListaDownloads()
            For Each column As DataGridViewColumn In DownloadDataGridView.Columns
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End If
    End Sub

    Private Sub DownloadDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DownloadDataGridView.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            DetalheTabControl.SelectedTab = AulaTabPage
            MontarAula(DownloadDataGridView.Rows(e.RowIndex).Cells(0).Value)
        Else
            'DownloadDataGridView.Sort(DownloadDataGridView.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
        End If
    End Sub

End Class