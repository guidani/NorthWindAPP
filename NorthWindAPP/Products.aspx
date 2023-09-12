<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Products.aspx.vb" Inherits="NorthWindAPP.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>ASP.NET</h1>

    </div>

    <div class="row">
        <h1>Search in GRIDVIEW - PRODUTOS</h1>
<%--        <p><%= suplierID %></p>
        <p><%= catID %></p>
        <p><%= prodName %></p>--%>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <asp:Label ID="Label1" runat="server" Text="Suplier"></asp:Label>
                <asp:DropDownList 
                    ID="DDLSuplier" 
                    runat="server" 
                    DataSourceID="SqlDataSourceSupplier" 
                    DataTextField="CompanyName" 
                    DataValueField="SupplierID" 
                    AppendDataBoundItems="true" 
                    OnDataBound="DDLSuplier_DataBound"
                    >
                    <asp:ListItem Value="" Selected="True" Text="Selecione" ></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
                <asp:DropDownList 
                    ID="DDLCategories" 
                    runat="server" 
                    DataSourceID="SqlDataSourceCategories" 
                    DataTextField="CategoryName" 
                    DataValueField="CategoryID" 
                    AppendDataBoundItems="true"
                    OnDataBound="DDLCategories_DataBound"
                    >
                    <asp:ListItem Value="" Selected="True" Text="Selecione" ></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="BtnDDLFilter" runat="server" Text="Filtrar" OnClick="BtnDDLFilter_Click"/>
            </div>
            <div class="row">
                <asp:Label ID="LblPesquisa" runat="server" Text="Pesquisa"></asp:Label>
                <asp:TextBox ID="TxtBoxPesquisa" runat="server"></asp:TextBox>
                <asp:Button ID="BtnPesquisa" runat="server" Text="Pesquisa" CommandName="Filter" OnCommand="BtnPesquisa_Command" OnClick="BtnDDLFilter_Click" OnLoad="BtnPesquisa_Load"/>
                <asp:Button ID="BtnResetFilter" runat="server" Text="Limpar" OnClick="BtnResetFilter_Click"/>
            </div>
            <asp:GridView
                ID="GridView1"
                runat="server"
                OnPageIndexChanging="GridView1_PageIndexChanging" 
                CellPadding="4" 
                ForeColor="#333333" 
                GridLines="None"
                EmptyDataText="Nenhum resultado corresponde a busca."
                >
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnPesquisa" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" />
            <asp:AsyncPostBackTrigger ControlID="DDLSuplier" />
            <asp:AsyncPostBackTrigger ControlID="DDLCategories" />
            <asp:AsyncPostBackTrigger ControlID="BtnDDLFilter" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>Carregando...</ProgressTemplate>
    </asp:UpdateProgress>

    <asp:SqlDataSource
        ID="SqlDataSourceProducts"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:NorthWindDbConnectionString %>"
        >
        <FilterParameters >
            <%--<asp:ControlParameter ControlID="TxtBoxPesquisa" ConvertEmptyStringToNull="true" Name="ProductName" PropertyName="Text"/>--%>
            <%--<asp:QueryStringParameter Name="SuplierID" QueryStringField="SuplierID" ConvertEmptyStringToNull="true"/>
            <asp:QueryStringParameter Name="CategorieID" QueryStringField="CategorieID" ConvertEmptyStringToNull="true"/>--%>
        </FilterParameters>
    </asp:SqlDataSource>
    <%-- para os dropdowns --%>
    <asp:SqlDataSource
        ID="SqlDataSourceSupplier"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:NorthWindDbConnectionString %>"
        SelectCommand="SELECT [SupplierID],[CompanyName] FROM [NorthWindDb].[dbo].[Suppliers]"></asp:SqlDataSource>
    <asp:SqlDataSource 
        SelectCommand="SELECT [CategoryID],[CategoryName]FROM [NorthWindDb].[dbo].[Categories]" 
        ConnectionString="<%$ ConnectionStrings:NorthWindDbConnectionString %>" 
        ID="SqlDataSourceCategories" 
        runat="server"></asp:SqlDataSource>
</asp:Content>
