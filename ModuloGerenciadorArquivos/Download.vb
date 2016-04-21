Imports DownloaderManager
Imports GerenciadorArquivos
Imports System.Threading
Imports System.IO

Public Class Download

#Region "Construtores"

    Sub New(ByVal aula As VideoAula)
        _videoAula = aula
    End Sub

#End Region

#Region "Atributos"

    Private _videoAula As VideoAula

    Private _downloaderPrimario As Downloader
    Private _downloaderVideo As Downloader
    Private _downloaderSlide As Downloader

    Private _threads As New Dictionary(Of Downloader, Thread)

    Private _isDownloadTotal As Boolean = False

#End Region

#Region "Propriedades"

    Public ReadOnly Property VideoAula() As VideoAula
        Get
            Return _videoAula
        End Get
    End Property

    Public ReadOnly Property Primario() As Downloader
        Get
            Return _downloaderPrimario
        End Get
    End Property

    Public ReadOnly Property Video() As Downloader
        Get
            Return _downloaderVideo
        End Get
    End Property

    Public ReadOnly Property Slide() As Downloader
        Get
            Return _downloaderSlide
        End Get
    End Property

    Public ReadOnly Property IsDownloadTotal() As Boolean
        Get
            Return _isDownloadTotal
        End Get
    End Property

#End Region

#Region "Delegates"

    Public Delegate Sub _delDownloadIniciado(ByVal download As Download)
    Public Delegate Sub _delDownloadAndamento(ByVal download As Download)
    Public Delegate Sub _delDownloadParado(ByVal download As Download)
    Public Delegate Sub _delDownloadCompleto(ByVal download As Download, ByVal sucesso As Boolean)

#End Region

#Region "Eventos"

    Public Event PrimarioIniciado As _delDownloadIniciado
    Public Event PrimarioAndamento As _delDownloadAndamento
    Public Event PrimarioParado As _delDownloadParado
    Public Event PrimarioCompleto As _delDownloadCompleto

    Public Event VideoIniciado As _delDownloadIniciado
    Public Event VideoAndamento As _delDownloadAndamento
    Public Event VideoParado As _delDownloadParado
    Public Event VideoCompleto As _delDownloadCompleto

    Public Event SlideIniciado As _delDownloadIniciado
    Public Event SlideAndamento As _delDownloadAndamento
    Public Event SlideParado As _delDownloadParado
    Public Event SlideCompleto As _delDownloadCompleto


    Public Sub DownloadIniciado(ByVal download As Downloader)
        Select Case download.ExtensaoArquivo
            Case "xml", "index", "sync"
                RaiseEvent PrimarioIniciado(Me)
            Case "flv"
                RaiseEvent VideoIniciado(Me)
            Case "swf"
                RaiseEvent SlideIniciado(Me)
        End Select
    End Sub

    Public Sub DownloadAndamento(ByVal download As Downloader)
        Select Case download.ExtensaoArquivo
            Case "xml", "index", "sync"
                RaiseEvent PrimarioAndamento(Me)
            Case "flv"
                RaiseEvent VideoAndamento(Me)
            Case "swf"
                RaiseEvent SlideAndamento(Me)
        End Select
    End Sub

    Public Sub DownloadParado(ByVal download As Downloader)
        Select Case download.ExtensaoArquivo
            Case "xml", "index", "sync"
                RaiseEvent PrimarioParado(Me)
            Case "flv"
                RaiseEvent VideoParado(Me)
            Case "swf"
                RaiseEvent SlideParado(Me)
        End Select
    End Sub

    Public Sub DownloadCompleto(ByVal download As Downloader, ByVal sucesso As Boolean)
        Select Case download.ExtensaoArquivo
            Case "xml", "index", "sync"
                VideoAula.Atualizar()
                RaiseEvent PrimarioCompleto(Me, sucesso)
                'PararPrimario()
                If Not (VideoAula.ArquivoBaseCompleto And VideoAula.MenuCompleto And VideoAula.SincronizadorCompleto) Then
                    IniciarPrimario()
                ElseIf IsDownloadTotal Then
                    IniciarVideo()
                    IniciarSlide()
                End If
            Case "flv"
                RaiseEvent VideoCompleto(Me, sucesso)
            Case "swf"
                VideoAula.Slides.Atualizar()
                RaiseEvent SlideCompleto(Me, sucesso)
                'PararSlide()
                If Not VideoAula.Slides.Completo Then
                    IniciarSlide()
                End If
        End Select
    End Sub

