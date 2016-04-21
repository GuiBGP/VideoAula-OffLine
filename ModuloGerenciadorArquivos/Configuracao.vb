Imports System.IO

Public Class Configuracao

#Region "Construtores"

    Private Sub New()

    End Sub

#End Region

#Region "Atributos"

    Private Shared _raiz As String
    Private Shared _aula As String
    Private Shared _importacao As String
    Private Shared _exportacao As String
    Private Shared _url As String
    Private Shared _proxy As String
    Private Shared _limite As Integer
    Private Shared _reiniciar As String

#End Region

#Region "Propriedades"

    Shared Property Raiz As String
        Get
            If Not Checado Then
                Carregar()
            End If
            Return _raiz
        End Get
        Set(ByVal value As String)
            _raiz = value
        End Set
    End Property

    Shared Property Aula As String
        Get
            If Not Checado Then
                Carregar()
            End If
            Return _aula
        End Get
        Set(ByVal value As String)
            _aula = value
        End Set
    End Property

    Shared Property Importacao As String
        Get
            If Not Checado Then
                Carregar()
            End If
            Return _importacao
        End Get
        Set(ByVal value As String)
            _importacao = value
        End Set
    End Property

    Shared Property Exportacao As String
        Get
            If Not Checado Then
                Carregar()
            End If
            Return _exportacao
        End Get
        Set(ByVal value As String)
            _exportacao = value
        End Set
    End Property

    Shared Property Url As String
        Get
            If Not Checado Then
                Carregar()
            End If
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property

    Shared Property Proxy As String
        Get
            If Not Checado Then
                Carregar()
            End If
            Return _proxy
        End Get
        Set(ByVal value As String)
            _proxy = value
        End Set
    End Property

    Shared Property Limite As Integer
        Get
            If Not Checado Then
                Carregar()
            End If
            Return _limite
        End Get
        Set(ByVal value As Integer)
            _limite = value
        End Set
    End Property

    Shared Property Reiniciar As Boolean
        Get
            If Not Checado Then
                Carregar()
            End If
            Return _reiniciar
        End Get
        Set(ByVal value As Boolean)
            _reiniciar = value
        End Set
    End Property

    Private Shared Property Checado As Boolean
    Private Shared Property ConfigIni As String = My.Application.Info.DirectoryPath & "\config.ini"
    'Private Shared Property ReadOnly Instancia As Configuracao

#End Region

#Region "Métodos"

#Region "Privados"

    Private Shared Sub Carregar()
        Checado = True
        If Not ExisteINI() Then
            CarregarConfiguracaoPadrao()
            SalvarINI()
        Else
            CarregarINI()
        End If
        'Instancia = MemberwiseClone(Me)
    End Sub

    Private Shared Function ExisteINI() As Boolean
        Return File.Exists(ConfigIni)
    End Function

    Private Shared Sub CarregarINI()
        Dim ini As New IniFile()
        ini.Load(ConfigIni)
        With ini.GetSection("Configuracao")
            Configuracao.Raiz = .GetKey("Raiz").Value
            Configuracao.Aula = .GetKey("Aula").Value
            Configuracao.Importacao = .GetKey("Importacao").Value
            Configuracao.Exportacao = .GetKey("Exportacao").Value
            Configuracao.Url = .GetKey("Url").Value
            Configuracao.Proxy = .GetKey("Proxy").Value
            Configuracao.Limite = .GetKey("Limite").Value
            Configuracao.Reiniciar = .GetKey("Reiniciar").Value
        End With
    End Sub

#End Region

#Region "Públicos"

    Public Shared Sub CarregarConfiguracaoPadrao()

        Configuracao.Raiz = My.Application.Info.DirectoryPath
        Configuracao.Aula = Raiz & "\Aulas\Sistemas_Comp"
        Configuracao.Importacao = Raiz
        Configuracao.Exportacao = Raiz
        Configuracao.Url = "http://videoaula.rnp.br/transfer.rio?file=/cederj/sistemas_comp"  '"http://gtedad05.pop-mg.rnp.br/transfer.rio?file=/cederj/sistemas_comp"
        Configuracao.Proxy = String.Empty
        Configuracao.Limite = 4
        Configuracao.Reiniciar = True

    End Sub

    Public Shared Sub SalvarINI()
        Dim ini As New IniFile()
        With ini.AddSection("Configuracao")
            .AddKey("Raiz").Value = Configuracao.Raiz
            .AddKey("Aula").Value = Configuracao.Aula
            .AddKey("Importacao").Value = Configuracao.Importacao
            .AddKey("Exportacao").Value = Configuracao.Exportacao
            .AddKey("Url").Value = Configuracao.Url
            .AddKey("Proxy").Value = Configuracao.Proxy
            .AddKey("Limite").Value = Configuracao.Limite
            .AddKey("Reiniciar").Value = Configuracao.Reiniciar
        End With
        ini.Save(ConfigIni)
    End Sub

#End Region

#End Region

End Class
