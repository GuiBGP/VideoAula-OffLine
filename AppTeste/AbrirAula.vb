Imports GerenciadorArquivos

Public Class AbrirAula

#Region "Atributos"
    Dim _aulaSelecionada As VideoAula
#End Region

    Private Sub AbrirAula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


    Public Sub MontarAula(ByVal idAula As String)
        MontarAula(New VideoAula(idAula))
    End Sub
    Private Sub MontarAula(ByVal aula As VideoAula)
        _aulaSelecionada = aula
        If aula.ArquivoBaseCompleto Then
            With aula
                CodigoAulaTextBox.Text = .Codigo
                DisciplinaAulaTextBox.Text = .Materia
                NomeAulaTextBox.Text = .Nome & " - " & .Titulo

                If .Completo Then
                    PorcentagemAulaLabel.Text = "100%"
                    PorcentagemAulaProgressBar.Maximum = 1
                    PorcentagemAulaProgressBar.Value = 1
                    DownloadButton.Enabled = False
                    ReproduzirButton.Enabled = True
                Else

                    DownloadButton.Enabled = True
                    ReproduzirButton.Enabled = False
                End If
            End With
        Else
            Dim codigo As String = aula.RelativePath.Substring(0, aula.RelativePath.IndexOf("\"))
            Dim nome As String = aula.RelativePath.Substring(aula.RelativePath.IndexOf("\") + 1)
            CodigoAulaTextBox.Text = codigo
            NomeAulaTextBox.Text = nome
            PorcentagemAulaLabel.Text = "000%"
            PorcentagemAulaProgressBar.Maximum = 0
            PorcentagemAulaProgressBar.Value = 0
            DownloadButton.Enabled = True
            ReproduzirButton.Enabled = False
        End If

    End Sub

    Private Sub DownloadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadButton.Click
        Dim ChildForm As DownloadForm = TryCast(Application.OpenForms("DownloadForm"), DownloadForm)
        If ChildForm Is Nothing Then
            ChildForm = New DownloadForm()
            ChildForm.MdiParent = Me.MdiParent
            ChildForm.DetalheTabControl.SelectedIndex = 0
            ChildForm.MontarAula(_aulaSelecionada)
            ChildForm.Show()
        Else
            ChildForm.Focus()
        End If
    End Sub

    Private Sub ReproduzirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReproduzirButton.Click
        Dim ChildForm As FormSincronia = TryCast(Application.OpenForms("FormSincronia"), FormSincronia)
        If ChildForm Is Nothing Then
            ChildForm = New FormSincronia(_aulaSelecionada, Me.MdiParent)
            ChildForm.Text = "Vídeo Aula - " & _aulaSelecionada.Materia & " - " & _aulaSelecionada.Titulo
            ChildForm.Show()
        Else
            ChildForm.Focus()
        End If
    End Sub

    Private Sub ProcurarRaizButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcurarRaizButton.Click
        'Exibe a caixa de diálogo
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Exibe a pasta selecionada
            NovaAulaTextBox.Text = OpenFileDialog.FileName
            MontarAula(New VideoAula(OpenFileDialog.FileName, True))
        End If
    End Sub
End Class