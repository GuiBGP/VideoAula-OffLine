Imports System.Windows.Forms

Public Class PrincipalMDIParent
    Private m_ChildFormNumber As Integer

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NovoDownloadStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click, DonwloadViewToolStripMenuItem.Click, DownloadViewToolStripButton.Click
        Dim ChildForm As DownloadForm = TryCast(Application.OpenForms("DownloadForm"), DownloadForm)
        Dim tabIndex As Integer = -CInt(sender Is DonwloadViewToolStripMenuItem Or sender Is DownloadViewToolStripButton)
        If ChildForm Is Nothing Then
            ChildForm = New DownloadForm
            ChildForm.MdiParent = Me
            ChildForm.Text = "Download"
            ChildForm.DetalheTabControl.SelectedIndex = tabIndex
            ChildForm.Show()
        Else
            ChildForm.DetalheTabControl.SelectedIndex = tabIndex
            ChildForm.Focus()
        End If
    End Sub

    Private Sub ConfiguracaoMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguracaoMenu.Click
        Dim ChildForm As Configuracao = TryCast(Application.OpenForms("Configuracao"), Configuracao)
        If ChildForm Is Nothing Then
            ChildForm = New Configuracao
            ChildForm.MdiParent = Me
            ChildForm.Text = "Configuração"
            ChildForm.Show()
        Else
            ChildForm.Focus()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim ChildForm As AboutBox = TryCast(Application.OpenForms("AboutBox"), AboutBox)
        If ChildForm Is Nothing Then
            ChildForm = New AboutBox
            ChildForm.MdiParent = Me
            ChildForm.Text = "Sobre"
            ChildForm.Show()
        Else
            ChildForm.Focus()
        End If
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles AbrirAulaToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim ChildForm As AbrirAula = TryCast(Application.OpenForms("AbrirAula"), AbrirAula)
        If ChildForm Is Nothing Then
            ChildForm = New AbrirAula
            ChildForm.MdiParent = Me
            ChildForm.Text = "Abrir Vídeo Aula"
            ChildForm.Show()
        Else
            ChildForm.Focus()
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Public Sub AddChild(ByVal Form As Form)

    End Sub


End Class
