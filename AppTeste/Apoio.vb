Imports System.Xml
Imports System.IO
Imports System.Text
Imports GerenciadorArquivos
Public Class Apoio

#Region "Importação"

#End Region

#Region "Exportação"
    
#End Region

#Region "TreeGriView"

    Public Shared Sub ImportaXmlParaTreeView(ByVal treeView As TreeView, ByVal filename As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(filename)

        treeView.Nodes.Clear()
        'Cria o Primeiro Nó : "Todos"
        treeView.Nodes.Add(New TreeNode With {.Name = xmlDoc.DocumentElement.Attributes.ItemOf("ID").Value, _
                                                .Text = xmlDoc.DocumentElement.Attributes.ItemOf("Valor").Value, _
                                                .ToolTipText = xmlDoc.DocumentElement.Attributes.ItemOf("Descricao").Value})

        AdicionarNoisFilhos(treeView.TopNode.Nodes, xmlDoc.DocumentElement)
    End Sub

    Private Shared Sub AdicionarNoisFilhos(ByVal niveisNo As TreeNodeCollection, ByVal noisXml As XmlNode)
        For Each noAtualXml As XmlNode In noisXml.ChildNodes
            Dim noAtual As New TreeNode
            With noAtual
                .Name = noAtualXml.Attributes.ItemOf("ID").Value
                .Text = noAtualXml.Attributes.ItemOf("Valor").Value
                .ToolTipText = noAtualXml.Attributes.ItemOf("Descricao").Value
            End With

            niveisNo.Add(noAtual)

            AdicionarNoisFilhos(noAtual.Nodes, noAtualXml)

            If noAtual.Nodes.Count = 0 Then noAtual.EnsureVisible()
        Next noAtualXml
    End Sub


    ''' <summary>
    ''' Carrega dados de Menu(.index) para TreeView
    ''' </summary>
    ''' <param name="treeView"></param>
    ''' <remarks></remarks>
    Public Shared Sub CarregaMenu(ByVal videoAula As VideoAula, ByVal treeView As TreeView)
        If videoAula.MenuCompleto Then
            Dim xmlDoc As New XmlDocument
            xmlDoc.XmlResolver = Nothing
            xmlDoc.Load(videoAula.MenuPath)
            treeView.Nodes.Clear()
            MenuAdicionarNoisFilhos(treeView.Nodes, xmlDoc.DocumentElement)
        End If
    End Sub

    ''' <summary>
    ''' Preenche uma TreeNodeCollection com os dados contidos no Menu (arquivo .index)
    ''' </summary>
    ''' <param name="niveisNo"></param>
    ''' <param name="noisXml"></param>
    ''' <remarks></remarks>
    Private Shared Sub MenuAdicionarNoisFilhos(ByVal niveisNo As TreeNodeCollection, ByVal noisXml As XmlNode)
        For Each noAtualXml As XmlNode In noisXml.ChildNodes
            If noAtualXml.Name.Equals("ind_item") Then

                Dim noAtual As New TreeNode
                With noAtual
                    .Name = noAtualXml.ChildNodes(0).InnerText.Replace(".", ",").Trim 'time
                    .Text = String.Format("({0}) - {1}", posicaoParaTempo(Double.Parse(.Name)), noAtualXml.ChildNodes(1).InnerText)  'Text
                    .ToolTipText = .Text
                End With
                niveisNo.Add(noAtual)
                MenuAdicionarNoisFilhos(noAtual.Nodes, noAtualXml)
                If noAtual.Nodes.Count = 0 Then noAtual.EnsureVisible()
            End If
        Next noAtualXml
    End Sub

    Private Shared Function posicaoParaTempo(ByVal posicao As Double) As String
        Dim seg, hrs, min As Integer
        seg = posicao
        hrs = seg \ 3600
        min = (seg - (hrs * 3600)) \ 60
        seg = seg - (hrs * 3600 + min * 60)

        Return String.Format("{0:D2}:{1:D2}:{2:D2}", hrs, min, seg)
    End Function

#End Region

End Class

