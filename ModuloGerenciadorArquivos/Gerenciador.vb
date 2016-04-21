Imports System.IO
Imports System.Xml
Imports System.Windows.Forms

Public Class Gerenciador

#Region "Atributos"
    Private Shared _dadosDeSincronia As Dictionary(Of Decimal, String)
#End Region

#Region "Construtores"
    Sub New()

    End Sub
#End Region

#Region "Propriedades"

#End Region

#Region "Métodos"

    Public Shared Function PathPasta(ByVal codigo As String) As String
        Return String.Format("{0}\{1}", Configuracao.Aula, codigo)
    End Function

    Public Shared Function PathPasta(ByVal codigo As String, ByVal arquivo As String) As String
        Return String.Format("{0}\{1}\{2}", Configuracao.Aula, codigo, arquivo.Substring(0, IIf(arquivo.Contains("."), arquivo.LastIndexOf("."), arquivo.Length)))
    End Function


    'Somente Abaixo da Hierarquia do Diretorio Raiz

    '(Via XML, Criar Modelo e Métodos)
    'Pegar Valores de XML, para determinar o De-Para, de Código e SubDiretório 


    'Pegar Tamanho Arquivo || Pasta  
    'TODO: Mudar Path Passado, Pagar do Dicionario de De-Para!
    Private Shared Function PegaTamanhoPasta(ByVal Caminho As String) As Long
        Dim Tamanho As Long = 0
        For Each Pasta As String In IO.Directory.GetDirectories(Caminho)
            Tamanho += PegaTamanhoPasta(Pasta)
        Next

        For Each Arquivo As String In IO.Directory.GetFiles(Caminho)
            Dim FI As New IO.FileInfo(Arquivo)
            Tamanho += FI.Length
        Next

        Return Tamanho
    End Function

    Public Shared Function Tamanho(ByVal codigo As String, Optional ByVal arquivo As String = "") As Long
        Return Nothing
    End Function

    'Pegar Tamanho Diretório
    Public Shared Function TamanhoDiretorioRaiz() As Long
        Return FileLen(Configuracao.Aula)
    End Function

    '(Verificar Melhor forma de Fazer, Buffer como deve ser feito?)
    'Retornar Arquivo apartir do Código || Aula

    'Public Shared Function RetornaArquivo(ByVal codigo As String, ByVal arquivo As String) As Arquivo
    '    Return Nothing
    'End Function


    'Retornar Stream apartir do Código || Aula

    '(Métodos Fornecidos pelo Sistema) || (Tratamento em Loop)
    'Verificar se Arquivo Existe Código || Aula
    Public Shared Function Existe(ByVal codigo As String, Optional ByVal arquivo As String = "") As Boolean
        If Not String.IsNullOrEmpty(arquivo) Then
            Return File.Exists(PathPasta(codigo, arquivo) & "\" & arquivo)
        End If
        Return File.Exists(PathPasta(codigo))
    End Function

    'Verificar se Lista de Arquivos está Completa Por Código || Aula || Total

    '(Tratamento em Loop)
    'Retornar Lista de Arquivos Existentes, Completos ( As Três Partes)
    Public Shared Function Existentes() As Dictionary(Of String, String)
        Return Nothing
    End Function

    'Retornar Lista de Arquivos Faltando, Sem nada, ou Faltando Parte
    Public Shared Function Faltando() As Dictionary(Of String, String)
        Return Nothing
    End Function

    '(Verificar melhores formas de Abordagem para isso, Usar TreeView Simples, Com Xml???)
    'Exportar lista de Arquivos para Path "XPTO"
    Public Shared Sub Exportar(ByVal lista As List(Of String))

    End Sub

    'Importar lista de Arquivos, Mantendo a Hierarquia
    Public Shared Sub Importar(ByVal lista As List(Of String))

    End Sub

    'Verificar como Fazer Merge dos Arquivos, Métodos de Busca dos Arquivos devem procurar no "N" diretórios para Emular Sucesso!
    'Deve poder Acoplar Driver's diferentes, pré-selecionados, ao Diretório Raiz, Criando um Diretorio FAKE, Agregando dados dos dois Path's
    Public Shared Sub CarregarDriver(ByVal diretorio As String)

    End Sub

#End Region

End Class
