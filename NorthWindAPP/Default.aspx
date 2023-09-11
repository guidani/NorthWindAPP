﻿<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="NorthWindAPP._Default" MaintainScrollPositionOnPostback="true" EnableViewState="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>

    </div>

    <div class="row">
        <h1>Search in GRIDVIEW</h1>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <hr />
                <asp:Label ID="Label1" runat="server" Text="Items selecionados"></asp:Label>
                <div style="height: 100px; overflow-x: scroll;">
                    <asp:CheckBoxList 
                        ID="CheckBoxList1" 
                        runat="server" 
                        CellPadding="5" 
                        CellSpacing="0" 
                        Font-Size="Small" 
                        Height="100px"
                        RepeatDirection="Horizontal"
                        OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                        CssClass="chcboxitem"
                        >
                    </asp:CheckBoxList>
                </div>
                <div>
                    <asp:Button ID="BtnToPause" runat="server" Text="Colocar todos em pausa" OnClick="BtnToPause_Click"/>
                </div>
                <div>
                    <asp:Button ID="BtnClearList" runat="server" Text="Limpar Lista" OnClick="BtnClearList_Click"/>
                </div>
                <div>
                    <asp:Button ID="BtnRemoveMarked" runat="server" Text="Remover Selecionados" OnClick="BtnRemoveMarked_Click"/>
                </div>
                <hr />
                <asp:TextBox ID="TextBox1" runat="server" placeholder="Pesquise"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
                <asp:Button ID="BtnSelectAll" runat="server" Text="Selecionar Tudo" OnClick="BtnSelectAll_Click"/>
                <asp:GridView
                    ID="GridView1"
                    runat="server"
                    DataSourceID="SqlDataSource1"
                    AllowPaging="True"
                    AllowSorting="True"
                    AutoGenerateDeleteButton="True"
                    AutoGenerateEditButton="True"
                    AutoGenerateSelectButton="True"
                    EmptyDataText="Nada encontrado."
                    ShowFooter="True" AutoGenerateColumns="False" DataKeyNames="CustomerID"
                    PagerStyle-CssClass="customPager h4 text-warning"
                    PagerStyle-ForeColor="#cccccc"
                    PagerStyle-HorizontalAlign="Right"
                    PagerSettings-FirstPageText="Primeiro"
                    PagerSettings-LastPageText="Último"
                    PagerSettings-NextPageText="avançar"
                    PagerSettings-PreviousPageText="voltar"
                    PagerSettings-Mode="NumericFirstLast"
                    OnRowCommand="GridView1_RowCommand"
                    SelectedRowStyle-BackColor="YellowGreen"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField HeaderText="Ação" CommandName="Select" ImageUrl="~/Images/icons8-link-externo.svg" ButtonType="Image" />
                        <asp:CheckBoxField HeaderText="Selecione" Text="selecione" />
                        <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                        <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                        <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
                        <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1" />
                <asp:AsyncPostBackTrigger ControlID="BtnSelectAll" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:SqlDataSource
            ID="SqlDataSource1"
            runat="server"
            ConnectionString="<%$ ConnectionStrings:NorthWindDbConnectionString %>"
            SelectCommand="SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle] FROM [Customers] ORDER BY [ContactName], [CompanyName]"
            FilterExpression="ContactName like '%{0}%' OR CompanyName LIKE '%{1}%'"
            DeleteCommand="DELETE FROM [Customers] WHERE [CustomerID] = @CustomerID"
            InsertCommand="INSERT INTO [Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle]) VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle)"
            UpdateCommand="UPDATE [Customers] SET [CompanyName] = @CompanyName, [ContactName] = @ContactName, [ContactTitle] = @ContactTitle WHERE [CustomerID] = @CustomerID">
            <DeleteParameters>
                <asp:Parameter Name="CustomerID" Type="String" />
            </DeleteParameters>
            <FilterParameters>
                <asp:ControlParameter Name="ContactName" ControlID="TextBox1" PropertyName="Text" />
                <asp:ControlParameter Name="CompanyName" ControlID="TextBox1" PropertyName="Text" />
            </FilterParameters>
            <InsertParameters>
                <asp:Parameter Name="CustomerID" Type="String" />
                <asp:Parameter Name="CompanyName" Type="String" />
                <asp:Parameter Name="ContactName" Type="String" />
                <asp:Parameter Name="ContactTitle" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="CompanyName" Type="String" />
                <asp:Parameter Name="ContactName" Type="String" />
                <asp:Parameter Name="ContactTitle" Type="String" />
                <asp:Parameter Name="CustomerID" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>