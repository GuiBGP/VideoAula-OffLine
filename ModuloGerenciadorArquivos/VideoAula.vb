Imports System.IO
Imports System.Xml
Imports System.Windows.Forms

Public Class VideoAula

#Region "Construtores"


    Sub New(ByVal path As String, Optional ByVal isAbsoltePath As Boolean = False)
        If Not isAbsoltePath Then
            _relativePath = path.Substring(0, path.IndexOf("\")).ToLowerInvariant & path.Substring(path.IndexOf("\"))
            _fullPath = String.Format("{0}\{1}", GerenciadorArquivos.Configuracao.Aula, RelativePath)
            _arquivoBase = FullPath.Substring(FullPath.LastIndexOf("\") + 1) & ".xml"
            path = _fullPath & "\" & _arquivoBase
        End If

        If path.ToUpperInvariant.LastIndexOf(".XML") = path.Length - (".XML").Length Then
            Dim ultimaBarra As Integer = path.LastIndexOf("\")
            _arquivoBase = path.Substring(ultimaBarra + 1, path.Length - ultimaBarra - 1)
            _fullPath = path.Substring(0, ultimaBarra)
            _relativePath = If(isAbsoltePath, _fullPath, _relativePath)
        End If

        Carregar()
    End Sub



    Private Sub Carregar()
        '_relativePath = pathRelativo.Substring(0, pathRelativo.IndexOf("\")).ToLowerInvariant & pathRelativo.Substring(pathRelativo.IndexOf("\"))
        '_fullPath = String.Format("{0}\{1}", GerenciadorArquivos.Configuracao.Aula, RelativePath)
        '_arquivoBase = FullPath.Substring(FullPath.LastIndexOf("\") + 1) & ".xml"


        If ArquivoBaseCompleto Then

            CarregarDados()

            If File.Exists(VideoPath) Then _tamanhoFisico = FileLen(VideoPath)

            If SincronizadorCompleto Then _slides = New Slides(SincronizadorPath)

            If MenuCompleto Then _temposMenu = RetornarTemposDeMenuSincronia()

        End If
    End Sub

#End Region

#Region "Atributos"

    Private _nome As String
    Private _tamanho As Long
    Private _titulo As String
    Private _tipo As String
    Private _professor As String
    Private _materia As String
    Private _codigo As String
    Private _curso As String
    Private _instituicao As String
    Private _bitRate As Integer
    Private _duracao As String
    Private _fullPath As String
    Private _relativePath As String

    Private _temposMenu As List(Of Double)

    Private _tamanhoFisico As Long
    Private _slides As Slides

    Private _arquivoBase As String
    Private _menu As String
    Private _sincronizador As String
    Private _video As String

#End Region

#Region "Propriedades"

    '<obj_filename>Aula_001.flv</obj_filename>
    Public ReadOnly Property Nome() As String
        Get
            Return _nome
        End Get
    End Property

    '<obj_filesize>38451206</obj_filesize>
    Public ReadOnly Property Tamanho() As Long
        Get
            Return _tamanho
        End Get
    End Property

    '<obj_title>Introdução ao computador</obj_title>
    Public ReadOnly Property Titulo() As String
        Get
            Return _titulo
        End Get
    End Property

    '<obj_type>FLV H264 VIDEO</obj_type>
    Public ReadOnly Property Tipo() As String
        Get
            Return _tipo
        End Get
    End Property

    '<professor>Alexandre Malheiros Meslin</professor>
    Public ReadOnly Property Professor() As String
        Get
            Return _professor
        End Get
    End Property

    '<course>Introdução à informática</course>
    Public ReadOnly Property Materia() As String
        Get
            Return _materia
        End Get
    End Property

    '<coursecode>ead05001</coursecode>
    Public ReadOnly Property Codigo() As String
        Get
            Return _codigo
        End Get
    End Property

    '<grad_program>Tecnologia em sistemas de computação</grad_program>
    Public ReadOnly Property Curso() As String
        Get
            Return _curso
        End Get
    End Property

    '<source>CEDERJ</source>
    Public ReadOnly Property Instituicao() As String
        Get
            Return _instituicao
        End Get
    End Property

    '<bitrate>100</bitrate>
    Public ReadOnly Property BitRate() As Integer
        Get
            Return _bitRate
        End Get
    End Property

    '<duration>00:50:04</duration>
    Public ReadOnly Property Duracao() As String
        Get
            Return _duracao
        End Get
    End Property

    Public ReadOnly Property Slides() As Slides
        Get
            Return _slides
        End Get
    End Property

    Public ReadOnly Property FullPath() As String
        Get
            Return _fullPath
        End Get
    End Property

    Public ReadOnly Property RelativePath() As String
        Get
            Return _relativePath
        End Get
    End Property

    Public ReadOnly Property TamanhoFisico() As Long
        Get
            Return _tamanhoFisico
        End Get
    End Property

    Public ReadOnly Property Estado() As EstadoArquivos
        Get
            If TamanhoFisico <> 0 Then
                If (Tamanho > TamanhoFisico) Then
                    Return EstadoArquivos.Incompleto

                ElseIf (Tamanho = TamanhoFisico) Then
                    Return EstadoArquivos.Completo

                ElseIf (Tamanho < TamanhoFisico) Then
                    Return EstadoArquivos.Erro
                End If
            Else
                Return EstadoArquivos.Inexistente
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Completo() As Boolean
        Get
            Return ((Estado = EstadoArquivos.Completo) And MenuCompleto And SincronizadorCompleto And If(Slides IsNot Nothing, Slides.Completo, False))
        End Get
    End Property

    Public ReadOnly Property ArquivoBase() As String
        Get
            Return _arquivoBase
        End Get
    End Property

    Public ReadOnly Property ArquivoBaseCompleto() As Boolean
        Get
            Return File.Exists(ArquivoBasePath)
        End Get
    End Property

    Public ReadOnly Property Menu() As String
        Get
            Return _menu
        End Get
    End Property

    Public ReadOnly Property MenuCompleto() As Boolean
        Get
            Return File.Exists(MenuPath)
        End Get
    End Property

    Public ReadOnly Property Sincronizador() As String
        Get
            Return _sincronizador
        End Get
    End Property

    Public ReadOnly Property SincronizadorCompleto() As Boolean
        Get
            Return File.Exists(SincronizadorPath)
        End Get
    End Property

    Public ReadOnly Property Video() As String
        Get
            Return _video
        End Get
    End Property

    Public ReadOnly Property VideoPath() As String
        Get
            Return String.Format("{0}\{1}", FullPath, Video)
        End Get
    End Property

    Public ReadOnly Property ArquivoBasePath() As String
        Get
            Return String.Format("{0}\{1}", FullPath, ArquivoBase)
        End Get
    End Property

    Public ReadOnly Property MenuPath() As String
        Get
            Return String.Format("{0}\{1}", FullPath, Menu)
        End Get
    End Property

    Public ReadOnly Property SincronizadorPath() As String
        Get
            Return String.Format("{0}\{1}", FullPath, Sincronizador)
        End Get
    End Property

#End Region

#Region "Métodos"

#Region "Privados"


    ''' <summary>
    ''' Carregada dados contido no arquivo .xml para a Instância de VideoAula.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CarregarDados()
        Dim xmlDoc As New XmlDocument
        xmlDoc.XmlResolver = Nothing
        xmlDoc.Load(ArquivoBasePath)

        With xmlDoc.SelectSingleNode("rio_object")

            _nome = .Item("obj_filename").InnerText
            _tamanho = .Item("obj_filesize").InnerText
            _titulo = .Item("obj_title").InnerText
            _tipo = .Item("obj_type").InnerText
            _professor = .Item("professor").InnerText
            _materia = .Item("course").InnerText
            _codigo = .Item("coursecode").InnerText
            _curso = .Item("grad_program").InnerText
            _instituicao = .Item("source").InnerText
            _bitRate = .Item("bitrate").InnerText
            _duracao = .Item("duration").InnerText
            _sincronizador = .SelectSingleNode("related_media/rm_item/rm_type[text()='sync']").ParentNode.SelectSingleNode("rm_filename").InnerText
            _menu = .SelectSingleNode("related_media/rm_item/rm_type[text()='index']").ParentNode.SelectSingleNode("rm_filename").InnerText
            _video = .SelectSingleNode("related_media/rm_item/rm_type[text()='video']").ParentNode.SelectSingleNode("rm_filename").InnerText

        End With

        If Nome.Contains(".") Then
            _nome = _nome.Substring(0, _nome.LastIndexOf("."))
        End If
    End Sub

    ''' <summary>
    ''' Retorna tempos para sincronia Menu x Slide
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RetornarTemposDeMenuSincronia() As List(Of Double)
        Dim xmlDoc As New XmlDocument
        xmlDoc.XmlResolver = Nothing
        xmlDoc.Load(MenuPath)
        Dim retorno As New List(Of Double)

        For Each noAtualXml As XmlNode In xmlDoc.GetElementsByTagName("time")
            retorno.Add(noAtualXml.InnerText.Replace(".", ",")) 'time
        Next
        Return retorno
    End Function

    Private Function BuscaBinariaRecursiva(ByVal menor As Integer, ByVal maior As Integer, ByVal chave As Decimal) As Double
        Dim meio As Integer
        If menor > maior Then
            BuscaBinariaRecursiva = _temposMenu.ElementAt(maior)
        Else
            meio = (menor + maior) \ 2
            If chave < _temposMenu.ElementAt(meio) Then
                BuscaBinariaRecursiva = BuscaBinariaRecursiva(menor, meio - 1, chave)
            ElseIf chave > _temposMenu.ElementAt(meio) Then
                BuscaBinariaRecursiva = BuscaBinariaRecursiva(meio + 1, maior, chave)
            Else
                BuscaBinariaRecursiva = _temposMenu.ElementAt(meio)
            End If
        End If
    End Function

#End Region

#Region "Públicos"

    ''' <summary>
    ''' Atualiza com dados dos novos arquivos de primários.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Atualizar()
        If ArquivoBaseCompleto Then
            CarregarDados()

            If File.Exists(VideoPath) Then _tamanhoFisico = FileLen(VideoPath)

            If SincronizadorCompleto Then _slides = New Slides(SincronizadorPath)

            If MenuCompleto Then _temposMenu = RetornarTemposDeMenuSincronia()

        End If
    End Sub

    Public Function AtualizarTamanhoVideo(ByVal novoTamanho As Long) As Decimal
        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.XmlResolver = Nothing
            xmlDoc.Load(ArquivoBasePath)
            xmlDoc.SelectSingleNode("rio_object/obj_filesize").InnerText = novoTamanho.ToString
            xmlDoc.Save(ArquivoBasePath)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Retorna melhor tempo para Menu, o tempo esta acossiado a um unico item de Menu.
    ''' </summary>
    ''' <param name="posicao"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BuscaMelhorTempoMenu(ByVal posicao As Double) As String
        If _temposMenu.Contains(posicao) Then Return posicao
        Return BuscaBinariaRecursiva(0, _temposMenu.Count - 1, posicao)
    End Function

#End Region

#End Region

End Class
