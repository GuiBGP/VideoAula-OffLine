Imports System.Xml
Imports System.IO

Public Class Slides

#Region "Construtores"

    Sub New(ByVal sincronizadorPath As String)
        If String.IsNullOrEmpty(sincronizadorPath) Then
            Throw New Exception("O Path não pode ser nulo")
        End If
        _fullPath = sincronizadorPath.Substring(0, sincronizadorPath.LastIndexOf("\"c))
        _sincronizadorPath = sincronizadorPath

        _sincronia = RetornarDadosDeSincronia()
        _sincroniaInversa = RetornarDadosDeSincroniaInversa()

        _total = _sincronia.Count
        _estado = VerificarEstadoDeSlides()

    End Sub

#End Region

#Region "Atributos"

    Private _sincronia As Dictionary(Of Decimal, String)
    Private _sincroniaInversa As Dictionary(Of String, Decimal)
    Private _estado As Dictionary(Of String, Boolean)
    Private _total As Integer
    Private _naoBaixados As New List(Of String)
    Private _baixados As New List(Of String)

    Private _fullPath As String
    Private _sincronizadorPath As String

#End Region

#Region "Propriedades"

    Public ReadOnly Property Sincronia() As Dictionary(Of Decimal, String)
        Get
            Return _sincronia
        End Get
    End Property

    Public ReadOnly Property SincroniaInversa() As Dictionary(Of String, Decimal)
        Get
            Return _sincroniaInversa
        End Get
    End Property

    Public ReadOnly Property Estado() As Dictionary(Of String, Boolean)
        Get
            Return _estado
        End Get
    End Property

    Public ReadOnly Property Total() As Integer
        Get
            Return _total
        End Get
    End Property

    Public ReadOnly Property Completo() As Boolean
        Get
            Return (NaoBaixados.Count = 0)
        End Get
    End Property

    Public ReadOnly Property NaoBaixados() As List(Of String)
        Get
            Return _naoBaixados
        End Get
    End Property

    Public ReadOnly Property Baixados() As List(Of String)
        Get
            Return _baixados
        End Get
    End Property

    Public ReadOnly Property FullPath() As String
        Get
            Return _fullPath
        End Get
    End Property

    Public ReadOnly Property SincronizadorPath() As String
        Get
            Return _sincronizadorPath
        End Get
    End Property

    Public ReadOnly Property SlidePath(ByVal slide As String) As String
        Get
            Return String.Format("{0}\{1}", FullPath, slide)
        End Get
    End Property

#End Region

#Region "Métodos"

#Region "Privados"

    ''' <summary>
    ''' Retornar os tempos e seus respectivos Slides.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RetornarDadosDeSincronia() As Dictionary(Of Decimal, String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(SincronizadorPath)
        Dim retorno As New Dictionary(Of Decimal, String)

        For Each noAtualXml As XmlNode In xmlDoc.DocumentElement.ChildNodes
            retorno(CDec(noAtualXml.Attributes.ItemOf("time").Value.Replace(".", ","))) = noAtualXml.Attributes.ItemOf("relative_path").Value
        Next
        Return retorno
    End Function

    ''' <summary>
    ''' Retorna o Slide e seus respectivos tempos.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function RetornarDadosDeSincroniaInversa() As Dictionary(Of String, Decimal)
        Dim retorno As New Dictionary(Of String, Decimal)

        For Each atual In Sincronia
            retorno(atual.Value) = atual.Key
        Next
        Return retorno
    End Function

    ''' <summary>
    ''' Verifica a existência ou não dos Slides descritos no Arquivo Primário de Sincronização (.sync)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function VerificarEstadoDeSlides() As Dictionary(Of String, Boolean)
        Dim retorno As New Dictionary(Of String, Boolean)
        For Each slide In _sincronia.Values
            retorno(slide) = File.Exists(String.Format("{0}\{1}", FullPath, slide))

            If retorno(slide) Then
                _baixados.Add(slide)
            Else
                _naoBaixados.Add(slide)
            End If

        Next
        Return retorno
    End Function

    ''' <summary>
    ''' Realiza Busca para definir Melhor Slide a ser executado.
    ''' </summary>
    ''' <param name="menor"></param>
    ''' <param name="maior"></param>
    ''' <param name="chave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BuscaBinariaRecursiva(ByVal menor As Integer, ByVal maior As Integer, ByVal chave As Decimal) As String
        Dim meio As Integer

        If menor > maior Then
            BuscaBinariaRecursiva = Sincronia.ElementAt(maior).Value
        Else
            meio = (menor + maior) / 2
            If chave < Sincronia.ElementAt(meio).Key Then
                BuscaBinariaRecursiva = BuscaBinariaRecursiva(menor, meio - 1, chave)
            ElseIf chave > Sincronia.ElementAt(meio).Key Then
                BuscaBinariaRecursiva = BuscaBinariaRecursiva(meio + 1, maior, chave)
            Else
                BuscaBinariaRecursiva = Sincronia.ElementAt(meio).Value
            End If
        End If
    End Function

#End Region

#Region "Públicos"

    ''' <summary>
    ''' Atualiza dados contidos no diretrório de Arquivos de Slide
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Atualizar()
        _baixados.Clear()
        _naoBaixados.Clear()
        VerificarEstadoDeSlides()
    End Sub

    ''' <summary>
    ''' Retorna o melhor Slide para aquele periodo de Execução.
    ''' </summary>
    ''' <param name="posicao"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BuscaMelhorSlide(ByVal posicao As Decimal) As String
        If Sincronia.ContainsKey(posicao) Then Return Sincronia(posicao)
        Return BuscaBinariaRecursiva(0, Total - 1, posicao)
    End Function

#End Region

#End Region

End Class
