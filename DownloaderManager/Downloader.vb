Imports System.IO
Imports System.Net

Public Class Downloader


#Region "Construtores"
    Public Sub New(ByVal urlDocumento As String, ByVal diretorio As String)
        DocumentoUrl = urlDocumento
        Path = diretorio
    End Sub
#End Region

#Region "Atributos"
    Private _documentoUrl As String = String.Empty
    Private _proxyUrl As String = String.Empty
    Private _path As String = String.Empty
    Private _pathArquivo As String = String.Empty
    Private _nomeArquivo As String = String.Empty
    Private _extensaoArquivo As String = String.Empty
    Private _concluido As Boolean = False
    Private _iniciado As Boolean = False
    Private _pausado As Boolean = False

    Private _totalBaixado As Int64

    Private request As HttpWebRequest
    Private response As HttpWebResponse

#End Region
    'TODO: Verificar a REAL Necessidade de Exception nas Propriedades Abaixo
#Region "Propriedades"

    Public Property DocumentoUrl() As String
        Get
            Return _documentoUrl
        End Get
        Set(ByVal value As String)
            If Not Iniciado Then
                _documentoUrl = value
            Else
                Throw New Exception("O DocumentoUrl não pode ser Alterado, pois o Download já foi Iniciado.")
            End If
        End Set
    End Property

    Public Property ProxyUrl() As String
        Get
            Return _proxyUrl
        End Get
        Set(ByVal value As String)
            If Not Iniciado Then
                _proxyUrl = value
            Else
                Throw New Exception("O Proxy não pode ser Alterado, pois o Download já foi Iniciado.")
            End If
        End Set
    End Property

    Public Property Path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            If Not Iniciado Then
                _path = value
            Else
                Throw New Exception("O Diretório de Destino não pode ser Alterado, pois o Download já foi Iniciado.")
            End If
        End Set
    End Property

    Public Property PathArquivo() As String
        Get
            Return _pathArquivo
        End Get
        Set(ByVal value As String)
            If Not Iniciado Then
                _pathArquivo = value
            Else
                Throw New Exception("O Endereço do Arquivo de Destino não pode ser Alterado, pois o Download já foi Iniciado.")
            End If
        End Set
    End Property

    Public Property NomeArquivo() As String
        Get
            If String.IsNullOrEmpty(_nomeArquivo) Then
                Return DocumentoUrl.Substring((DocumentoUrl.LastIndexOf("/") + 1), (DocumentoUrl.Length - DocumentoUrl.LastIndexOf("/") - 1))
            End If
            Return _nomeArquivo
        End Get
        Set(ByVal value As String)
            If Not Iniciado Then
                _nomeArquivo = value
            Else
                Throw New Exception("O nome do Arquivo não pode ser Alterado, pois o Download já foi Iniciado.")
            End If
        End Set
    End Property

    Public Property ExtensaoArquivo() As String
        Get
            If String.IsNullOrEmpty(_nomeArquivo) Then
                Return DocumentoUrl.Substring((DocumentoUrl.LastIndexOf(".") + 1), (DocumentoUrl.Length - DocumentoUrl.LastIndexOf(".") - 1)).ToLowerInvariant
            End If
            Return _nomeArquivo
        End Get
        Set(ByVal value As String)
            If Not Iniciado Then
                _extensaoArquivo = value
            Else
                Throw New Exception("O nome do Arquivo não pode ser Alterado, pois o Download já foi Iniciado.")
            End If
        End Set
    End Property

    Public ReadOnly Property Concluido() As Boolean
        Get
            Return _concluido
        End Get
    End Property

    Public ReadOnly Property Iniciado() As Boolean
        Get
            Return _iniciado
        End Get
    End Property

    Public ReadOnly Property Pausado() As Boolean
        Get
            Return _pausado
        End Get
    End Property

    Public ReadOnly Property TotalArquivo() As Int64
        Get
            Return response.ContentLength
        End Get
    End Property

    Public ReadOnly Property TotalBaixado() As Int64
        Get
            Return _totalBaixado
        End Get
    End Property

#End Region

#Region "Delegates"
    Public Delegate Sub _delDownloadIniciado(ByVal thread As Downloader)
    Public Delegate Sub _delProcessandoDados(ByVal thread As Downloader)
    Public Delegate Sub _delDownloadCompleto(ByVal thread As Downloader, ByVal sucesso As Boolean)
#End Region