#End Region

#Region "Métodos"

#Region "Privados"

    Private Sub RealizarDownload(ByVal arquivo As String, ByRef dwnloader As Downloader)
        Dim url As String = String.Format("{0}/{1}/{2}", GerenciadorArquivos.Configuracao.Url, Me.VideoAula.RelativePath.Replace("\", "/"), arquivo)

        dwnloader = New DownloaderManager.Downloader(url, Me.VideoAula.FullPath)
        Dim tsDelegate As ThreadStart = New ThreadStart(AddressOf dwnloader.StartDownload)

        AddHandler dwnloader.DownloadIniciado, AddressOf DownloadIniciado
        AddHandler dwnloader.DownloadProcessandoDados, AddressOf DownloadAndamento
        AddHandler dwnloader.DownloadCompleto, AddressOf DownloadCompleto

        Dim t As Thread = New Thread(tsDelegate)
        _threads.Add(dwnloader, t)
        t.Start()
    End Sub

#End Region

#Region "Públicos"

    Public Sub IniciarTodos()
        If (VideoAula.ArquivoBaseCompleto And VideoAula.MenuCompleto And VideoAula.SincronizadorCompleto) Then
            IniciarVideo()
            IniciarSlide()
        Else
            _isDownloadTotal = True
            IniciarPrimario()
        End If
    End Sub

    Public Sub IniciarPrimario()
        'If _downloaderPrimario Is Nothing Then
        If Not VideoAula.ArquivoBaseCompleto Then
            RealizarDownload(VideoAula.ArquivoBase, _downloaderPrimario)
        ElseIf Not VideoAula.MenuCompleto Then
            RealizarDownload(VideoAula.Menu, _downloaderPrimario)
        ElseIf Not VideoAula.SincronizadorCompleto Then
            RealizarDownload(VideoAula.Sincronizador, _downloaderPrimario)
        End If
        'End If
    End Sub

    Public Sub IniciarVideo()
        'If _downloaderVideo Is Nothing Then
        If VideoAula.ArquivoBaseCompleto Then
            RealizarDownload(VideoAula.Video, _downloaderVideo)
        End If
        'End If
    End Sub

    Public Sub IniciarSlide()
        'If _downloaderSlide Is Nothing Then
        If VideoAula.ArquivoBaseCompleto AndAlso VideoAula.SincronizadorCompleto Then
            If Not VideoAula.Slides.Completo Then
                RealizarDownload(VideoAula.Slides.NaoBaixados.First, _downloaderSlide)
            End If
        End If
        'End If
    End Sub


    Public Sub PararTodos()
        PararPrimario()
        PararVideo()
        PararSlide()
    End Sub

    Public Sub PararPrimario()
        If _downloaderPrimario IsNot Nothing AndAlso _threads.ContainsKey(_downloaderPrimario) Then
            DownloadParado(_downloaderPrimario)
            _threads(_downloaderPrimario).Abort()
            _threads.Remove(_downloaderPrimario)
            _downloaderPrimario = Nothing
        End If
    End Sub

    Public Sub PararVideo()
        If _downloaderVideo IsNot Nothing AndAlso _threads.ContainsKey(_downloaderVideo) Then
            DownloadParado(_downloaderVideo)
            _threads(_downloaderVideo).Abort()
            _threads.Remove(_downloaderVideo)
            _downloaderVideo = Nothing
        End If
    End Sub

    Public Sub PararSlide()
        If _downloaderSlide IsNot Nothing AndAlso _threads.ContainsKey(_downloaderSlide) Then
            DownloadParado(_downloaderSlide)
            _threads(_downloaderSlide).Abort()
            _threads.Remove(_downloaderSlide)
            If _downloaderSlide.Iniciado Then
                Dim PathArquivo As String = _downloaderSlide.PathArquivo
                While File.Exists(PathArquivo)
                    Try
                        _downloaderSlide = Nothing
                        File.Delete(PathArquivo)
                    Catch
                        'TRATAR??
                    End Try
                End While
            Else
                _downloaderSlide = Nothing
            End If
        End If
    End Sub

    Public Sub SalvarLista()
        'TODO: Implementar a Persistencia da Lista de Downloads (Avaliar Serialização)
    End Sub

    Public Sub RecuperarLista()
        'TODO: Implementar a Recuperação da Lista de Downloads
    End Sub

#End Region

#End Region

End Class


