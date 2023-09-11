Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim texto = TextBox1.Text
        'Dim ds = SqlDataSource1.SelectCommand = $"SELECT * FROM [NorthWindDb].[dbo].[Customers] WHERE ContactName LIKE '%{texto}%'"
        'GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            Dim index = Convert.ToInt32(e.CommandArgument)
            Dim selectedRow As GridViewRow = GridView1.Rows(index)
            Dim customerID As TableCell = selectedRow.Cells(3)
            Dim id As String = customerID.Text

            Dim listItem As New ListItem(id)

            If Not CheckBoxList1.Items.Contains(listItem) Then
                CheckBoxList1.Items.Add(listItem)
            End If

            'MsgBox($"Você selecionou: {id}")
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim item = GridView1.SelectedValue.ToString()
        'MsgBox(item)
    End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub BtnSelectAll_Click(sender As Object, e As EventArgs)
        Dim rows As GridViewRowCollection = GridView1.Rows
        For Each row As GridViewRow In rows
            Dim customerID As TableCell = row.Cells(3)
            Dim id As String = customerID.Text

            Dim listItem As New ListItem(id)

            If Not CheckBoxList1.Items.Contains(listItem) Then
                CheckBoxList1.Items.Add(listItem)
            End If
        Next
    End Sub

    Protected Sub BtnToPause_Click(sender As Object, e As EventArgs)
        Dim chcItems = CheckBoxList1.Items
        For Each item As ListItem In chcItems
            Dim a = item.Selected
            Dim b = item.Value
            Dim ee = item.Enabled
            Dim f = item.ToString

        Next
    End Sub

    Protected Sub BtnClearList_Click(sender As Object, e As EventArgs)
        If MsgBox("Tem certeza que deseja remover todos os items da lista?", MsgBoxStyle.OkCancel) Then
            CheckBoxList1.Items.Clear()
        End If
    End Sub

    Protected Sub BtnRemoveMarked_Click(sender As Object, e As EventArgs)
        Dim chcItems = CheckBoxList1.Items
        Dim chcItemsCopy As New ListItemCollection
        If MsgBox("Tem certeza que deseja remover todos os items selecionados?", MsgBoxStyle.OkCancel) Then
            For Each item As ListItem In chcItems
                If Not item.Selected Then
                    chcItemsCopy.Add(item)
                End If
            Next
            CheckBoxList1.Items.Clear()
            For Each item As ListItem In chcItemsCopy
                CheckBoxList1.Items.Add(item)
            Next
        End If

    End Sub
End Class