#Region "Eventos"
    Public Event DownloadIniciado As _delDownloadIniciado
    Public Event DownloadProcessandoDados As _delProcessandoDados
    Public Event DownloadCompleto As _delDownloadCompleto
#End Region

#Region "Métodos"

    ''' <summary>
    ''' Inicia o download do arquivo anexado em um diretório especificado.
    ''' </summary>
    Public Sub StartDownload()
        If String.IsNullOrEmpty(DocumentoUrl) Then
            Throw New ArgumentException("Por Favor Informe a URL.")
        End If
        If String.IsNullOrEmpty(Path) Then
            Throw New ArgumentException("Por Favor Informe o Diretório.")
        End If

        If Not Directory.Exists(Path) Then
            Try
                Directory.CreateDirectory(Path)
            Catch ex As Exception
                Throw New ArgumentException("Não foi possível criar um novo diretório, " & Path)
            End Try
        End If

        PathArquivo = Path & "\" & NomeArquivo
        PathArquivo = PathArquivo.Replace("/", " ").Replace("%20", " ")

        _iniciado = True
        _pausado = False

        'Aciona o Evento para ser capturado pelas Camadas Acima!
        RaiseEvent DownloadIniciado(Me)

        _concluido = False

        Dim stream As Stream = Nothing
        Dim fstream As FileStream = Nothing
        Dim pontoDePartida As Int64

        Try

            'Defini Ponto de Partida para Download, se arquivo Já Existir, Continuaremos o Download
            If File.Exists(PathArquivo) Then
                pontoDePartida = Convert.ToInt64(New FileInfo(PathArquivo).Length)
            End If

            Dim proxy As IWebProxy = Nothing
            'Verifica a Existencia de Proxy, e Atribui valor caso Haja
            If ProxyUrl IsNot Nothing AndAlso Not String.IsNullOrEmpty(ProxyUrl) Then
                proxy = New WebProxy(ProxyUrl, True)
                proxy.Credentials = CredentialCache.DefaultCredentials
            End If

            'Faz requisição ao Servidor
            request = DirectCast(WebRequest.Create(DocumentoUrl), HttpWebRequest)

            ' Define Ponto de Partida para a Requisição
            request.AddRange(pontoDePartida)

            request.Credentials = CredentialCache.DefaultCredentials

            If proxy IsNot Nothing Then
                request.Proxy = proxy
            End If

            'Aguarda Resposta do Servidor
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            'Começa Download do Arquivo
            stream = response.GetResponseStream()

            ''Cria Arquivo
            'fstream = New FileStream(pathDestino, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read)

            If (pontoDePartida = 0) Then
                fstream = New FileStream(PathArquivo, FileMode.Create, FileAccess.Write, FileShare.Read)
            Else
                fstream = New FileStream(PathArquivo, FileMode.Append, FileAccess.Write, FileShare.Read)
            End If

            ReadFully(stream, fstream)

            'Finaliza
            fstream.Close()
            stream.Close()


            _concluido = True
            _iniciado = False

            'Aciona o Evento para ser capturado pelas Camadas Acima!
            RaiseEvent DownloadCompleto(Me, Concluido)
        Catch
            _concluido = False
        Finally
            If fstream IsNot Nothing Then
                fstream.Close()
            End If
            If stream IsNot Nothing Then
                stream.Close()
            End If
        End Try
    End Sub


    ''' <summary>
    ''' Lê dados de um fluxo até o fim é alcançado.
    ''' Os dados são retornados como um array de bytes. Um IOException é
    ''' lançada se qualquer uma das chamadas subjacentes IO falhar.
    ''' </summary>
    ''' <param name="stream">The stream to read data from</param>
    ''' <param name="fileStream">The initial buffer length</param>
    Public Sub ReadFully(ByVal stream As Stream, ByVal fileStream As FileStream)
        Dim tamanhoInicial As Integer = 32768

        'Define Tamanho de Buffer
        Dim buffer As Byte() = New Byte(tamanhoInicial - 1) {}
        Dim bytesSize As Integer = 0

        ' Loop through the buffer until the buffer is empty
        While (InlineAssignHelper(bytesSize, stream.Read(buffer, 0, buffer.Length))) > 0

            fileStream.Write(buffer, 0, bytesSize)
            _totalBaixado = fileStream.Length
            'Aciona o Evento para ser capturado pelas Camadas Acima!
            RaiseEvent DownloadProcessandoDados(Me)

            If Pausado Then
                Exit While
            End If
        End While

    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

#End Region

End Class
