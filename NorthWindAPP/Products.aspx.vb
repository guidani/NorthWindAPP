﻿Public Class Products
    Inherits System.Web.UI.Page

    Dim suplierID
    Dim catID
    Dim prodName

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        suplierID = If(Request.QueryString("SuplierID") IsNot Nothing, Request.QueryString("SuplierID").ToString, "")
        catID = If(Request.QueryString("CategorieID") IsNot Nothing, Request.QueryString("CategorieID").ToString, "")
        prodName = If(Request.QueryString("ProductName") IsNot Nothing, Request.QueryString("ProductName").ToString, "")
        If Not IsPostBack Then
            ExecuteCommand()
        End If
    End Sub

    Protected Sub BtnPesquisa_Command(sender As Object, e As CommandEventArgs)
        Dim texto As String = LblPesquisa.Text

    End Sub

    Protected Sub BtnDDLFilter_Click(sender As Object, e As EventArgs)
        Dim suplierId = DDLSuplier.SelectedValue
        Dim categorieId = DDLCategories.SelectedValue
        Dim productName = TxtBoxPesquisa.Text
        Response.Redirect($"Products.aspx?SuplierID={suplierId}&CategorieID={categorieId}&ProductName={productName}")
    End Sub

    Protected Sub DDLSuplier_DataBound(sender As Object, e As EventArgs)
        If suplierID <> "" Then
            DDLSuplier.SelectedValue = suplierID
        End If
    End Sub

    Protected Sub DDLCategories_DataBound(sender As Object, e As EventArgs)
        If catID <> "" Then
            DDLCategories.SelectedValue = catID
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        ExecuteCommand()
    End Sub

    Protected Sub ExecuteCommand()
        SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
        SqlDataSourceProducts.FilterExpression = $"SupplierID {If(suplierID <> "", " = " + suplierID, " IS NOT NULL ")} and CategoryID {If(catID <> "", " = " + catID, " IS NOT NULL")} and ProductName {If(prodName <> "", " LIKE '%" + prodName + "%'", " IS NOT NULL")}"
        SqlDataSourceProducts.DataBind()
        GridView1.DataSource = SqlDataSourceProducts
        GridView1.AllowPaging = True
        GridView1.DataBind()
        UpdatePanel1.Update()
    End Sub

    Protected Sub BtnPesquisa_Load(sender As Object, e As EventArgs)
        If prodName <> "" Then
            TxtBoxPesquisa.Text = prodName.ToString
        End If
    End Sub

    Protected Sub BtnResetFilter_Click(sender As Object, e As EventArgs)
        Response.Redirect($"Products.aspx")
    End Sub
End Class