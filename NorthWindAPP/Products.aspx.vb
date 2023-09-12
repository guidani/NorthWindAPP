Public Class Products
    Inherits System.Web.UI.Page


    Dim suplierID
    Dim catID
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        suplierID = If(Request.QueryString("SuplierID") IsNot Nothing, Request.QueryString("SuplierID").ToString, "")
        catID = If(Request.QueryString("CategorieID") IsNot Nothing, Request.QueryString("CategorieID").ToString, "")
        If Not IsPostBack Then
            If suplierID <> "" And catID = "" Then
                SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
                SqlDataSourceProducts.FilterExpression = $"SupplierID = {suplierID} and CategoryID is not null"
                SqlDataSourceProducts.DataBind()
                GridView1.DataSource = SqlDataSourceProducts
                GridView1.AllowPaging = True
                GridView1.DataBind()
                UpdatePanel1.Update()
            ElseIf suplierID = "" And catID <> "" Then
                SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
                SqlDataSourceProducts.FilterExpression = $"SupplierID IS NOT NULL and CategoryID = {catID}"
                SqlDataSourceProducts.DataBind()
                GridView1.DataSource = SqlDataSourceProducts
                GridView1.AllowPaging = True
                GridView1.DataBind()
                UpdatePanel1.Update()
            ElseIf suplierID <> "" And catID <> "" Then
                SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
                SqlDataSourceProducts.FilterExpression = $"SupplierID = {suplierID} and CategoryID = {catID}"
                SqlDataSourceProducts.DataBind()
                GridView1.DataSource = SqlDataSourceProducts
                GridView1.AllowPaging = True
                GridView1.DataBind()
                UpdatePanel1.Update()
            Else
                SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
                SqlDataSourceProducts.FilterExpression = $"SupplierID IS NOT NULL and CategoryID IS NOT NULL"
                SqlDataSourceProducts.Select(DataSourceSelectArguments.Empty)
                SqlDataSourceProducts.DataBind()
                GridView1.DataSource = SqlDataSourceProducts
                GridView1.AllowPaging = True
                GridView1.DataBind()
                UpdatePanel1.Update()
            End If
        End If
    End Sub

    Protected Sub BtnPesquisa_Command(sender As Object, e As CommandEventArgs)
        Dim texto As String = LblPesquisa.Text

    End Sub

    Protected Sub BtnDDLFilter_Click(sender As Object, e As EventArgs)
        Dim suplierId = DDLSuplier.SelectedValue
        Dim categorieId = DDLCategories.SelectedValue
        Response.Redirect($"Products.aspx?SuplierID={suplierId}&CategorieID={categorieId}")
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


        If suplierID = "" And catID <> "" Then
            GridView1.PageIndex = e.NewPageIndex
            GridViewWithCategory()
        ElseIf suplierID <> "" And catID = "" Then
            GridView1.PageIndex = e.NewPageIndex
            GridViewWithSuplier()
        ElseIf suplierID <> "" And catID <> "" Then
            GridView1.PageIndex = e.NewPageIndex
            GridViewWithSuplierAndCategory()
        Else
            GridView1.PageIndex = e.NewPageIndex
            GridViewWithoutSuplierAndCategory()
        End If
    End Sub

    Private Sub GridViewWithoutSuplierAndCategory()
        SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
        SqlDataSourceProducts.FilterExpression = $"SupplierID IS NOT NULL and CategoryID IS NOT NULL"
        'SqlDataSourceProducts.Select(DataSourceSelectArguments.Empty)
        SqlDataSourceProducts.DataBind()
        GridView1.DataSource = SqlDataSourceProducts
        GridView1.AllowPaging = True
        GridView1.DataBind()
        UpdatePanel1.Update()
    End Sub

    Private Sub GridViewWithSuplierAndCategory()
        SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
        SqlDataSourceProducts.FilterExpression = $"SupplierID = {suplierID} and CategoryID = {catID}"
        SqlDataSourceProducts.DataBind()
        GridView1.DataSource = SqlDataSourceProducts
        GridView1.AllowPaging = True
        GridView1.DataBind()
        UpdatePanel1.Update()
    End Sub

    Private Sub GridViewWithSuplier()
        SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
        SqlDataSourceProducts.FilterExpression = $"SupplierID = {suplierID} and CategoryID is not null"
        SqlDataSourceProducts.DataBind()
        GridView1.DataSource = SqlDataSourceProducts
        GridView1.AllowPaging = True
        GridView1.DataBind()
        UpdatePanel1.Update()
    End Sub

    Protected Sub GridViewWithCategory()
        SqlDataSourceProducts.SelectCommand = $"SELECT [ProductID],[ProductName],[SupplierID],[CategoryID] FROM [NorthWindDb].[dbo].[Products]"
        SqlDataSourceProducts.FilterExpression = $"SupplierID IS NOT NULL and CategoryID = {catID}"
        SqlDataSourceProducts.DataBind()
        GridView1.DataSource = SqlDataSourceProducts
        GridView1.AllowPaging = True
        GridView1.DataBind()
        UpdatePanel1.Update()
    End Sub
End Class