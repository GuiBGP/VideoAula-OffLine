Public Class Configuracao

    Private Sub Configuracao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CarregarConfiguracao()
    End Sub

    Private Sub ProcurarRaizButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcurarRaizButton.Click
        AbrirDialogoDiretorio(RaizTextBox.Text, "Selecione a Pasta Raiz")
    End Sub

    Private Sub PadraoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PadraoButton.Click
        GerenciadorArquivos.Configuracao.CarregarConfiguracaoPadrao()
        CarregarConfiguracao()
    End Sub

    Private Sub CancelarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarButton.Click
        Me.Close()
    End Sub

    Private Sub SalvarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarButton.Click
        SalvarConfiguracao()
        Me.Close()
    End Sub

    Private Function AbrirDialogoDiretorio(ByVal defaultPath As String, Optional ByVal descricao As String = "Selecione a Pasta") As String
        defaultPath = defaultPath.Trim
        'Define as propriedades do controle FolderBrowserDialog
        FolderBrowserDialog.Description = descricao
        FolderBrowserDialog.SelectedPath = If(String.IsNullOrEmpty(defaultPath), Environment.GetFolderPath(Environment.SpecialFolder.Desktop), defaultPath)
        FolderBrowserDialog.ShowNewFolderButton = True

        'Exibe a caixa de diálogo
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Exibe a pasta selecionada
            Return FolderBrowserDialog.SelectedPath
        End If
        Return String.Empty
    End Function

    Private Sub SalvarConfiguracao()
        GerenciadorArquivos.Configuracao.Raiz = RaizTextBox.Text
        GerenciadorArquivos.Configuracao.Url = URLTextBox.Text
        GerenciadorArquivos.Configuracao.Proxy = ProxyTextBox.Text
        GerenciadorArquivos.Configuracao.Limite = LimiteTextBox.Text
        GerenciadorArquivos.Configuracao.Reiniciar = ContinuarCheckBox.Checked
        GerenciadorArquivos.Configuracao.SalvarINI()
    End Sub

    Private Sub CarregarConfiguracao()
        RaizTextBox.Text = GerenciadorArquivos.Configuracao.Raiz
        URLTextBox.Text = GerenciadorArquivos.Configuracao.Url
        ProxyTextBox.Text = GerenciadorArquivos.Configuracao.Proxy
        LimiteTextBox.Text = GerenciadorArquivos.Configuracao.Limite
        ContinuarCheckBox.Checked = GerenciadorArquivos.Configuracao.Reiniciar
    End Sub

    Private Sub TestarUrlButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestarUrlButton.Click
        Dim url As New System.Uri(URLTextBox.Text & "/ead05001/Aula_001/Aula_001.xml")
        Dim request As System.Net.WebRequest
        request = System.Net.WebRequest.Create(url)
        Dim response As System.Net.WebResponse
        Try
            response = request.GetResponse()
            response.Close()
            request = Nothing
            MsgBox("Site Encontrado!")
        Catch ex As Exception
            request = Nothing
            MsgBox("Site não Encontrado. Cheque a url e a conexão de internet.")
        End Try
    End Sub
End Class